namespace AritmeticCompression;

public class Symbol
{
    public char Name { get; init; }

    public double Range => High - Low;

    public double Frequency { get; set; }

    public double Low { get; init; }
    public double High { get; init; }
}