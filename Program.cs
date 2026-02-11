using Spectre.Console;
using System.Drawing;

namespace SQLapp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            AnsiConsole.Clear();
            AnsiConsole.Write(new FigletText("Store DB App").Centered().Color(Spectre.Console.Color.Green));

            var choice = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title("[yellow]Välj ett alternativ[/]")
                    .AddChoices(new[]
                    {
                        "List Customers",
                        "List Products",
                        "Add Product To Order",
                        "Create Order",
                        "Update Order",
                        "Delete Order",
                        "Reports",
                        "Exit"
                    }));
            try
            {
                switch (choice)
                {
                    case "List Customers":
                        break;

                    case "List Products":
                        break;

                    case "Add Product To Order":
                        break;

                    case "Create Order":
                        break;

                    case "Update Order":
                        break;

                    case "Delete Order":
                        break;

                    case "Reports":
                        break;

                    case "Exit":
                        return;
                }
            }

            catch (Exception ex)
            {
                AnsiConsole.MarkupLine($"[red]Fel: {ex.Message}[/]");
            }

            AnsiConsole.MarkupLine("\nTryck valfri tangent...");
            Console.ReadKey();
        }
    }
}
