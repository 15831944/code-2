﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;


namespace AP_C 
{
    class RDR1 : B1iSN 
    {
        public string DocEntry = "DocEntry";
        public string DocNum = "DocNum";
        public string LineNum = "LineNum";
        public string ItemCode = "ItemCode";
        public string Dscription = "ItemDescription";
        public string Quantity = "Quantity";
        public string ShipDate = "ShipDate";
        public string Price = "Price";
        public string PriceAfVAT = "PriceAfterVAT";
        public string Currency = "Currency";
        public string Rate = "Rate";
        public string DiscPrcnt = "DiscountPercent";
        public string VendorNum = "VendorNum";
        public string SerialNum = "SerialNum";
        public string WhsCode = "WarehouseCode";
        public string SlpCode = "SalesPersonCode";
        public string Commission = "CommisionPercent";
        public string TreeType = "TreeType";
        public string AcctCode = "AccountCode";
        public string UseBaseUn = "UseBaseUnits";
        public string SubCatNum = "SupplierCatNum";
        public string OcrCode = "CostingCode";
        public string Project = "ProjectCode";
        public string CodeBars = "BarCode";
        public string VatGroup = "VatGroup";
        public string Height1 = "Height1";
        public string Hght1Unit = "Hight1Unit";
        public string Height2 = "Height2";
        public string Hght2Unit = "Height2Unit";
        public string Length1 = "Lengh1";
        public string Len1Unit = "Lengh1Unit";
        public string length2 = "Lengh2";
        public string Len2Unit = "Lengh2Unit";
        public string Weight1 = "Weight1";
        public string Wght1Unit = "Weight1Unit";
        public string Weight2 = "Weight2";
        public string Wght2Unit = "Weight2Unit";
        public string Factor1 = "Factor1";
        public string Factor2 = "Factor2";
        public string Factor3 = "Factor3";
        public string Factor4 = "Factor4";
        public string BaseType = "BaseType";
        public string BaseEntry = "BaseEntry";
        public string BaseLine = "BaseLine";
        public string Volume = "Volume";
        public string VolUnit = "VolumeUnit";
        public string Width1 = "Width1";
        public string Wdth1Unit = "Width1Unit";
        public string Width2 = "Width2";
        public string Wdth2Unit = "Width2Unit";
        public string Address = "Address";
        public string TaxCode = "TaxCode";
        public string TaxType = "TaxType";
        public string TaxStatus = "TaxLiable";
        public string BackOrdr = "BackOrder";
        public string FreeTxt = "FreeText";
        public string TrnsCode = "ShippingMethod";
        public string CEECFlag = "CorrectionInvoiceItem";
        public string ToStock = "CorrInvAmountToStock";
        public string ToDiff = "CorrInvAmountToDiffAcct";
        public string WtLiable = "WTLiable";
        public string DeferrTax = "DeferredTax";
        public string unitMsr = "MeasureUnit";
        public string NumPerMsr = "UnitsOfMeasurment";
        public string LineTotal = "LineTotal";
        public string VatPrcnt = "TaxPercentagePerRow";
        public string ConsumeFCT = "ConsumerSalesForecast";
        public string ExciseAmt = "ExciseAmount";
        public string CountryOrg = "CountryOrg";
        public string SWW = "SWW";
        public string TranType = "TransactionType";
        public string DistribExp = "DistributeExpense";
        public string ShipToCode = "ShipToCode";
        public string TotalFrgn = "RowTotalFC";
        public string CFOPCode = "CFOPCode";
        public string CSTCode = "CSTCode";
        public string Usage = "Usage";
        public string TaxOnly = "TaxOnly";
        public string PriceBefDi = "UnitPrice";
        public string LineStatus = "LineStatus";
        public string LineType = "LineType";
        public string CogsOcrCod = "COGSCostingCode";
        public string CogsAcct = "COGSAccountCode";
        public string ChgAsmBoMW = "ChangeAssemlyBoMWarehouse";
        public string GrossBuyPr = "GrossBuyPrice";
        public string GrossBase = "GrossBase";
        public string GPTtlBasPr = "GrossProfitTotalBasePrice";
        public string OcrCode2 = "CostingCode2";
        public string OcrCode3 = "CostingCode3";
        public string OcrCode4 = "CostingCode4";
        public string OcrCode5 = "CostingCode5";
        public string Text = "ItemDetails";
        public string LocCode = "LocationCode";
        public string ActDelDate = "ActualDeliveryDate";
        public string ExLineNo = "ExLineNo";

