using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using WebApiSaveImage.Models;

namespace WebApiSaveImage.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeopleController : ControllerBase
    {
        private MyDbContext _context;

        public PeopleController(MyDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Person>> Get()
        {
            return _context.Persons;
        }

        [HttpPost]
        public IActionResult Post()
        {
            var data = HttpContext.Request.Form;
            var dic = Request.Form.ToDictionary(x => x.Key, x => x.Value.ToString());
            Person person = new Person();

            foreach (var kvp in data.Keys)
            {
                PropertyInfo pi =
                    person.GetType()
                        .GetProperty(kvp, BindingFlags.Public | BindingFlags.Instance);
                if (pi != null)
                {
                    pi.SetValue(person, dic[kvp], null);
                }
            }

            if (data.Files.Count > 0)
            {
                IFormFile img = data.Files[0];
                person.ImageName = img.FileName;
                string savePath = Path.Combine(Directory.GetCurrentDirectory(),
                    "wwwroot/images", person.ImageName);
                using (var fileStream = new FileStream(savePath, FileMode.Create))
                {
                    img.CopyTo(fileStream);
                }
            }

            _context.Persons.Add(person);
            _context.SaveChanges();

            return Ok(person);
        }
    }
}
