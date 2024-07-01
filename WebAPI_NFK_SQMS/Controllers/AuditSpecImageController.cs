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

    public class AuditSpecImageController : Controller
    {
        private readonly ApplicationDBContext _context;

        public AuditSpecImageController(ApplicationDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<tblSQMS_Audit_Spec_Images>>> GetSpecImages()
        {
            return await _context.tblSQMS_Audit_Spec_Images.ToListAsync();
        }

        //POST: api/FinalAuditFaultImage
        [HttpPost]
        public async Task<ActionResult<tblSQMS_Audit_Spec_Images>> CreateAudit_SpecImage(tblSQMS_Audit_Spec_Images tblSQMS_Audit_Spec_Images)
        {
            try
            {
                _context.tblSQMS_Audit_Spec_Images.Add(tblSQMS_Audit_Spec_Images);
                await _context.SaveChangesAsync();

                return CreatedAtAction("CreateAudit_SpecImage", new { id = tblSQMS_Audit_Spec_Images.Id }, tblSQMS_Audit_Spec_Images);

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error in Data Creation In Database");
            }
        }
    }
}
