using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using WebAPI_NFK_SQMS.DB_Context;
using DataAccessLayer.Models.Transactions;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using System.Data;
using Microsoft.Data.SqlClient;

namespace WebAPI_NFK_SQMS.Controllers
{
    [EnableCors("SiteCorsPolicy")]
    [Route("api/[controller]")]
    [ApiController]

    public class FinalCheckController : Controller
    {
        private readonly ApplicationDBContext _context;

        public FinalCheckController(ApplicationDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<tblSQMS_FinalCheck_Info>>> GetFinalCheckInfo()
        {
            return await _context.tblSQMS_FinalCheck_Info.ToListAsync();
        }

        //POST: api/FinalCheck
        [HttpPost]
        public async Task<ActionResult<tblSQMS_FinalCheck_Info>> CreateFinalCheck_Info(tblSQMS_FinalCheck_Info tblSQMS_FinalCheck_Info)
        {
            try
            {
                _context.tblSQMS_FinalCheck_Info.Add(tblSQMS_FinalCheck_Info);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetFinalCheckInfo", new { id = tblSQMS_FinalCheck_Info.Id }, tblSQMS_FinalCheck_Info);

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error in Data Creation In Database");
            }
        }


        // GET: api/FinalCheck/5
        [HttpGet("{pId}")]
        public async Task<ActionResult<tblSQMS_FinalCheck_Info>> GetFinalCheckInfo(long pId)
        {
            var finalCheckInfo = await _context.tblSQMS_FinalCheck_Info.FirstOrDefaultAsync(a => a.Id == pId);

            if (finalCheckInfo == null)
            {
                return NotFound();
            }

            return finalCheckInfo;
        }


        // PUT: api/FinalCheck/5
        [HttpPut("{pId}")]
        public async Task<IActionResult> PutEndLineInfo(long pId, tblSQMS_FinalCheck_Info tblSQMS_FinalCheck_Info)
        {
            if (pId != tblSQMS_FinalCheck_Info.Id)
            {
                return BadRequest();
            }

            _context.Entry(tblSQMS_FinalCheck_Info).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FinalCheckInfoExisit(pId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }

            }

            return CreatedAtAction("GetFinalCheckInfo", tblSQMS_FinalCheck_Info);
        }








        private bool FinalCheckInfoExisit(long pId)
        {
            return _context.tblSQMS_FinalCheck_Info.Any(e => e.Id == pId);
        }




    }
}
