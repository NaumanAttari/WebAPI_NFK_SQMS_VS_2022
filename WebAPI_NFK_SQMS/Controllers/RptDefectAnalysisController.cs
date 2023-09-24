using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using WebAPI_NFK_SQMS.DB_Context;
using DataAccessLayer.Models.Sql_Functions;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;


namespace WebAPI_NFK_SQMS.Controllers
{

    [EnableCors("SiteCorsPolicy")]
    [Route("api/[controller]")]
    [ApiController]

    public class RptDefectAnalysisController : ControllerBase 

    {
        private readonly ApplicationDBContext _context;

        public RptDefectAnalysisController(ApplicationDBContext context)
        {
            _context = context;
        }


        [HttpGet("{fromDate}/{toDate}")]
        public async Task<ActionResult<IEnumerable<rptDefectAnalysis>>> GetDefectPcs(string fromDate, string toDate)
        {
            return await _context.DefectAnalysis.FromSqlRaw("Select * from fn_DefectAnalysis('" + fromDate + "','" + toDate + "')").ToListAsync();
        }


        [HttpGet("details")]
        public async Task<ActionResult<IEnumerable<rptDefectAnalysis>>> Details(string fromDate, string toDate)
        {
            return await _context.DefectAnalysis.FromSqlRaw("Select * from fn_DefectAnalysis('" + fromDate + "','" + toDate + "', null)").ToListAsync();
        }

        [HttpGet("DetailswithOperation")]
        public async Task<ActionResult<IEnumerable<rptDefectAnalysis>>> DetailswithOperation(string fromDate, string toDate, string Operation)
        {
            return await _context.DefectAnalysis.FromSqlRaw("Select * from fn_DefectAnalysis('" + fromDate + "','" + toDate + "','" + Operation + "')").ToListAsync();
        }







    }
}
