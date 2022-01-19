using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Samsung.Web.Models;
using Samsung.Web.Areas.Admin.Models;

namespace Samsung.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class TeamController : Controller
    {
        private readonly ILogger<TeamController> _logger;

        public TeamController(ILogger<TeamController> logger)
        {
            _logger = logger;
        }

        public IActionResult GetTeamData()
        {
            var dataTableModel = new DataTablesAjaxRequestModel(Request);
            var model = new TeamListModel();
            var data = model.GetTeams(dataTableModel);
            return Json(data);
            //return Json(new TeamListModel().GetTeams(new DataTablesAjaxRequestModel(Request)));
        }

        public IActionResult Index()
        {
            return View(new TeamListModel());
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View(new CreateTeamModel());
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Create(CreateTeamModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    model.Create();
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "Failed to create Team");
                    _logger.LogError(ex, "Create Team Failed");
                }
            }

            return View(model);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var model = new EditTeamModel();
            model.LoadModelData(id);
            return View(model);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Edit(EditTeamModel model)
        {
            if (ModelState.IsValid)
            {
                model.Update();
            }

            return View(model);
        }

        public IActionResult Delete(int id)
        {
            var model = new TeamListModel();
            model.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
