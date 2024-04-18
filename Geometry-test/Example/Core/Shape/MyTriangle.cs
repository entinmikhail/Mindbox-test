using Geometry.Core.Type;

namespace Example.Core.Shape;

public sealed class MyTriangle(float a_Length, float b_Length, float c_Length) : Triangle(a_Length, b_Length, c_Length)
{
    private double? _area;
    private bool? _isRightAngled;

    public override double GetArea()
    {
        _area ??= base.GetArea();
        return _area.Value;
    }

    public override bool IsRightAngled()
    {
        _isRightAngled ??= base.IsRightAngled();
        return _isRightAngled.Value;
    }
}