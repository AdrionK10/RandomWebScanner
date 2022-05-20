using System.Text;

namespace RandomWebScanner;

public class RandomSiteGenerator
{
    public string RandomSite()
    {
        var rand = new Random();
        var minChar = 5;
        var maxChar = 20;

        var charLen = rand.Next(minChar, maxChar);

        return "www." + Generate(charLen) + ".com";
    }
    
    private string Generate(int len)
    {
        var r = new Random();
        var binary = false;
        
        if (binary != true)
        {
            if (findRandom() == 1)
                return generateBinaryString(len);
        }
        else
            return generateBinaryString(len);
        
        StringBuilder name = new StringBuilder();
        
        string[] consonants =
        {
            "a", "b", "c", "d", "f", "g", "h", "j", "k", "l", "m", "l", "n", "p", "r", "s", "sh", "t", "v", "w", "x"
        };
        string[] vowels = {"a", "e", "i", "o", "u", "y"};
        
        name.Append(consonants[r.Next(consonants.Length)]);
        name.Append(vowels[r.Next(vowels.Length)]);
        var b = 2;
        while (b < len)
        {
            name.Append(consonants[r.Next(consonants.Length)]);
            b++;
            name.Append(vowels[r.Next(vowels.Length)]);
            b++;
        }
        
        return name.ToString().Replace(" ", "");
    }
    
    
    
    
    static int findRandom()
    {
        Random rand = new Random();
        return rand.Next() % 2;
    }
    
    static string generateBinaryString(int length)
    {
        StringBuilder s = new();
        
        for(int i = 0; i < length; i++)
            s.Append(findRandom());

        return s.ToString();
    }
    
}