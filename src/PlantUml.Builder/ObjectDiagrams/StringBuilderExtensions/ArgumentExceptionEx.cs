using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace PlantUml.Builder;

internal static class ArgumentException
{
    /// <summary>Throws an exception if <paramref name="argument"/> is <see langword="null"/>, empty, or consists only of white-space characters.</summary>
    /// <param name="argument">The string argument to validate.</param>
    /// <param name="paramName">The name of the parameter with which <paramref name="argument"/> corresponds.</param>
    /// <exception cref="ArgumentNullException"><paramref name="argument"/> is <see langword="null"/>.</exception>
    /// <exception cref="ArgumentException"><paramref name="argument"/> is empty or consists only of white-space characters.</exception>
    /// <remarks>This method will be replaced with .NET 8.0</remarks>
    public static void ThrowIfNullOrWhitespace([NotNull] string argument, [CallerArgumentExpression("argument")] string paramName = null)
    {
        ArgumentNullException.ThrowIfNull(argument, paramName);

        if (string.IsNullOrWhiteSpace(argument)) throw new System.ArgumentException("The value cannot be an empty string or composed entirely of whitespace.", paramName);
    }
}
