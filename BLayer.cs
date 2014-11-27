using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NAC_Dashboard.Controllers.Models;

namespace NAC_Dashboard.Controllers.Models
{
    public class BLayer 
    {
        DataLayer DL = new DataLayer();

        public DataSet chklogin(String UserName, String Password)
        {
            String[] ParamName = { "@UserName", "@Password" };
            SqlDbType[] ParamType = { SqlDbType.VarChar, SqlDbType.VarChar };
            String[] ParamValue = { UserName, Password };
            return DL.ExecSPDS("userLogin", ParamName, ParamType, ParamValue, false);
        }

        public DataSet getSecondQTRTarget()
        {
            String[] ParamName = { };
            SqlDbType[] ParamType = { };
            String[] ParamValue = { };
            return DL.ExecSPDSNAC("DashboardDailySalesTarget", ParamName, ParamType, ParamValue, false);
        }

        public DataSet rptSalesComparisonTop10Sales(string MetalID, DateTime FromDate, DateTime ToDate)
        {
            String[] ParamName = { "@Metal", "@FROMDATE", "@TODATE" };
            SqlDbType[] ParamType = { SqlDbType.VarChar, SqlDbType.DateTime, SqlDbType.DateTime };
            String[] ParamValue = { MetalID, FromDate.ToString(), ToDate.ToString() };
            return DL.ExecSPDSNAC("DashboardTop10Sales", ParamName, ParamType, ParamValue, false);
        }

        public DataSet rptComparisonTop10Sales(string MetalID, DateTime FromDate, DateTime ToDate)
        {
            String[] ParamName = { "@Metal", "@FROMDATE", "@TODATE" };
            SqlDbType[] ParamType = { SqlDbType.VarChar, SqlDbType.DateTime, SqlDbType.DateTime };
            String[] ParamValue = { MetalID, FromDate.ToString(), ToDate.ToString() };
            return DL.ExecSPDSNAC("DrilldownTop10Sales", ParamName, ParamType, ParamValue, false);
        }

        public DataTable SalesPersonPerform(DateTime fromdate, DateTime ToDate)
        {
            String[] ParamName = { "@FROMDATE", "@TODATE" };
            SqlDbType[] ParamType = { SqlDbType.DateTime, SqlDbType.DateTime };
            String[] ParamValue = { fromdate.ToString(), ToDate.ToString() };
            return DL.ReadDataNAC("DrilldownSalesPersonPerformance", ParamName, ParamType, ParamValue);
        } 

        public DataSet rptSaleAndStockValue(DateTime FromDate, DateTime ToDate)
        {
            String[] ParamName = { "@FROMDATE", "@TODATE" };
            SqlDbType[] ParamType = { SqlDbType.DateTime, SqlDbType.DateTime };
            String[] ParamValue = { FromDate.ToString(), ToDate.ToString() };
            return DL.ExecSPDSNAC("DrillDownDashboardFloorWiseSalesYTD", ParamName, ParamType, ParamValue, false);
        }
        public DataTable rptFloorSale()
        {
            String[] ParamName = {  };
            SqlDbType[] ParamType = {  };
            String[] ParamValue = {  };
            return DL.ReadDataNAC("DashboardFloorWiseSales", ParamName, ParamType, ParamValue);
        }        
        
        public DataTable rptEstimationChartsNAC(DateTime FromDate, DateTime ToDate)
        {
            String[] ParamName = { "@FROMDATE", "@TODATE" };
            SqlDbType[] ParamType = { SqlDbType.DateTime, SqlDbType.DateTime };
            String[] ParamValue = { FromDate.ToString(), ToDate.ToString() };
            return DL.ReadDataNAC("DrilldownEstimationConversion", ParamName, ParamType, ParamValue);
            // GetEstimationCuntReport
        }


        public DataTable rptEstimationCharts()
        {
            String[] ParamName = { };
            SqlDbType[] ParamType = {  };
            String[] ParamValue = {  };
            return DL.ReadDataNAC("DashboardEstimationConversion", ParamName, ParamType, ParamValue);
        }

        public DataTable rptStockFromDrilldown(DateTime ToDate)
        {
            String[] ParamName = { "@EndDate" };
            SqlDbType[] ParamType = { SqlDbType.DateTime };
            String[] ParamValue = { ToDate.ToString() };
            return DL.ReadDataNAC("GetNACStockAgeingDrillDown", ParamName, ParamType, ParamValue);
        }

        public DataTable rptStockReportchild(String ItemCTRID, String ITEMID, String SUBITEMID)
        {
            String[] ParamName = { "@ITEMCTRID", "@ITEMID", "@SUBITEMID" };
            SqlDbType[] ParamType = { SqlDbType.Int, SqlDbType.Int, SqlDbType.Int };
            String[] ParamValue = { ItemCTRID.ToString(), ITEMID.ToString(), SUBITEMID.ToString() };
            return DL.ReadDataNAC("GetNACStockAgeingDrillDownChd", ParamName, ParamType, ParamValue);
        }

        public DataTable rptStockAvailabilty()
        {
            String[] ParamName = {};
            SqlDbType[] ParamType = {};
            String[] ParamValue = {};
            return DL.ReadDataNAC("DashboardStockAvailability", ParamName, ParamType, ParamValue);
        }

