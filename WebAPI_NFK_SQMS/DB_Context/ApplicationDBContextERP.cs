using DataAccessLayer.Models;
using DataAccessLayer.Models.MasterInfo;
using DataAccessLayer.Models.Expo_NFK;
using DataAccessLayer.Models.Transactions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI_NFK_SQMS.DB_Context
{
    public class ApplicationDBContextERP : DbContext
    {
        public ApplicationDBContextERP(DbContextOptions<ApplicationDBContextERP> options)
               : base(options)
        {

        }


        public DbQuery<vw_CB_Detail> vw_CB_Detail { get; set; }
        public DbQuery<vw_Style_Master> vw_Style_Master { get; set; }



        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }


    }
}
