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

    public class AuditMeasurementImageController : Controller
    {
        private readonly ApplicationDBContext _context;

        public AuditMeasurementImageController(ApplicationDBContext context)
        {
            _context = context;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<tblSQMS_Audit_Measurement_Images>>> GetMeasurementImages()
        {
            return await _context.tblSQMS_Audit_Measurement_Images.ToListAsync();
        }

        //POST: api/FinalAuditFaultImage
        [HttpPost]
        public async Task<ActionResult<tblSQMS_Audit_Measurement_Images>> CreateAudit_MeasurementImage(tblSQMS_Audit_Measurement_Images tblSQMS_Audit_Measurement_Images)
        {
            try
            {
                _context.tblSQMS_Audit_Measurement_Images.Add(tblSQMS_Audit_Measurement_Images);
                await _context.SaveChangesAsync();

                return CreatedAtAction("CreateAudit_MeasurementImage", new { id = tblSQMS_Audit_Measurement_Images.Id }, tblSQMS_Audit_Measurement_Images);

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error in Data Creation In Database");
            }
        }
    }
}
