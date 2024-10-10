using System;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public enum LogLevel { Warning, Info, Error }

public class Logger
{
    private Logger() { }
    private static Logger Instance()


    private static Logger GetInstance()
    {
        if (instance != null)
            return instance;

        return new Logger();
    }
    public void Log(string message, LogLevel level)
    {
        switch (level)
        {
            case LogLevel.Warning:
                Console.WriteLine("{0}: {1}" + level, message);
                break;
            case LogLevel.Info:
                Console.WriteLine("{0}: {1}" + level, message);
                break;
            case LogLevel.Error:
                Console.WriteLine("{0}: {1}" + level, message);
                break;
        }
    }
}

public Log(string message, LogLevel level)


internal class Program
{
    static void Main(string[] args)
    {
        Logger logger = Logger.GetInstance();
        logger.Log("", LogLevel.Warning);
    }
}