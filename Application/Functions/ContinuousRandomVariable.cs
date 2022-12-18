using MathNet.Numerics.Integration;

namespace Functions;

/// <summary>
///     Creates a new instance of <see cref="ContinuousOneDimensionalRandomVariable" />.
/// </summary>
public class ContinuousOneDimensionalRandomVariable : IRandomVariable<double>
{
    private double Shift { get; set; }
    private (double LeftEndPoint, double RightEndPoint) Domain { get; set; }
    private IHazardFunction<double> HazardFunction { get; set; }
    private IFunction<double> SurvivalFunction { get; set; }

    /// <inheritdoc />
    public double EvaluateHazardFunction(double x)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    public double EvaluateDensityFunction(double x)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    public double EvaluateDistributionFunction(double x)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    public double EvaluateSurvivalFunction(double x)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    public double ComputeExpectation()
    {
        // TODO this method for computing the expectation is only valid for POSITIVE random variables!
        var integral = NewtonCotesTrapeziumRule.IntegrateAdaptive(
            t => SurvivalFunction.Evaluate(t),
            Domain.LeftEndPoint, Domain.RightEndPoint - Shift, 0.01);

        return integral;
    }

    /// <inheritdoc />
    public double ComputeVariance()
    {
        throw new NotImplementedException();
    }

    /// <summary>
    ///     Uses the builder pattern to create an instance of <see cref="ContinuousOneDimensionalRandomVariable" /> using a
    ///     hazard function.
    /// </summary>
    /// <param name="hazardFunction">The hazard function.</param>
    /// <param name="shift">A shift applied to the hazard function, i.e. $t \mapto \mu(shift + t)$.</param>
    /// <param name="domain">The domain the function is defined on, usually $[0, \infty)$.</param>
    /// <returns>An instance of <see cref="ContinuousOneDimensionalRandomVariable" />.</returns>
    public ContinuousOneDimensionalRandomVariable WithHazardFunction(
        IHazardFunction<double> hazardFunction, double shift, (double leftEndPoint, double rightEndPoint) domain)
    {
        Shift = shift;
        Domain = domain;
        HazardFunction = hazardFunction;

        var integratedHazardFunction =
            (double t) => HazardFunction.Integrate(Shift + Domain.LeftEndPoint, Shift + t);
        var survivalFunction =
            (double t) => Math.Exp(-1.0 * integratedHazardFunction(t));
        SurvivalFunction = new Function<double>(survivalFunction);

        return this;
    }
}