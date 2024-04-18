using Example.Core.Shape;

namespace ExampleTests;

[TestClass]
public class TriangleTests
{
    [TestMethod]
    public void CtorFloatMinValues()
    {
        Assert.ThrowsException<ArgumentOutOfRangeException>(() =>
        {
            new MyTriangle(float.MinValue, float.MinValue, float.MinValue);
        });
    }
    
    [TestMethod]
    public void CtorNotValidTriangle()
    {
        Assert.ThrowsException<ArgumentException>(() =>
        {
            new MyTriangle(10, 10, float.MaxValue);
        });
    }
    
    [TestMethod]
    public void CtorFloatNull()
    {
        Assert.ThrowsException<ArgumentOutOfRangeException>(() =>
        {
            new MyTriangle(0, 0, 0);
        });    
    }
    
    [TestMethod]
    public void GetArea()
    {
        var triangle = new MyTriangle(10, 10, 10);
        
        var expected = 43.30127018922193;

        Assert.AreEqual(expected, triangle.GetArea());
    } 
    
    [TestMethod]
    public void IsRightAngledFalse()
    {
        var triangle = new MyTriangle(10, 10, 10);
        
        var expected = false;

        Assert.AreEqual(expected, triangle.IsRightAngled());
    }
    
    [TestMethod]
    public void IsRightAngledTrue()
    {
        var triangle = new MyTriangle(3, 4, 5);
        
        var expected = true;

        Assert.AreEqual(expected, triangle.IsRightAngled());
    }
    
    [TestMethod]
    public void GetAreaFloatMaxValues()
    {
        var triangle = new MyTriangle(float.MaxValue, float.MaxValue, float.MaxValue);
        
        var expected = 5.0139439441307764E+76;
        
        Assert.AreEqual(expected, triangle.GetArea());
    } 
    
    [TestMethod]
    public void GetAreaFloatEpsilon()
    {
        var triangle = new MyTriangle(float.Epsilon, float.Epsilon, float.Epsilon);
        
        var expected = 8.502799301000025E-91;
        
        Assert.AreEqual(expected, triangle.GetArea());
    }
}