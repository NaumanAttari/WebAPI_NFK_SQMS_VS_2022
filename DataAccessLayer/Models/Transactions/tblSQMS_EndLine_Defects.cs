using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccessLayer.Models.Transactions
{
    public class tblSQMS_EndLine_Defects
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public long Id { get; set; }
        public string Floor { get; set; }
        public string ProdLineNo { get; set; }
        public string QCCardNo { get; set; }
        public string QCName { get; set; }
        public string WorkerCardNo { get; set; }         
        public string WorkerName { get; set; }
        public string Operation { get; set; }
        public string CBNo { get; set; }
        public string Size { get; set; }
        public string BundleNo { get; set; }
        public string EndLineFaults { get; set; }
        public string FaultyPCS { get; set; }
        public string BundleStatus { get; set; }
         


    }
}
