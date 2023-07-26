// See https://aka.ms/new-console-template for more information

using System.Xml.Serialization;

delegate void LogDel(string text);

class Program
{
    static void Main(string[] args)
    {
        Log log = new Log();
        //LogDel logDel = new LogDel(log.LogPrint);
        //LogDel logDel2 = new LogDel(log.LogTextToFile);

        //logDel(name);
        //logDel2(name);

        //Multi LogDel
        LogDel logConsole, logFile;
        logConsole = new LogDel(log.LogPrint);
        logFile = new LogDel(log.LogTextToFile);
        LogDel multiLogDel = logConsole + logFile;

        string name = Console.ReadLine();

        //multiLogDel(name);
        //Passing delegate as a parameter
        LogText(multiLogDel, name);

        

        Console.ReadKey();
    }
    static void LogText(LogDel logDel, string text)
    {
        logDel(text);
    }
}

public class Log
{
    public void LogPrint(string text)
    {
        Console.WriteLine($"{DateTime.Now}: {text}");
    }

    public void LogTextToFile(string text)
    {
        using (StreamWriter sw = new StreamWriter(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Log.txt"), true))
        {
            sw.WriteLine($"{DateTime.Now}: {text}");
        }
    }

}