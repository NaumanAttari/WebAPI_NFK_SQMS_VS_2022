using DataAccessLayer.Models.Sql_Functions;
using DataAccessLayer.Models.TrafficLights;
using DataAccessLayer.Models.TrafficLights.Table_Valued_Functions;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI_NFK_SQMS.DB_Context;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace WebAPI_NFK_SQMS.Controllers
{
    [EnableCors("SiteCorsPolicy")]
    [Route("api/[controller]")]
    [ApiController]

    public class FinalAuditStatusForTrafficLightsController : Controller
    {
        private readonly ApplicationDBContext _context;

        public FinalAuditStatusForTrafficLightsController(ApplicationDBContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }



        //[HttpGet("GetFinalAuditStatus")]
        //public async Task<ActionResult<IEnumerable<FinalAuditStatusForTrafficLights>>> FinalAuditStatusForTrafficLights(string Floor,string fromTime, string toTime)
        //{
        //    return await _context.FinalAuditStatusForTrafficLights.FromSqlRaw("Select * from fn_AuditStatus_for_Traffic_Lights('" +  Floor + "','" + fromTime + "','" + toTime + "')").ToListAsync();
        //}



        [HttpGet("ExecuteFinalAuditOQLNextRun")]
        public async Task<ActionResult<IEnumerable<FinalAuditNextRun>>> ExecuteFinalAuditOQLNextRun(string Floor)
        {
            var parameterFloor = new SqlParameter
            {
                ParameterName = "pFloor",
                SqlDbType = System.Data.SqlDbType.NVarChar,
                Value = Floor,
            }; 

            return await _context.FinalAuditNextRun.FromSqlRaw("exec dbo.sp_TrafficLight_NextRun @pFloor ", parameterFloor).ToListAsync();

        }

        [HttpGet("GetFinalAuditOQLStatus")]
        public async Task<ActionResult<IEnumerable<fn_Final_Audit_Status_For_Traffic_Lights>>> fn_Final_Audit_Status_For_Traffic_Lights(string Floor)
        {

            var FinalAuditPeriod = await _context.FinalAuditPeriodforTrafficLights.FromSqlRaw("select 1 Id,format(DATEADD(MINUTE,-59,dbo.fn_TrafficLight_LastHour_FloorsWise('" + Floor + "')),'HH:mm') StartTime, dbo.fn_TrafficLight_LastHour_FloorsWise('" + Floor + "') EndTime").FirstOrDefaultAsync();
            
            //return await _context.fn_Final_Audit_Status_For_Traffic_Lights.FromSqlRaw("Select * from dbo.fn_tab_TrafficLight_LastHour_FloorsWise('" + Floor + "','14:01', '15:59')").ToListAsync();
            
            return await _context.fn_Final_Audit_Status_For_Traffic_Lights.FromSqlRaw("Select * from dbo.fn_tab_TrafficLight_LastHour_FloorsWise('" + Floor + "','" + FinalAuditPeriod.StartTime + "', '" + FinalAuditPeriod.EndTime + "')").ToListAsync();

        }


        //[HttpGet("GetFinalAuditOQLStatus")]
        //public async Task<ActionResult<IEnumerable<vw_Final_Audit_Status_For_Traffic_Lights>>> vw_Final_Audit_Status_For_Traffic_Lights(string Floor)
        //{
        //    var ViewFinalAuditOQLDetail = await _context.vw_Final_Audit_Status_For_Traffic_Lights.Where(a => a.Floor == Floor).ToListAsync();

        //    if (ViewFinalAuditOQLDetail == null)
        //    {
        //        return NotFound();
        //    }

        //    return ViewFinalAuditOQLDetail;

        //}






        [HttpGet("details")]
        public async Task<ActionResult<IEnumerable<rptDefectAnalysis>>> Details(string fromDate, string toDate)
        {
            return await _context.DefectAnalysis.FromSqlRaw("Select * from fn_DefectAnalysis('" + fromDate + "','" + toDate + "', null)").ToListAsync();
        }


    }
}