        public DataTable rptStockAvailabiltyTable()
        {
            String[] ParamName = { };
            SqlDbType[] ParamType = { };
            String[] ParamValue = { };
            return DL.ReadDataNAC("DashboardStockAvailabilityTable", ParamName, ParamType, ParamValue);
        }
        //ChitCustomerInfo start//

        public DataTable ChitCustomerdataDetails()
        {
            String[] ParamName = { };
            SqlDbType[] ParamType = { };
            String[] ParamValue = { };
            return DL.ReadDataNAC("DashboardChitCustomerInfo", ParamName, ParamType, ParamValue);
        }

        //ChitCustomerInfo end//
        //status remain 
        public DataTable Statusremain()
        {
            String[] ParamName = { };
            SqlDbType[] ParamType = { };
            String[] ParamValue = { };
            return DL.ReadDataNAC("DashboardChitStatusReminder", ParamName, ParamType, ParamValue);
        }
        //status remain ends
        public DataSet getSecondQTRTarg(DateTime fromdate, DateTime todate)
        {
            String[] ParamName = { "@FROMDATE", "@TODATE" };
            SqlDbType[] ParamType = { SqlDbType.DateTime, SqlDbType.DateTime };
            String[] ParamValue = { fromdate.ToString(), todate.ToString() };
            return DL.ExecSPDSNAC("DrillDownDailySaleTarget", ParamName, ParamType, ParamValue, false);
        }

        public DataSet rptSalesPerformance()
        {
            String[] ParamName = {};
            SqlDbType[] ParamType = {};
            String[] ParamValue = {};
            return DL.ExecSPDSNAC("DashboardSalesPersonPerformance", ParamName, ParamType, ParamValue, false);
        }

        public DataSet rptSpecialApprovals()
        {
            String[] ParamName = { };
            SqlDbType[] ParamType = { };
            String[] ParamValue = { };
            return DL.ExecSPDSNAC("DASHBOARDAPPROVALNEW", ParamName, ParamType, ParamValue, false);
        }

        public DataTable rptSalesReturns()
        {
            String[] ParamName = { };
            SqlDbType[] ParamType = { };
            String[] ParamValue = { };
            return DL.ReadDataNAC("DASHBOARDSALES_RETURN", ParamName, ParamType, ParamValue);
        }

        public DataSet Allchit(DateTime FromDate, DateTime ToDate)
        {
            String[] ParamName = { "@FROMDATE", "@TODATE" };
            SqlDbType[] ParamType = { SqlDbType.DateTime, SqlDbType.DateTime };
            String[] ParamValue = { FromDate.ToString(), ToDate.ToString() };
            return DL.ExecSPDSNAC("CHITALLCHARTS", ParamName, ParamType, ParamValue, false);
        }

        public DataTable chits(DateTime FromDate, DateTime ToDate)
        {
            String[] ParamName = { "@FROMDATE", "@TODATE" };
            SqlDbType[] ParamType = { SqlDbType.DateTime, SqlDbType.DateTime };
            String[] ParamValue = { FromDate.ToString(), ToDate.ToString() };
            return DL.ReadDataNAC("ALLChits", ParamName, ParamType, ParamValue);
        }

        public DataTable dashboardChit()
        {
            String[] ParamName = {  };
            SqlDbType[] ParamType = {  };
            String[] ParamValue = {  };
            return DL.ReadDataNAC("DashboardChitsNew", ParamName, ParamType, ParamValue); 
        }
        

        public DataTable TrendinSales()
        {
            String[] ParamName = { };
            SqlDbType[] ParamType = { };
            String[] ParamValue = { };
            return DL.ReadDataNAC("DashboardTrendInSales", ParamName, ParamType, ParamValue);
        }

        public DataSet Ordersummary()
        {
            String[] ParamName = { };
            SqlDbType[] ParamType = { };
            String[] ParamValue = { };
            return DL.ExecSPDSNAC("DashboardOrderReportNew", ParamName, ParamType, ParamValue, false);
        }

        public DataSet Ordersummaryfullrept(DateTime fromdate, DateTime todate)
        {
            String[] ParamName = { "@FROMDATE" ,"@TODATE"};
            SqlDbType[] ParamType = { SqlDbType.DateTime, SqlDbType.DateTime };
            String[] ParamValue = { fromdate.ToString(), todate.ToString() };
            return DL.ExecSPDSNAC("GetOrderStatusAll", ParamName, ParamType, ParamValue, false);
        }


        public DataSet SpecialApprove(DateTime fromdate, DateTime todate)
        {
            String[] ParamName = { "@FRMDATE", "@TODATE" };
            SqlDbType[] ParamType = { SqlDbType.DateTime, SqlDbType.DateTime };
            String[] ParamValue = { fromdate.ToString(), todate.ToString() };
            return DL.ExecSPDSNAC("DRILLDOWNAPPROVAL", ParamName, ParamType, ParamValue, false);
        }

        public DataTable Salesreturn(DateTime FromDate, DateTime ToDate)
        {
            String[] ParamName = { "@FRMDATE", "@TODATE" };
            SqlDbType[] ParamType = { SqlDbType.DateTime, SqlDbType.DateTime };
            String[] ParamValue = { FromDate.ToString(), ToDate.ToString() };
            return DL.ReadDataNAC("SALES_RETURNFULLREPORT", ParamName, ParamType, ParamValue);
        }

