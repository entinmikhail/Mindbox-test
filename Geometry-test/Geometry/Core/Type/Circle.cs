using Geometry.Abstraction;
using Geometry.Core.Validation;

namespace Geometry.Core.Type;

public class Circle : ICircle
{
    public float Radius { get; }

    protected Circle(float radius)
    {
        Radius = radius;
    }

    public static bool TryCreateByRadius(float radius, out ICircle circleSample)
    {
        circleSample = null;

        if (!CircleValidation.IsCircleValid(radius))
            return false;
        
        circleSample = new Circle(radius);
        return true;
    }

    public virtual double GetArea() => GetAreaByRadius(Radius);

    public override int GetHashCode() => Radius.GetHashCode();

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != GetType()) return false;
        return Equals((Circle)obj);
    }

    private bool Equals(ICircle other) => Radius.Equals(other.Radius);
    
    /// <summary>
    /// Возвращает площадь круга по радиусу. Принимает значения в диапазоне [float.Epsilon; float.MaxValue]
    /// </summary>
    /// <returns> Площадь </returns>
    public static double GetAreaByRadius(float radius)
    {
        if (!CircleValidation.IsCircleValid(radius))
            return -1;
        
        return Math.PI * radius * radius;
    }
}