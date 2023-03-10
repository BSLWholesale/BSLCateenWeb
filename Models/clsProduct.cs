using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BSLWeb.Models
{
    public class clsProduct
    {
        public class clsRequestProduct
        {
            public string vCategory { get; set; }
            public int nProductId { get; set; }
            public string vProductName { get; set; }
            public string vGround { get; set; }
            public string vBorder { get; set; }
            public string vSize { get; set; }
            public string vPrice { get; set; }
            public int nQuantity { get; set; }
            public bool bIsStatus { get; set; }
            public string vCustomerId { get; set; }
            public string vOrderId { get; set; }

            //01 March 2023
            public int nPly { get; set; }
            public int nCount { get; set; }
            public string vCountType { get; set; }
            public string vBlendDescription { get; set; }
            public string vSlub { get; set; }
            public string vTechnique { get; set; }
            public string vQuality { get; set; }
            //01 March 2023

            //08 March 2023
            public string vFabricType { get; set; }
            public string vSeason { get; set; }
            //08 March 2023
        }

        public class clsResponseProduct
        {
            public string vErrorMsg { get; set; }
            public string vStatus { get; set; }
            public int nCountItem { get; set; }
        }

        public class clsDeleteProduct
        {
            public string vCustomerId { get; set; }
            public int nProductId { get; set; }
        }
    }

    public class clsProductDetails
    {
        public string vMaterialCode { get; set; }
        public string vQuality { get; set; }
        public double nPrice { get; set; }
        public string vCurrency { get; set; }
        public double nExchangeRng { get; set; }
        public string vBlendDescription { get; set; }
        public string vBlendValue { get; set; }
        public string vWeaveType { get; set; }
        public int nGSM { get; set; }
        public string vStrechType { get; set; }
        public string vDesignPattern { get; set; }
        public string vShade { get; set; }
        public string vUsage { get; set; }
        public string vRemarks { get; set; }
        public string vProduct { get; set; }
        public string vCreatedBy { get; set; }
        public DateTime dCreatedOn { get; set; }
        public string vModifiedBy { get; set; }
        public DateTime dModifiedOn { get; set; }
        public string vAddress { get; set; }
        public int nFinishType { get; set; }
        public string vErrorMsg { get; set; }
    }

    public class clsProductCart
    {
        public int Id { get; set; }
        public string vCategory { get; set; }
        public int nProductId { get; set; }
        public string vProductName { get; set; }
        public string vGround { get; set; }
        public string vBorder { get; set; }
        public string vSize { get; set; }
        public string vPrice { get; set; }
        public int nQuantity { get; set; }
        public bool bIsStatus { get; set; }
        public string vCustomerId { get; set; }
        public string vOrderId { get; set; }
        //02 March 2023 Yarn Parameters
        public int nPly { get; set; }
        public int nCount { get; set; }
        public string vCountType { get; set; }
        public string vBlendDescription { get; set; }
        public string vSlub { get; set; }
        public string vTechnique { get; set; }
        public string vQuality { get; set; }
        //02 March 2023

        //08 March 2023 RMG Parameters
        public string vFabricType { get; set; }
        public string vSeason { get; set; }
        //08 March 2023 RMG Parameters
    }
}