        //Finance Bank Credit Limit - START
        public DataTable getBankCreditLimit()
        {
            String[] ParamName = { };
            SqlDbType[] ParamType = { };
            String[] ParamValue = { };
            return DL.ReadDataNACBank("DashboardBankCCLimit", ParamName, ParamType, ParamValue);
        }
        //Finance Bank Credit Limit - END       

        //HR dashboard starts//

        //Top 10 Sales Person Performance - Start
        public DataSet rptSalesPerformanceHR()
        {
            String[] ParamName = { };
            SqlDbType[] ParamType = { };
            String[] ParamValue = { };
            return DL.ExecSPDSNAC("DashboardSalesPersonPerformanceHR", ParamName, ParamType, ParamValue, false);
        }
        //Top 10 Sales Person Performance - End

        //Top 10 Chit Sales - Start
        public DataSet rptTOP10chitHR()
        {
            String[] ParamName = { };
            SqlDbType[] ParamType = { };
            String[] ParamValue = { };
            return DL.ExecSPDSNAC("DashboardChitPerformanceHR", ParamName, ParamType, ParamValue, false);
        }
        //Top 10 Chit Sales - End

        //Top 10 Estimation - Start
        public DataSet rptEstimationHR()
        {
            String[] ParamName = { };
            SqlDbType[] ParamType = { };
            String[] ParamValue = { };
            return DL.ExecSPDSNAC("DashboardEstimationHR", ParamName, ParamType, ParamValue, false);
        }
        //Top 10 Estimation - End

        //Top 10 Estimation Not Saled - Start
        public DataSet rptEstimationnosalHR()
        {
            String[] ParamName = { };
            SqlDbType[] ParamType = { };
            String[] ParamValue = { };
            return DL.ExecSPDSNAC("DashboardEstimationNoSaleHR", ParamName, ParamType, ParamValue, false);
        }
        //Top 10 Estimation Not Saled - End

        //HR dashboard -Ends//

        public DataTable drilldownsalesperformance(DateTime fromdate, DateTime ToDate)
        {
            String[] ParamName = { "@FROMDATE", "@TODATE" };
            SqlDbType[] ParamType = { SqlDbType.DateTime, SqlDbType.DateTime };
            String[] ParamValue = { fromdate.ToString(), ToDate.ToString() };
            return DL.ReadDataNAC("DrillDownSalesPersonPerformanceHR", ParamName, ParamType, ParamValue);
        }       

        public DataTable drilldownFloorwise(DateTime fromdate, DateTime ToDate)
        {
            String[] ParamName = { "@FROMDATE", "@TODATE" };
            SqlDbType[] ParamType = { SqlDbType.DateTime, SqlDbType.DateTime };
            String[] ParamValue = { fromdate.ToString(), ToDate.ToString() };
            return DL.ReadDataNAC("DrillDownChitPerformanceHR", ParamName, ParamType, ParamValue);
        }

        public DataTable DrilldownChit(DateTime FromDate, DateTime ToDate)
        {
            String[] ParamName = { "@FROMDATE", "@TODATE" };
            SqlDbType[] ParamType = { SqlDbType.DateTime, SqlDbType.DateTime };
            String[] ParamValue = { FromDate.ToString(), ToDate.ToString() };
            return DL.ReadDataNAC("DrillDownChit", ParamName, ParamType, ParamValue);
        }

        public DataTable drilldownEstimationnosal(DateTime fromdate, DateTime ToDate)
        {
            String[] ParamName = { "@FROMDATE", "@TODATE" };
            SqlDbType[] ParamType = { SqlDbType.DateTime, SqlDbType.DateTime };
            String[] ParamValue = { fromdate.ToString(), ToDate.ToString() };
            return DL.ReadDataNAC("DrillDownEstimationNoSaleHR", ParamName, ParamType, ParamValue);
        }

        public DataTable drilldownEstimation(DateTime fromdate, DateTime ToDate)
        {
            String[] ParamName = { "@FROMDATE", "@TODATE" };
            SqlDbType[] ParamType = { SqlDbType.DateTime, SqlDbType.DateTime };
            String[] ParamValue = { fromdate.ToString(), ToDate.ToString() };
            return DL.ReadDataNAC("DrillDownEstimationHR", ParamName, ParamType, ParamValue);
        }
        public DataSet rptSalesPerformanceHRdrill(DateTime fromdate, DateTime ToDate)
        {
            String[] ParamName = { "@FROMDATE", "@TODATE" };
            SqlDbType[] ParamType = { SqlDbType.DateTime, SqlDbType.DateTime };
            String[] ParamValue = { fromdate.ToString(), ToDate.ToString() };
            return DL.ExecSPDSNAC("DashboardSalesPersonPerformanceHRDrillDown", ParamName, ParamType, ParamValue, false);
        }
        public DataSet getSecondQTRTargetYTD()
        {
            String[] ParamName = { };
            SqlDbType[] ParamType = { };
            String[] ParamValue = { };
            return DL.ExecSPDSNAC("DashboardDailySalesTargetYTD", ParamName, ParamType, ParamValue, false);
        }

        public DataTable rptFloorSaleYTD()
        {
            String[] ParamName = { };
            SqlDbType[] ParamType = { };
            String[] ParamValue = { };
            return DL.ReadDataNAC("DashboardFloorWiseSalesYTD", ParamName, ParamType, ParamValue);
        }

        public DataTable dashboardChitYTD()
        {
            String[] ParamName = { };
            SqlDbType[] ParamType = { };
            String[] ParamValue = { };
            return DL.ReadDataNAC("DashboardChitsYTDNew", ParamName, ParamType, ParamValue);
        }

