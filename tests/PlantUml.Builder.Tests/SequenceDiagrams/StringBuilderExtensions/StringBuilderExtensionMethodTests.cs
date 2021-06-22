using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PlantUml.Builder.Tests;

namespace PlantUml.Builder.SequenceDiagrams.Tests
{
    [TestClass]
    public class StringBuilderExtensionMethodTests
    {
        [TestMethod]
        [DynamicData(nameof(GetStringBuilderExtensionMethods), DynamicDataSourceType.Method, DynamicDataDisplayName = nameof(GetStringBuilderExtensionMethodsDisplayName))]
        public void ExtensionMethodsShouldNotWorkOnANullStringBuilder(string methodName, object[] methodParameters)
        {
            // Assign
            StringBuilder stringBuilder = null;

            var method = typeof(StringBuilderExtensions).FindOverloadedMethod(methodName, methodParameters.Select(p => p.GetType()));
            var remainingParameters = method.GetParameters().Skip(methodParameters.Length + 1).Select(p => Type.Missing);
            var parameters = new object[] { stringBuilder }.Concat(methodParameters).Concat(remainingParameters).ToArray();

            // Act
            Action action = () => method.Invoke(null, parameters);

            // Assert
            action.Should().ThrowExactly<TargetInvocationException>()
                .WithInnerExceptionExactly<ArgumentNullException>()
                .And.ParamName.Should().Be("stringBuilder");
        }

        private static IEnumerable<object[]> GetStringBuilderExtensionMethods()
        {
            yield return new object[] { "AutoNumber", new object[0] };
            yield return new object[] { "IncreaseAutoNumber", new object[0] };
            yield return new object[] { "ResumeAutoNumber", new object[0] };
            yield return new object[] { "StopAutoNumber", new object[0] };
        }

        public static string GetStringBuilderExtensionMethodsDisplayName(MethodInfo _, object[] data)
        {
            return $"Method \"{data[0]}\" should throw an argument exception when StringBuilder is `null`";
        }
    }
}
