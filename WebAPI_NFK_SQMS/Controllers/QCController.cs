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

    public class QCController : Controller
    {
        private readonly ApplicationDBContext _context;

        public QCController(ApplicationDBContext context)
        {
            _context = context;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<tblSQMS_Master_QC>>> GetQC()
        {
            return await _context.tblSQMS_Master_QC.OrderBy(x=>x.QCName).ToListAsync();
        }



        //POST: api/Operations
        [HttpPost]
        public async Task<ActionResult<tblSQMS_Master_QC>> CreateOperations(tblSQMS_Master_QC tblSQMSQC)
        {
            try
            {
                _context.tblSQMS_Master_QC.Add(tblSQMSQC);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetQC", new { id = tblSQMSQC.Id }, tblSQMSQC);

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error in Data Creation In Database");
            }
        }

        // GET: api/Operations/5
        [HttpGet("{pId}")]
        public async Task<ActionResult<tblSQMS_Master_QC>> GetQC(long pId)
        {
            var QCs = await _context.tblSQMS_Master_QC.FirstOrDefaultAsync(a => a.Id == pId);

            if (QCs == null)
            {
                return NotFound();
            }

            return QCs;
        }

        // PUT: api/Operations/5
        [HttpPut("{pId}")]
        public async Task<IActionResult> PutQC(long pId, tblSQMS_Master_QC tblSQMSQC)
        {
            if (pId != tblSQMSQC.Id)
            {
                return BadRequest();
            }

            _context.Entry(tblSQMSQC).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!QCExisit(pId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }

            }

            return CreatedAtAction("GetQC", tblSQMSQC);
        }

        private bool QCExisit(long pId)
        {
            return _context.tblSQMS_Master_QC.Any(e => e.Id == pId);
        }



        private bool checkQCNameUses(string pQCCardNo)
        {
            bool i = _context.tblSQMS_Fault_Gen_Categ.Any(e => e.QCCardNo == pQCCardNo);
            bool j = _context.tblSQMS_Endline_Info.Any(e => e.QCCardNo == pQCCardNo);
            bool k = _context.tblSQMS_EndLine_Defects.Any(e => e.QCCardNo == pQCCardNo);

            if (i || j || k)
                return false;
            else
                return true;

        }



        [HttpDelete("{QCId}")]
        public async Task<bool> DeleteQC(long QCId)
        {
            var qcDet = await _context.tblSQMS_Master_QC.FindAsync(QCId);

            if (checkQCNameUses(qcDet.QCCardNo))
            {
                _context.tblSQMS_Master_QC.Remove(qcDet);
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
