using System.Net.Mime;

namespace RandomWebScanner;

public class DoPing
{
    private readonly Pinger pinger = new();
    private readonly RandomSiteGenerator randSiteGenerator = new();
    
    public void FindRandomPings(long num)
    {
        var filestream = new FileStream($"FoundSites{DateTime.Now:MMddyy-HHmmss}.txt", FileMode.Create);
        var stdConsole  = new StreamWriter(Console.OpenStandardOutput());
        var streamWriter = new StreamWriter(filestream);
        streamWriter.AutoFlush = true;

        var pings = new Dictionary<string, bool>();
        for (int i = 0; i <= num; i++)
        {
            var randSite = randSiteGenerator.RandomSite();
            var pinged = pinger.PingHost(randSite);
            if (!pings.ContainsKey(randSite))
                pings.Add(randSite, pinged);

            Console.SetOut(stdConsole);
            if (pinged)
            {
                Console.WriteLine("[" + (i + 1) + " / " + num + "]" + "  " + randSite + "  **[Life Found]**");
                Console.SetOut(streamWriter);
                Console.WriteLine("Found: " + randSite);
            }
            else
                Console.WriteLine("[" + (i + 1) + " / " + num + "]"+  "  " + randSite);
        }
    }
}