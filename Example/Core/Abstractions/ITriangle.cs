namespace Example.Core.Abstractions;

public interface ITriangle : IShape
{
    bool IsRightAngled();
    
    float A_Length { get; }
    float B_Length { get; }
    float C_Length { get; }
}