        public DataTable rptEstimationChartsYTD()
        {
            String[] ParamName = { };
            SqlDbType[] ParamType = { };
            String[] ParamValue = { };
            return DL.ReadDataNAC("DashboardEstimationConversionYTD", ParamName, ParamType, ParamValue);
        }

        public DataTable getTop10CounterSalesYTD()
        {
            String[] ParamName = { };
            SqlDbType[] ParamType = { };
            String[] ParamValue = { };
            return DL.ReadDataNAC("DashboardTop10SalesCounterwiseYTD", ParamName, ParamType, ParamValue);
        }

        //ACTUALBUDGET
        public DataTable getSalePurchase()
        {
            String[] ParamName = { };
            SqlDbType[] ParamType = { };
            String[] ParamValue = { };
            return DL.ReadDataNAC("DashboardSalesPurchaseGoldPriceYTD", ParamName, ParamType, ParamValue);
        }
        //end

        // Naresh - YDT Comparision SP Call START - Done
        public DataSet getYDTComparision()
        {
            String[] ParamName = { };
            SqlDbType[] ParamType = { };
            String[] ParamValue = { };
            return DL.ExecSPDSNAC("DashboardBillingSalesYTD", ParamName, ParamType, ParamValue, false);
        }

        // Naresh - YDT Comparision SP Call END
        // Naresh - YDT Comparision1 SP Call START - NR
        public DataSet getYDTComparision1()
        {
            String[] ParamName = { };
            SqlDbType[] ParamType = { };
            String[] ParamValue = { };
            return DL.ExecSPDSNAC("YTDCOMPARISION", ParamName, ParamType, ParamValue, false);
        }

        // Naresh - YDT Comparision1 SP Call END
        // Naresh - chit START - Done
        public DataSet getCHITNEW_MTD_YTD()
        {
            String[] ParamName = { };
            SqlDbType[] ParamType = { };
            String[] ParamValue = { };
            return DL.ExecSPDSNAC("DashboardBillingChit", ParamName, ParamType, ParamValue, false);
        }

        // Naresh - chit END
        // Naresh - totsal START
        public DataSet getTOTALSALEVSPURCHASE()
        {
            String[] ParamName = { };
            SqlDbType[] ParamType = { };
            String[] ParamValue = { };
            return DL.ExecSPDSNAC("DashboardBillingSalesVsPurchase", ParamName, ParamType, ParamValue, false);
        }

        // Naresh - totsal END
        // Naresh - CREDIT_APP_OUT START - Done
        public DataSet getCREDIT_APP_OUT()
        {
            String[] ParamName = { };
            SqlDbType[] ParamType = { };
            String[] ParamValue = { };
            return DL.ExecSPDSNAC("DashboardBillingCBAO", ParamName, ParamType, ParamValue, false);
        }

        // Naresh - CREDIT_APP_OUT END
        // Naresh - FLOORWISE_METALSALE START
        public DataSet getFLOORWISE_METALSALE()
        {
            String[] ParamName = { };
            SqlDbType[] ParamType = { };
            String[] ParamValue = { };
            return DL.ExecSPDSNAC("DashboardBillingFloorSales", ParamName, ParamType, ParamValue, false);
        }

        // Naresh - FLOORWISE_METALSALE END




        // Naresh - CARD_CHQ_SALERETURN START
        public DataSet getCARD_CHQ_SALERETURN()
        {
            String[] ParamName = { };
            SqlDbType[] ParamType = { };
            String[] ParamValue = { };
            return DL.ExecSPDSNAC("DashboardBillingTransaction", ParamName, ParamType, ParamValue, false);
        }

        // Naresh - CARD_CHQ_SALERETURN END
        // Naresh - order status START
        public DataSet getorderdiamond()
        {
            String[] ParamName = { };
            SqlDbType[] ParamType = { };
            String[] ParamValue = { };
            return DL.ExecSPDSNAC("DashboardBillingOrderDiamond", ParamName, ParamType, ParamValue, false);
        }
        public DataSet getordergold()
        {
            String[] ParamName = { };
            SqlDbType[] ParamType = { };
            String[] ParamValue = { };
            return DL.ExecSPDSNAC("DashboardBillingOrderGold", ParamName, ParamType, ParamValue, false);
        }
        public DataSet getordersilver()
        {
            String[] ParamName = { };
            SqlDbType[] ParamType = { };
            String[] ParamValue = { };
            return DL.ExecSPDSNAC("DashboardBillingOrderSilver", ParamName, ParamType, ParamValue, false);
        }
        public DataSet getorderpending()
        {
            String[] ParamName = { };
            SqlDbType[] ParamType = { };
            String[] ParamValue = { };
            return DL.ExecSPDSNAC("DashboardBillingOrderPending", ParamName, ParamType, ParamValue, false);
        }
        public DataSet getorderoverdue()
        {
            String[] ParamName = { };
            SqlDbType[] ParamType = { };
            String[] ParamValue = { };
            return DL.ExecSPDSNAC("DashboardBillingOrderOverDue", ParamName, ParamType, ParamValue, false);
        }
        // Naresh - order status END

