using App;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests;

[TestClass]
public class UnitTest
{
    [TestMethod]
    public void TestMethod() // (0,0) -> (2,30)
    {
        double expected = 30.066592756745816;
        double actual = Program.CalculateDistance("15F6B6B5L16R8B16F20L6F13F11R");

        Assert.AreEqual(actual, expected);
    }

    [TestMethod] // line along the positive x-axis
    public void TestPositiveXAxis()
    {
        double expected = 111;
        double actual = Program.CalculateDistance("1R10R100R");

        Assert.AreEqual(actual, expected);
    }

    [TestMethod] // line along the negative x-axis
    public void TestNegativeXAxis()
    {
        double expected = 111;
        double actual = Program.CalculateDistance("1L10L100L");

        Assert.AreEqual(actual, expected);
    }

    [TestMethod] // line along the positive y-axis
    public void TestPositiveYAxis()
    {
        double expected = 111;
        double actual = Program.CalculateDistance("1F10F100F");

        Assert.AreEqual(actual, expected);
    }

    [TestMethod] // line along the negative y-axis
    public void TestNegativeYAxis()
    {
        double expected = 111;
        double actual = Program.CalculateDistance("1B10B100B");

        Assert.AreEqual(actual, expected);
    }

    [TestMethod] // line that does not move from (0,0)
    public void TestCenter()
    {
        double expected = 0;
        double actual = Program.CalculateDistance("1F1B1R1L");

        Assert.AreEqual(actual, expected);
    }

        [TestMethod] // line that ends in quadrant 1 (+,+)
    public void TestQuadrant1()
    {
        double expected = 7.0710678118654755;
        double actual = Program.CalculateDistance("5F5R");

        Assert.AreEqual(actual, expected);
    }

            [TestMethod] // line that ends in quadrant 2 (-,+)
    public void TestQuadrant2()
    {
        double expected = 7.0710678118654755;
        double actual = Program.CalculateDistance("5F5L");

        Assert.AreEqual(actual, expected);
    }

    [TestMethod] // line that ends in quadrant 3 (-,-)
    public void TestQuadrant3()
    {
        double expected = 7.0710678118654755;
        double actual = Program.CalculateDistance("5B5L");

        Assert.AreEqual(actual, expected);
    }

    [TestMethod] // line that ends in quadrant 4 (+,-)
    public void TestQuadrant4()
    {
        double expected = 7.0710678118654755;
        double actual = Program.CalculateDistance("5B5R");

        Assert.AreEqual(actual, expected);
    }

    [TestMethod] // empty string input
    public void TestEmptyInput()
    {
        Action act = () => Program.CalculateDistance("");

        Assert.ThrowsException<ArgumentNullException>(act);
    }

    [TestMethod] // input that only has a distance
    public void TestOnlyDistance()
    {
        Action act = () => Program.CalculateDistance("1000");

        Assert.ThrowsException<ArgumentException>(act);
    }

    [TestMethod] // input that only has a direction
    public void TestOnlyDirection()
    {
        Action act = () => Program.CalculateDistance("F");

        Assert.ThrowsException<ArgumentException>(act);   
    }


    [TestMethod] // invalid direction input
    public void TestInvalidDirection()
    {
        Action act = () => Program.CalculateDistance("1C");

        Assert.ThrowsException<ArgumentException>(act);
    }

    [TestMethod] // invalid distance input
    public void TestInvalidDistance()
    {
        Action act = () => Program.CalculateDistance("1.3F");

        Assert.ThrowsException<ArgumentException>(act);
    }

    [TestMethod] // 2 distance inputs 1 direction input
    public void Test2Distances1Direction()
    {
        Action act = () => Program.CalculateDistance("1F2");

        Assert.ThrowsException<ArgumentException>(act);
    }

        [TestMethod] // 2 direction inputs 1 distance input
    public void Test2Directions1Distance()
    {
        Action act = () => Program.CalculateDistance("1FB");

        Assert.ThrowsException<ArgumentException>(act);
    }

    [TestMethod] // input that has an invalid symbol
    public void TestInvalidSymbol()
    {
        Action act = () => Program.CalculateDistance("1F2$3B");

        Assert.ThrowsException<ArgumentException>(act);
    }

    [TestMethod] // input that has a whitespace
    public void TestWhitespace()
    {
        Action act = () => Program.CalculateDistance("5F 5R");

        Assert.ThrowsException<ArgumentException>(act);

    }

        [TestMethod] // input that is null
    public void TestNullInput()
    {
        Action act = () => Program.CalculateDistance(null);

        Assert.ThrowsException<ArgumentNullException>(act);
    }
}