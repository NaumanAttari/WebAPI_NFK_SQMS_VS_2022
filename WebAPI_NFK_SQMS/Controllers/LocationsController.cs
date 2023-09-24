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


    public class LocationsController : ControllerBase
    {
        private readonly ApplicationDBContext _context;

        public LocationsController(ApplicationDBContext context)
        {
            _context = context;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<tblSQMS_Master_Locations>>> GetLocations()
        {
            return await _context.tblSQMS_Master_Locations.ToListAsync();
        }



        //POST: api/Operations
        [HttpPost]
        public async Task<ActionResult<tblSQMS_Master_Locations>> CreateLocations(tblSQMS_Master_Locations tblSQMSLocations)
        {
            try
            {
                _context.tblSQMS_Master_Locations.Add(tblSQMSLocations);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetLocations", new { id = tblSQMSLocations.Id }, tblSQMSLocations);

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error in Data Creation In Database");
            }
        }

        // GET: api/Operations/5
        [HttpGet("{pId}")]
        public async Task<ActionResult<tblSQMS_Master_Locations>> GetLocations(long pId)
        {
            var locations = await _context.tblSQMS_Master_Locations.FirstOrDefaultAsync(a => a.Id == pId);

            if (locations == null)
            {
                return NotFound();
            }

            return locations;
        }

        // PUT: api/Operations/5
        [HttpPut("{pId}")]
        public async Task<IActionResult> PutLocations(long pId, tblSQMS_Master_Locations tblSQMSLocations)
        {
            if (pId != tblSQMSLocations.Id)
            {
                return BadRequest();
            }

            _context.Entry(tblSQMSLocations).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LocationsExisit(pId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }

            }

            return CreatedAtAction("GetLocations", tblSQMSLocations);
        }

        private bool LocationsExisit(long pId)
        {
            return _context.tblSQMS_Master_Locations.Any(e => e.Id == pId);
        }


    }
}
