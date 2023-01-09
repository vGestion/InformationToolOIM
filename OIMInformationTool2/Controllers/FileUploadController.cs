using Microsoft.AspNetCore.Mvc;
using OIMInformationTool2.Models;
using OIMInformationTool2.Utils;

namespace OIMInformationTool2.Controllers
{
    public class FileUploadController : Controller

    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost("FileUpload")]
        public async Task<IActionResult> Index(List<IFormFile> files)
        {
            var size = files.Sum(f => f.Length);
            var filePaths = new List<String>();

            foreach (var formFile in files)
            {
                if(formFile.Length > 0)
                {
                    var filePath = Path.Combine(Directory.GetCurrentDirectory(), formFile.FileName);
                    filePaths.Add(filePath);

                    using(var stream = new FileStream(filePath, FileMode.Create))
                    {                       
                        await formFile.CopyToAsync(stream);
                    }
                }
            }
            this.HttpContext.Session.SetString("archivo", filePaths[0]);

            return RedirectToAction("InsertFromExcel","Nominal");
        }
    }
}
