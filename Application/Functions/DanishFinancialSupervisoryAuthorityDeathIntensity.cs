namespace Functions;

/// <summary>
///     Abstract class containing logic related to the Danish FSA's benchmark model for lifetime modelling.
/// </summary>
public abstract class DanishFinancialSupervisoryAuthorityDeathIntensity :
    PiecewiseConstantFunction<double>, IHazardFunction<double>
{
    private readonly int _benchmarkYear;
    private readonly int _birthDateYear;
    private readonly double _currentAge;
    private readonly int _indexMax;

    /// <summary>
    ///     Initializes a new instance of <see cref="DanishFinancialSupervisoryAuthorityDeathIntensity" />. Note that
    ///     <see cref="ComputeValues" /> is called to compute the values for the base class.
    /// </summary>
    /// <param name="intensityValues">The intensity values.</param>
    /// <param name="improvementValues">The improvements values.</param>
    /// <param name="birthDate">The date of birth.</param>
    /// <param name="benchmarkYear">The benchmark year.</param>
    protected DanishFinancialSupervisoryAuthorityDeathIntensity(
        IEnumerable<double> intensityValues, IEnumerable<double> improvementValues, DateTime birthDate,
        int benchmarkYear)
        : base(ComputeValues(intensityValues, improvementValues, birthDate.Year, benchmarkYear))
    {
        _birthDateYear = birthDate.Year;
        _benchmarkYear = benchmarkYear;
        _currentAge = 1; // TODO
        XMin = _benchmarkYear - _birthDateYear;
        XMax = 110;
        _indexMax = XMax - XMin;
    }

    /// <summary>
    ///     The maximum value for the intensity function.
    /// </summary>
    public int XMax { get; }

    /// <summary>
    ///     The minimum values for the intensity function.
    /// </summary>
    public int XMin { get; }

    /// <remarks>Note that no fields should be set here, that should be done in the constructor.</remarks>
    private static double[] ComputeValues(IEnumerable<double> intensityValues, IEnumerable<double> improvementValues,
        int birthDateYear, int benchmarkYear)
    {
        var intensity = intensityValues.ToArray();
        var improvement = improvementValues.ToArray();

        if (improvement.Length != 111)
            throw new ArgumentException(
                $"The parameter has length '{improvement.Length}', but should be 111.", nameof(improvementValues));

        if (intensity.Length != 111)
            throw new ArgumentException(
                $"The parameter has length '{intensity.Length}', but should be 111.", nameof(intensityValues));

        if (benchmarkYear - birthDateYear < 0)
            throw new ArgumentOutOfRangeException(
                $"Unsupported combination of benchmark year '{benchmarkYear}' and birth-date year'{birthDateYear}'.");

        var values = new double[111];

        for (var x = 0; x < values.Length; x++)
            values[x] =
                x < benchmarkYear - birthDateYear
                    ? double.NaN
                    : intensity[x] * Math.Pow(1 - improvement[x], birthDateYear - benchmarkYear + x);

        return values;
    }

    /// <inheritdoc />
    protected override void ValidateInput(double x)
    {
        if (x < XMin)
            throw new ArgumentOutOfRangeException(
                nameof(x), $"Mismatch between age '{x}' and birth date year '{_birthDateYear}'. " +
                           $"The age must be >= {XMin}.");

        base.ValidateInput(x);
    }
}