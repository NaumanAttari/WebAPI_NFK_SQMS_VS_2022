using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccessLayer.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI_NFK_SQMS.DB_Context;

namespace WebAPI_NFK_SQMS.Controllers
{
    [EnableCors("SiteCorsPolicy")]
    [Route("api/[controller]")]
    [ApiController]
    public class CuttingController : ControllerBase
    {

        private readonly ApplicationDBContext _context;

        public CuttingController(ApplicationDBContext context)
        {
            _context = context;
        }

        //[HttpGet("x/{AB}")]
        //public string GetCBDetail( string AB)
        //{
        //    return "test SQMS = " + AB;
        //}

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ViewCuttingDetail>>> GetCBDetail()
        {
            return await _context.View_CuttingDetail.ToListAsync();
        }


        // GET: api/Cutting/CB-10001        
        [HttpGet("{CBNO}")]
        public async Task<ActionResult<IEnumerable<ViewCuttingDetail>>> GetCBDetailByID(string CBNo)
        {
            var cuttingDetail = await _context.View_CuttingDetail.Where(a => a.CBNo == CBNo).ToListAsync();

            if (cuttingDetail == null)
            {
                return NotFound();
            }

            return cuttingDetail;
        }



    }
}
