namespace RandomWebScanner;

public class RandomSiteGenerator
{
    public string RandomSite()
    {
        var rand = new Random();
        var minChar = 4;
        var maxChar = 15;

        var charLen = rand.Next(minChar, maxChar);

        return "www." + Generate(charLen) + ".com";
    }
    
    private string Generate(int len)
    {
        var r = new Random();
        string[] consonants = {"a", "b", "c", "d", "f", "g", "h", "j", "k", "l", "m", "l", "n", "p", "r", "s", "sh", "t", "v", "w", "x"};
        string[] vowels = {"a", "e", "i", "o", "u", "y"};
        var name = "";
        name += consonants[r.Next(consonants.Length)].ToUpper();
        name += vowels[r.Next(vowels.Length)];
        var b = 2; //b tells how many times a new letter has been added. It's 2 right now because the first two letters are already in the name.
        while (b < len)
        {
            name += consonants[r.Next(consonants.Length)];
            b++;
            name += vowels[r.Next(vowels.Length)];
            b++;
        }

        name = name.Replace(" ", "");
        return name;
    }
    
}