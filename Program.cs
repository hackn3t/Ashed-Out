/* Ashed-Out
 *  - A simple project to combat the nasty habbit!
 * 
 *  I wrote this for fun and to mess around with console colors!
 *  
 *  Author:             TommyCh0ng (A.K.A. Tommy McLoughlin)
 *  Author Email:       ThomasPMcLoughlin@gmail.com
 * 
 * You are free to use this code for whatever you want!
 * 
      ████████                                                                  
      ██▓▓    ██          ████████████████████████████                          
    ████████████████████████                          ██                        
    ██                    ██░░██████████████████████░░  ██      ██████          
    ██░░░░░░░░░░░░░░░░░░░░██░░██                  ████░░  ██  ██      ██        
    ██▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒██░░██░░████████████░░░░██░░██░░████░░░░████          
    ████████████████████████░░██░░▓▓▒▒▒▒▒▒▒▒▒▒██░░██░░  ████░░░░██              
        ██▓▓▒▒▒▒▒▒▒▒▒▒▒▒▒▒██░░██░░████████████░░░░██░░░░████░░░░░░██            
          ██▒▒▒▒▒▒▒▒▒▒▒▒▒▒██░░██░░░░░░░░░░░░░░░░░░██░░▒▒██░░██░░░░██            
            ████████████████░░██▒▒████████████▒▒▒▒██▒▒▒▒██▒▒░░██████            
                          ██░░██████[haKnet]████████████▒▒▒▒▒▒▓▓▓▓▓▓██          
                            ██▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒░░██▓▓▓▓██▓▓▓▓██        
                              ██████████████████████████░░██▓▓██░░██▓▓██        
                                  ██▒▒██  ██▒▒▒▒██  ██▒▒████▓▓▓▓██▓▓▓▓██        
                                  ██▒▒██  ██▒▒██    ██▒▒▒▒██▓▓▓▓▓▓▓▓▓▓▓▓██      
                                  ██░░░░████████████░░░░██  ██▓▓▓▓▓▓▓▓▓▓██      
                                    ██░░░░░░░░░░░░░░░░██    ██▓▓▓▓▓▓▓▓▓▓██      
                                      ████████████████      ██  ▓▓▓▓▓▓▓▓▓▓██    
                                                            ██  ▓▓▓▓██▓▓▓▓██    
                                                            ██  ▓▓██░░██▓▓██    
                                                            ██▓▓  ▓▓██▓▓▓▓██    
                                                            ██▓▓▓▓▓▓▓▓▓▓▓▓██    
                                                              ██▓▓▓▓▓▓▓▓██      
                                                                ████████    
 */

using System;
using System.IO;
using Newtonsoft.Json; // Requires the Newtonsoft.Json package

namespace QuitSmokingAppConsole
{
    class Program
    {
        static int dailyLimit;
        static int cigarettesSmokedToday;
        static int taperInterval;
        static DateTime lastTaperDate;
        static string settingsFile = "settings.json";

        static void Main(string[] args)
        {
            DisplayBanner(); // Display ASCII banner at startup
            LoadSettings();

            while (true)
            {
                Console.Clear();
                DisplayBanner(); // Display the banner at the top of the menu
                DisplayProgressBar(); // Display the progress bar here
                DisplayMenu(); // Display the menu

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        LogCigarette();
                        break;
                    case "2":
                        ShowSettings();
                        break;
                    case "3":
                        ChangeSettings();
                        break;
                    case "4":
                        Console.WriteLine("Exiting...");
                        SaveSettings();
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Press any key to try again.");
                        Console.ReadKey();
                        break;
                }
            }
        }

