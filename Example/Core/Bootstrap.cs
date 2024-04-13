using UsageExample.Core.Abstractions;
using UsageExample.Core.Factory;

namespace UsageExample.Core;

public class Bootstrap
{
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

        if (ShapeFactory.TryCreateCircleByRadius(-1f, out var secondCircle))
            yield return secondCircle;
    }
}