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
    public class BookController : Controller
    {
            private readonly ILogger<BookController> _logger;

            public BookController(ILogger<BookController> logger)
            {
                _logger = logger;
            }
            public IActionResult Index()
            {
                var model = new BookListModel();
                return View(model);

            }

            public JsonResult GetJsonResult()
            {
                var tableModel = new DataTablesAjaxRequestModel(Request);
                var model = new BookListModel();
                var data = model.getBooks(tableModel);

                return Json(data);

            }

            public IActionResult Create()
            {
                var model = new CreateBookModel();
                return View(model);

            }
            [HttpPost, ValidateAntiForgeryToken]
            public IActionResult Create(CreateBookModel model)
            {
                if (ModelState.IsValid)
                {
                    try
                    {
                        model.createBook();
                    }
                    catch (Exception ex)
                    {
                        ModelState.AddModelError("", "failed to create new book");
                        _logger.LogError(ex, "failed to create book");

                    }
                }
                return View(model);

            }

            public IActionResult Delete(int id)
            {
                var model = new BookListModel();

                model.deleteBook(id);

                return RedirectToAction(nameof(Index));

            }
            public IActionResult Edit(int id)
            {
                var model = new EditBookModel();

                model.LoadModelData(id);

                return View(model);

            }
            [HttpPost, ValidateAntiForgeryToken]
            public IActionResult Edit(EditBookModel model)
            {
                if (ModelState.IsValid)

                {
                    try
                    {
                        model.updateBook();
                    }

                    catch (Exception ex)
                    {
                        ModelState.AddModelError("", "fail to update book");
                        _logger.LogError(ex, "fail to update book");

                    }
                }
                return RedirectToAction(nameof(Index));

            }
        }
}
