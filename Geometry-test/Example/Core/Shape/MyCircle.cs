using Example.Utility;
using Geometry.Abstraction;
using Geometry.Core.Type;
using Geometry.Core.Validation;

namespace Example.Core.Shape;

public sealed class MyCircle : Circle
{
    private readonly ILogger _logger;

    private MyCircle(float radius, ILogger logger) : base(radius)
    {
        _logger = logger;
    }

    public static bool TryCreateByRadius(float radius, ILogger logger, out ICircle circleSample)
    {
        circleSample = null;

        if (!CircleValidation.IsCircleValid(radius))
            return false;
        
        circleSample = new MyCircle(radius, logger);
        return true;
    }

    public override double GetArea()
    {
        var area = base.GetArea();
        _logger.Log($"Area of {nameof(MyCircle)} with radius {Radius} is {area}");
        return area;
    }
}