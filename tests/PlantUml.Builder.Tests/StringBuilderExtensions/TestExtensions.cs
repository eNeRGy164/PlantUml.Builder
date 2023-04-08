using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace PlantUml.Builder;

internal static class TestExtensions
{
    internal static MethodInfo FindOverloadedMethod(this Type type, string methodName, IEnumerable<Type> parameterTypes)
    {
        var methods = type.GetMethods().Where(m => m.Name == methodName).ToList();
        if (methods.Count == 1)
        {
            return methods.First();
        }

        var knownTypes = new[] { methods.First().GetParameters().First().ParameterType }.Concat(parameterTypes).ToArray();

        return methods.Single(m =>
        {
            var p = m.GetParameters();
            return p.Length >= knownTypes.Length
                && !p.Skip(knownTypes.Length).Any(p => !p.IsOptional)
                && p.Select(p => p.ParameterType).Take(knownTypes.Length).SequenceEqual(knownTypes);
        });
    }
}
