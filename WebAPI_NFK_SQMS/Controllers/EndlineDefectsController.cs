using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using WebAPI_NFK_SQMS.DB_Context;
using DataAccessLayer.Models.MasterInfo;
using DataAccessLayer.Models.Transactions;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;

namespace WebAPI_NFK_SQMS.Controllers
{
    [EnableCors("SiteCorsPolicy")]
    [Route("api/[controller]")]
    [ApiController]

    public class EndlineDefectsController : ControllerBase
    {
        private readonly ApplicationDBContext _context;

        public EndlineDefectsController(ApplicationDBContext context)
        {
            _context = context;

        }



        [HttpGet]
        public async Task<ActionResult<IEnumerable<tblSQMS_EndLine_Defects>>> GetEndlineDefects()
        {
            return await _context.tblSQMS_EndLine_Defects.ToListAsync();
        }

        // GET: api/EndlineDefects/CBNo/CB-0000
        [HttpGet("CBNo/{pCBNo}")]
        public async Task<ActionResult<IEnumerable<tblSQMS_EndLine_Defects>>> GetEndlineDefectsbyCBNO(string pCBNo)
        {
            return await _context.tblSQMS_EndLine_Defects.Where(a=> a.CBNo == pCBNo).ToListAsync();
        }


        //public async Task<ActionResult> PostPODetail([FromBody] List<PODetail> poDetail)
        //{
        //    _ = _context.INVENTORY_PO_DETAIL.AddRangeAsync(poDetail);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetPODetail", poDetail);
        //}


        //POST: api/EndlineDefects
        [HttpPost]
        public async Task<ActionResult<tblSQMS_EndLine_Defects>> CreateEndLineDefects(tblSQMS_EndLine_Defects tblSQMS_EndLine_Defects)
        {
            try
            {
                _context.tblSQMS_EndLine_Defects.Add(tblSQMS_EndLine_Defects);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetEndlineDefects", new { id = tblSQMS_EndLine_Defects.Id }, tblSQMS_EndLine_Defects);

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error in Data Creation In Database");
            }
        }

        // GET: api/EndlineDefects/5
        [HttpGet("{pId}")]
        public async Task<ActionResult<tblSQMS_EndLine_Defects>> GetEndlineDefects(long pId)
        {
            var floors = await _context.tblSQMS_EndLine_Defects.FirstOrDefaultAsync(a => a.Id == pId);

            if (floors == null)
            {
                return NotFound();
            }

            return floors;
        }

        // PUT: api/EndlineDefects/5
        [HttpPut("{pId}")]
        public async Task<IActionResult> PutEndLineDefects(long pId, tblSQMS_EndLine_Defects tblSQMS_EndLine_Defects)
        {
            if (pId != tblSQMS_EndLine_Defects.Id)
            {
                return BadRequest();
            }

            _context.Entry(tblSQMS_EndLine_Defects).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EndlineDefectsExisit(pId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }

            }

            return CreatedAtAction("GetEndlineDefects", tblSQMS_EndLine_Defects);
        }

        private bool EndlineDefectsExisit(long pId)
        {
            return _context.tblSQMS_EndLine_Defects.Any(e => e.Id == pId);
        }
    }
}
