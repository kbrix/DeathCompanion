using Functions;
using NUnit.Framework;

namespace FunctionsTests;

public class PiecewiseConstantFunctionTests
{
    [TestCase(0.0, 1.0)]
    [TestCase(0.5, 1.0)]
    [TestCase(0.9, 1.0)]
    [TestCase(1.0, 2.0)]
    [TestCase(1.2, 2.0)]
    [TestCase(2.0, 3.0)]
    [TestCase(2.9, 3.0)]
    [TestCase(3.0, 4.0)]
    public void PiecewiseConstantFunction_Evaluate_ReturnsValue(double x, double expectedValue)
    {
        // Arrange
        var values = new[] {1d, 2d, 3d, 4d};
        var function = new PiecewiseConstantFunction<double>(values);
        // Act
        var result = function.Evaluate(x);
        // Assert
        Assert.That(result, Is.EqualTo(expectedValue));
    }

    [TestCase(0.0, 2.0, 3.0)]
    [TestCase(0.0, 3.0, 6.0)]
    [TestCase(0.002, 0.005, 0.003)]
    [TestCase(0.25, 0.75, 0.5)]
    [TestCase(0.25, 1.0, 0.75)]
    [TestCase(0.5, 1.5, 1.5)]
    [TestCase(0.5, 3.0, 5.5)]
    public void PiecewiseConstantFunction_Integrate_ReturnsValue(double a, double b, double expectedValue)
    {
        // Arrange
        var values = new[] {1d, 2d, 3d, 4d};
        var function = new PiecewiseConstantFunction<double>(values);
        // Act
        var result = function.Integrate(a, b);
        // Assert
        Assert.That(result, Is.EqualTo(expectedValue));
    }
}