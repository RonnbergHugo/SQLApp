using SQLapp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SQLapp {
	internal class OrderService {
		public static void CreateOrder() {
			using (var eHandel = new EHandelContext()) {
				string address;

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

				Console.Write("Address: ");
				address = Console.ReadLine();

				if (string.IsNullOrWhiteSpace(address)) {
					Console.WriteLine("Felaktig address.");
					return;
				}

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

	}
}
