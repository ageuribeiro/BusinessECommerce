using System;

namespace BusinessECommerce.Orchestration
{
    internal static class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                string nameRPA = args.Length > 0 ? args[0] : "AutomationWeb";
                Console.WriteLine($"Starting RPA process: {nameRPA}");
                // Additional logic for the RPA process can be added here
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }
}