        public override void Rlp(ref string tmp)
        {
            tmp = Trans(tmp, "DocEntry", DocEntry);
            tmp = Trans(tmp, "DocNum", DocNum);
            tmp = Trans(tmp, "LineNum", LineNum);
            tmp = Trans(tmp, "ItemCode", ItemCode);
            tmp = Trans(tmp, "Dscription", Dscription);
            tmp = Trans(tmp, "Quantity", Quantity);
            tmp = Trans(tmp, "ShipDate", ShipDate);
            tmp = Trans(tmp, "Price", Price);
            tmp = Trans(tmp, "PriceAfVAT", PriceAfVAT);
            tmp = Trans(tmp, "Currency", Currency);
            tmp = Trans(tmp, "Rate", Rate);
            tmp = Trans(tmp, "DiscPrcnt", DiscPrcnt);
            tmp = Trans(tmp, "VendorNum", VendorNum);
            tmp = Trans(tmp, "SerialNum", SerialNum);
            tmp = Trans(tmp, "WhsCode", WhsCode);
            tmp = Trans(tmp, "SlpCode", SlpCode);
            tmp = Trans(tmp, "Commission", Commission);
            tmp = Trans(tmp, "TreeType", TreeType);
            tmp = Trans(tmp, "AcctCode", AcctCode);
            tmp = Trans(tmp, "UseBaseUn", UseBaseUn);
            tmp = Trans(tmp, "SubCatNum", SubCatNum);
            tmp = Trans(tmp, "OcrCode", OcrCode);
            tmp = Trans(tmp, "Project", Project);
            tmp = Trans(tmp, "CodeBars", CodeBars);
            tmp = Trans(tmp, "VatGroup", VatGroup);
            tmp = Trans(tmp, "Height1", Height1);
            tmp = Trans(tmp, "Hght1Unit", Hght1Unit);
            tmp = Trans(tmp, "Height2", Height2);
            tmp = Trans(tmp, "Hght2Unit", Hght2Unit);
            tmp = Trans(tmp, "Length1", Length1);
            tmp = Trans(tmp, "Len1Unit", Len1Unit);
            tmp = Trans(tmp, "length2", length2);
            tmp = Trans(tmp, "Len2Unit", Len2Unit);
            tmp = Trans(tmp, "Weight1", Weight1);
            tmp = Trans(tmp, "Wght1Unit", Wght1Unit);
            tmp = Trans(tmp, "Weight2", Weight2);
            tmp = Trans(tmp, "Wght2Unit", Wght2Unit);
            tmp = Trans(tmp, "Factor1", Factor1);
            tmp = Trans(tmp, "Factor2", Factor2);
            tmp = Trans(tmp, "Factor3", Factor3);
            tmp = Trans(tmp, "Factor4", Factor4);
            tmp = Trans(tmp, "BaseType", BaseType);
            tmp = Trans(tmp, "BaseEntry", BaseEntry);
            tmp = Trans(tmp, "BaseLine", BaseLine);
            tmp = Trans(tmp, "Volume", Volume);
            tmp = Trans(tmp, "VolUnit", VolUnit);
            tmp = Trans(tmp, "Width1", Width1);
            tmp = Trans(tmp, "Wdth1Unit", Wdth1Unit);
            tmp = Trans(tmp, "Width2", Width2);
            tmp = Trans(tmp, "Wdth2Unit", Wdth2Unit);
            tmp = Trans(tmp, "Address", Address);
            tmp = Trans(tmp, "TaxCode", TaxCode);
            tmp = Trans(tmp, "TaxType", TaxType);
            tmp = Trans(tmp, "TaxStatus", TaxStatus);
            tmp = Trans(tmp, "BackOrdr", BackOrdr);
            tmp = Trans(tmp, "FreeTxt", FreeTxt);
            tmp = Trans(tmp, "TrnsCode", TrnsCode);
            tmp = Trans(tmp, "CEECFlag", CEECFlag);
            tmp = Trans(tmp, "ToStock", ToStock);
            tmp = Trans(tmp, "ToDiff", ToDiff);
            tmp = Trans(tmp, "WtLiable", WtLiable);
            tmp = Trans(tmp, "DeferrTax", DeferrTax);
            tmp = Trans(tmp, "unitMsr", unitMsr);
            tmp = Trans(tmp, "NumPerMsr", NumPerMsr);
            tmp = Trans(tmp, "LineTotal", LineTotal);
            tmp = Trans(tmp, "VatPrcnt", VatPrcnt);
            tmp = Trans(tmp, "ConsumeFCT", ConsumeFCT);
            tmp = Trans(tmp, "ExciseAmt", ExciseAmt);
            tmp = Trans(tmp, "CountryOrg", CountryOrg);
            tmp = Trans(tmp, "SWW", SWW);
            tmp = Trans(tmp, "TranType", TranType);
            tmp = Trans(tmp, "DistribExp", DistribExp);
            tmp = Trans(tmp, "ShipToCode", ShipToCode);
            tmp = Trans(tmp, "TotalFrgn", TotalFrgn);
            tmp = Trans(tmp, "CFOPCode", CFOPCode);
            tmp = Trans(tmp, "CSTCode", CSTCode);
            tmp = Trans(tmp, "Usage", Usage);
            tmp = Trans(tmp, "TaxOnly", TaxOnly);
            tmp = Trans(tmp, "PriceBefDi", PriceBefDi);
            tmp = Trans(tmp, "LineStatus", LineStatus);
            tmp = Trans(tmp, "LineType", LineType);
            tmp = Trans(tmp, "CogsOcrCod", CogsOcrCod);
            tmp = Trans(tmp, "CogsAcct", CogsAcct);
            tmp = Trans(tmp, "ChgAsmBoMW", ChgAsmBoMW);
            tmp = Trans(tmp, "GrossBuyPr", GrossBuyPr);
            tmp = Trans(tmp, "GrossBase", GrossBase);
            tmp = Trans(tmp, "GPTtlBasPr", GPTtlBasPr);
            tmp = Trans(tmp, "OcrCode2", OcrCode2);
            tmp = Trans(tmp, "OcrCode3", OcrCode3);
            tmp = Trans(tmp, "OcrCode4", OcrCode4);
            tmp = Trans(tmp, "OcrCode5", OcrCode5);
            tmp = Trans(tmp, "Text", Text);
            tmp = Trans(tmp, "LocCode", LocCode);
            tmp = Trans(tmp, "ActDelDate", ActDelDate);
            tmp = Trans(tmp, "ExLineNo", ExLineNo);
        }
    }
}
