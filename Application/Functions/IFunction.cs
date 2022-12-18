using System.Numerics;

namespace Functions;

/// <summary>
///     Interface for one-dimension functions.
/// </summary>
/// <typeparam name="T">The floating point number type.</typeparam>
public interface IFunction<T> where T : IFloatingPoint<T>
{
    /// <summary>
    ///     Evaluates the function.
    /// </summary>
    /// <param name="x">The value to evaluate the function in.</param>
    /// <returns>The evaluated value.</returns>
    public T Evaluate(T x);

    /// <summary>
    ///     Integrates the function over a closed interval.
    /// </summary>
    /// <param name="a">The lower limit of the integral.</param>
    /// <param name="b">The upper limit of the integral.</param>
    /// <returns>The integral value.</returns>
    public T Integrate(T a, T b);
}