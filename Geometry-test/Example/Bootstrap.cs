using Example.Core.Factory;
using Example.Utility;
using Geometry.Abstraction;

namespace Example;

public class Bootstrap
{
    private readonly ILogger _logger = new Logger();

    public void Run()
    {
        foreach (var shape in GetShapes())
        {
            Console.WriteLine($"{shape.GetType().Name} with area - {shape.GetArea()}");
        }
    }

    private IEnumerable<IShape> GetShapes()
    {
        if (ShapeFactory.TryCreateTriangleByThreeSides(10f, 10f, 10f, out var firstTriangle))
            yield return firstTriangle;
        
        if (ShapeFactory.TryCreateTriangleByThreeSides(12f, 130f, 10f, out var secondTriangle))
            yield return secondTriangle;

        if (ShapeFactory.TryCreateCircleByRadius(10f, out var firstCircle))
            yield return firstCircle;
        
        if (ShapeFactory.TryCreateMyCircleByRadius(10f, _logger, out var circleWithLogger))
            yield return circleWithLogger;

        if (ShapeFactory.TryCreateCircleByRadius(-1f, out var secondCircle))
            yield return secondCircle;
    }
}