using UsageExample.Core.Shape;

namespace TestProject1;

[TestClass]
public class CircleTests
{
    [TestMethod]
    public void GetArea()
    {
        if (!Circle.TryCreateByRadius(10, out var circleSample))
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
        if (!Circle.TryCreateByRadius(float.MaxValue, out var circleSample))
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
        if (!Circle.TryCreateByRadius(float.Epsilon, out var circleSample))
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
        if (Circle.TryCreateByRadius(float.MinValue, out _))
        {
            Assert.Fail();
        }
    }
    
    [TestMethod]
    public void TryCreateByFloatMax()
    {
        if (!Circle.TryCreateByRadius(float.MaxValue, out _))
        {
            Assert.Fail();
        }
    }
}