        //chit-saleret chart
        public DataTable rptchitchqsaleret()
        {
            String[] ParamName = { };
            SqlDbType[] ParamType = { };
            String[] ParamValue = { };
            return DL.ReadDataNAC("DashboardBillingTransaction", ParamName, ParamType, ParamValue);
        }
        //chart floorwise metal sale
        public DataSet chartfloorwisemetal()
        {
            String[] ParamName = { };
            SqlDbType[] ParamType = { };
            String[] ParamValue = { };
            return DL.ExecSPDSNAC("DashboardBillingFloorSales", ParamName, ParamType, ParamValue, false);
        }

        public DataTable getDailysalesshowroom(DateTime fromdate, DateTime ToDate)
        {
            String[] ParamName = { "@FROMDATE", "@TODATE" };
            SqlDbType[] ParamType = { SqlDbType.DateTime, SqlDbType.DateTime };
            String[] ParamValue = { fromdate.ToString(), ToDate.ToString() };
            return DL.ReadDataNAC("DrillDownDailySaleTargetshowroom", ParamName, ParamType, ParamValue);
        }

        //stack chart

        public DataSet dashboardtotsal1()
        {
            String[] ParamName = { };
            SqlDbType[] ParamType = { };
            String[] ParamValue = { };
            return DL.ExecSPDSNAC("DashboardBillingSalesVsPurchase", ParamName, ParamType, ParamValue, false);
        }
        //LINE CHART

        public DataSet dashboardytdcomp()
        {
            String[] ParamName = { };
            SqlDbType[] ParamType = { };
            String[] ParamValue = { };
            return DL.ExecSPDSNAC("DashboardBillingSalesYTD", ParamName, ParamType, ParamValue, false);
        }

        public DataSet rptSalesComparisonTop10SalesYTD(string MetalID, DateTime FromDate, DateTime ToDate)
        {
            String[] ParamName = { "@Metal", "@FROMDATE", "@TODATE" };
            SqlDbType[] ParamType = { SqlDbType.VarChar, SqlDbType.DateTime, SqlDbType.DateTime };
            String[] ParamValue = { MetalID, FromDate.ToString(), ToDate.ToString() };
            return DL.ExecSPDSNAC("DashboardTop10SalesYTD", ParamName, ParamType, ParamValue, false);
        }

        public DataSet rptSalesPerformanceYTD()
        {
            String[] ParamName = { };
            SqlDbType[] ParamType = { };
            String[] ParamValue = { };
            return DL.ExecSPDSNAC("DashboardSalesPersonPerformanceYTD", ParamName, ParamType, ParamValue, false);
        }

        public DataSet OrdersummaryYTD()
        {
            String[] ParamName = { };
            SqlDbType[] ParamType = { };
            String[] ParamValue = { };
            return DL.ExecSPDSNAC("DashboardOrderReportYTDNew", ParamName, ParamType, ParamValue, false);
        }

        public DataSet rptSpecialApprovalsYTD()
        {
            String[] ParamName = { };
            SqlDbType[] ParamType = { };
            String[] ParamValue = {  };
            return DL.ExecSPDSNAC("DASHBOARDAPPROVAL_YTDNEW", ParamName, ParamType, ParamValue, false);
        }

        public DataTable rptSalesReturnsYTD()
        {
            String[] ParamName = {};
            SqlDbType[] ParamType = {};
            String[] ParamValue = { };
            return DL.ReadDataNAC("DASHBOARDSALES_RETURN_YTD", ParamName, ParamType, ParamValue);
        }
        //CHIT COLLECTION STARTS//
        public DataTable TableChitCollection()
        {
            String[] ParamName = { };
            SqlDbType[] ParamType = { };
            String[] ParamValue = { };
            return DL.ReadDataNAC("DashboardChitCollectionTotal", ParamName, ParamType, ParamValue);
        }

        public DataTable ChitPDCRemainder()
        {
            String[] ParamName = { };
            SqlDbType[] ParamType = { };
            String[] ParamValue = { };
            return DL.ReadDataNAC("DashboardPDCChequeReminderTotal", ParamName, ParamType, ParamValue);
        }
        public DataTable ChitPDCRemainderdrilldown(DateTime fromdate, DateTime ToDate)
        {
            String[] ParamName = { "@FROMDATE", "@TODATE" };
            SqlDbType[] ParamType = { SqlDbType.DateTime, SqlDbType.DateTime };
            String[] ParamValue = { fromdate.ToString(), ToDate.ToString() };
            return DL.ReadDataNAC("DashboardPDCChequeReminder", ParamName, ParamType, ParamValue);
        } 
        //end
        public DataTable SalesTargetSILVER()
        {
            String[] ParamName = { };
            SqlDbType[] ParamType = { };
            String[] ParamValue = { };
            return DL.ReadDataNAC("DashboardDailySalesTargetSilvermine", ParamName, ParamType, ParamValue);
        }

        public DataTable SalesTargetSILVERYTD()
        {
            String[] ParamName = { };
            SqlDbType[] ParamType = { };
            String[] ParamValue = { };
            return DL.ReadDataNAC("DashboardDailySalesTargetSilvermineYTD", ParamName, ParamType, ParamValue);
        }

        public DataTable FloorwiseMetalSales()
        {
            String[] ParamName = { };
            SqlDbType[] ParamType = { };
            String[] ParamValue = { };
            return DL.ReadDataNAC("DashboardFloorWiseMetalSales", ParamName, ParamType, ParamValue);
        }

