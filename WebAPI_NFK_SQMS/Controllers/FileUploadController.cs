using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using WebAPI_NFK_SQMS.DB_Context;
using DataAccessLayer.Models;
using DataAccessLayer.Models.MasterInfo;
using DataAccessLayer.Models.Transactions;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using System.IO;
using System;
using System.Threading.Tasks;

namespace WebAPI_NFK_SQMS.Controllers
{
    [EnableCors("SiteCorsPolicy")]
    [Route("api/[controller]")]
    [ApiController]
    public class FileUploadController : Controller
    {
        [HttpPost]
        public ActionResult Post([FromForm] FileModel file)
        {
            try
            {
                //Directory.GetCurrentDirectory()
                string path = Path.Combine("E:", "faultimages", file.FileName);
                //string path = Path.Combine("D:", "faultimages", file.FileName);             

                using (Stream stream = new FileStream(path, FileMode.Create))
                {
                    file.FormFile.CopyTo(stream);
                }
                return Ok(path);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }


        [HttpPost("UploadSpecImages")]
        public ActionResult UploadSpecImages([FromForm] FileModel file)
        {
            try
            {
                //Directory.GetCurrentDirectory()
                string path = Path.Combine("E:", "specimages", file.FileName);
                //string path = Path.Combine("D:", "specimages", file.FileName);

                using (Stream stream = new FileStream(path, FileMode.Create))
                {
                    file.FormFile.CopyTo(stream);
                }
                return Ok(path);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

    }
}
