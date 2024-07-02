using System.IO;

namespace Program
{
    class Program
    {
        public static void tree(string directoryToScan, string working2, string resp)
        {
            string[] allFolders = Directory.GetDirectories(directoryToScan);
            string[] allFiles = Directory.GetFiles(directoryToScan);
            foreach (string file in allFiles) 
            {
                if (!file.Contains(working2))
                {
                    if (file.EndsWith(".fasta") || file.EndsWith(".fa"))
                    {
                        bool a = file.Equals(working2);
                        if (!a)
                        {
                            string h = File.ReadAllText(file);
                            string cleaned = h.TrimEnd('\r', '\n');
                            File.AppendAllText(working2, cleaned + Environment.NewLine);
                        }
                        Console.WriteLine("Completed directory " + file);
                    }
                }
                else
                {
                    Console.WriteLine("Skipped directory " + working2);
                }
            }
            foreach (string folder in allFolders)
            {
                tree(folder, working2, resp);
            }
        }
        public static void Main()
        {
            Console.WriteLine("What do you want your end file to be named? Do not include file extensions.");
            string resp = Console.ReadLine();
            while (resp != null)
            {
                Console.WriteLine("In what directory do you want to scan?");
                string working = Console.ReadLine();
                while (working != null)
                {
                    Directory.SetCurrentDirectory(working);
                    string working2 = working + "\\combex\\" + resp + ".fa";
                    if (!File.Exists(working2))
                    {
                        if (!Directory.Exists(working + "\\combex\\"))
                        {
                            Directory.CreateDirectory(working + "\\combex\\");
                        }
                        var i = File.Create(working2);
                        i.Close();
                    }
                    tree(working, working2, resp);
                    Console.WriteLine("All directories completed.");
                    break;
                }
                break;
            }

        }
    }
}
