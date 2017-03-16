using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Montante;

namespace MVCLinearSystem.Controllers
{
    public class LinearSystemController : Controller
    {
        // GET: LinearSystem
        public ActionResult Index()
        {
            return View("Index");
        }

        [HttpPost]
        public ActionResult Index(MVCLinearSystem.Models.LinearSystemModel linearModel)
        {
            
            Montante.Montante solver = new Montante.Montante();
            double[,] input = new double[3, 4];
            input[0, 0] = linearModel.x1;
            input[0, 1] = linearModel.y1;
            input[0, 2] = linearModel.z1;
            input[0, 3] = linearModel.result1;
            input[1, 0] = linearModel.x2;
            input[1, 1] = linearModel.y2;
            input[1, 2] = linearModel.z2;
            input[1, 3] = linearModel.result2;
            input[2, 0] = linearModel.x3;
            input[2, 1] = linearModel.y3;
            input[2, 2] = linearModel.z3;
            input[2, 3] = linearModel.result3;

            double[] results = solver.SolveByMontante(input);

            linearModel.x = results[0];
            linearModel.y = results[1];
            linearModel.z = results[2];

            return View(linearModel);
        }
    }
}