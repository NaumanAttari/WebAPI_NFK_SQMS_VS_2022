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

    public class VwCBDetController : ControllerBase
    {
        private readonly ApplicationDBContextERP _context;

        public VwCBDetController(ApplicationDBContextERP context)
        {
            _context = context;
        }


        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<vw_CB_Detail>>> GetCBDet()
        //{
        //    return await _context.vw_CB_Detail.ToListAsync();
        //}


        // GET: api/Cutting/CB-10001
        [HttpGet("{CBNO}")]
        public async Task<ActionResult<IEnumerable<vw_CB_Detail>>> GetLineInfoDetailByID(string CBNo)
        {
            var LineInfo = await _context.vw_CB_Detail.Where(a => a.CBNo == CBNo).ToListAsync();

            if (LineInfo == null)
            {
                return NotFound();
            }

            return LineInfo;
        }


    }
}
