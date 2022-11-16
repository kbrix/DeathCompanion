using System.Numerics;

[assembly: CLSCompliant(true)]

namespace Functions;

/// <summary>
///     A class representing a piecewise constant function defined by a values defined on a equidistant grid starting at
///     zero with a step-size of one.
/// </summary>
/// <typeparam name="T">The number type of the values.</typeparam>
public class PiecewiseConstantFunction<T> where T : IFloatingPoint<T>
{
    /// <summary>
    ///     Initializes a new instance of <see cref="PiecewiseConstantFunction{T}" />.
    /// </summary>
    /// <param name="values">The values defining the function.</param>
    public PiecewiseConstantFunction(T[] values)
    {
        Values = values;
        Indices = Enumerable.Range(0, values.Length).ToArray();
    }

    /// <summary>
    ///     The values defining the function. The function is right-continuous.
    /// </summary>
    private T[] Values { get; }

    private int[] Indices { get; }

    private int IndexMax => Indices.Length - 1;

    /// <summary>
    ///     Validates input before evaluation, throws
    /// </summary>
    /// <param name="x"></param>
    /// <exception cref="ArgumentOutOfRangeException"></exception>
    protected virtual void ValidateInput(T x)
    {
        if (x < T.Zero || x > T.CreateChecked(IndexMax))
            throw new ArgumentOutOfRangeException(
                nameof(x), $"The value '{x}' should belong to the closed interval [0, {IndexMax}].");
    }

    /// <summary>
    ///     Evaluates the function.
    /// </summary>
    /// <param name="x">The value to evaluate the function in.</param>
    /// <returns>The evaluated value.</returns>
    public virtual T Evaluate(T x)
    {
        ValidateInput(x);

        var index = Convert.ToInt32(T.Floor(x));
        return Values[index];
    }

    /// <summary>
    ///     Integrates the function over a closed interval.
    /// </summary>
    /// <param name="a">The lower limit of the integral.</param>
    /// <param name="b">The upper limit of the integral.</param>
    /// <returns>The integral value.</returns>
    public virtual T Integrate(T a, T b)
    {
        ValidateInput(a);
        ValidateInput(b);

        if (a == b)
            return T.Zero;

        if (a > b)
            return T.NegativeOne * Integrate(b, a);

        if (b - a < T.One)
            return (b - a) * Evaluate(a);

        var aStar = T.Ceiling(a);
        var leftEndPoint = (aStar - a) * Evaluate(a);

        var bStar = T.Floor(b);
        var rightEndPoint = (b - bStar) * Evaluate(bStar);

        var innerPoints = T.Zero;

        for (T x = aStar; x < bStar; x++)
            innerPoints += Evaluate(x);

        return leftEndPoint + innerPoints + rightEndPoint;
    }

    /// <inheritdoc cref="Evaluate" />
    /// <remarks>A memoized version.</remarks>
    public virtual T EvaluateMemoized(T x)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc cref="Integrate" />
    /// <remarks>A memoized version.</remarks>
    public virtual T IntegrateMemoized(T a, T b)
    {
        throw new NotImplementedException();
    }
}