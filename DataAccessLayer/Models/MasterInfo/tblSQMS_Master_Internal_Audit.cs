using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataAccessLayer.Models.MasterInfo
{
    public class tblSQMS_Master_Internal_Audit
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public long Id { get; set; }

        public string Section { get; set; }

        public string Descriptions { get; set; }

        public int Sort { get; set; }

         
    }
}
