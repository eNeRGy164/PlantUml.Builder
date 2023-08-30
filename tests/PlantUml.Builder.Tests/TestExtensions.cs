namespace PlantUml.Builder;

internal static class TestExtensions
{
    internal static MethodInfo FindOverloadedMethod(this Type type, string methodName, IEnumerable<Type> parameterTypes)
    {
        var methods = type.GetMethods().Where(m => m.Name == methodName).ToList();
        if (methods.Count == 1)
        {
            return methods[0];
        }

        var knownTypesList = new List<Type> { methods[0].GetParameters()[0].ParameterType };
        knownTypesList.AddRange(parameterTypes);
        var knownTypes = knownTypesList.ToArray();

        foreach (var method in methods)
        {
            var parameters = method.GetParameters();
            var hasParams = parameters[^1].IsDefined(typeof(ParamArrayAttribute), false);

            if ((hasParams || parameters.Length >= knownTypes.Length)
                && !RemainingParametersAreOptional(parameters, knownTypes)
                && CompareKnownTypes(parameters, knownTypes, hasParams))
            {
                return method;
            }
        }

        throw new InvalidOperationException("Method not found.");

        static bool RemainingParametersAreOptional(ParameterInfo[] parameters, Type[] knownTypes)
        {
            for (int i = knownTypes.Length; i < parameters.Length; i++)
            {
                var parameter = parameters[i];
                if (!parameter.IsOptional && !parameter.IsDefined(typeof(ParamArrayAttribute), false))
                {
                    return true;
                }
            }
            return false;
        }

        static bool CompareKnownTypes(ParameterInfo[] parameters, Type[] knownTypes, bool hasParams)
        {
            var parameterTypes = new Type[parameters.Length];
            for (int i = 0; i < parameters.Length; i++)
            {
                parameterTypes[i] = parameters[i].ParameterType;
            }

            if (hasParams)
            {
                var lastParamType = parameterTypes[^1].GetElementType();

                var index = Array.IndexOf(knownTypes, lastParamType);
                if (index > -1 && knownTypes.Length > parameters.Length)
                {
                    Array.Resize(ref knownTypes, index + 1);

                    knownTypes[^1] = Array.CreateInstance(lastParamType, 0).GetType();
                }
                else
                {
                    parameterTypes[^1] = lastParamType;
                }
            }

            for (int i = 0; i < knownTypes.Length; i++)
            {
                if (parameterTypes[i] != knownTypes[i]) return false;
            }

            return true;
        }
    }

    /// <summary>
    /// Gets the extension method information and its parameters for the specified method name and parameters.
    /// </summary>
    /// <param name="type">The type on which to find the overloaded method.</param>
    /// <param name="this">The instance of the object calling the extension method.</param>
    /// <param name="methodName">The name of the method to find.</param>
    /// <param name="methodParameters">The parameters for the method.</param>
    /// <returns>A tuple containing the <see cref="MethodInfo"/> object representing the method and an object array containing the parameters.</returns>
    /// <exception cref="AmbiguousMatchException">Thrown when multiple methods match the specified criteria.</exception>
    /// <example>
    /// <code>
    /// var (method, parameters) = typeof(StringBuilderExtensions).GetExtensionMethodAndParameters(stringBuilder, "Diamond", new object[] { "name" });
    /// </code>
    /// </example>
    public static (MethodInfo, object[]) GetExtensionMethodAndParameters(this Type type, object @this, string methodName, object[] methodParameters)
    {
        var parameterTypes = new Type[methodParameters.Length];
        var parameters = new object[methodParameters.Length + 1];
        parameters[0] = @this;

        for (var i = 0; i < methodParameters.Length; i++)
        {
            parameterTypes[i] = methodParameters[i]?.GetType();
            parameters[i + 1] = methodParameters[i] ?? Type.Missing;
        }

        var method = type.FindOverloadedMethod(methodName, parameterTypes);
        var parameterInfos = method.GetParameters();

        var totalParameters = parameterInfos.Length;
        if (totalParameters <= methodParameters.Length + 1)
        {
            var lastType = parameterInfos[^1];
            var lastTypeElementType = lastType.ParameterType.GetElementType();

            if (lastType.IsDefined(typeof(ParamArrayAttribute), false) && parameters[^1].GetType() == lastTypeElementType)
            {
                int paramValuesCount = 0;
                foreach (var param in parameters)
                {
                    if (param.GetType() == lastTypeElementType)
                    {
                        paramValuesCount++;
                    }
                }

                var newValueArray = Array.CreateInstance(lastTypeElementType, paramValuesCount);
                int index = 0;

                foreach (var param in parameters)
                {
                    if (param.GetType() == lastTypeElementType)
                    {
                        newValueArray.SetValue(param, index++);
                    }
                }

                Array.Resize(ref parameters, parameters.Length - (paramValuesCount - 1));

                parameters[^1] = newValueArray;
            }

            return (method, parameters);
        }

        Array.Resize(ref parameters, totalParameters);

        // Fill in remaining parameters with Type.Missing
        for (var i = methodParameters.Length + 1; i < totalParameters; i++)
        {
            var parameterInfo = parameterInfos[i];
            if (parameterInfo.IsOptional)
            {
                parameters[i] = Type.Missing;
            }
            else if (parameterInfo.IsDefined(typeof(ParamArrayAttribute), false))
            {
                parameters[i] = Array.CreateInstance(parameterInfo.ParameterType.GetElementType(), 0);
            }
            else
            {
                throw new NotImplementedException();
            }
        }

        return (method, parameters);
    }
}
