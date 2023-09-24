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

namespace WebAPI_NFK_SQMS.Controllers
{

    [EnableCors("SiteCorsPolicy")]
    [Route("api/[controller]")]
    [ApiController]

    public class LineinfoController : ControllerBase
    {

        private readonly ApplicationDBContext _context;

        public LineinfoController(ApplicationDBContext context)
        {
            _context = context;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<tblSQMS_Master_Line_Info>>> GetLineInfo()
        {
            return await _context.tblSQMS_Master_Line_Info.ToListAsync();
        }



        //POST: api/Operations
        [HttpPost]
        public async Task<ActionResult<tblSQMS_Master_Line_Info>> CreateLineInfo(tblSQMS_Master_Line_Info tblSQMSLineInfo)
        {
            try
            {
                _context.tblSQMS_Master_Line_Info.Add(tblSQMSLineInfo);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetLineInfo", new { id = tblSQMSLineInfo.Id }, tblSQMSLineInfo);

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error in Data Creation In Database");
            }
        }

        // GET: api/Operations/5
        [HttpGet("{pId}")]
        public async Task<ActionResult<tblSQMS_Master_Line_Info>> GetLineInfo(long pId)
        {
            var faults = await _context.tblSQMS_Master_Line_Info.FirstOrDefaultAsync(a => a.Id == pId);

            if (faults == null)
            {
                return NotFound();
            }

            return faults;
        }

        // PUT: api/Operations/5
        [HttpPut("{pId}")]
        public async Task<IActionResult> PutFaults(long pId, tblSQMS_Master_Line_Info tblSQMSLineInfo)
        {
            if (pId != tblSQMSLineInfo.Id)
            {
                return BadRequest();
            }

            _context.Entry(tblSQMSLineInfo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LineinfoExisit(pId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }

            }

            return CreatedAtAction("GetLineInfo", tblSQMSLineInfo);
        }

        private bool LineinfoExisit(long pId)
        {
            return _context.tblSQMS_Master_Line_Info.Any(e => e.Id == pId);
        }


    }
}
