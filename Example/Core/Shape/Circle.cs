using Geometry.Core.Calculation;
using Geometry.Core.Validation;
using UsageExample.Core.Abstractions;

namespace UsageExample.Core.Shape;

public sealed class Circle : ICircle
{
    public float Radius { get; }

    private Circle(float radius)
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

    public double GetArea() => CircleMath.GetAreaByRadius(Radius);

    public override int GetHashCode() => Radius.GetHashCode();

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != GetType()) return false;
        return Equals((Circle)obj);
    }

    private bool Equals(ICircle other) => Radius.Equals(other.Radius);
}