        public DataTable FloorwiseMetalSalesYTD()
        {
            String[] ParamName = { };
            SqlDbType[] ParamType = { };
            String[] ParamValue = { };
            return DL.ReadDataNAC("DashboardFloorWiseMetalSalesYTD", ParamName, ParamType, ParamValue);
        }

        //PDC STARTS
        public DataTable PDCCheque()
        {
            String[] ParamName = { };
            SqlDbType[] ParamType = { };
            String[] ParamValue = { };
            return DL.ReadDataNAC("DashboardPDCChequeReminderPendingDays", ParamName, ParamType, ParamValue);
        }
        //PDC ENDS

        //Floorwise metal YTD starts//
        public DataTable FloorwiseMetalTable()
        {
            String[] ParamName = { };
            SqlDbType[] ParamType = { };
            String[] ParamValue = { };
            return DL.ReadDataNAC("DashboardFloorWiseMetalSalesYTDTable", ParamName, ParamType, ParamValue);
        }
        //Floorwise metal YTD ends//

        //Floorwise metal starts//
        public DataTable FloorwiseMetalTab()
        {
            String[] ParamName = { };
            SqlDbType[] ParamType = { };
            String[] ParamValue = { };
            return DL.ReadDataNAC("DashboardFloorWiseMetalSalesTable", ParamName, ParamType, ParamValue);

        }
            //Floorwise metal ends//

        //Counterwise sales - Start//
        public DataTable getTop10CounterSales()
        {
            String[] ParamName = { };
            SqlDbType[] ParamType = { };
            String[] ParamValue = { };
            return DL.ReadDataNAC("DashboardTop10SalesCounterwise", ParamName, ParamType, ParamValue);
        }
        //Counterwise sales - End//

        public DataTable FloorwiseSaleMetal(DateTime fromdate, DateTime ToDate)
        {
            String[] ParamName = { "@FROMDATE", "@TODATE" };
            SqlDbType[] ParamType = { SqlDbType.DateTime, SqlDbType.DateTime };
            String[] ParamValue = { fromdate.ToString(), ToDate.ToString() };
            return DL.ReadDataNAC("DrilldownFloorWiseMetalSalesTable", ParamName, ParamType, ParamValue);
        }

        //ChitCustomerInfo start//

        public DataTable ChitCustomerdata()
        {
            String[] ParamName = { };
            SqlDbType[] ParamType = { };
            String[] ParamValue = { };
            return DL.ReadDataNAC("DashboardChitCustomerInfo", ParamName, ParamType, ParamValue);
        }

        //ChitCustomerInfo end//

        //counterwise sales starts//
        public DataTable drilldownCounterwise(DateTime fromdate, DateTime todate)
        {
            String[] ParamName = { "@FROMDATE", "@TODATE" };
            SqlDbType[] ParamType = { SqlDbType.DateTime, SqlDbType.DateTime };
            String[] ParamValue = { fromdate.ToString(), todate.ToString() };
            return DL.ReadDataNAC("DrilldownTop10SalesCounterwise", ParamName, ParamType, ParamValue);
        }
        //counterwise sales ends//

        //sales,purchase,avggoldprice starts//
        public DataTable drilldownSalePurchase(DateTime fromdate, DateTime ToDate)
        {
            String[] ParamName = { "@FROMDATE", "@TODATE" };
            SqlDbType[] ParamType = { SqlDbType.DateTime, SqlDbType.DateTime };
            String[] ParamValue = { fromdate.ToString(), ToDate.ToString() };
            return DL.ReadDataNAC("DrilldownSalesPurchaseGoldPriceYTD", ParamName, ParamType, ParamValue);
        }

        public DataTable getDailysalesSILVERmgt(DateTime fromdate, DateTime ToDate)
        {
            String[] ParamName = { "@FROMDATE", "@TODATE" };
            SqlDbType[] ParamType = { SqlDbType.DateTime, SqlDbType.DateTime };
            String[] ParamValue = { fromdate.ToString(), ToDate.ToString() };
            return DL.ReadDataNAC("DrillDownSilvermineMgt", ParamName, ParamType, ParamValue);
        }
        public DataTable getDailysalesSILVERshowroom(DateTime fromdate, DateTime ToDate)
        {
            String[] ParamName = { "@FROMDATE", "@TODATE" };
            SqlDbType[] ParamType = { SqlDbType.DateTime, SqlDbType.DateTime };
            String[] ParamValue = { fromdate.ToString(), ToDate.ToString() };
            return DL.ReadDataNAC("DrillDownSilvermineShowRoom", ParamName, ParamType, ParamValue);
        }
        //Daily chit collection starts
        public DataSet ChitDailyCollections()
        {
            String[] ParamName = { };
            SqlDbType[] ParamType = { };
            String[] ParamValue = { };
            return DL.ExecSPDSNAC("DashboardChitCollection", ParamName, ParamType, ParamValue, false);
        }
        //Daily chit collection ends

        public DataTable rptUserDetails()
        {
            String[] ParamName = { };
            SqlDbType[] ParamType = { };
            String[] ParamValue = { };
            return DL.ReadData("getUserDetailsDashboard", ParamName, ParamType, ParamValue);
        }

        public Int32 DeleteUSer(Int32 userID)
        {
            String[] ParamName = { "@userID" };
            SqlDbType[] ParamType = { SqlDbType.Int, SqlDbType.VarChar };
            String[] ParamValue = { userID.ToString() };
            return DL.ExecSPInt("DeleteUserDashboard", ParamName, ParamType, ParamValue);
        }

