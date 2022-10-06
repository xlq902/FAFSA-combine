// Created by Eric Yang for the University of Connecticut, 2022

using System.IO;

string working = "C:\\Users\\tetrg\\OneDrive\\Documents\\Personal\\Marine Research\\Rhoptry Proteins\\ROP18";
Directory.SetCurrentDirectory(working);
string[] dirs = Directory.GetDirectories(working);

if (!File.Exists(working + "\\combex\\" + "compfa-ROP18.fasta"))
{
    var i = File.Create(working + "\\combex\\" + "compfa-ROP18.fasta");
    i.Close();
}

foreach (string dir in dirs)
{
    try
    {
        Directory.SetCurrentDirectory(dir);
        string[] dirs2 = Directory.GetFiles(dir);

        foreach (string dir2 in dirs2)
        {
            if (dir2.EndsWith(".fasta") || dir2.EndsWith(".fa"))
            {
                bool a = dir2.Equals(working + "\\combex\\" + "compfa-ROP18.fasta");
                if (!a)
                {
                    string h = File.ReadAllText(dir2);
                    string cleaned = h.TrimEnd('\r', '\n');
                    File.AppendAllText(working + "\\combex\\" + "compfa-ROP18.fasta", cleaned + Environment.NewLine);
                }
                Console.WriteLine("Completed directory " + dir);
            }
        }
    }
    catch
    {
        Console.WriteLine("Unknown error occurred in directory " + dir);
    }
}

Console.WriteLine("All directories completed.");