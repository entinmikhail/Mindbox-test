using Geometry.Core.Configurations;
using Geometry.Core.Validation;

namespace Geometry.Core.Calculation;

public static class TriangleMath
{
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

        return Math.Abs(aPow2 + bPow2 - cPow2) < GeometryConstants.TOLERANCE ||
               Math.Abs(aPow2 + cPow2 - bPow2) < GeometryConstants.TOLERANCE ||
               Math.Abs(bPow2 + cPow2 - aPow2) < GeometryConstants.TOLERANCE;
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