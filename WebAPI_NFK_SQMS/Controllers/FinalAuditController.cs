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

    public class FinalAuditController : Controller
    {
        private readonly ApplicationDBContext _context;

        public FinalAuditController(ApplicationDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<tblSQMS_FinalAudit_Info>>> GetFinalAuditInfo()
        {
            return await _context.tblSQMS_FinalAudit_Info.ToListAsync();
        }

        //POST: api/FinalAudit
        [HttpPost]
        public async Task<ActionResult<tblSQMS_FinalAudit_Info>> CreateFinalAudit_Info(tblSQMS_FinalAudit_Info tblSQMS_FinalAudit_Info)
        {
            try
            {
                _context.tblSQMS_FinalAudit_Info.Add(tblSQMS_FinalAudit_Info);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetFinalAuditInfo", new { id = tblSQMS_FinalAudit_Info.Id }, tblSQMS_FinalAudit_Info);

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error in Data Creation In Database");
            }
        }


        // GET: api/FinalAudit/5
        [HttpGet("{pId}")]
        public async Task<ActionResult<tblSQMS_FinalAudit_Info>> GetFinalAuditInfo(long pId)
        {
            var finalAuditInfo = await _context.tblSQMS_FinalAudit_Info.FirstOrDefaultAsync(a => a.Id == pId);

            if (finalAuditInfo == null)
            {
                return NotFound();
            }

            return finalAuditInfo;
        }


        // PUT: api/FinalAudit/5
        [HttpPut("{pId}")]
        public async Task<IActionResult> PutFinalAuditInfo(long pId, tblSQMS_FinalAudit_Info tblSQMS_FinalAudit_Infos)
        {
            if (pId != tblSQMS_FinalAudit_Infos.Id)
            {
                return BadRequest();
            }

            _context.Entry(tblSQMS_FinalAudit_Infos).State = EntityState.Unchanged;            
            _context.Entry(tblSQMS_FinalAudit_Infos).Property(x => x.MajorPcs).IsModified = true;
            _context.Entry(tblSQMS_FinalAudit_Infos).Property(x => x.MinorPcs).IsModified = true;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FinalAuditInfoExisit(pId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }

            }

            return CreatedAtAction("GetFinalAuditInfo", tblSQMS_FinalAudit_Infos);
        }








        private bool FinalAuditInfoExisit(long pId)
        {
            return _context.tblSQMS_FinalAudit_Info.Any(e => e.Id == pId);
        }




    }
}
