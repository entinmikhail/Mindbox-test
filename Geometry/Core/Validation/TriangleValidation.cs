using System.Globalization;

namespace Geometry.Core.Validation;

public static class TriangleValidation
{
    public static bool IsTriangleValid(float a_Length, float b_Length, float c_Length)
    {
        if (a_Length <= 0f || b_Length <= 0f || c_Length <= 0f)
            return false;

        if (a_Length + b_Length <= c_Length || a_Length + c_Length <= b_Length || b_Length + c_Length <= a_Length)
            return false;

        return true;
    }
    
    public static void ThrowExceptionIfTriangleIsNotValid(float a_Length, float b_Length, float c_Length)
    {
        if (a_Length <= 0f)
        {
            throw new ArgumentOutOfRangeException(nameof(a_Length), 
                a_Length.ToString(CultureInfo.InvariantCulture), "The value must be greater than 0");
        }

        if (b_Length <= 0f)
        {
            throw new ArgumentOutOfRangeException(nameof(b_Length), 
                b_Length.ToString(CultureInfo.InvariantCulture), "The value must be greater than 0");
        }

        if (c_Length <= 0f)
        {
            throw new ArgumentOutOfRangeException(nameof(c_Length), 
                c_Length.ToString(CultureInfo.InvariantCulture), "The value must be greater than 0");
        }

        if (a_Length + b_Length <= c_Length)
        {
            throw new ArgumentException($"Sum of {nameof(a_Length)} and {nameof(b_Length)} must be greater than {nameof(c_Length)}. Triangle is not valid", 
                c_Length.ToString(CultureInfo.InvariantCulture));
        }
        
        if (a_Length + c_Length <= b_Length)
        {
            throw new ArgumentException($"Sum of {nameof(a_Length)} and {nameof(c_Length)} must be greater than {nameof(b_Length)}. Triangle is not valid", 
                c_Length.ToString(CultureInfo.InvariantCulture));
        }
        
        if (b_Length + c_Length <= a_Length)
        {
            throw new ArgumentException($"Sum of {nameof(b_Length)} and {nameof(c_Length)} must be greater than {nameof(a_Length)}. Triangle is not valid", 
                c_Length.ToString(CultureInfo.InvariantCulture));
        }
    }
}