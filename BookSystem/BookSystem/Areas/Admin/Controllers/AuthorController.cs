using BookSystem.Areas.Admin.Models;
using BookSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookSystem.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AuthorController : Controller
    {
        private readonly ILogger<AuthorController> _logger;

        public AuthorController(ILogger<AuthorController> logger)
        {
            _logger = logger;
        }
        public IActionResult Index()
        {
            var model = new AuthorListModel();
            return View(model);

        }

        public JsonResult GetJsonResult()
        {
            var tableModel = new DataTablesAjaxRequestModel(Request);
            var model = new AuthorListModel();
            var data = model.getAuthors(tableModel);

            return Json(data);

        }

        public IActionResult Create()
        {
            var model = new CreateAuthorModel();
            return View(model);

        }
        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Create(CreateAuthorModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    model.createAuthor();
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "failed to create new author");
                    _logger.LogError(ex, "failed to create author");

                }
            }
            return View(model);

        }

        public IActionResult Delete(int id)
        {
            var model = new AuthorListModel();

            model.deleteAuthor(id);

            return RedirectToAction(nameof(Index));

        }
        public IActionResult Edit(int id)
        {
            var model = new EditAuthorModel();

            model.LoadModelData(id);

            return View(model);

        }
        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Edit(EditAuthorModel model)
        {
            if (ModelState.IsValid)

            {
                try
                {
                    model.updateAuthor();
                }

                catch (Exception ex)
                {
                    ModelState.AddModelError("", "fail to update author");
                    _logger.LogError(ex, "fail to update author");

                }
            }
            return RedirectToAction(nameof(Index));

        }
    }
}
