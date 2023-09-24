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

    public class FaultsController : ControllerBase 
    {
        private readonly ApplicationDBContext _context;

        public FaultsController(ApplicationDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<tblSQMS_Master_Faults>>> GetFaults()
        {
            return await _context.tblSQMS_Master_Faults.OrderBy(x=>x.Faults).ToListAsync();
        }



        //POST: api/Operations
        [HttpPost]
        public async Task<ActionResult<tblSQMS_Master_Faults>> CreateFaults(tblSQMS_Master_Faults tblSQMSFaults)
        {
            try
            {
                _context.tblSQMS_Master_Faults.Add(tblSQMSFaults);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetFaults", new { id = tblSQMSFaults.Id }, tblSQMSFaults);

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error in Data Creation In Database");
            }
        }

        // GET: api/Operations/5
        [HttpGet("{pId}")]
        public async Task<ActionResult<tblSQMS_Master_Faults>> GetFaults(long pId)
        {
            var faults = await _context.tblSQMS_Master_Faults.FirstOrDefaultAsync(a => a.Id == pId);

            if (faults == null)
            {
                return NotFound();
            }

            return faults;
        }

        // PUT: api/Operations/5
        [HttpPut("{pId}")]
        public async Task<IActionResult> PutFaults(long pId, tblSQMS_Master_Faults tblSQMSFaults)
        {
            if (pId != tblSQMSFaults.Id)
            {
                return BadRequest();
            }

            _context.Entry(tblSQMSFaults).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FaultsExisit(pId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }

            }

            return CreatedAtAction("GetFaults", tblSQMSFaults);
        }

        private bool FaultsExisit(long pId)
        {
            return _context.tblSQMS_Master_Faults.Any(e => e.Id == pId);
        }


        private bool checkFaultUses(string pFault)
        {
            bool i = _context.tblSQMS_InLine_Defects.Any(e => e.InlineFaults == pFault);
            bool j = _context.tblSQMS_EndLine_Defects.Any(e => e.EndLineFaults == pFault);


            if (i || j)
                return false;
            else
                return true;

        }



        [HttpDelete("{faultID}")]
        public async Task<bool> DeleteFault(long faultID)
        {
            var faultDet = await _context.tblSQMS_Master_Faults.FindAsync(faultID);

            if (checkFaultUses(faultDet.Faults))
            {
                _context.tblSQMS_Master_Faults.Remove(faultDet);
                await _context.SaveChangesAsync();
                return true;
            }
            else
            {
                return false;
            }

        }


    }
}
