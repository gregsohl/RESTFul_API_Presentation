using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

using WebApplication2.Models;

namespace WebApplication2.Controllers
{
	public class ProductsController : ApiController
	{
		readonly Product[] m_Products = new [] 
        { 
            new Product { Id = 1, Name = "Tomato Soup", Category = "Groceries", Price = 1 }, 
            new Product { Id = 2, Name = "Yo-yo", Category = "Toys", Price = 3.75M }, 
            new Product { Id = 3, Name = "Hammer", Category = "Hardware", Price = 16.99M }, 
            new Product { Id = 4, Name = "Hammer Drill", Category = "Hardware", Price = 247.99M } 
        };

		/// <summary>
		/// Gets all products.
		/// </summary>
		/// <remarks>
		/// http://server/api/Products
		/// </remarks>
		/// <returns></returns>
		public IEnumerable<Product> GetAllProducts()
		{
			return m_Products;
		}

		/// <summary>
		/// Gets the product by identifier.
		/// </summary>
		/// <param name="id">The identifier.</param>
		/// <remarks>
		/// http://server/api/Products/1
		/// </remarks>
		/// <returns></returns>
		public IHttpActionResult GetProductById(int id)
		{
			var product = m_Products.FirstOrDefault((p) => p.Id == id);
			if (product == null)
			{
				return NotFound();
			}
			return Ok(product);
		}

		/// <summary>
		/// Get a product by name
		/// </summary>
		/// <param name="name">The name.</param>
		/// <remarks>
		/// http://server/api/Products/Hammer
		/// </remarks>
		/// <returns></returns>
		public IHttpActionResult GetProductByName(string name)
		{
			IEnumerable<Product> filteredList = m_Products.Where(x => x.Name.StartsWith(name));
			
			if (filteredList.Any())
				return Ok(filteredList);

			return NotFound();
		}
	}
}
