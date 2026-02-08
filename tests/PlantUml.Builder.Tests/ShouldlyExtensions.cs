using System.Text.RegularExpressions;

namespace Shouldly;

internal static class ShouldlyExtensions
{
    internal static TException ShouldThrowExactly<TException>(this Action action)
        where TException : Exception
    {
        var exception = Should.Throw<TException>(action);
        exception.GetType().ShouldBe(typeof(TException));
        return exception;
    }

    internal static TInnerException ShouldHaveInnerExceptionExactly<TInnerException>(this Exception exception)
        where TInnerException : Exception
    {
        exception.InnerException.ShouldNotBeNull();
        exception.InnerException.GetType().ShouldBe(typeof(TInnerException));
        return (TInnerException)exception.InnerException;
    }

    internal static TException WithParameterName<TException>(this TException exception, string parameterName)
        where TException : ArgumentException
    {
        exception.ParamName.ShouldBe(parameterName);
        return exception;
    }

    internal static TException WithMessage<TException>(this TException exception, string wildcardPattern)
        where TException : Exception
    {
        var regexPattern = "^" + Regex.Escape(wildcardPattern).Replace("\\*", ".*").Replace("\\?", ".") + "$";
        Regex.IsMatch(exception.Message, regexPattern, RegexOptions.Singleline).ShouldBeTrue();
        return exception;
    }
}
