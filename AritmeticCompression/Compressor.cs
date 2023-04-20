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
                var actual = new Symbol()
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
        var chars = new float[26];
        foreach (var charr in input.ToLower())
        {
            if (char.IsLetter(charr))
            {
                chars[charr - 'a']++;
            }
        }

        var count = 0;
        for (var i = 0; i < chars.Length; i++)
        {
            if (chars[i] > 0)
            {
                var low = count == 0 ? 0 : _symbols[count - 1].High;
                count++;
                var frequency = chars[i] / input.Length;
                _symbols.Add(new Symbol()
                {
                    Name = (char)(i + 'a'),
                    Frequency = frequency,
                    Low = low,
                    High = low + frequency
                });
            }
        }
    }

    public string Decode(double input)
    {
        string output = string.Empty;
        while (true)
        {
            var last = _symbols.FirstOrDefault(x => x.Low <= input && x.High > input);
            if (last != null)
            {
                output += last.Name;
                if (input == 0) break;
                input = (input - last.Low) / last.Range;
            }

            Console.WriteLine(input);
        }

        return output;
    }
}