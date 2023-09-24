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


    public class RoundsController : ControllerBase
    {
        private readonly ApplicationDBContext _context;

        public RoundsController(ApplicationDBContext context)
        {
            _context = context;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<tblSQMS_Master_Rounds>>> GetRounds()
        {
            return await _context.tblSQMS_Master_Rounds.ToListAsync();
        }



        //POST: api/Operations
        [HttpPost]
        public async Task<ActionResult<tblSQMS_Master_Rounds>> CreateRounds(tblSQMS_Master_Rounds tblSQMSRounds)
        {
            try
            {
                _context.tblSQMS_Master_Rounds.Add(tblSQMSRounds);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetRounds", new { id = tblSQMSRounds.Id }, tblSQMSRounds);

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error in Data Creation In Database");
            }
        }

        // GET: api/Operations/5
        [HttpGet("{pId}")]
        public async Task<ActionResult<tblSQMS_Master_Rounds>> GetRounds(long pId)
        {
            var rounds = await _context.tblSQMS_Master_Rounds.FirstOrDefaultAsync(a => a.Id == pId);

            if (rounds == null)
            {
                return NotFound();
            }

            return rounds;
        }

        // PUT: api/Operations/5
        [HttpPut("{pId}")]
        public async Task<IActionResult> PutRounds(long pId, tblSQMS_Master_Rounds tblSQMSRounds)
        {
            if (pId != tblSQMSRounds.Id)
            {
                return BadRequest();
            }

            _context.Entry(tblSQMSRounds).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RoundsExisit(pId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }

            }

            return CreatedAtAction("GetRounds", tblSQMSRounds);
        }

        private bool RoundsExisit(long pId)
        {
            return _context.tblSQMS_Master_Rounds.Any(e => e.Id == pId);
        }


        private bool checkRoundUses(string pRound)
        {
            bool i = _context.tblSQMS_Fault_Gen_Categ.Any(e => e.RoundNo == pRound);
            
            if (i)
                return false;
            else
                return true;

        }



        [HttpDelete("{RoundId}")]
        public async Task<bool> DeleteRound(long RoundId)
        {
            var roundDet = await _context.tblSQMS_Master_Rounds.FindAsync(RoundId);

            if (checkRoundUses(roundDet.Rounds))
            {
                _context.tblSQMS_Master_Rounds.Remove(roundDet);
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
