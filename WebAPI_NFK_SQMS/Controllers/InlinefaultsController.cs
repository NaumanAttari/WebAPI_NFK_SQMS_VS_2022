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

    public class InlinefaultsController : ControllerBase
    {
        private readonly ApplicationDBContext _context;

        public InlinefaultsController(ApplicationDBContext context)
        {
            _context = context;

        }



        [HttpGet]
        public async Task<ActionResult<IEnumerable<tblSQMS_InLine_Defects>>> GetInlineDefects()
        {
            return await _context.tblSQMS_InLine_Defects.ToListAsync();
        }


        //public async Task<ActionResult> PostPODetail([FromBody] List<PODetail> poDetail)
        //{
        //    _ = _context.INVENTORY_PO_DETAIL.AddRangeAsync(poDetail);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetPODetail", poDetail);
        //}


        //POST: api/Faultgencat
        [HttpPost]
        public async Task<ActionResult<tblSQMS_InLine_Defects>> CreateInLineDefects(tblSQMS_InLine_Defects tblSQMSInlineDefects)
        {
            try
            {
                _context.tblSQMS_InLine_Defects.Add(tblSQMSInlineDefects);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetInlineDefects", new { id = tblSQMSInlineDefects.Id }, tblSQMSInlineDefects);

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error in Data Creation In Database");
            }
        }

        // GET: api/Faultgencat/5
        [HttpGet("{pId}")]
        public async Task<ActionResult<tblSQMS_InLine_Defects>> GetInlineDefects(long pId)
        {
            var floors = await _context.tblSQMS_InLine_Defects.FirstOrDefaultAsync(a => a.Id == pId);

            if (floors == null)
            {
                return NotFound();
            }

            return floors;
        }

        // PUT: api/Faultgencat/5
        [HttpPut("{pId}")]
        public async Task<IActionResult> PutFaultGenCat(long pId, tblSQMS_InLine_Defects tblSQMSInlineDefects)
        {
            if (pId != tblSQMSInlineDefects.Id)
            {
                return BadRequest();
            }

            _context.Entry(tblSQMSInlineDefects).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FaultGenCatExisit(pId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }

            }

            return CreatedAtAction("GetInlineDefects", tblSQMSInlineDefects);
        }

        private bool FaultGenCatExisit(long pId)
        {
            return _context.tblSQMS_InLine_Defects.Any(e => e.Id == pId);
        }
    }
}
