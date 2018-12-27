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
        static public string edit;
        static public string editval;
        static public string Searchstr;
        static public string Bridgeelement1;
        static public string Bridgeelement2;

        public IActionResult Index()
        {

            IndexViewModel indexViewModel = new IndexViewModel();

            return View(indexViewModel);
        }

        public IActionResult Error()
        {

            return View();
        }


        [HttpGet]
        public IActionResult Result()
        {
            if (TheDictionary.Count > 0)
            {
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

                TheDictionary.Add(resultViewModel.NewElement1.ToLower(), resultViewModel.NewElement2.ToLower());

                resultViewModel.TheDictionary = TheDictionary;

                return View(resultViewModel);
            }

            return Redirect("/Home/Error");

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

                return Redirect("/Home/Result");
            }

            return Redirect("/Home/Error");

        }

        [HttpGet]
        public IActionResult EditSelect()
        {
            if (TheDictionary.Count > 0)
            {
                EditSelectViewModel editSelectViewModel = new EditSelectViewModel();

                editSelectViewModel.TheDictionary = TheDictionary;

                return View(editSelectViewModel);
            }

            else
            {
                return Redirect("/");
            }
        }


        [HttpPost]
        public IActionResult EditSelect(EditSelectViewModel editSelectViewModel)
        {

            if (ModelState.IsValid)
            {

                edit = editSelectViewModel.NewElement1;
                editval = TheDictionary[edit];
                ViewBag.value = editval;
                Bridgeelement1 = editSelectViewModel.NewElement1;
                Bridgeelement2 = editval;
                TheDictionary.Remove(editSelectViewModel.NewElement1);

                return View("EditItem");
            }

            return Redirect("/Home/Error");

        }


        [HttpGet]
        public IActionResult EditItem()
        {
            if (TheDictionary.Count > 0)
            {

                EditItemViewModel editItemViewModel = new EditItemViewModel();

                return View(editItemViewModel);
            }

            else
            {
                return Redirect("/");
            }
        }

        [HttpPost]
        public IActionResult EditItem(EditItemViewModel editItemViewModel)

        {
            if (ModelState.IsValid)

            {


                TheDictionary.Add(edit, editItemViewModel.NewElement2);

                return Redirect("/Home/Result");
            }

            TheDictionary.Add(Bridgeelement1, Bridgeelement2);
            return Redirect("/Home/Error");

        }

        [HttpGet]
        public IActionResult SearchSelect()
        {
            if (TheDictionary.Count > 0)
            {
                SearchSelectViewModel searchSelectViewModel = new SearchSelectViewModel();

                return View(searchSelectViewModel);
            }

            else
            {
                return Redirect("/");
            }
        }

        [HttpPost]
        public IActionResult SearchSelect(SearchSelectViewModel searchSelectViewModel)

        {
            if (ModelState.IsValid)

            {
                Searchstr = searchSelectViewModel.Searchstr;
                return Redirect("/Home/SearchResult");
            }

            return Redirect("/Home/Error");

        }

        [HttpGet]
        public IActionResult SearchResult()
        {
            if (TheDictionary.Count > 0)
            {
                SearchResultViewModel searchResultViewModel = new SearchResultViewModel();

                var Anslist = TheDictionary.Where(c => c.Value.Contains(Searchstr.ToLower()));

                ViewBag.Anslist = Anslist;

                return View(searchResultViewModel);
            }

            else
            {
                return Redirect("/");
            }
        }

    }

}
