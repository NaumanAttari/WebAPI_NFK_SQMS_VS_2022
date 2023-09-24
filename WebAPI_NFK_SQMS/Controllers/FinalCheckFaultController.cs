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
    public class FinalCheckFaultController : Controller
    {
        private readonly ApplicationDBContext _context;
        public FinalCheckFaultController(ApplicationDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<tblSQMS_FinalCheck_Defects>>> GetFinalCheckFault()
        {
            return await _context.tblSQMS_FinalCheck_Defects.ToListAsync();
        }



        //POST: api/FinalCheck
        [HttpPost]
        public async Task<ActionResult<tblSQMS_FinalCheck_Defects>> CreateFinalCheck_Fault(tblSQMS_FinalCheck_Defects tblSQMS_FinalCheck_Defects)
        {
            try
            {
                _context.tblSQMS_FinalCheck_Defects.Add(tblSQMS_FinalCheck_Defects);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetFinalCheckFault", new { id = tblSQMS_FinalCheck_Defects.Id }, tblSQMS_FinalCheck_Defects);

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error in Data Creation In Database");
            }
        }


        // GET: api/FinalCheck/5
        [HttpGet("{pId}")]
        public async Task<ActionResult<tblSQMS_FinalCheck_Defects>> GetFinalCheckFault(long pId)
        {
            var finalCheckFault = await _context.tblSQMS_FinalCheck_Defects.FirstOrDefaultAsync(a => a.Id == pId);

            if (finalCheckFault == null)
            {
                return NotFound();
            }

            return finalCheckFault;
        }



        // PUT: api/FinalCheck/5
        [HttpPut("{pId}")]
        public async Task<IActionResult> PutFinalCheckFault(long pId, tblSQMS_FinalCheck_Defects tblSQMS_FinalCheck_Defects)
        {
            if (pId != tblSQMS_FinalCheck_Defects.Id)
            {
                return BadRequest();
            }

            _context.Entry(tblSQMS_FinalCheck_Defects).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FinalCheckFaultExisit(pId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }

            }

            return CreatedAtAction("GetFinalCheckFault", tblSQMS_FinalCheck_Defects);
        }


        private bool FinalCheckFaultExisit(long pId)
        {
            return _context.tblSQMS_FinalCheck_Defects.Any(e => e.Id == pId);
        }




    }
}
