using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BSNTools.Web.API.Controllers
{
    [Route("api/docs")]
    [ApiController]
    public class DocsController : ControllerBase
    {
        // GET: api/<DocsController>
        [HttpGet]
        [Route("GetDoc/{fileName}")]
        public string GetDoc(string fileName)
        {
           return System.IO.File.ReadAllText("Assets/Docs/" + fileName);
        }

        [HttpGet]
        [Route("GetAllDocs")]
        public IEnumerable<string> GetAllDocs()
        {
            return Directory.GetFiles("Assets/Docs/", "*.md").Select(i => Path.GetFileName(i));
        }
    }
}
