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

        public ViewResult List(string category,int page=1)
        {
            ProductsListViewModel model = new ProductsListViewModel
            {
                Products=repository.Products
                       .Where(p=>category==null || p.Category==category)
                       .OrderBy(p=>p.ProductID)
                       .Skip((page-1)*pageSize)
                       .Take(pageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage=page,
                    ItemsPerPage=pageSize,
                    TotalItems=category==null?
                                        repository.Products.Count():
                                        repository.Products.Where(p=>p.Category==category).Count()
                },
                CurrentCategory=category
            };
            return View(model);
        }
	}
}