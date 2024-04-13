using Geometry.Core.Validation;

namespace Geometry.Core.Calculation;

public static class CircleMath
{
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