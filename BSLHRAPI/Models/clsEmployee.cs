using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BSLHRAPI.Models
{
    public class clsEmployee
    {
        public Nullable<Int64> EmpId { get; set; }
        public string EmpName { get; set; }
        public string EmpLastName { get; set; }
        public string EmpEmailId { get; set; }
        public string EmpMobile { get; set; }
        public Nullable<int> EmpGrade { get; set; }
        public string EmpLocation { get; set; }
        public Nullable<int> BSLTravelDesk { get; set; }
        public string EmpPassword { get; set; }
        public Nullable<DateTime> DOB { get; set; }
        public string vErrorMsg { get; set; }
    }

    public class ExpenseClaimMaster
    {
        public Nullable<Int64> ExpenseID { get; set; }
        public Nullable<Int64> EmpId { get; set; }
        public Nullable<DateTime> AppliedDate { get; set; }
        public string ApproveStatus { get; set; }
    }
    public class ExpenseClaimDetail
    {
        public Nullable<int> EDetId { get; set; }
        public Nullable<Int64> ExpenseID { get; set; }
        public Nullable<int> EModeId { get; set; }
        public Nullable<Int64> TravelId { get; set; }
        public float EAmount { get; set; }

        public string Remarks { get; set; }
    }

    public class clsExpenseMode
    {
        public Nullable<int> EModeId { get; set; }
        public string EModeDescription { get; set; }
    }

    public class clsTravelDeskMaster
    {
        public Nullable<int> TDeskId { get; set; }
        public string TDeskDescription { get; set; }
        public string TDeskLocation { get; set; }
    }

    public class clsTravelMode
    {
        public Nullable<int> TModeId { get; set; }
        public string TravelDescription { get; set; }
    }

    public class clsTravelRequestDetail
    {
        public Nullable<int> TRDetId { get; set; }
        public Nullable<Int64> TravelID { get; set; }
        public Nullable<int> TravelType { get; set; }

        public Nullable<int> TModeId { get; set; }
        public float Amount { get; set; }
        public Nullable<int> Qty { get; set; }
    }
}