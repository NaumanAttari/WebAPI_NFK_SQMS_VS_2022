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

    public class BundleCardController : ControllerBase 
    {
        private readonly ApplicationDBContext _context;

        public BundleCardController(ApplicationDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<tblSQMS_EndLine_Bundle_Cards>>> GetBundleCard()
        {
            return await _context.tblSQMS_EndLine_Bundle_Cards.ToListAsync();
        }



        //POST: api/BundleCard
        [HttpPost]
        public async Task<ActionResult<tblSQMS_EndLine_Bundle_Cards>> CreateFaults(tblSQMS_EndLine_Bundle_Cards tblSQMSBundleCard)
        {
            try
            {
                 
                 _context.tblSQMS_EndLine_Bundle_Cards.Add(tblSQMSBundleCard);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetBundleCard", new { id = tblSQMSBundleCard.Id }, tblSQMSBundleCard);

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error in Data Creation In Database");
            }
        }

        // GET: api/BundleCard/5
        [HttpGet("{pId}")]
        public async Task<ActionResult<tblSQMS_EndLine_Bundle_Cards>> GetBundleCard(long pId)
        {
            var faults = await _context.tblSQMS_EndLine_Bundle_Cards.FirstOrDefaultAsync(a => a.Id == pId);

            if (faults == null)
            {
                return NotFound();
            }

            return faults;
        }


        // GET: api/BundleCard/StyleNo/K-87
        [HttpGet("StyleNo/{styleNo}")]
        public async Task<ActionResult<IEnumerable<tblSQMS_EndLine_Bundle_Cards>>> GetBundleCard_StyleNo(string styleNo)
        {
            var styleDet = await _context.tblSQMS_EndLine_Bundle_Cards.Where(a => a.StyleNo == styleNo).ToListAsync();

            if (styleDet == null)
            {
                return NotFound();
            }

            return styleDet;
        }


        [HttpGet("CBNo")]
        public async Task<ActionResult<IEnumerable<tblSQMS_EndLine_Bundle_Cards>>> GetBundleCardCBWise()
        {
            return await _context.tblSQMS_EndLine_Bundle_Cards.ToListAsync();
        }

        // GET: api/BundleCard/CBNo/CB-0000
        [HttpGet("CBNo/{pCBNo}")]
        public async Task<ActionResult<IEnumerable<tblSQMS_EndLine_Bundle_Cards>>> GetBundleCardCBWise(string pCBNo)
        {
            var CBDet = await _context.tblSQMS_EndLine_Bundle_Cards.Where(a => a.CBNo == pCBNo).ToListAsync();

            if (CBDet == null)
            {
                return NotFound();
            }

            return CBDet;
        }

        // PUT: api/BundleCard/5
        [HttpPut("{pId}")]
        public async Task<IActionResult> PutFaults(long pId, tblSQMS_EndLine_Bundle_Cards tblSQMSBundleCard)
        {
            if (pId != tblSQMSBundleCard.Id)
            {
                return BadRequest();
            }

            _context.Entry(tblSQMSBundleCard).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BundleCardExisit(pId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }

            }

            return CreatedAtAction("GetBundleCard", tblSQMSBundleCard);
        }

        private bool BundleCardExisit(long pId)
        {
            return _context.tblSQMS_EndLine_Bundle_Cards.Any(e => e.Id == pId);
        }





    }
}
