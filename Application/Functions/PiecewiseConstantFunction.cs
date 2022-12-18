using System.Globalization;
using System.Numerics;

[assembly: CLSCompliant(true)]

namespace Functions;

/// <summary>
///     A class representing a piecewise constant function defined by a values defined on a equidistant grid starting at
///     zero with a step-size of one.
/// </summary>
/// <typeparam name="T">The number type of the values.</typeparam>
public class PiecewiseConstantFunction<T> : IFunction<T> where T : IFloatingPoint<T>
{
    /// <summary>
    ///     Initializes a new instance of <see cref="PiecewiseConstantFunction{T}" />.
    /// </summary>
    /// <param name="values">The values defining the function.</param>
    public PiecewiseConstantFunction(T[] values)
    {
        Values = values ?? throw new ArgumentNullException(nameof(values));
        Indices = Enumerable.Range(0, values.Length).ToArray();
    }

    /// <summary>
    ///     The values defining the function. The function is right-continuous.
    /// </summary>
    private T[] Values { get; }

    private int[] Indices { get; }

    private int IndexMax => Indices.Length - 1;

    /// <inheritdoc />
    public virtual T Evaluate(T x)
    {
        ValidateInput(x);

        var index = Convert.ToInt32(T.Floor(x), CultureInfo.InvariantCulture);
        return Values[index];
    }


    /// <inheritdoc />
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

        for (var x = aStar; x < bStar; x++)
            innerPoints += Evaluate(x);

        return leftEndPoint + innerPoints + rightEndPoint;
    }

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