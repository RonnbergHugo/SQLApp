using Microsoft.IdentityModel.Tokens;
using Spectre.Console;
using SQLapp.Models;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace SQLapp {
	internal class OrderService {
		public static void getAddress(ref string s) {
			Console.Write("Address: ");

			s = Console.ReadLine();

			if (string.IsNullOrWhiteSpace(s))
				Console.WriteLine("Felaktig address.");
		}

		public static void CreateOrder() {
			string address = "";

			using (var eHandel = new EHandelContext()) {
				Console.Write("Customer Id: ");

				if (!int.TryParse(Console.ReadLine(), out int customerId)) {
					Console.WriteLine("Felaktigt ID.");
					return;
				}

				var customer = eHandel.Customers.Find(customerId);

				if (customer == null) {
					Console.WriteLine("Customer finns inte.");
					return;
				}

				OrderService.getAddress(ref address);

				if (address.IsNullOrEmpty())
					return;

				var order = new Order {
					CustomerId = customerId,
					Address = address,
					OrderDate = DateTime.Now,
				};

				eHandel.Orders.Add(order);
				eHandel.SaveChanges();

				Console.WriteLine("Order skapad!");
			}
		}

		public static void DeleteOrder() {
			using (var eHandel = new EHandelContext()) {
				Console.Write("Order Id att radera: ");

				if (!int.TryParse(Console.ReadLine(), out int id)) {
					Console.WriteLine("Felaktigt ID.");
					return;
				}

				var order = eHandel.Orders.Find(id);

				if (order == null) {
					Console.WriteLine("Order finns inte.");
					return;
				}

				eHandel.Orders.Remove(order);
				eHandel.SaveChanges();

				Console.WriteLine("Order raderad!");
			}
		}

		public static void UpdateOrder() {
			string address = "";
			int id;

			using (var eHandel = new EHandelContext()) {
				Console.Write("Order Id: ");

				if (!int.TryParse(Console.ReadLine(), out id)) {
					Console.WriteLine("Felaktigt ID.");
					return;
				}

				var order = eHandel.Orders.Find(id);

				if (order == null) {
					Console.WriteLine("Order finns inte.");
					return;
				}

				string choice = choice = AnsiConsole.Prompt(
					new SelectionPrompt<string>()
						.Title("Uppdatera: ")
						.AddChoices("Address", "Customer"));

				switch (choice) {
					case "Address":
						OrderService.getAddress(ref address);

						if (address.IsNullOrEmpty())
							return;
						order.Address = address;
						break;
					case "Customer":
						Console.Write("Customer Id: ");

						if (!int.TryParse(Console.ReadLine(), out id)) {
							Console.WriteLine("Felaktigt ID.");
							return;
						}
						if (!eHandel.Customers.Any(c => c.Id == id)) {
							Console.WriteLine("Customer finns inte.");
							return;
						}
						order.CustomerId = id;
						break;
				}

				eHandel.SaveChanges();

				Console.WriteLine("Status uppdaterad!");
			}
		}
	}
}
