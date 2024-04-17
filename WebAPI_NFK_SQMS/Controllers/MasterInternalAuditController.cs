using DataAccessLayer.Models.MasterInfo;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI_NFK_SQMS.DB_Context;

namespace WebAPI_NFK_SQMS.Controllers
{

    [EnableCors("SiteCorsPolicy")]
    [Route("api/[controller]")]
    [ApiController]

    public class MasterInternalAuditController : Controller
    {
        private readonly ApplicationDBContext _context;

        public MasterInternalAuditController(ApplicationDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<tblSQMS_Master_Internal_Audit>>> GetMasterInternalAudit()
        {
            var ab = "s";
            return await _context.tblSQMS_Master_Internal_Audit.OrderBy(x => x.Sort).ToListAsync();
        }


        [HttpPost]
        public async Task<ActionResult<tblSQMS_Master_Internal_Audit>> CreateFaults(tblSQMS_Master_Internal_Audit tblSQMSMasterInternalAudit)
        {
            try
            {
                _context.tblSQMS_Master_Internal_Audit.Add(tblSQMSMasterInternalAudit);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetMasterInternalAudit", new { id = tblSQMSMasterInternalAudit.Id }, tblSQMSMasterInternalAudit);

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error in Data Creation In Database");
            }
        }

        [HttpGet("{pId}")]
        public async Task<ActionResult<tblSQMS_Master_Internal_Audit>> GetMasterInternalAudit(long pId)
        {
            var masterInternalAudit = await _context.tblSQMS_Master_Internal_Audit.FirstOrDefaultAsync(a => a.Id == pId);

            if (masterInternalAudit == null)
            {
                return NotFound();
            }

            return masterInternalAudit;
        }


        [HttpPut("{pId}")]
        public async Task<IActionResult> PutFaults(long pId, tblSQMS_Master_Internal_Audit tblSQMSMasterInternalAudit)
        {
            if (pId != tblSQMSMasterInternalAudit.Id)
            {
                return BadRequest();
            }

            _context.Entry(tblSQMSMasterInternalAudit).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MasterInternalAuditExisit(pId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }

            }

            return CreatedAtAction("GetMasterInternalAudit", tblSQMSMasterInternalAudit);
        }

        private bool MasterInternalAuditExisit(long pId)
        {
            return _context.tblSQMS_Master_Internal_Audit.Any(e => e.Id == pId);
        }


        [HttpDelete("{MasterInternalAuditID}")]
        public async Task<bool> DeleteFault(long MasterInternalAuditID)
        {
            var masterInternalAuditDet = await _context.tblSQMS_Master_Internal_Audit.FindAsync(MasterInternalAuditID);

            //if (checkFaultUses(faultDet.Faults))
            {
                _context.tblSQMS_Master_Internal_Audit.Remove(masterInternalAuditDet);
                await _context.SaveChangesAsync();
                return true;
                //}
                //else
                //{
                //    return false;
                //}

            }
        }

    }  
}
