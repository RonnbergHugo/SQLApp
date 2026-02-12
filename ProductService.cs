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
	}
}
