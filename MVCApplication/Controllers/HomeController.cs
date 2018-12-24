using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MVCApplication.Models;
using MVCApplication.ViewModels;

namespace MVCApplication.Controllers
{
  
    public class HomeController : Controller
    {
        static public Dictionary<string, string> TheDictionary = new Dictionary<string, string>();

        public IActionResult Index()
        {
            
        IndexViewModel indexViewModel = new IndexViewModel();

            return View(indexViewModel);
        }

        [HttpGet]
        public IActionResult Result()
        {
            if(TheDictionary.Count > 0) { 
            ResultViewModel resultViewModel = new ResultViewModel();

                resultViewModel.TheDictionary = TheDictionary;

                return View(resultViewModel);
            }

            else
            {
                return Redirect("/");
            }
        }

        [HttpPost]
        public IActionResult Result(ResultViewModel resultViewModel)

        {
            if (ModelState.IsValid)
            {

                TheDictionary.Add(resultViewModel.NewElement1, resultViewModel.NewElement2);

                resultViewModel.TheDictionary = TheDictionary;

                return View(resultViewModel);
            }

            return Redirect("/");

        }

        [HttpGet]
        public IActionResult Remove()
        {
            if (TheDictionary.Count > 0)
            {
                RemoveViewModel removeViewModel = new RemoveViewModel();

                removeViewModel.TheDictionary = TheDictionary;

                return View(removeViewModel);
            }

            else
            {
                return Redirect("/");
            }
        }

        [HttpPost]
        public IActionResult Remove(RemoveViewModel removeViewModel)

        {
            if (ModelState.IsValid)
            {

                TheDictionary.Remove(removeViewModel.NewElement1);

                removeViewModel.TheDictionary = TheDictionary;

                return View(removeViewModel);
            }

            return Redirect("/");

        }


    }



}
