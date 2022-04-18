using System;

namespace SAAR.ViewModels
{
    public class PackInfoViewModel
    {
        public string CaseNo { get; set; }
        public string Party { get; set; }
        public string Comp_GSTno { get; set; }
        public string BillNo { get; set; }
        public DateTime? BillDate { get; set; }
    }
}