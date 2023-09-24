using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccessLayer.Models.MasterInfo
{
    public class tblSQMS_Master_Line_Info
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public long Id { get; set; }

        public string Floor { get; set; }
        public string ProdLineNo { get; set; }
        public string Operation { get; set; }
        public string CardNo { get; set; }
        public string MachineNo { get; set; }
        public string Shifts { get; set; }

        public string Status { get; set; }


    }
}
