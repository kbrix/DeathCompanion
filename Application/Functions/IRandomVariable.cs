using System.Numerics;

namespace Functions;

/// <summary>
///     Interface for functionality related to random varaibles.
/// </summary>
/// <typeparam name="T"></typeparam>
public interface IRandomVariable<T> where T : IFloatingPoint<T>
{
    /// <summary>
    ///     Evaluates the hazard function.
    /// </summary>
    /// <param name="x">The value to evaluate the function at.</param>
    /// <returns>The evaluated value.</returns>
    public T EvaluateHazardFunction(T x);

    /// <summary>
    ///     Evaluates the density function (usually called $f$).
    /// </summary>
    /// <param name="x">The value to evaluate the function at.</param>
    /// <returns>The evaluated value.</returns>
    public T EvaluateDensityFunction(T x);

    /// <summary>
    ///     Evaluates the distribution function (usually called $F$).
    /// </summary>
    /// <param name="x">The value to evaluate the function at.</param>
    /// <returns>The evaluated value.</returns>
    public T EvaluateDistributionFunction(T x);

    /// <summary>
    ///     Evaluates the survival function (usually called $\widehat F$).
    /// </summary>
    /// <param name="x">The value to evaluate the function at.</param>
    /// <returns>The evaluated value.</returns>
    public T EvaluateSurvivalFunction(T x);

    /// <summary>
    ///     Computes the expectation of the random variable (first moment).
    /// </summary>
    /// <returns>The expectation.</returns>
    public T ComputeExpectation();

    /// <summary>
    ///     Computes the variance of the random variable (second centered moment).
    /// </summary>
    /// <returns>The variance.</returns>
    public T ComputeVariance();
}