        static void DisplayBanner()
        {
            Console.Clear(); // Clear console before displaying banner
            Console.ForegroundColor = ConsoleColor.DarkCyan; // Set banner color
            Console.WriteLine("*******************************************************");
            Console.WriteLine("*          .--.   .----..-. .-..----..----.           *");
            Console.WriteLine("*         / {} \\ { {__  | {_} || {_  | {}  \\          *");
            Console.WriteLine("*        /  /\\  \\.-._} }| { } || {__ |     /          *");
            Console.WriteLine("*        `-'  `-'`----' `-' `-'`----'`----'           *");
            Console.WriteLine("*               .----. .-. .-. .---.                  *");
            Console.WriteLine("*              /  {}  \\| { } |{_   _}                 *");
            Console.WriteLine("*              \\      /| {_} |  | |                   *");
            Console.WriteLine("*               `----' `-----'  `-'                   *");
            Console.WriteLine("*                                                     *");
            Console.WriteLine("*=====================================================*");
            Console.Write("*        ");
            Console.ForegroundColor = ConsoleColor.DarkGray; // Set version color
            Console.Write("Version: ");
            Console.ForegroundColor = ConsoleColor.DarkYellow; // Set version number color
            Console.Write("1.0");
            Console.ForegroundColor = ConsoleColor.DarkGray; // Set author color
            Console.Write("       Author: ");
            Console.ForegroundColor = ConsoleColor.DarkYellow; // Set author name color
            Console.Write("TommyCh0ng");
            Console.ForegroundColor = ConsoleColor.DarkCyan; // Reset to DarkCyan before the asterisk
            Console.WriteLine("        *");
            Console.ForegroundColor = ConsoleColor.DarkCyan; // Set asterisks to DarkCyan
            Console.WriteLine("*=====================================================*");
            Console.ResetColor(); // Reset color back to default
        }

        static void DisplayMenu()
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan; // Menu title color
            Console.WriteLine("*=====================================================*");
            Console.Write("*            Cigarettes Smoked Today: "); // Use Write to stay on the same line
            Console.ForegroundColor = ConsoleColor.Red; // Set smoked cigarette count to Red
            Console.Write($"{cigarettesSmokedToday}"); // Use Write to print the count without a new line
            Console.ForegroundColor = ConsoleColor.DarkCyan; // Set asterisk color back to DarkCyan
            Console.WriteLine("               *"); // Complete the line with DarkCyan asterisk
            Console.ForegroundColor = ConsoleColor.DarkCyan; // Continue with DarkCyan for next line
            Console.WriteLine("*=====================================================*");

