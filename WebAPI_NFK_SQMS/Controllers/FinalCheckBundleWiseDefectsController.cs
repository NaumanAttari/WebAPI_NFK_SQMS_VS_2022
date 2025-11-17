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

    public class FinalCheckBundleWiseDefectsController : ControllerBase
    {
        private readonly ApplicationDBContext _context;

        public FinalCheckBundleWiseDefectsController(ApplicationDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<tblSQMS_FinalCheck_BundleWise_Defects>>> GetFinalCheck_BundleWiseDefects()
        {
            return await _context.tblSQMS_FinalCheck_BundleWise_Defects.ToListAsync();
        }

        // GET: api/EndlineDefects/CBNo/CB-0000
        [HttpGet("CBNo/{pCBNo}")]
        public async Task<ActionResult<IEnumerable<tblSQMS_FinalCheck_BundleWise_Defects>>> GetFinalCheck_BundleWiseDefectsbyCBNO(string pCBNo)
        {
            return await _context.tblSQMS_FinalCheck_BundleWise_Defects.Where(a=> a.CBNo == pCBNo).ToListAsync();
        }


        //public async Task<ActionResult> PostPODetail([FromBody] List<PODetail> poDetail)
        //{
        //    _ = _context.INVENTORY_PO_DETAIL.AddRangeAsync(poDetail);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetPODetail", poDetail);
        //}


        //POST: api/EndlineDefects
        [HttpPost]
        public async Task<ActionResult<tblSQMS_FinalCheck_BundleWise_Defects>> CreateEndLineDefects(tblSQMS_FinalCheck_BundleWise_Defects tblSQMS_FinalCheck_BundleWise_Defects)
        {
            try
            {
                _context.tblSQMS_FinalCheck_BundleWise_Defects.Add(tblSQMS_FinalCheck_BundleWise_Defects);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetFinalCheck_BundleWiseDefects", new { id = tblSQMS_FinalCheck_BundleWise_Defects.Id }, tblSQMS_FinalCheck_BundleWise_Defects);

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error in Data Creation In Database");
            }
        }

        // GET: api/EndlineDefects/5
        [HttpGet("{pId}")]
        public async Task<ActionResult<tblSQMS_FinalCheck_BundleWise_Defects>> GetEndlineDefects(long pId)
        {
            var floors = await _context.tblSQMS_FinalCheck_BundleWise_Defects.FirstOrDefaultAsync(a => a.Id == pId);

            if (floors == null)
            {
                return NotFound();
            }

            return floors;
        }

        // PUT: api/EndlineDefects/5
        [HttpPut("{pId}")]
        public async Task<IActionResult> PutEndLineDefects(long pId, tblSQMS_FinalCheck_BundleWise_Defects tblSQMS_FinalCheck_BundleWise_Defects)
        {
            if (pId != tblSQMS_FinalCheck_BundleWise_Defects.Id)
            {
                return BadRequest();
            }

            _context.Entry(tblSQMS_FinalCheck_BundleWise_Defects).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FinalCheck_BundleWiseDefectsExisit(pId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }

            }

            return CreatedAtAction("GetFinalCheck_BundleWiseDefects", tblSQMS_FinalCheck_BundleWise_Defects);
        }

        private bool FinalCheck_BundleWiseDefectsExisit(long pId)
        {
            return _context.tblSQMS_FinalCheck_BundleWise_Defects.Any(e => e.Id == pId);
        }
    }
}
