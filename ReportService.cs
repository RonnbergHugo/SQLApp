using SQLapp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SQLapp {
	internal class ReportService {
		public static void TotalSalesPerOrder() {
			using (var eHandel = new EHandelContext()) {
				var report = eHandel.Orders
					.Select(o => new {
						o.Id,
						Total = o.OrderItems
							.Sum(oi => oi.Quant * oi.Product.Price)
					})
					.ToList();

				foreach (var r in report)
					Console.WriteLine($"Order {r.Id} - Total: {r.Total} kr");
			}
		}

		public static void TopSellingProducts() {
			using (var eHandel = new EHandelContext()) {
				var report = eHandel.OrderItems
					.GroupBy(oi => oi.Product.Name)
					.Select(g => new {
						Product = g.Key,
						TotalSold = g.Sum(x => x.Quant)
					})
					.OrderByDescending(x => x.TotalSold)
					.ToList();

				foreach (var r in report)
					Console.WriteLine($"{r.Product} - {r.TotalSold} sålda");
			}
		}

		public static void TopCustomers() {
			using (var eHandel = new EHandelContext()) {
				var report = eHandel.Orders
					.GroupBy(o => o.Customer.Name)
					.Select(g => new {
						Customer = g.Key,
						OrderCount = g.Count()
					})
					.OrderByDescending(x => x.OrderCount)
					.ToList();

				foreach (var r in report)
					Console.WriteLine($"{r.Customer} - {r.OrderCount} orders");
			}
		}
	}
}
