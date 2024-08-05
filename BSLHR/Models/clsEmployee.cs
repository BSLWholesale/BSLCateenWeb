using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BSLHR.Models
{
    public class clsEmployee
    {
        public Int64 EmpId { get; set; }
        public string EmpName { get; set; }
        public string EmpLastName { get; set; }
        public string EmpEmailId { get; set; }
        public string EmpMobile { get; set; }
        public Nullable<DateTime> DOB { get; set; }
        public int EmpGrade { get; set; }
        public string EmpLocation { get; set; }
        public int BSLTravelDesk { get; set; }
        public string EmpPassword { get; set; }
    }
    public class ExpenseClaimMaster
    {
        public Int64 ExpenseID { get; set; }
        public Int64 EmpId { get; set; }
        public DateTime AppliedDate { get; set; }
        public string ApproveStatus { get; set; }
    }
    public class ExpenseClaimDetail
    {
        public int EDetId { get; set; }
        public Int64 ExpenseID { get; set; }
        public int EModeId { get; set; }
        public Int64 TravelId { get; set; }
        public float EAmount { get; set; }
        
        public string Remarks { get; set; }
    }

    public class clsExpenseMode
    {
        public int EModeId { get; set; }
        public string EModeDescription { get; set; }
    }

    public class clsTravelDeskMaster
    {
        public int TDeskId { get; set; }
        public string TDeskDescription { get; set; }
        public string TDeskLocation { get; set; }
    }
    public class clsTravelMode
    {
        public int TModeId { get; set; }
        public string TravelDescription { get; set; }
    }

    public class clsTravelRequestDetail
    {
        public int TRDetId { get; set; }
        public Int64 TravelID { get; set; }
        public int TravelType { get; set; }

        public int TModeId { get; set; }
        public float Amount { get; set; }
        public int Qty { get; set; }
    }
}