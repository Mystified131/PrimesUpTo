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

        public IActionResult Index()
        {
            IndexViewModel indexViewModel = new IndexViewModel();

            return View(indexViewModel);
        }

        public IActionResult Error()
        {

            return View();
        }

        public IActionResult Result()
        {
            ResultViewModel resultViewModel = new ResultViewModel();

            resultViewModel.Error = "To test a new number, please return to the 'Input' page.";

            return View(resultViewModel);
        }

        [HttpPost]
        public IActionResult Result(ResultViewModel resultViewModel)

        {
            if (ModelState.IsValid)


            {

                resultViewModel.State = true;
                List<int> Answer = new List<int>();

                for (int j = 0; j <= resultViewModel.Numin; j++)
                {

                    bool Ans = true;

                    if  ((j > 2) && (j % 2 == 0))
                    {

                        Ans = false;

                    }

                    var boundary = (int)Math.Floor(Math.Sqrt(j));

                    for (int i = 3; i <= boundary; i += 2)
                        if (j % i == 0)
                        {
                            Ans = false;
                        }

                    

                    if (Ans == true)
                    {
                        Answer.Add(j);
                        Answer.Remove(1);
                        Answer.Remove(0);
                        if (Answer.Count == resultViewModel.Numlim)
                        {
                            resultViewModel.Answer = Answer;
                            return View(resultViewModel);

                        }

                    }

                }

                Answer.Remove(1);
                Answer.Remove(0);
                resultViewModel.Answer = Answer;
                return View(resultViewModel);
            }


            return Redirect("/Home/Error");

        }

    }

}