        public Int32 InsertUpdateUser(String UserID, String UserName, String Password, String Email, String Phone, String Phone2, String FirstName, String LastName, String CompanyId, String Usertype, String Active, int CreatedBy)
        {
            String[] ParamName = { "@UserID", "@UserName", "@Password", "@Email", "@Phone", "@Phone2", "@FirstName", "@LastName", "@CompanyId", "@UserType", "@Active", "@CreatedByUserId" };
            SqlDbType[] ParamType = { SqlDbType.VarChar, SqlDbType.VarChar, SqlDbType.VarChar, SqlDbType.VarChar, SqlDbType.VarChar, SqlDbType.VarChar, SqlDbType.VarChar, SqlDbType.VarChar, SqlDbType.Int, SqlDbType.Int, SqlDbType.Int, SqlDbType.Int };
            String[] ParamValue = { UserID, UserName, Password, Email, Phone, Phone2, FirstName, LastName, CompanyId, Usertype, Active, Convert.ToString(CreatedBy) };
            return DL.ExecSPInt("InsertUpdateUser", ParamName, ParamType, ParamValue);
        }
    }

    public class logscreen
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }

    public class StockReportDrilldown
    {
        public string ITEMCTRID { get; set; }
        public string ITEMID { get; set; }
        public string SUBITEMID { get; set; }
        public string COUNTER { get; set; }
        public string ITEM { get; set; }
        public string SUBITEM { get; set; }
        public string CPCS { get; set; }
        public string CNETWT { get; set; }
    }

    public class SalesPersonPerform
    {
        public string EMPNAME { get; set; }
        public string TRANNO { get; set; }
        public string NETWT { get; set; }
        public string AMOUNT { get; set; }
    }
   
//naresh hr starts
 public class SalesPersonPerformHR
 {
 public string EMPNAME { get; set; }
 public string SALENETWT { get; set; }
 public string SALECOUNT { get; set; }
 public string SALEDIAWT { get; set; }
 public string SALEAMOUNT { get; set; }
 public string NOSALENETWT { get; set; }
 public string NOSALECOUNT { get; set; }
 public string NOSALEDIAWT { get; set; }
 public string NOSALEAMOUNT { get; set; }
 }
 public class SalesPersonPerformHRdrill
 {
     public string EMPNAME { get; set; }
     public string SALENETWT { get; set; }
     public string SALECOUNT { get; set; }
     public string SALEDIAWT { get; set; }
     public string SALEAMOUNT { get; set; }
     //public string NOSALENETWT { get; set; }
     //public string NOSALECOUNT { get; set; }
     //public string NOSALEDIAWT { get; set; }
     //public string NOSALEAMOUNT { get; set; }
 }
 public class Chithr
 {
 public string EMPNAME { get; set; }
 public string AMOUNT { get; set; }
 public string CHITCOUNT { get; set; }
 }

 public class EstimationHR
 {
 public string EMPNAME { get; set; }
 public string ESTIMATION { get; set; }
 public string SALENETWT { get; set; }
 public string SALECOUNT { get; set; }
 public string SALEDIAWT { get; set; }
 public string SALEAMOUNT { get; set; }
 public string NOSALENETWT { get; set; }
 public string NOSALECOUNT { get; set; }
 public string NOSALEDIAWT { get; set; }
 public string NOSALEAMOUNT { get; set; }
 }
 public class EstimationnosalHR
 {
 public string EMPNAME { get; set; }
 public string SALENETWT { get; set; }
 public string SALECOUNT { get; set; }
 public string SALEDIAWT { get; set; }
 public string SALEAMOUNT { get; set; }
 public string NOSALENETWT { get; set; }
 public string NOSALECOUNT { get; set; }
 public string NOSALEDIAWT { get; set; }
 public string NOSALEAMOUNT { get; set; }
 }
