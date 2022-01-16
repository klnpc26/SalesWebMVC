using Microsoft.AspNetCore.Mvc;
using SalesWebMVC.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesWebMVC.Controllers
{
    public class SalesRecordsController : Controller
    {
        private readonly SalesRecordsService _salesRecordsService;

        public SalesRecordsController(SalesRecordsService salesRecordsService)
        {
            _salesRecordsService = salesRecordsService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> SimpleSearch(DateTime? dtStart, DateTime? dtEnd)
        {
            if (!dtStart.HasValue)
            {
                dtStart = DateTime.Now.AddDays(-1);
            }

            if (!dtEnd.HasValue)
            {
                dtEnd = DateTime.Now;
            }

            ViewData["dtStart"] = dtStart.Value.ToString("yyyy-MM-dd");
            ViewData["dtEnd"] = dtEnd.Value.ToString("yyyy-MM-dd");

            var result = await _salesRecordsService.FindByDateAsync(dtStart, dtEnd);

            return View(result);
        }

        public async Task<IActionResult> GroupingSearch(DateTime? dtStart, DateTime? dtEnd)
        {
            if (!dtStart.HasValue)
            {
                dtStart = DateTime.Now.AddDays(-1);
            }

            if (!dtEnd.HasValue)
            {
                dtEnd = DateTime.Now;
            }

            ViewData["dtStart"] = dtStart.Value.ToString("yyyy-MM-dd");
            ViewData["dtEnd"] = dtEnd.Value.ToString("yyyy-MM-dd");

            var result = await _salesRecordsService.FindByDateGroupingAsync(dtStart, dtEnd);

            return View(result);
        }
    }
}
