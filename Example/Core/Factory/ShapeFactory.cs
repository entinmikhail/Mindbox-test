using Example.Core.Abstractions;
using Example.Core.Shape;

namespace Example.Core.Factory;

public static class ShapeFactory
{
    public static bool TryCreateTriangleByThreeSides(float a, float b, float c, out IShape shape)
    {
        try
        {
            shape = new Triangle(a, b, c);
            return true;
        }
        catch (Exception e)
        {
            shape = null;
            Console.WriteLine(e);
            return false;
        }
    }
    
    public static bool TryCreateCircleByRadius(float radius, out IShape shape)
    {
        if (Circle.TryCreateByRadius(radius, out var circle))
        {
            shape = circle;
            return true;
        }

        shape = null;
        return false;
    }
}