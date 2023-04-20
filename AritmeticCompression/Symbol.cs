namespace AritmeticCompression;

public class Symbol
{
    public char Name { get; set; }

    public double Range
    {
        get { return High - Low; }
    }

    public double Frequency { get; set; }

    public double Low { get; set; }
    public double High { get; set; }
}