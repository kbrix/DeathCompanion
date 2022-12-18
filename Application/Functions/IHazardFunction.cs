using System.Numerics;

namespace Functions;

/// <summary>
///     Interface for hazard functions used for defining positive continuous random variables.
/// </summary>
/// <typeparam name="T">The floating point number type.</typeparam>
public interface IHazardFunction<T> : IFunction<T> where T : IFloatingPoint<T>
{
}