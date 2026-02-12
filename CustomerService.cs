using SQLapp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SQLapp {
	public class CustomerService {
		public static void ListCustomers() {
			using (var eHandel = new EHandelContext()) {
				var customers = eHandel.Customers.ToList();

				foreach (var c in customers)
					Console.WriteLine($"{c.Id} - {c.Name}");
			}
		}
	}
}
