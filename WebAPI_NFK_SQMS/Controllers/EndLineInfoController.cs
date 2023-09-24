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

    public class EndLineInfoController : ControllerBase
    {
        private readonly ApplicationDBContext _context;

        public EndLineInfoController(ApplicationDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<tblSQMS_Endline_Info>>> GetEndLineInfo()
        {
            return await _context.tblSQMS_Endline_Info.ToListAsync();
        }

        // GET: api/CBNo/CB-0000
        [HttpGet("CBNo/{pCBNo}")]
        public async Task<ActionResult<IEnumerable<tblSQMS_Endline_Info>>> GetEndLineInfoCBWise(string pCBNo)
        {
            return await _context.tblSQMS_Endline_Info.Where(a => a.CBNo == pCBNo).ToListAsync();
        }

        //POST: api/Operations
        [HttpPost]
        public async Task<ActionResult<tblSQMS_Endline_Info>> CreateEndLineInfo(tblSQMS_Endline_Info tblSQMS_Endline_Info)
        {
            try
            {
                _context.tblSQMS_Endline_Info.Add(tblSQMS_Endline_Info);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetEndLineInfo", new { id = tblSQMS_Endline_Info.Id }, tblSQMS_Endline_Info);

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error in Data Creation In Database");
            }
        }

        // GET: api/Operations/5
        [HttpGet("{pId}")]
        public async Task<ActionResult<tblSQMS_Endline_Info>> GetEndLineInfo(long pId)
        {
            var endLineInfo = await _context.tblSQMS_Endline_Info.FirstOrDefaultAsync(a => a.Id == pId);

            if (endLineInfo == null)
            {
                return NotFound();
            }

            return endLineInfo;
        }

        // PUT: api/EndlineInfo/5
        [HttpPut("{pId}")]         
        public async Task<IActionResult> PutEndLineInfo(long pId, tblSQMS_Endline_Info tblSQMS_Endline_Info)
        {
            if (pId != tblSQMS_Endline_Info.Id)
            {
                return BadRequest();
            }

            _context.Entry(tblSQMS_Endline_Info).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EndLineInfoExisit(pId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }

            }

            return CreatedAtAction("GetEndLineInfo", tblSQMS_Endline_Info);
        }



        // PUT: api/EndlineInfo/update/5
        [HttpPut("update/{pId}")]
        public async Task<IActionResult> PutEndLineInfoUpdate(long pId, tblSQMS_Endline_Info tblSQMS_Endline_Infox)
        {
            if (pId != tblSQMS_Endline_Infox.Id)
            {
                return BadRequest();
            }

            bool BundleClosed = tblSQMS_Endline_Infox.BundleClosed;

            try
            {
                
                await _context.Database.ExecuteSqlRawAsync("exec sp_check " + pId  + "," +
                    (tblSQMS_Endline_Infox.FreshPCS.Equals("") ? "null" : "'" + tblSQMS_Endline_Infox.FreshPCS + "'") + "," +
                    (tblSQMS_Endline_Infox.RejectedPCS.Equals("") ? "null" : "'" + tblSQMS_Endline_Infox.RejectedPCS + "'") + "," +
                    (tblSQMS_Endline_Infox.FaultyPCS.Equals("") ? "null" : "'" + tblSQMS_Endline_Infox.FaultyPCS + "'") + "," +
                    (tblSQMS_Endline_Infox.PCSOnRework.Equals("") ? "null" : "'" + tblSQMS_Endline_Infox.PCSOnRework + "'") + "," +
                    (tblSQMS_Endline_Infox.FreshPCSOnRework.Equals("") ? "null" : "'" + tblSQMS_Endline_Infox.FreshPCSOnRework + "'") + "," +
                    (tblSQMS_Endline_Infox.RejectedPCSOnRework.Equals("") ? "null" : "'" + tblSQMS_Endline_Infox.RejectedPCSOnRework + "'") + "," +
                    (tblSQMS_Endline_Infox.FaultyPCSOnRework.Equals("") ? "null" : "'" + tblSQMS_Endline_Infox.FaultyPCSOnRework + "'") + "," +
                    BundleClosed
                    + "");

            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EndLineInfoExisit(pId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }

            }

            return CreatedAtAction("GetEndLineInfo", tblSQMS_Endline_Infox);
        }


        private bool EndLineInfoExisit(long pId)
        {
            return _context.tblSQMS_Endline_Info.Any(e => e.Id == pId);
        }





    }
}
