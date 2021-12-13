using System;

namespace Presentation
{
    internal static class ConsoleUtilities
    {
        internal static int AskCLIForInt(string ToConsole)
        {
            try
            {
                Console.WriteLine(ToConsole);
                return int.TryParse(Console.ReadLine(), out int value) ? value : -1;
            }
            catch (Exception e)
            {
                Console.WriteLine($"Exception in ConsoleUtilities/AskCLIForInt. ExceptionType = {e.GetType().FullName} ExceptionMessage = {e.Message}");
                return -1;
            }
        }

        internal static string AskCLIForString(string ToConsole)
        {
            try
            {
                Console.WriteLine(ToConsole);
                return Convert.ToString(Console.ReadLine());
            }
            catch (Exception e)
            {
                Console.WriteLine($"Exception in ConsoleUtilities/AskCLIForString. ExceptionType = {e.GetType().FullName} ExceptionMessage = {e.Message}");
                return "";
            }
        }
    }
}
