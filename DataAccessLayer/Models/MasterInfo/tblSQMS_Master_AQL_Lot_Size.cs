using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataAccessLayer.Models.MasterInfo
{
    public class tblSQMS_Master_AQL_Lot_Size
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]

        public long Id { get; set; }

        public DateTime Dated { get; set; }

        public string Lot_Size { get; set; }

        public long Qty { get; set; }

        public string AQL_0_40_Major { get; set; }
        public string AQL_0_40_Minor { get; set; }
        public string AQL_0_065_Major { get; set; }
        public string AQL_0_065_Minor { get; set; }
        public string AQL_0_65_Major { get; set; }
        public string AQL_0_65_Minor { get; set; }
        public string AQL_1_0_Major { get; set; }
        public string AQL_1_0_Minor { get; set; }
        public string AQL_1_5_Major { get; set; }
        public string AQL_1_5_Minor { get; set; }
        public string AQL_2_5_Major { get; set; }
        public string AQL_2_5_Minor { get; set; }
        public string AQL_4_0_Major { get; set; }
        public string AQL_4_0_Minor { get; set; }

    }
}
