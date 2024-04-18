using Example.Core.Shape;
using Example.Utility;

namespace ExampleTests;

[TestClass]
public class CircleTests
{
    private readonly ILogger _logger = new Logger();

    [TestMethod]
    public void GetArea()
    {
        if (!MyCircle.TryCreateByRadius(10, _logger, out var circleSample))
        {
            Assert.Fail();
            return;
        }
        
        var expected = 314.1592653589793;

        Assert.AreEqual(expected, circleSample.GetArea());
    }
    
    [TestMethod]
    public void GetAreaFloatMaxValues()
    {
        if (!MyCircle.TryCreateByRadius(float.MaxValue, _logger, out var circleSample))
        {
            Assert.Fail();
            return;
        }
        
        var expected = 3.637715335268164E+77;
        
        Assert.AreEqual(expected, circleSample.GetArea());
    }
    
    [TestMethod]
    public void GetAreaFloatEpsilon()
    {
        if (!MyCircle.TryCreateByRadius(float.Epsilon, _logger, out var circleSample))
        {
            Assert.Fail();
            return;
        }

        var expected = 6.168948786545999E-90d;
        
        Assert.AreEqual(expected, circleSample.GetArea());
    }
    
    [TestMethod]
    public void TryCreateByFloatMinValues()
    {
        if (MyCircle.TryCreateByRadius(float.MinValue, _logger, out _))
        {
            Assert.Fail();
        }
    }
    
    [TestMethod]
    public void TryCreateByFloatMax()
    {
        if (!MyCircle.TryCreateByRadius(float.MaxValue, _logger, out _))
        {
            Assert.Fail();
        }
    }
}