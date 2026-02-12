using Spectre.Console;
using SQLapp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SQLapp {
	internal class ProductService {
		public static void ListProducts() {
			using (var eHandel = new EHandelContext()) {
				var products = eHandel.Products.ToList();

				foreach (var p in products)
					Console.WriteLine($"{p.Id} - {p.Name} - {p.Price} kr");
			}
		}

		public static void AddProductToOrder() {
			using (var eHandel = new EHandelContext()) {
				Console.Write("Order Id: ");
				if (!int.TryParse(Console.ReadLine(), out int orderId)) {
					Console.WriteLine("Felaktigt ID.");
					return;
				}

				Console.Write("Product Id: ");
				if (!int.TryParse(Console.ReadLine(), out int productId)) {
					Console.WriteLine("Felaktigt ID.");
					return;
				}

				Console.Write("Quantity: ");
				if (!int.TryParse(Console.ReadLine(), out int quant) || quant <= 0)
					quant = 1;

				var order = eHandel.Orders.Find(orderId);
				var product = eHandel.Products.Find(productId);

				if (order == null || product == null) {
					Console.WriteLine("Order eller Product finns inte.");
					return;
				}

				var orderItem = new OrderItem {
					OrderId = orderId,
					ProductId = productId,
					Quant = quant
				};

				eHandel.OrderItems.Add(orderItem);
				eHandel.SaveChanges();

				Console.WriteLine("Produkt tillagd!");

				if (AnsiConsole.Confirm("Add more?"))
					AddProductToOrder();
			}
		}
	}
}
