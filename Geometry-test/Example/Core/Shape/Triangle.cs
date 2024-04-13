using Example.Core.Abstractions;
using Geometry.Core.Calculation;
using Geometry.Core.Validation;

namespace Example.Core.Shape;

public sealed class Triangle : ITriangle
{
    public float A_Length { get;  }
    public float B_Length { get; }
    public float C_Length { get; }
    
    public Triangle(float a_Length, float b_Length, float c_Length)
    {
        TriangleValidation.ThrowExceptionIfTriangleIsNotValid(a_Length, b_Length, c_Length);
        
        A_Length = a_Length;
        B_Length = b_Length;
        C_Length = c_Length;
    }
    
    public double GetArea() => TriangleMath.GetAreaByThreeSides(A_Length, B_Length, C_Length);
    
    public bool IsRightAngled() => TriangleMath.IsRightAngledByThreeSides(A_Length, B_Length, C_Length);
    
    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != GetType()) return false;
        return Equals((ITriangle)obj);
    }

    public override int GetHashCode() => HashCode.Combine(A_Length, B_Length, C_Length);

    private bool Equals(ITriangle other) => A_Length.Equals(other.A_Length) && B_Length.Equals(other.B_Length) && C_Length.Equals(other.C_Length);
}