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

    public class FinalAuditFaultImageController : Controller
    {
        private readonly ApplicationDBContext _context;

        public FinalAuditFaultImageController(ApplicationDBContext context)
        {
            _context = context;
        }         

        //POST: api/FinalAuditFaultImage
        [HttpPost]
        public async Task<ActionResult<tblSQMS_FinalAudit_Defect_Images>> CreateFinalAudit_FaultImage(tblSQMS_FinalAudit_Defect_Images tblSQMS_FinalAudit_Defect_Images)
        {
            try
            {
                _context.tblSQMS_FinalAudit_Defect_Images.Add(tblSQMS_FinalAudit_Defect_Images);
                await _context.SaveChangesAsync();

                return CreatedAtAction("CreateFinalAudit_FaultImage", new { id = tblSQMS_FinalAudit_Defect_Images.Id }, tblSQMS_FinalAudit_Defect_Images);

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error in Data Creation In Database");
            }
        }
    }
}
