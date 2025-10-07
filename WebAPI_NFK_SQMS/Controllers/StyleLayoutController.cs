using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using WebAPI_NFK_SQMS.DB_Context;
using DataAccessLayer.Models;
using DataAccessLayer.Models.MasterInfo;
using DataAccessLayer.Models.Transactions;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;

namespace WebAPI_NFK_SQMS.Controllers
{
    [EnableCors("SiteCorsPolicy")]
    [Route("api/[controller]")]
    [ApiController]

    public class StyleLayoutController : ControllerBase
    {
        private readonly ApplicationDBContext _context;

        public StyleLayoutController(ApplicationDBContext context)
        {
            _context = context;
        }


        [HttpGet("All")]
        public async Task<ActionResult<IEnumerable<tblSQMS_Master_Style_Layout>>> GetStyle_Layout()
        {
            return await _context.tblSQMS_Master_Style_Layout.ToListAsync();
        }


        [HttpGet("StyleNo")]
        public async Task<ActionResult<IEnumerable<vw_StyleLayout>>> GetStyle()
        {
            return await _context.vw_StyleLayout.ToListAsync();
        }

        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<tblSQMS_Master_Style_Layout>>> GetStyle_Layout()
        //{
        //    return await _context.tblSQMS_Master_Style_Layout.ToListAsync();
        //}


        //public async Task<ActionResult> PostPODetail([FromBody] List<PODetail> poDetail)
        //{
        //    _ = _context.INVENTORY_PO_DETAIL.AddRangeAsync(poDetail);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetPODetail", poDetail);
        //}


        //POST: api/StyleLayout
        [HttpPost]
        public async Task<ActionResult<tblSQMS_Master_Style_Layout>> CreateStyleLayout(tblSQMS_Master_Style_Layout tblSQMSStyle_Layout)
        {
            try
            {
                _context.tblSQMS_Master_Style_Layout.Add(tblSQMSStyle_Layout);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetStyle", new { id = tblSQMSStyle_Layout.Id }, tblSQMSStyle_Layout);

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error in Data Creation In Database");
            }
        }

        // GET: api/StyleLayout/5
        //[HttpGet("{pStyleNo}")]
        //public async Task<ActionResult<IEnumerable<tblSQMS_Master_Style_Layout>>> GetStyle_Layout(string pStyleNo)
        //{
        //    var styleLayout = await _context.tblSQMS_Master_Style_Layout.Where(a => a.StyleNo == pStyleNo).ToListAsync();

        //    if (styleLayout == null)
        //    {
        //        return NotFound();
        //    }

        //    return styleLayout;
        //}


        //[HttpGet("a/{pStyleNo}")]
        public async Task<ActionResult<IEnumerable<tblSQMS_Master_Style_Layout>>> GetStyle_LayoutNew([FromQuery] string pStyleNo)
        {
            var styleLayout = await _context.tblSQMS_Master_Style_Layout.Where(a => a.StyleNo == pStyleNo).ToListAsync();

            if (styleLayout == null)
            {
                return NotFound();
            }

            return styleLayout;
        }






        // PUT: api/StyleLayout/5
        [HttpPut("{pId}")]
        public async Task<IActionResult> PutStyle_Layout(long pId, tblSQMS_Master_Style_Layout tblSQMS_Master_Style_Layout)
        {
            if (pId != tblSQMS_Master_Style_Layout.Id)
            {
                return BadRequest();
            }

            _context.Entry(tblSQMS_Master_Style_Layout).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Style_LayoutExisit(pId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }

            }

            return CreatedAtAction("GetStyle_Layout", tblSQMS_Master_Style_Layout);
        }


        [HttpDelete("{styleID}")]
        public async Task<ActionResult<tblSQMS_Master_Style_Layout>> DeleteStyleLayout(long styleID)
        {
            var styleDet = await _context.tblSQMS_Master_Style_Layout.FindAsync(styleID);
            if (styleDet == null)
            {
                return NotFound();
            }

            _context.tblSQMS_Master_Style_Layout.Remove(styleDet);
            await _context.SaveChangesAsync();

            return styleDet;
        }

        private bool Style_LayoutExisit(long pId)
        {
            return _context.tblSQMS_Master_Style_Layout.Any(e => e.Id == pId);
        }
    }
}
