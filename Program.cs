using Spectre.Console;
using System.Drawing;

namespace SQLapp {
    internal class Program {
        static void Main(string[] args) {

            while (true) {
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

                try {
                    switch (choice) {
                        case "List Customers":
                            CustomerService.ListCustomers();
                            break;

                        case "List Products":
                            ProductService.ListProducts();
                            break;

                        case "Add Product To Order":
                            ProductService.AddProductToOrder();
                            break;

                        case "Create Order":
                            OrderService.CreateOrder();
                            break;

                        case "Update Order":
                            OrderService.UpdateOrder();
                            break;

                        case "Delete Order":
                            OrderService.DeleteOrder();
                            break;

                        case "Reports":
							string report = AnsiConsole.Prompt(
					            new SelectionPrompt<string>()
						            .Title("Reports: ")
						            .AddChoices("Total sales per order", "Top selling products", "Top customers"));
                            switch (report) {
                                case "Total sales per order":
                                    ReportService.TotalSalesPerOrder();
                                    break;
                                case "Top selling products":
                                    ReportService.TopSellingProducts();
                                    break;
                                case "Top customers":
                                    ReportService.TopCustomers();
                                    break;
							}
							break;

                        case "Exit":
                            return;
                    }
                }

                catch (Exception ex) {
                    AnsiConsole.MarkupLine($"[red]Fel: {ex.Message}[/]");
                }

				AnsiConsole.MarkupLine("\nTryck valfri tangent...");
                Console.ReadKey();
			}
        }
    }
}
