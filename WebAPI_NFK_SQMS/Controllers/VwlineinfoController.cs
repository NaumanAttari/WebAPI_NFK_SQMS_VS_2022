using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using WebAPI_NFK_SQMS.DB_Context;
using DataAccessLayer.Models.MasterInfo;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using DataAccessLayer.Models;

namespace WebAPI_NFK_SQMS.Controllers
{
    [EnableCors("SiteCorsPolicy")]
    [Route("api/[controller]")]
    [ApiController]

    public class VwlineinfoController : ControllerBase
    {
        private readonly ApplicationDBContext _context;

        public VwlineinfoController(ApplicationDBContext context)
        {
            _context = context;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<vw_tblSQMS_Master_Line_Info>>> GetLineInfoDetail()
        {
            return await _context.vw_tblSQMS_Master_Line_Info.OrderByDescending(c=>c.Id).ToListAsync();
        }


        // GET: api/Cutting/CB-10001
        [HttpGet("{CBNO}")]
        public async Task<ActionResult<IEnumerable<vw_tblSQMS_Master_Line_Info>>> GetLineInfoDetailByID(long Id)
        {
            var LineInfo = await _context.vw_tblSQMS_Master_Line_Info.Where(a => a.Id == Id).ToListAsync();

            if (LineInfo == null)
            {
                return NotFound();
            }

            return LineInfo;
        }



    }
}
