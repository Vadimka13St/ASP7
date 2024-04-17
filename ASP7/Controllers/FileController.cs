
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace ASP7.Controllers
{
    public class FileController : Controller
    {
        public IActionResult DownloadFile()
        {
            return View();
        }

        [HttpPost]
        public IActionResult DownloadFile(string firstName, string fileName)
        {
            var content = $"Enter name and Surname: {firstName}\n";
            var byteArray = Encoding.UTF8.GetBytes(content);
            var stream = new MemoryStream(byteArray);

            if (string.IsNullOrEmpty(fileName))
            {
                fileName = "default.txt";
            }
            else if (!fileName.EndsWith(".txt"))
            {
                fileName += ".txt";
            }

            return File(stream, "text/plain", fileName);
        }
    }
}
