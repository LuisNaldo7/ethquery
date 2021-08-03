using System;

public static class Helper
{
    public static void PrintErr(string errDesc, Exception ex)
    {
        string message = errDesc + Environment.NewLine + ex.ToString();
        Console.WriteLine(message);
    }
}