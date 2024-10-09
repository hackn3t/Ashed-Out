Ashed-Out
Overview
Ashed-Out is a simple console application designed to help users gradually quit smoking by tracking their daily cigarette consumption and implementing a tapering strategy. The application provides a user-friendly interface to log cigarettes smoked, view current settings, and adjust those settings as needed.

Features
Log Cigarettes: Easily log the number of cigarettes smoked each day.
Daily Limit: Set and adjust a daily limit on cigarette consumption to aid in tapering down.
Tapering Strategy: Automatically decreases the daily limit over time, encouraging users to reduce their intake gradually.
Settings Management: Load and save user settings, including daily limits and tapering intervals, using JSON file storage.
Progress Tracking: Visualize progress with a dynamic progress bar indicating how many cigarettes have been smoked against the daily limit.
Getting Started
Prerequisites
.NET Core SDK (version 5.0 or later)
Newtonsoft.Json NuGet package
Installation
Clone the repository to your local machine using the following command:

bash
Copy code
git clone https://github.com/yourusername/ashed-out.git
Navigate to the project directory:

bash
Copy code
cd ashed-out
Install the required packages:

bash
Copy code
dotnet add package Newtonsoft.Json
Build the project:

bash
Copy code
dotnet build
Run the application:

bash
Copy code
dotnet run
Usage
Once the application is running, you will see a menu with the following options:

Log a Cigarette: Increase the count of cigarettes smoked for the day.
Show Settings: Display current settings, including daily limit, taper interval, and last taper date.
Change Settings: Update your daily limit and taper interval.
Exit: Save your settings and exit the application.
Example Workflow
Start the application and review the initial settings.
Adjust the daily limit and taper interval if necessary.
Log each cigarette smoked throughout the day.
Monitor progress toward your smoking reduction goals via the progress bar.
Save settings upon exiting to retain information for the next session.
Code Structure
The main components of the application include:

![002](https://github.com/user-attachments/assets/0f7eb74d-e7c5-4344-8023-171cd8573aaf)
![001](https://github.com/user-attachments/assets/b421ff20-acea-4294-b65a-5a116e1db585)

Program.cs: Contains the core functionality and user interface.
Settings Class: Represents the user settings, including daily limit, cigarettes smoked, taper interval, and last taper date.
Methods:
DisplayBanner(): Shows the application banner and information.
DisplayMenu(): Renders the main menu.
LogCigarette(): Increments the cigarette count and checks against the daily limit.
ShowSettings(): Displays the current settings.
ChangeSettings(): Allows users to update their settings.
LoadSettings(): Loads user settings from a JSON file.
SaveSettings(): Saves user settings to a JSON file.
InitializeDefaults(): Initializes default settings if no previous settings exist.
CheckTaper(): Adjusts the daily limit based on the taper interval.
Contributing
Contributions are welcome! If you have suggestions for improvements or new features, feel free to fork the repository and submit a pull request.

License
This project is open-source and available under the MIT License.

Author
TommyCh0ng (Tommy McLoughlin)
Email: ThomasPMcLoughlin@gmail.com
Feel free to use this code for whatever you want!

