using System.Security.Cryptography.X509Certificates;

public class Computer
{
    public string name;
    public double lastTimeConnected;
    public string server;
    public Computer(string name, double lastTimeConnected, string server) { this.name = name; this.lastTimeConnected = lastTimeConnected; this.server = server; }

    public void Print()
    {
        Console.WriteLine($"Computer: {name}  lastTimeConnected:  {lastTimeConnected} Server : {server}");
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        ;
        string directoryPath = "C:\\Users\\volfe\\Desktop\\andry";
        string[] files = Directory.GetFiles(directoryPath, "*.csv");




        List<Computer> servers = new List<Computer>()
        {
            /*
    new Computer("Desktop1", 25),
    new Computer("Desktop2", 200),
    new Computer("Desktop3", 1200),
    new Computer("Desktop3", 800),
    new Computer("Desktop4", 800),
    new Computer("Desktop4",1200),
    new Computer("Desktop4", 1500),
            */
        };

        foreach (string filePath in files)
        {
            string[] lines = File.ReadAllLines(filePath);

            for (int i = 1; i < lines.Length; i++)
            {
                string line = lines[i];

                string[] parts = line.Split(',');

                string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(filePath);
                Computer computer = new Computer(parts[0], Convert.ToInt32(parts[1]), fileNameWithoutExtension);



                servers.Add(computer);
            }
        }



        foreach (Computer computer in servers)
        {
            computer.Print();
        }



        /*
    double verylasttime =0;
    string name = "";

   
         List<Computer> disctinctcomputers = new List<Computer>()
        { };


  

   for ( int i=0; i < servers.Count; i++ )
   {
       for( int j = 0; j < servers.Count; j++ )
       {
           if (servers[i].name == servers[j].name)
           {

               if (servers[i].lastTimeConnected < servers[j].lastTimeConnected )
               {
                   if(verylasttime < servers[i].lastTimeConnected ) 
                   {
                       verylasttime = servers[i].lastTimeConnected;
                       name = servers[i].name;
                       disctinctcomputers.Add(new Computer(name, verylasttime));
                       //Console.WriteLine($" name{name } last time connection{verylasttime} ");   

                   }

               }

           }

       }
       int count = 0;
       for (int a = 0; a < servers.Count; a++)
       {
           for (int b = 0; b < servers.Count; b++)
           {
               if (servers[a].name == servers[b].name) 
               { 
                   count=count+1;
                   if(count==0)
                   { disctinctcomputers.Add(new Computer(servers[a].name, servers[a].lastTimeConnected)); }
               }
           }

       }



   }
   Console.WriteLine("Distinct");
   foreach (Computer computer in disctinctcomputers)
   {
       computer.Print();
   }
   */


        List<Computer> disctinctcomputers = servers
        .GroupBy(obj => obj.name)
        .Select(group => group.OrderBy(obj => obj.lastTimeConnected).First())
        .ToList();


        List<Computer> computerToRemove = servers.Except(disctinctcomputers).ToList();
        Console.WriteLine("Computers to be deleted");
        foreach (Computer computer in computerToRemove)
        {
            Console.Write("Kick off this computer:");
            computer.Print();


        }
        Console.WriteLine("Computers to be Alive");
        foreach (Computer computer in disctinctcomputers)
        {
            Console.Write("Live:");
            computer.Print();


        }


    }
}




