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


    public class InitfaultsController : ControllerBase
    {
        private readonly ApplicationDBContext _context;

        public InitfaultsController(ApplicationDBContext context)
        {
            _context = context;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<tblSQMS_Master_Init_Faults>>> GetInitFaults()
        {
            return await _context.tblSQMS_Master_Init_Faults.ToListAsync();
        }



        //POST: api/Operations
        [HttpPost]
        public async Task<ActionResult<tblSQMS_Master_Init_Faults>> CreateRounds(tblSQMS_Master_Init_Faults tblSQMSInitFaults)
        {
            try
            {
                _context.tblSQMS_Master_Init_Faults.Add(tblSQMSInitFaults);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetInitFaults", new { id = tblSQMSInitFaults.Id }, tblSQMSInitFaults);

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error in Data Creation In Database");
            }
        }

        // GET: api/Operations/5
        [HttpGet("{pId}")]
        public async Task<ActionResult<tblSQMS_Master_Init_Faults>> GetInitFaults(long pId)
        {
            var initfaults = await _context.tblSQMS_Master_Init_Faults.FirstOrDefaultAsync(a => a.Id == pId);

            if (initfaults == null)
            {
                return NotFound();
            }

            return initfaults;
        }

        // PUT: api/Operations/5
        [HttpPut("{pId}")]
        public async Task<IActionResult> PutInitFaults(long pId, tblSQMS_Master_Init_Faults tblSQMSInitFaults)
        {
            if (pId != tblSQMSInitFaults.Id)
            {
                return BadRequest();
            }

            _context.Entry(tblSQMSInitFaults).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InitFaultsExisit(pId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }

            }

            return CreatedAtAction("GetInitFaults", tblSQMSInitFaults);
        }

        private bool InitFaultsExisit(long pId)
        {
            return _context.tblSQMS_Master_Init_Faults.Any(e => e.Id == pId);
        }


        private bool checkInitFaultUses(string pinitFault)
        {
            bool i = _context.tblSQMS_Fault_Gen_Categ.Any(e => e.InitChkPoints == pinitFault);
            
            if (i)
                return false;
            else
                return true;

        }



        [HttpDelete("{initfaultID}")]
        public async Task<bool> DeleteInitFault(long initfaultID)
        {
            var initfaultDet = await _context.tblSQMS_Master_Init_Faults.FindAsync(initfaultID);

            if (checkInitFaultUses(initfaultDet.InitChkPoints))
            {
                _context.tblSQMS_Master_Init_Faults.Remove(initfaultDet);
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
