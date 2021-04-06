using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Sample.Core.interfaces;
using Sample.Core.interfaces.dto;
using Sample.WebMVC.Command;
using Sample.WebMVC.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Sample.WebMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private ITimeRecordingUseCase TimeRecordingUseCase { get; }

        public HomeController(ITimeRecordingUseCase timeRecordingUseCase, ILogger<HomeController> logger)
        {
            this.TimeRecordingUseCase = timeRecordingUseCase;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Index()
        {
            IReadOnlyList<DailyTimeRecordDto> listDailyTimeRecord = this.TimeRecordingUseCase.ListDailyRecord();

            return View(listDailyTimeRecord);
        }

        [HttpPost]
        public IActionResult Edit(DailyTimeRecordEditCommand dailyTimeRecordEditCommand)
        {
            // TODO: Update Domain
            return Ok();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
