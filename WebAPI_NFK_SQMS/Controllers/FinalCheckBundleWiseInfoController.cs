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

    public class FinalCheckBundleWiseInfoController : ControllerBase
    {
        private readonly ApplicationDBContext _context;

        public FinalCheckBundleWiseInfoController(ApplicationDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<tblSQMS_FinalCheck_BundleWise_Info>>> GetFinalCheck_BundleWiseInfo()
        {
            return await _context.tblSQMS_FinalCheck_BundleWise_Info.ToListAsync();
        }

        // GET: api/CBNo/CB-0000
        [HttpGet("CBNo/{pCBNo}")]
        public async Task<ActionResult<IEnumerable<tblSQMS_FinalCheck_BundleWise_Info>>> GetFinalCheck_BundleWiseCBWise(string pCBNo)
        {
            return await _context.tblSQMS_FinalCheck_BundleWise_Info.Where(a => a.CBNo == pCBNo).ToListAsync();
        }

        //POST: api/Operations
        [HttpPost]
        public async Task<ActionResult<tblSQMS_FinalCheck_BundleWise_Info>> CreateGetEndLineInfoCBWiseInfo(tblSQMS_FinalCheck_BundleWise_Info tblSQMS_GetFinalCheck_BundleWiseInfoCBWise_Info)
        {
            try
            {
                _context.tblSQMS_FinalCheck_BundleWise_Info.Add(tblSQMS_GetFinalCheck_BundleWiseInfoCBWise_Info);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetFinalCheck_BundleWiseInfo", new { id = tblSQMS_GetFinalCheck_BundleWiseInfoCBWise_Info.Id }, tblSQMS_GetFinalCheck_BundleWiseInfoCBWise_Info);

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error in Data Creation In Database");
            }
        }

        // GET: api/Operations/5
        [HttpGet("{pId}")]
        public async Task<ActionResult<tblSQMS_FinalCheck_BundleWise_Info>> GetFinalCheck_BundleWiseInfo(long pId)
        {
            var endLineInfo = await _context.tblSQMS_FinalCheck_BundleWise_Info.FirstOrDefaultAsync(a => a.Id == pId);

            if (endLineInfo == null)
            {
                return NotFound();
            }

            return endLineInfo;
        }

        // PUT: api/FinalCheckBundleWiseInfo/5
        [HttpPut("{pId}")]         
        public async Task<IActionResult> PutEndLineInfo(long pId, tblSQMS_FinalCheck_BundleWise_Info tblSQMS_FinalCheck_BundleWise_Info)
        {
            if (pId != tblSQMS_FinalCheck_BundleWise_Info.Id)
            {
                return BadRequest();
            }

            _context.Entry(tblSQMS_FinalCheck_BundleWise_Info).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FinalCheck_BundleWiseInfoExisit(pId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }

            }

            return CreatedAtAction("GetFinalCheck_BundleWiseInfo", tblSQMS_FinalCheck_BundleWise_Info);
        }



        // PUT: api/EndlineInfo/update/5
        [HttpPut("update/{pId}")]
        public async Task<IActionResult> PutFinalCheck_BundleWiseInfoUpdate(long pId, tblSQMS_FinalCheck_BundleWise_Info tblSQMS_FinalCheck_BundleWise_Infox)
        {
            if (pId != tblSQMS_FinalCheck_BundleWise_Infox.Id)
            {
                return BadRequest();
            }

            bool BundleClosed = tblSQMS_FinalCheck_BundleWise_Infox.BundleClosed;

            try
            {
                
                await _context.Database.ExecuteSqlRawAsync("exec sp_check_finalCheck_BundleWise " + pId  + "," +
                    (tblSQMS_FinalCheck_BundleWise_Infox.ActualFreshPCS.Equals("") ? "null" : "'" + tblSQMS_FinalCheck_BundleWise_Infox.ActualFreshPCS + "'") + "," +
                    (tblSQMS_FinalCheck_BundleWise_Infox.RejectedPCS.Equals("") ? "null" : "'" + tblSQMS_FinalCheck_BundleWise_Infox.RejectedPCS + "'") + "," +
                    (tblSQMS_FinalCheck_BundleWise_Infox.AlterPCS.Equals("") ? "null" : "'" + tblSQMS_FinalCheck_BundleWise_Infox.AlterPCS + "'") + "," +
                    (tblSQMS_FinalCheck_BundleWise_Infox.FaultyPCS.Equals("") ? "null" : "'" + tblSQMS_FinalCheck_BundleWise_Infox.FaultyPCS + "'") + "," +
                    (tblSQMS_FinalCheck_BundleWise_Infox.PCSOnRework.Equals("") ? "null" : "'" + tblSQMS_FinalCheck_BundleWise_Infox.PCSOnRework + "'") + "," +
                    (tblSQMS_FinalCheck_BundleWise_Infox.FreshPCSOnRework.Equals("") ? "null" : "'" + tblSQMS_FinalCheck_BundleWise_Infox.FreshPCSOnRework + "'") + "," +
                    (tblSQMS_FinalCheck_BundleWise_Infox.RejectedPCSOnRework.Equals("") ? "null" : "'" + tblSQMS_FinalCheck_BundleWise_Infox.RejectedPCSOnRework + "'") + "," +
                    (tblSQMS_FinalCheck_BundleWise_Infox.FaultyPCSOnRework.Equals("") ? "null" : "'" + tblSQMS_FinalCheck_BundleWise_Infox.FaultyPCSOnRework + "'") + "," +
                    BundleClosed
                    + "");

            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FinalCheck_BundleWiseInfoExisit(pId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }

            }

            return CreatedAtAction("GetFinalCheck_BundleWiseInfo", tblSQMS_FinalCheck_BundleWise_Infox);
        }


        private bool FinalCheck_BundleWiseInfoExisit(long pId)
        {
            return _context.tblSQMS_FinalCheck_BundleWise_Info.Any(e => e.Id == pId);
        }





    }
}
