using Geometry.Abstraction;
using Geometry.Configuration;
using Geometry.Core.Validation;

namespace Geometry.Core.Type;

public class Triangle : ITriangle
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
    
    public virtual double GetArea() => GetAreaByThreeSides(A_Length, B_Length, C_Length);
    
    public virtual bool IsRightAngled() => IsRightAngledByThreeSides(A_Length, B_Length, C_Length);
    
    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != GetType()) return false;
        return Equals((ITriangle)obj);
    }

    public override int GetHashCode() => HashCode.Combine(A_Length, B_Length, C_Length);

    private bool Equals(ITriangle other) => A_Length.Equals(other.A_Length) && B_Length.Equals(other.B_Length) && C_Length.Equals(other.C_Length);
    
    /// <summary>
    /// Проверяет является ли треугольник прямоугольным по трём сторонам. Принимает значения в диапазоне [float.Epsilon; float.MaxValue]
    /// </summary>
    public static bool IsRightAngledByThreeSides(float a_Length, float b_Length, float c_Length)
    {
        if (!TriangleValidation.IsTriangleValid(a_Length, b_Length, c_Length))
            return false;
        
        double aPow2 = a_Length * a_Length;
        double bPow2 = b_Length * b_Length;
        double cPow2 = c_Length * c_Length;

        return Math.Abs(aPow2 + bPow2 - cPow2) < GeometryConstants.Tolerance ||
               Math.Abs(aPow2 + cPow2 - bPow2) < GeometryConstants.Tolerance ||
               Math.Abs(bPow2 + cPow2 - aPow2) < GeometryConstants.Tolerance;
    }

    /// <summary>
    /// Возвращает площадь треугольника по трём сторонам. Принимает значения в диапазоне [float.Epsilon; float.MaxValue]
    /// </summary>
    /// <returns> Площадь </returns>
    public static double GetAreaByThreeSides(float a_Length, float b_Length, float c_Length)
    {
        if (!TriangleValidation.IsTriangleValid(a_Length, b_Length, c_Length))
            return -1d;
        
        var halfPerimeter = ((double)a_Length + b_Length + c_Length) / 2d;
        return Math.Sqrt(halfPerimeter * (halfPerimeter - a_Length) 
                                       * (halfPerimeter - b_Length) 
                                       * (halfPerimeter - c_Length));
    }
}