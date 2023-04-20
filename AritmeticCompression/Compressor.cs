namespace AritmeticCompression;

public class Compressor
{
    private readonly List<Symbol> _symbols;

    public Compressor()
    {
        _symbols = new List<Symbol>();
    }

    public double Encode(string input)
    {
        CalculateFrequencies(input);
        Symbol last = new()
        {
            Low = 0, High = 1
        };
        foreach (var symbol in input)
        {
            var s = _symbols.FirstOrDefault(x => x.Name == symbol);
            if (s != null)
            {
                var low = last.Low + last.Range * s.Low;
                var high = last.Low + last.Range * s.High;
                Symbol actual = new Symbol()
                {
                    Name = symbol,
                    Low = low,
                    High = high
                };
                last = actual;
            }
        }

        return last.Low;
    }

    private void CalculateFrequencies(string input)
    {
        int[] chars = new int[26];
        foreach (var charr in input.ToLower())
        {
            if (char.IsLetter(charr))
            {
                chars[charr - 'a']++;
            }
        }

        int count = 0;
        for (int i = 0; i < chars.Length; i++)
        {
            if (chars[i] > 0)
            {
                var low = count == 0 ? 0 : _symbols[count - 1].High;
                count++;
                var frequency = (double)chars[i] / input.Length;
                _symbols.Add(new Symbol()
                {
                    Name = (char)(i+'a'),
                    Frequency = frequency,
                    Low = low,
                    High = low + frequency
                });
            }
        }
    }
}