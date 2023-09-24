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

    public class OperationsController : ControllerBase
    {
        private readonly ApplicationDBContext _context;

        public OperationsController(ApplicationDBContext context)
        {
            _context = context;
        }



        [HttpGet]
        public async Task<ActionResult<IEnumerable<tblSQMS_Master_Operation>>> GetOperations()
        {
            return await _context.tblSQMS_Master_Operation.OrderBy(x => x.OperationName).ToListAsync();
        }



        //POST: api/Operations
        [HttpPost]
        public async Task<ActionResult<tblSQMS_Master_Machine_Opts>> CreateOperations(tblSQMS_Master_Operation  tblSQMSOperations)
        {
            try
            {
                _context.tblSQMS_Master_Operation.Add(tblSQMSOperations);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetOperations", new { id = tblSQMSOperations.Id }, tblSQMSOperations);

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error in Data Creation In Database");
            }
        }

        // GET: api/Operations/5
        [HttpGet("{pId}")]
        public async Task<ActionResult<tblSQMS_Master_Operation>> GetOperations(long pId)
        {
            var operations = await _context.tblSQMS_Master_Operation.FirstOrDefaultAsync(a => a.Id == pId);

            if (operations == null)
            {
                return NotFound();
            }

            return operations;
        }

        // PUT: api/Operations/5
        [HttpPut("{pId}")]
        public async Task<IActionResult> PutOperations(long pId, tblSQMS_Master_Operation  tblSQMSOperations)
        {
            if (pId != tblSQMSOperations.Id)
            {
                return BadRequest();
            }

            _context.Entry(tblSQMSOperations).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OperationExisit(pId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }

            }

            return CreatedAtAction("GetOperations", tblSQMSOperations);
        }

        private bool OperationExisit(long pId)
        {
            return _context.tblSQMS_Master_Operation.Any(e => e.Id == pId);
        }


        private bool checkOperationUses(string pOperation)
        {
            bool i = _context.tblSQMS_Fault_Gen_Categ.Any(e => e.Operation == pOperation );
            bool j = _context.tblSQMS_EndLine_Defects.Any(e => e.Operation == pOperation);
            bool k = _context.tblSQMS_Master_Machine_Opts.Any(e => e.OperationName == pOperation );
            bool l = _context.tblSQMS_InLine_Defects.Any(e => e.Operation == pOperation );


            if (i || j || k || l)
                return false;
            else
                return true;

        }



        [HttpDelete("{operationID}")]
        public async Task<bool> DeleteOperation(long operationID)
        {
            var operationDet = await _context.tblSQMS_Master_Operation.FindAsync(operationID);

            if (checkOperationUses(operationDet.OperationName))
            {
                _context.tblSQMS_Master_Operation.Remove(operationDet);
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
