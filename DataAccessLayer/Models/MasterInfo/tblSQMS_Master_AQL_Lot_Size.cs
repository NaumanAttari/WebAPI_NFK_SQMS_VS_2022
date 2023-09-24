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

        public string AQL_A_Major { get; set; }
        public string AQL_A_Minor { get; set; }
        public string AQL_B_Major { get; set; }
        public string AQL_B_Minor { get; set; }
        public string AQL_C_Major { get; set; }
        public string AQL_C_Minor { get; set; }

    }
}
