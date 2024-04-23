using Geometry.Abstraction;
using Geometry.Core.Type;
using Geometry.Core.Validation;

namespace Example.Core.Shape;

public readonly struct TriangleStruct : ITriangle
{
    public float A_Length { get; }
    public float B_Length { get; }
    public float C_Length { get; }
    
    public TriangleStruct(float aLength, float bLength, float cLength)
    {
        TriangleValidation.ThrowExceptionIfTriangleIsNotValid(aLength, bLength, cLength);
        
        A_Length = aLength;
        B_Length = bLength;
        C_Length = cLength;
    }
    
    public double GetArea() => Triangle.GetAreaByThreeSides(A_Length, B_Length, C_Length);

    public bool IsRightAngled() => Triangle.IsRightAngledByThreeSides(A_Length, B_Length, C_Length);
    
    public bool Equals(TriangleStruct other) => A_Length.Equals(other.A_Length) && B_Length.Equals(other.B_Length) && C_Length.Equals(other.C_Length);

    public override bool Equals(object? obj) => obj is TriangleStruct other && Equals(other);

    public override int GetHashCode() => HashCode.Combine(A_Length, B_Length, C_Length);
}