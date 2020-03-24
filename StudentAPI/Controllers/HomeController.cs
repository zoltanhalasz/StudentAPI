using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Highsoft.Web.Mvc.Charts;

namespace StudentAPI.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            List<double> marketingDepartmentCollection = new
            List<double>{ 49.9, 51.5, 32.0, 82.0, 75.0, 66.0, 32.0, 25.0, 35.4, 65.1, 58.6, 34.4 };
            List<double> CsDepartmentCollection = new List<double>{40.5, 34.5, 84.4, 39.2, 23.2, 45.0, 55.6, 18.5, 26.4, 14.1, 23.6, 84.4 };
            List<LineSeriesData> marketingData = new List<LineSeriesData>();
            List<LineSeriesData> CsData = new List<LineSeriesData>();
            marketingDepartmentCollection.ForEach(p => marketingData.Add( new LineSeriesData { Y = p }));
            CsDepartmentCollection.ForEach(p => CsData.Add( new LineSeriesData { Y = p }));
            ViewData["marketingData"] = marketingData;
            ViewData["CsData"] = CsData;
            return View();
        }

        public IActionResult GaugeChart()
        {
            List<GaugeSeriesData> gaugeData = new List<GaugeSeriesData>();
            gaugeData.Add(new GaugeSeriesData { Y = 60 });
            ViewData["gaugeData"] = gaugeData;
            return View();
        }

    }
}