//naresh hr ends
   

    public class DailysalesDrilldown
    {
        public string FLOORNAME { get; set; }
        public string COUNTERNAME { get; set; }
        public string ANNUALTARGET { get; set; }
        public string NETWT { get; set; }
        public string ANNUALTARGETPER { get; set; }
        public string CNETWT { get; set; }
    }

    public class FloorWiseSalesDrilldown
    {
        public string ORDERID { get; set; }
        public string FLOORNAME { get; set; }
        public string NETWT { get; set; }
        public string DIAWT { get; set; }
        public string AMOUNT { get; set; }

    }

    public class FloorChitDrilldown
    {
        public string SCHEMENAME { get; set; }
        public string STATUS { get; set; }
        public string CNT { get; set; }
        public string AMOUNT { get; set; }
    }

    public class SpecialApprovalDrilldown
    {
        public string EMPLOYEE { get; set; }        
        public string ITEMNAME { get; set; }
        public string TOTAL_COUNT { get; set; }
        public string PCS { get; set; }
        public string NETWT { get; set; }
        public string AMOUNT { get; set; }
    }

    public class SalesReturnDrilldown
    {
        public string TRANNO { get; set; }
        public string CUSTOMER { get; set; }
        public string ITEM { get; set; }
        public string NETWT { get; set; }
        public string AMOUNT { get; set; }
    }

    public class OrderSummaryDrilldown
    {
        public string ORDERNO { get; set; }
        public string CUSNAME { get; set; }
        public string EMPNAME { get; set; }
        public string ITEM { get; set; }
        public string SUBITEM { get; set; }
        public string ORDERNAME { get; set; }
        public string ORDATE { get; set; }
        public string REMDATE { get; set; }
        public string DUEDATE { get; set; }
        public string DELIVERYDATE { get; set; }
        public string STATUS { get; set; }
        public string PCS { get; set; }
        public string NETWT { get; set; }
        public string DIAPCS { get; set; }
        public string DIAWT { get; set; }
        public string RATE { get; set; }
        public string VALUE { get; set; }
        public string ADVANCE { get; set; }
        public string DESIGNER { get; set; }
        public string METAL { get; set; }
    }

    public class Top10SalesDrilldown
    {
        public string ITEMNAME { get; set; }
        public string NETWT { get; set; }
        public string AMOUNT { get; set; }
    }

    public class EstimationToConversionDrilldown
    {
        public string FLOORNAME { get; set; }
        public string COUNTERNAME { get; set; }
        public string CONVERSION { get; set; }
        public string ESTCOUNT { get; set; }
        public string ESTAMOUNT { get; set; }
    }

    public class FloorwiseSaleMetalDrilldown
    {
        public string FLOORNAME { get; set; }
        public string GOLD { get; set; }
        public string SILVER { get; set; }
        public string DIAMOND { get; set; }
        public string OTHERS { get; set; }
    }

    public class chitstatus
    {
        public string REGNO { get; set; }
        public string PNAME { get; set; }
        public string SCHEMENAME { get; set; }
        public string JOINDATE { get; set; }
        public string AMOUNT { get; set; }
    }
    public class chitcusinfo
    {
        public string REGNO { get; set; }
        public string PNAME { get; set; }
        public string SCHEMENAME { get; set; }
        public string INSPAID { get; set; }
        public string TOTINS { get; set; }
        public string JOINDATE { get; set; }
        public string BILLNO { get; set; }
        public string AMOUNT { get; set; }
        public string WEIGHT { get; set; }
        public string BONUS { get; set; }
        public string GIFTVALUE { get; set; }
        public string DEDUCTGIFTVALUE { get; set; }
        public string DEDUCTION { get; set; }
        public string TOTALAMT { get; set; }
        public string INIAMOUNT { get; set; }
        public string CLOSEDATE { get; set; }
    }
    public class PDCCheque
    {
        public string PDCRECEIPTNO { get; set; }
        public string PDCRECEIPTDATE { get; set; }
        public string GROUPCODE { get; set; }
        public string REGNO { get; set; }
        public string CHEQUENO { get; set; }
        public string CHEQUEDATE { get; set; }
        public string CHEQUEBANK { get; set; }
        public string CHEQUEAMOUNT { get; set; }
        public string status { get; set; }
    }

    public class CounterwisesalesDrilldown
    {
        public string COUNTERNAME { get; set; }
        public string NETWT { get; set; }
        public string AMOUNT { get; set; }
    }

    public class SalePurchaseDrilldown
    {
        public string WEEKID { get; set; }
        public string SALEAMOUNT { get; set; }
        public string PURCHASEAMOUNT { get; set; }
        public string PRICE { get; set; }
        public string DATERANGE { get; set; }
    }

    public class DailysalesShowroomDrilldown
    {
        public string FLOORNAME { get; set; }
        public string COUNTERNAME { get; set; }
        public string TARGET { get; set; }
        public string NETWT { get; set; }
        public string DAILYTARGETPER { get; set; }
        public string CNETWT { get; set; }
    }

    public class DailysalesSILVERShowroomDrilldown
    {
        public string ITEM { get; set; }
        public string DAILYTARGET { get; set; }
        public string NETWT { get; set; }
        public string DAILYTARGETPER { get; set; }
        public string CNETWT { get; set; }
    }

    public class DailysalesSILVERmgtDrilldown
    {
        public string ITEM { get; set; }
        public string ANNUALTARGET { get; set; }
        public string NETWT { get; set; }
        public string ANNUALTARGETPER { get; set; }
        public string CNETWT { get; set; }
    }
    //Daily chit collection-New
    public class DailyChitCollectionDrilldown
    {
        public string PNAME { get; set; }
        public string PERSONALID { get; set; }
        public string GROUPCODE { get; set; }
        public string SCHEMENAME { get; set; }
        public string JOINDATE { get; set; }
        public string REGNO { get; set; }
        public string AMOUNT { get; set; }
    }
    //Daily chit collection-Existing
    public class DailyChitCollection1Drilldown
    {
        public string PNAME { get; set; }
        public string PERSONALID { get; set; }
        public string GROUPCODE { get; set; }
        public string SCHEMENAME { get; set; }
        public string JOINDATE { get; set; }
        public string RDATE { get; set; }
        public string REGNO { get; set; }
        public string AMOUNT { get; set; }

    }

    //Daily chit collection-ONLINE
    public class DailyChitCollection2Drilldown
    {
        public string PNAME { get; set; }
        public string PERSONALID { get; set; }
        public string GROUPCODE { get; set; }
        public string SCHEMENAME { get; set; }
        public string JOINDATE { get; set; }
        public string RDATE { get; set; }
        public string REGNO { get; set; }
        public string AMOUNT { get; set; }

    }
    public class UserMaster
    {
        public string ID { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Phone2 { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ACTIVE { get; set; }
        public string UserTypeName { get; set; }

    }

}
