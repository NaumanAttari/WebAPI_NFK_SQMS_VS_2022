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

    public class MachineOptController : ControllerBase
    {
        private readonly ApplicationDBContext _context;


        public MachineOptController(ApplicationDBContext context)
        {
            _context = context;
        }



        [HttpGet]
        public async Task<ActionResult<IEnumerable<tblSQMS_Master_Machine_Opts>>> GetMachineOpt()
        {
            return await _context.tblSQMS_Master_Machine_Opts.OrderBy(x => x.OperatorName).ToListAsync();
        }

        //POST: api/MachineOpt
        [HttpPost]
        public async Task<ActionResult<tblSQMS_Master_Machine_Opts>> CreateMachineOpt(tblSQMS_Master_Machine_Opts tblSQMSMachineOpt)
        {
            try
            {
                _context.tblSQMS_Master_Machine_Opts.Add(tblSQMSMachineOpt);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetMachineOpt", new { id = tblSQMSMachineOpt.Id  }, tblSQMSMachineOpt);

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error in Data Creation In Database");
            }
        }

        // GET: api/MachineOpt/5
        [HttpGet("{pId}")]
        public async Task<ActionResult<tblSQMS_Master_Machine_Opts>> GetMachineOpt(long pId)
        {
            var machineOpt = await _context.tblSQMS_Master_Machine_Opts.FirstOrDefaultAsync(a => a.Id == pId);

            if (machineOpt == null)
            {
                return NotFound();
            }

            return machineOpt;
        }

        // PUT: api/MachineOpt/5
        [HttpPut("{pId}")]
        public async Task<IActionResult> PutMachineOpt(long pId, tblSQMS_Master_Machine_Opts tblSQMSMachineOpt)
        {
            if (pId != tblSQMSMachineOpt.Id)
            {
                return BadRequest();
            }

            _context.Entry(tblSQMSMachineOpt).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MachineOptExisit(pId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }

            }

            return CreatedAtAction("GetMachineOpt", tblSQMSMachineOpt);
        }

        private bool MachineOptExisit(long pId)
        {
            return _context.tblSQMS_Master_Machine_Opts.Any(e => e.Id == pId);
        }



        private bool checkWorkerUses(string pWorkerCardNo)
        {
            bool i = _context.tblSQMS_Fault_Gen_Categ.Any(e => e.CardNo == pWorkerCardNo);
            bool j = _context.tblSQMS_EndLine_Defects.Any(e => e.WorkerCardNo == pWorkerCardNo);

            if (i || j)
                return false;
            else
                return true;

        }



        [HttpDelete("{OptID}")]
        public async Task<bool> DeleteOpt(long OptID)
        {
            var optDet = await _context.tblSQMS_Master_Machine_Opts.FindAsync(OptID);

            if (checkWorkerUses(optDet.CardNo))
            {
                _context.tblSQMS_Master_Machine_Opts.Remove(optDet);
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
