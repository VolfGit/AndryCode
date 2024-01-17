public class Computer
{
    public string name;
    public int lastTimeConnected;

    public Computer(string n, int time) { name = n; lastTimeConnected = time; }

    public void Print()
    {
        Console.WriteLine($"Computer: {name}  :lastTimeConnected {lastTimeConnected}");
    }
}

public class Program
{
    public static void Main(string[] args)
    {

        List<Computer> servers = new List<Computer>()
           {
   new Computer("Desktop1", 25),
    new Computer("Desktop2", 200),
    new Computer("Desktop3", 1200),
    new Computer("Desktop3", 800),
    new Computer("Desktop4", 800),
    new Computer("Desktop4",1200),
    new Computer("Desktop4", 1500),
           };

        foreach (Computer computer in servers)
        {
            computer.Print();
        } 



       
           double thresholdTime = 1000.00;



        List<Computer> computerToRemove = servers
.Where(obj => obj.lastTimeConnected >= thresholdTime && servers.Count(o => o.name == obj.name) > 1)
.ToList();


        foreach (Computer computer in computerToRemove)
        {
            Console.Write("Kick off this computer:");
            computer.Print();
            
           
        }

            
    }
}




