using System.Numerics;

namespace Functions;

/// <inheritdoc />
public class Function<T> : IFunction<T> where T : IFloatingPoint<T>
{
    /// <summary>
    ///     Creates a new instance of <see cref="Function{T}" />.
    /// </summary>
    /// <param name="f">The backing function.</param>
    public Function(Func<T, T> f)
    {
        BackingFunction = f;
    }

    private Func<T, T> BackingFunction { get; }

    /// <inheritdoc />
    public T Evaluate(T x)
    {
        return BackingFunction.Invoke(x);
    }

    /// <inheritdoc />
    public T Integrate(T a, T b)
    {
        throw new NotImplementedException();
    }
}