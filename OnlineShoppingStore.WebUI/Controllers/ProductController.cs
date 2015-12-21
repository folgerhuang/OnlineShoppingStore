using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineShoppingStore.Domain.Abstract;
using OnlineShoppingStore.WebUI.Models;


namespace OnlineShoppingStore.WebUI.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepository repository;
        private int pageSize = 4;
        public ProductController(IProductRepository repo)
        {
            repository = repo;
        }

        public ViewResult List(int page=1)
        {
            ProductsListViewModel model = new ProductsListViewModel
            {
                Products=repository.Products
                       .OrderBy(p=>p.ProductID)
                       .Skip((page-1)*pageSize)
                       .Take(pageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage=page,
                    ItemsPerPage=pageSize,
                    TotalItems=repository.Products.Count()
                }
            };
            return View(model);
        }
	}
}