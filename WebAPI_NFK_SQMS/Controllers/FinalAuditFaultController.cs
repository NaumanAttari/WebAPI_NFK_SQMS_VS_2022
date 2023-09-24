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

    public class FinalAuditFaultController : Controller
    {
        private readonly ApplicationDBContext _context;

        public FinalAuditFaultController(ApplicationDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<tblSQMS_FinalAudit_Defects>>> GetFinalAuditFaultInfo()
        {
            return await _context.tblSQMS_FinalAudit_Defects.ToListAsync();
        }

        //POST: api/FinalAuditFault
        [HttpPost]
        public async Task<ActionResult> CreateFinalAuditFault_Info([FromBody] List<tblSQMS_FinalAudit_Defects> FinalAuditFaultDetail)
        {
            _ = _context.tblSQMS_FinalAudit_Defects.AddRangeAsync(FinalAuditFaultDetail);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFinalAuditFaultInfo", FinalAuditFaultDetail);
        }

        //public async Task<ActionResult<tblSQMS_FinalAudit_Defects>> CreateFinalAuditFault_Info(tblSQMS_FinalAudit_Defects tblSQMS_FinalAudit_Defects)
        //{
        //    try
        //    {
        //        _context.tblSQMS_FinalAudit_Defects.Add(tblSQMS_FinalAudit_Defects);
        //        await _context.SaveChangesAsync();

        //        return CreatedAtAction("GetFinalAuditFaultInfo", new { id = tblSQMS_FinalAudit_Defects.Id }, tblSQMS_FinalAudit_Defects);

        //    }
        //    catch (Exception)
        //    {
        //        return StatusCode(StatusCodes.Status500InternalServerError,
        //            "Error in Data Creation In Database");
        //    }
        //}





        // GET: api/FinalAuditFault/5
        [HttpGet("{pId}")]
        public async Task<ActionResult<tblSQMS_FinalAudit_Defects>> GetFinalAuditFaultInfo(long pId)
        {
            var FinalAuditFaultInfo = await _context.tblSQMS_FinalAudit_Defects.FirstOrDefaultAsync(a => a.Id == pId);

            if (FinalAuditFaultInfo == null)
            {
                return NotFound();
            }

            return FinalAuditFaultInfo;
        }

        // GET: api/FinalAuditFault/masterId/5
        [HttpGet("masterId/{pId}")]
        public async Task<ActionResult<IEnumerable<tblSQMS_FinalAudit_Defects>>> GetFinalAuditFaultInfo_WithMasterId(long pId)
        {
            var GetFinalAuditFaultInfo_WithMasterId = await _context.tblSQMS_FinalAudit_Defects.Where(a => a.MasterId == pId).ToListAsync();

            if (GetFinalAuditFaultInfo_WithMasterId == null)
            {
                return NotFound();
            }

            return GetFinalAuditFaultInfo_WithMasterId;
        }


        // PUT: api/FinalAuditFault/5
        [HttpPut("{pId}")]
        public async Task<IActionResult> PutEndLineInfo(long pId, tblSQMS_FinalAudit_Defects tblSQMS_FinalAudit_Defects)
        {
            if (pId != tblSQMS_FinalAudit_Defects.Id)
            {
                return BadRequest();
            }

            _context.Entry(tblSQMS_FinalAudit_Defects).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FinalAuditFaultInfoExisit(pId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }

            }

            return CreatedAtAction("GetFinalAuditFaultInfo", tblSQMS_FinalAudit_Defects);
        }








        private bool FinalAuditFaultInfoExisit(long pId)
        {
            return _context.tblSQMS_FinalAudit_Defects.Any(e => e.Id == pId);
        }




    }
}
