﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineShoppingStore.Domain.Abstract;

namespace OnlineShoppingStore.WebUI.Controllers
{
    public class NavController : Controller
    {
        private IProductRepository repository;

        public NavController(IProductRepository rep)
        {
            repository = rep;
        }
        public PartialViewResult Menu(string category=null)
        {
            ViewBag.SelectedCategory = category;
            IEnumerable<string> categories = repository.Products
                                            .Select(p => p.Category)
                                            .Distinct()
                                            .OrderBy(x => x);
            return PartialView(categories);
        }
	}
}