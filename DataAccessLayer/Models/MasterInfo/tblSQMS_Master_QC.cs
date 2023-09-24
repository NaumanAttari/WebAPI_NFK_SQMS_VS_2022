using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccessLayer.Models.MasterInfo
{
    public class tblSQMS_Master_QC
    {

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public long Id { get; set; }

        public string QCCardNo { get; set; }

        public string QCName { get; set; }

        public string LocationName { get; set; }

        public string Pwd { get; set; }


    }
}
