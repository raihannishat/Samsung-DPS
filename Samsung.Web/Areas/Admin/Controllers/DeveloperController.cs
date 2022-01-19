using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Samsung.Web.Areas.Admin.Models;
using Samsung.Web.Models;

namespace Samsung.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DeveloperController : Controller
    {
        private readonly ILogger<DeveloperController> _logger;

        public DeveloperController(ILogger<DeveloperController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View(new DeveloperListModel());
        }

        public IActionResult GetDeveloperData()
        {
            return Json(new DeveloperListModel().GetDevelopers(new DataTablesAjaxRequestModel(Request)));
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View(new CreateDeveloperModel());
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Create(CreateDeveloperModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    model.Create();
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "Failed to create Developer");
                    _logger.LogError(ex, "Create Developer Failed");
                }
            }

            return View(model);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var model = new EditDeveloperModel();
            model.LoadModelData(id);
            return View(model);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Edit(EditDeveloperModel model)
        {
            if (ModelState.IsValid)
            {
                model.Update();
            }

            return View(model);
        }

        public IActionResult Delete(int id)
        {
            var model = new DeveloperListModel();
            model.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
