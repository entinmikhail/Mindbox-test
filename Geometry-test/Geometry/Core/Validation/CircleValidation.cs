using System.Globalization;

namespace Geometry.Core.Validation;

public static class CircleValidation
{
    public static bool IsCircleValid(float radius)
    {
        return radius > 0;
    }
    
    public static void ThrowExceptionIfCircleIsNotValid(float radius)
    {
        if (radius <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(radius), radius.ToString(CultureInfo.InvariantCulture),
                "The value must be greater than 0");
        }
    }
}