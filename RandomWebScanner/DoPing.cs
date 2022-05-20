using static System.IO.Directory;

namespace RandomWebScanner;

public class DoPing
{
    private readonly Pinger pinger = new();
    private readonly RandomSiteGenerator randSiteGenerator = new();
    
    public void FindRandomPings(long num)
    {
        var root = AppDomain.CurrentDomain.BaseDirectory;
        if (!Exists(@$"{root}\output"))
            CreateDirectory(@$"{root}\output");
        
        var foundStream = new FileStream(@$"{root}\output\Response{DateTime.Now:MMddyy-HHmmss}.txt", FileMode.Create);
        var notFoundStream = new FileStream(@$"{root}\output\NoResponse{DateTime.Now:MMddyy-HHmmss}.txt", FileMode.Create);
        var stdConsole  = new StreamWriter(Console.OpenStandardOutput());
        var foundWriter = new StreamWriter(foundStream);
        var notFoundWriter = new StreamWriter(notFoundStream);
        foundWriter.AutoFlush = true;
        notFoundWriter.AutoFlush = true;

        var pings = new List<string>();
        for (int i = 0; i <= num; i++)
        {
            var randSite = randSiteGenerator.RandomSite();
            var pinged = pinger.PingHost(randSite);
            
            if (!pings.Contains(randSite))
                pings.Add(randSite);
            else 
            {
                Console.SetOut(stdConsole);
                Console.WriteLine($"****************** Duplicate Random Site Skipped -> {randSite}");
                continue;
            }
            
            Console.SetOut(stdConsole);
                
            Console.WriteLine("[" + (i + 1) + " / " + num + "]" + "  " + randSite +
                              (pinged ? "**[Responded]**" : "[No Response]"));

            Console.SetOut(pinged ? foundWriter : notFoundWriter);
            Console.WriteLine(randSite);
        }
    }
}