            // Menu options
            Console.ForegroundColor = ConsoleColor.Magenta; // Set color for the numbers
            Console.WriteLine("*     1. Log a Cigarette                              *");
            Console.WriteLine("*     2. Show settings                                *");
            Console.WriteLine("*     3. Change settings                              *");
            Console.WriteLine("*     4. Exit                                         *");
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("*=====================================================*");
            Console.ForegroundColor = ConsoleColor.Green; // Set color for "»»"
            Console.Write("»» "); // Display "»» "
            Console.ForegroundColor = ConsoleColor.DarkGray; // Set color for "Select Option:"
            Console.Write("Select Option: ");
            Console.ResetColor(); // Reset color back to default
        }

        static void LogCigarette()
        {
            if (cigarettesSmokedToday >= dailyLimit)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("[!!] You have reached your daily limit! [!!]");
            }
            else
            {
                cigarettesSmokedToday++;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("» Cigarette logged.");
            }
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine(" Press any key to continue... ");
            Console.ResetColor();
            Console.ReadKey();
        }

        static void ShowSettings()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("*====================[ Settings ]=====================*");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Green; // Set color for "»"
            Console.Write("» "); // Display "» "
            Console.ForegroundColor = ConsoleColor.DarkGray; // Set color for "Daily limit: "
            Console.Write("Daily limit: ");
            Console.ForegroundColor = ConsoleColor.Magenta; // Set color for "Daily limit" number
            Console.WriteLine($"{dailyLimit}"); // Display daily limit number

            Console.ForegroundColor = ConsoleColor.Green; // Set color for "»"
            Console.Write("» "); // Display "» "
            Console.ForegroundColor = ConsoleColor.DarkGray; // Set color for "Taper interval: "
            Console.Write("Taper interval (days): ");
            Console.ForegroundColor = ConsoleColor.Magenta; // Set color for "Taper interval" number
            Console.WriteLine($"{taperInterval}"); // Display taper interval

            Console.ForegroundColor = ConsoleColor.Green; // Set color for "»"
            Console.Write("» "); // Display "» "
            Console.ForegroundColor = ConsoleColor.DarkGray; // Set color for "Last taper date: "
            Console.Write("Last taper date: ");
            Console.ForegroundColor = ConsoleColor.Magenta; // Set color for "Last taper date" value
            Console.WriteLine($"{lastTaperDate.ToShortDateString()}"); // Display last taper date

            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine(" Press any key to continue... ");
            Console.ResetColor();
            Console.ReadKey();
        }

        static void ChangeSettings()
        {
            Console.Write("* Enter new daily limit: ");
            dailyLimit = int.Parse(Console.ReadLine());

            Console.Write("* Enter taper interval (in days): ");
            taperInterval = int.Parse(Console.ReadLine());

            lastTaperDate = DateTime.Now;

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("* Settings updated. Press any key to continue... *");
            Console.ResetColor();
            Console.ReadKey();
        }

        static void LoadSettings()
        {
            if (File.Exists(settingsFile))
            {
                try
                {
                    string json = File.ReadAllText(settingsFile);
                    var settings = JsonConvert.DeserializeObject<Settings>(json);
                    dailyLimit = settings.DailyLimit;
                    cigarettesSmokedToday = settings.CigarettesSmokedToday;
                    taperInterval = settings.TaperInterval;
                    lastTaperDate = settings.LastTaperDate;
                    Console.WriteLine("Settings loaded successfully.");
                }
                catch (Exception)
                {
                    Console.WriteLine("Failed to load settings. Using default values.");
                    InitializeDefaults();
                }
            }
            else
            {
                InitializeDefaults();
            }

            CheckTaper();
        }

        static void SaveSettings()
        {
            var settings = new Settings
            {
                DailyLimit = dailyLimit,
                CigarettesSmokedToday = cigarettesSmokedToday,
                TaperInterval = taperInterval,
                LastTaperDate = lastTaperDate
            };

            string json = JsonConvert.SerializeObject(settings, Formatting.Indented);
            File.WriteAllText(settingsFile, json);
        }

        static void InitializeDefaults()
        {
            dailyLimit = 10; // Default daily limit
            cigarettesSmokedToday = 0; // Default cigarettes smoked today
            taperInterval = 7; // Default taper interval
            lastTaperDate = DateTime.Now; // Set last taper date to today
        }

        static void CheckTaper()
        {
            if (DateTime.Now >= lastTaperDate.AddDays(taperInterval))
            {
                if (dailyLimit > 0)
                {
                    dailyLimit--; // Reduce daily limit
                    lastTaperDate = DateTime.Now; // Update last taper date
                    Console.WriteLine("Your daily limit has been decreased by 1.");
                }
            }
        }

        static void DisplayProgressBar()
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan; // Set color for the asterisk before "Progress:"
            Console.Write("*        Progress: "); // Display "Progress: " without brackets

            // Ensure we do not exceed the limits for calculations
            if (dailyLimit <= 0)
            {
                Console.WriteLine("Daily limit must be greater than 0.");
                return;
            }

            // Calculate the progress bar
            int barLength = 20; // Length of the progress bar
            int filledLength = (int)((float)cigarettesSmokedToday / dailyLimit * barLength); // Filled portion

            // Draw the filled and unfilled parts of the progress bar
            for (int i = 0; i < barLength; i++)
            {
                if (i < filledLength)
                {
                    Console.BackgroundColor = ConsoleColor.Green; // Set filled part color
                    Console.Write(" "); // Filled part
                }
                else
                {
                    Console.BackgroundColor = ConsoleColor.DarkGray; // Set unfilled part color
                    Console.Write(" "); // Unfilled part
                }
            }

            Console.ResetColor(); // Reset color back to default
            Console.ForegroundColor = ConsoleColor.DarkCyan; // Set color for the '*'
            Console.WriteLine($" {cigarettesSmokedToday}/{dailyLimit}          *"); // Display progress stats
            Console.ResetColor(); // Reset color back to default
        }
    }

    public class Settings
    {
        public int DailyLimit { get; set; }
        public int CigarettesSmokedToday { get; set; }
        public int TaperInterval { get; set; }
        public DateTime LastTaperDate { get; set; }
    }
}
