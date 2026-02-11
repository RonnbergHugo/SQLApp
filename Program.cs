using Spectre.Console;
using System.Drawing;

namespace SQLapp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            AnsiConsole.Clear();
            AnsiConsole.Write(new FigletText("School App").Centered().Color(Spectre.Console.Color.Green));

            var choice = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title("[yellow]Välj ett alternativ[/]")
                    .AddChoices(new[]
                    {
                        "List Students",
                        "List Courses",
                        "Enroll Student",
                        "Create Submission",
                        "Update Grade",
                        "Delete Student",
                        "Reports",
                        "Exit"
                    }));

            switch (choice)
            {
                case "List Students":
                    break;

                case "List Courses":
                    break;

                case "Enroll Student":
                    break;

                case "Create Submission":
                    break;

                case "Update Grade":
                    break;

                case "Delete Student":
                    break;

                case "Reports":
                    break;

                case "Exit":
                    return;
            }

            AnsiConsole.MarkupLine("\n[grey]Tryck valfri tangent...[/]");
            Console.ReadKey();
        }
    }
}
