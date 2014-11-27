using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NAC_Dashboard.Controllers.Models;
using System.Data;
using System.Collections;
using System.IO;
using System.Data.OleDb;
using System.Text;
using Aspose.Cells;
using System.Reflection;
namespace NAC_Dashboard.Controllers
{
    public class HomeController : Controller
    {
        BLayer BL = new BLayer();
        public ActionResult Index()
        {
            ViewBag.Message = "Modify this template to kick-start your ASP.NET MVC application.";

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Dashboard()
        {
            return View();
        }

        public ActionResult DashboardTable()
        {
            return View();
        }

        public ActionResult DashboardMarketing()
        {
            return View();
        }

        public ActionResult DashboardManagement()
        {
            return View();
        }

        public ActionResult FinanceDashboardTable()
        {
            return View();
        }

        public ActionResult OnlyFinanceDashboardTable()
        {
            return View();
        }

        public ActionResult OnlyMarketingDashboardChart()
        {
            return View();
        }

        public ActionResult OnlyMarketingDashboardTable()
        {
            return View();
        }

        public ActionResult FinanceDashboard()
        {
            return View();
        }

        public ActionResult MarketingDashboardTable()
        {
            return View();
        }

        public ActionResult EstimationNoSaleHR()
        {
            return View();
        }


        public ActionResult ManagementDashboardTable()
        {
            return View();
        }

        public ActionResult DashboardTableHR()
        {
            return View();
        }

        public ActionResult DashboardHR()
        {
            return View();
        }

        public ActionResult DashboardBilling()
        {
            return View();
        }

        public ActionResult BillingDashboardTable()
        {
            return View();
        }

        //TN starts//
        public ActionResult DashboardTN()
        {
            return View();
        }

        public ActionResult DashboardTableTN()
        {
            return View();
        }

        public ActionResult DashboardManagementTN()
        {
            return View();
        }

        public ActionResult ManagementDashboardTableTN()
        {
            return View();
        }

        public ActionResult DashboardMarketingTN()
        {
            return View();
        }

        public ActionResult MarketingDashboardTableTN()
        {
            return View();
        }

        public ActionResult FinanceDashboardTN()
        {
            return View();
        }

        public ActionResult FinanceDashboardTableTN()
        {
            return View();
        }
        public ActionResult DashboardTableHRTN()
        {
            return View();
        }

        public ActionResult DashboardHRTN()
        {
            return View();
        }


        // Daily Target Vs Sales start

        public ActionResult DailySalesVsTarget()
        {
            return View();
        }

        public ActionResult DailySalesVsTargetSILshowroom()
        {
            return View();
        }

        public ActionResult DailySalesVsTargetSILmgt()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        public ActionResult loginscreen(String UN, String Pass)
        {
            DataSet ds = new DataSet();
            Int32 ID;
            String UserName;
            String UserType;
            ds = BL.chklogin(UN, Pass);
            DataTable dtUsers = ds.Tables[0];
            ID = Convert.ToInt32(dtUsers.Rows[0]["Id"].ToString());
            if (ID != -2)
            {
                DataTable dtUserRights = ds.Tables[1];
                Session["dtUserRights"] = dtUserRights;

                UserName = dtUsers.Rows[0]["UserName"].ToString();
                UserType = dtUsers.Rows[0]["UserType"].ToString();
                //UserName = Session["UserName"].ToString();  
                Session["UserName"] = UserName.ToString();
                Session["UserType"] = UserType.ToString();
                String sss = "Success";
                Session["UserID"] = ID;
                //return RedirectToAction("home", "Dashboard");

            }
            else
            {
                UserType = ID.ToString();
            }
            return Json(new
            {
                aaDataUserType = UserType
            }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetUserName()
        {
            string UN = " ";
            //if (Session["UserName"] != "null" || Session["UserName"] != "")
            if (string.IsNullOrEmpty((string)Session["UserName"]))
            {
            }
            else
            {
                UN = Session["UserName"].ToString();
            }

            return Content(UN);

            //return Content(Session["UserName"].ToString());
        }

        public ActionResult GetUserType()
        {
            string UT = " ";
            //if (Session["UserType"] != "null" || Session["UserType"] != "")
            if (string.IsNullOrEmpty((string)Session["UserType"]))
            {
            }
            else
            {
                UT = Session["UserType"].ToString();
            }

            return Content(UT);

            //return Content(Session["UserName"].ToString());
        }

        //status remainder  start
        public ActionResult Statusremainder1()
        {
            DataTable dtstatusremain = BL.Statusremain();
            List<System.Collections.ArrayList> statusremainderilldwn = new List<System.Collections.ArrayList>();
            foreach (DataRow dataRow in dtstatusremain.Rows)
            {
                System.Collections.ArrayList values = new System.Collections.ArrayList();
                foreach (object value in dataRow.ItemArray)
                    values.Add(value);
                statusremainderilldwn.Add(values);
            }
            var model = Enumerable.Range(0, dtstatusremain.Rows.Count).Select(x => new chitstatus
            {
                REGNO = dtstatusremain.Rows[x]["REGNO"].ToString(),
                PNAME = dtstatusremain.Rows[x]["PNAME"].ToString(),
                SCHEMENAME = dtstatusremain.Rows[x]["SCHEMENAME"].ToString(),
                JOINDATE = dtstatusremain.Rows[x]["JOINDATE"].ToString(),
                AMOUNT = dtstatusremain.Rows[x]["AMOUNT"].ToString(),


            });
            return Json(new
            {
                aaData = model,

            }, JsonRequestBehavior.AllowGet);
        }
        //status remainder end
        public ActionResult get2ndQRT(DateTime fromdate, DateTime todate)
        {
            DataSet dsSecondQTRTarget1 = BL.getSecondQTRTarg(fromdate, todate);
            DataTable dtSecondQTRTarget1 = dsSecondQTRTarget1.Tables[0];

            List<System.Collections.ArrayList> SecondQTRTarget1 = new List<System.Collections.ArrayList>();
            foreach (DataRow dataRow in dtSecondQTRTarget1.Rows)
            {
                System.Collections.ArrayList values = new System.Collections.ArrayList();
                foreach (object value in dataRow.ItemArray)
                    values.Add(value);
                SecondQTRTarget1.Add(values);
            }
            var model = Enumerable.Range(0, dtSecondQTRTarget1.Rows.Count).Select(x => new DailysalesDrilldown
            {
                FLOORNAME = dtSecondQTRTarget1.Rows[x]["FLOORNAME"].ToString(),
                COUNTERNAME = dtSecondQTRTarget1.Rows[x]["COUNTERNAME"].ToString(),
                ANNUALTARGET = dtSecondQTRTarget1.Rows[x]["ANNUALTARGET"].ToString(),
                NETWT = dtSecondQTRTarget1.Rows[x]["NETWT"].ToString(),
                ANNUALTARGETPER = dtSecondQTRTarget1.Rows[x]["ANNUALTARGETPER"].ToString(),
                CNETWT = dtSecondQTRTarget1.Rows[x]["CNETWT"].ToString()
            });
            return Json(new
            {
                aaData = model,

            }, JsonRequestBehavior.AllowGet);

        }
        // ChitCustomerInfo starts//

        public ActionResult ChitCustomerdetails()
        {
            DataTable DTChitCustomerInfo = BL.ChitCustomerdataDetails();
            Session["DTChitCustomerInfo"] = DTChitCustomerInfo;
            List<System.Collections.ArrayList> DTChitCustomerInfodata = new List<System.Collections.ArrayList>();
            foreach (DataRow dataRow in DTChitCustomerInfo.Rows)
            {
                System.Collections.ArrayList values = new System.Collections.ArrayList();
                foreach (object value in dataRow.ItemArray)
                    values.Add(value);
                DTChitCustomerInfodata.Add(values);
            }
            var model = Enumerable.Range(0, DTChitCustomerInfo.Rows.Count).Select(x => new chitcusinfo
            {
                REGNO = DTChitCustomerInfo.Rows[x]["REGNO"].ToString(),
                PNAME = DTChitCustomerInfo.Rows[x]["PNAME"].ToString(),
                SCHEMENAME = DTChitCustomerInfo.Rows[x]["SCHEMENAME"].ToString(),
                INSPAID = DTChitCustomerInfo.Rows[x]["INSPAID"].ToString(),
                TOTINS = DTChitCustomerInfo.Rows[x]["TOTINS"].ToString(),
                JOINDATE = DTChitCustomerInfo.Rows[x]["JOINDATE"].ToString(),
                BILLNO = DTChitCustomerInfo.Rows[x]["BILLNO"].ToString(),
                AMOUNT = DTChitCustomerInfo.Rows[x]["AMOUNT"].ToString(),
                WEIGHT = DTChitCustomerInfo.Rows[x]["WEIGHT"].ToString(),
                BONUS = DTChitCustomerInfo.Rows[x]["BONUS"].ToString(),
                GIFTVALUE = DTChitCustomerInfo.Rows[x]["GIFTVALUE"].ToString(),
                DEDUCTGIFTVALUE = DTChitCustomerInfo.Rows[x]["DEDUCTGIFTVALUE"].ToString(),
                DEDUCTION = DTChitCustomerInfo.Rows[x]["DEDUCTION"].ToString(),
                TOTALAMT = DTChitCustomerInfo.Rows[x]["TOTALAMT"].ToString(),
                INIAMOUNT = DTChitCustomerInfo.Rows[x]["INIAMOUNT"].ToString(),
                CLOSEDATE = DTChitCustomerInfo.Rows[x]["CLOSEDATE"].ToString(),

            });

            return Json(new
            {
                aaData = model,

            }, JsonRequestBehavior.AllowGet);

        }

        //ChitCustomerInfo ends//
        // StoreWise Sales         

        public ActionResult DrilldownComparisonTop10(String MetalID, DateTime FromDate, DateTime ToDate)
        {
            DataSet dsComparisonTop10Sal = BL.rptComparisonTop10Sales(MetalID, FromDate, ToDate);
            Session["dsComparisonTop10Sal"] = dsComparisonTop10Sal;
            DataTable dtSalesComparisonPieChartML = dsComparisonTop10Sal.Tables[0];
            DataTable dtSalesComparisonTableML = dsComparisonTop10Sal.Tables[1];

            List<System.Collections.ArrayList> SalesComparisonChartML = new List<System.Collections.ArrayList>();
            foreach (DataRow dataRow in dtSalesComparisonPieChartML.Rows)
            {
                System.Collections.ArrayList values = new System.Collections.ArrayList();
                foreach (object value in dataRow.ItemArray)
                    values.Add(value);
                SalesComparisonChartML.Add(values);
            }

            var model = Enumerable.Range(0, dtSalesComparisonPieChartML.Rows.Count).Select(x => new Top10SalesDrilldown
            {
                ITEMNAME = dtSalesComparisonPieChartML.Rows[x]["ITEMNAME"].ToString(),
                NETWT = dtSalesComparisonPieChartML.Rows[x]["NETWT"].ToString(),
                AMOUNT = dtSalesComparisonPieChartML.Rows[x]["AMOUNT"].ToString(),

            });

            return Json(new
            {
                aaData = model,
                //aaDataMLTAble = ComparisonSalTableML,

            }, JsonRequestBehavior.AllowGet);
        }

        //For Daily vs Target showroom - Start

        public ActionResult DailySalesVsTargetShowroom()
        {
            return View();
        }

        public ActionResult getDailySalesTargetshowroom(DateTime fromdate, DateTime todate)
        {
            DataTable dtSecondQTRTargetshowroom = BL.getDailysalesshowroom(fromdate, todate);

            List<System.Collections.ArrayList> SecondQTRTargetshowroom = new List<System.Collections.ArrayList>();
            foreach (DataRow dataRow in dtSecondQTRTargetshowroom.Rows)
            {
                System.Collections.ArrayList values = new System.Collections.ArrayList();
                foreach (object value in dataRow.ItemArray)
                    values.Add(value);
                SecondQTRTargetshowroom.Add(values);
            }
            var model = Enumerable.Range(0, dtSecondQTRTargetshowroom.Rows.Count).Select(x => new DailysalesShowroomDrilldown
            {
                FLOORNAME = dtSecondQTRTargetshowroom.Rows[x]["FLOORNAME"].ToString(),
                COUNTERNAME = dtSecondQTRTargetshowroom.Rows[x]["COUNTERNAME"].ToString(),
                TARGET = dtSecondQTRTargetshowroom.Rows[x]["TARGET"].ToString(),
                NETWT = dtSecondQTRTargetshowroom.Rows[x]["NETWT"].ToString(),
                DAILYTARGETPER = dtSecondQTRTargetshowroom.Rows[x]["DAILYTARGETPER"].ToString(),
                CNETWT = dtSecondQTRTargetshowroom.Rows[x]["CNETWT"].ToString()
            });
            return Json(new
            {
                aaData = model,

            }, JsonRequestBehavior.AllowGet);

        }

        //For Daily vs Target showroom - End

        // Floor Wise sale
        public ActionResult FloorwiseSales()
        {
            return View();
        }

        public ActionResult FloorwiseSalesss(DateTime FromDate, DateTime ToDate)
        {
            DataSet dsSalesandStockrpt = BL.rptSaleAndStockValue(FromDate, ToDate);
            DataTable dtSalesandStockrpt = dsSalesandStockrpt.Tables[0];
            //DataTable dtSalesandStocktotal = dsSalesandStockrpt.Tables[1];

            List<System.Collections.ArrayList> dtSalesandStockrptChartML = new List<System.Collections.ArrayList>();
            foreach (DataRow dataRow in dtSalesandStockrpt.Rows)
            {
                System.Collections.ArrayList values = new System.Collections.ArrayList();
                foreach (object value in dataRow.ItemArray)
                    values.Add(value);
                dtSalesandStockrptChartML.Add(values);
            }
            var model = Enumerable.Range(0, dtSalesandStockrpt.Rows.Count).Select(x => new FloorWiseSalesDrilldown
            {
                ORDERID = dtSalesandStockrpt.Rows[x]["ORDERID"].ToString(),
                FLOORNAME = dtSalesandStockrpt.Rows[x]["FLOORNAME"].ToString(),
                NETWT = dtSalesandStockrpt.Rows[x]["NETWT"].ToString(),
                DIAWT = dtSalesandStockrpt.Rows[x]["DIAWT"].ToString(),
                AMOUNT = dtSalesandStockrpt.Rows[x]["AMOUNT"].ToString(),

            });
            return Json(new
            {
                aaData = model,

            }, JsonRequestBehavior.AllowGet);
        }



        // Estimation Conversion start//

        public ActionResult EstimationConversion()
        {
            return View();
        }

        public ActionResult EstimationToConversion(DateTime FromDate, DateTime ToDate)
        {
            DataTable dtEstimationReport = BL.rptEstimationChartsNAC(FromDate, ToDate);
            List<System.Collections.ArrayList> EstimationRpt = new List<System.Collections.ArrayList>();
            foreach (DataRow dataRow in dtEstimationReport.Rows)
            {
                System.Collections.ArrayList values = new System.Collections.ArrayList();
                foreach (object value in dataRow.ItemArray)
                    values.Add(value);
                EstimationRpt.Add(values);
            }
            //var model = EstimationRpt;
            var model = Enumerable.Range(0, dtEstimationReport.Rows.Count).Select(x => new EstimationToConversionDrilldown
            {
                FLOORNAME = dtEstimationReport.Rows[x]["FLOORNAME"].ToString(),
                COUNTERNAME = dtEstimationReport.Rows[x]["COUNTERNAME"].ToString(),
                CONVERSION = dtEstimationReport.Rows[x]["CONVERSION"].ToString(),
                ESTCOUNT = dtEstimationReport.Rows[x]["ESTCOUNT"].ToString(),
                ESTAMOUNT = dtEstimationReport.Rows[x]["ESTAMOUNT"].ToString(),
            });

            return Json(new
            {
                aaData = model,

            }, JsonRequestBehavior.AllowGet);
        }

        //Stock Report

        public ActionResult StockReportDrilldown()
        {
            return View();
        }

        public ActionResult StockAgeing()
        {
            return View();
        }

        public ActionResult GetStockReportDrilldown(DateTime ToDate)
        {
            // ToDate = "2014-10-10";
            //DateTime EndDate = Convert.ToDateTime(ToDate);
            DataTable dtStockReport = BL.rptStockFromDrilldown(ToDate);
            Session["dtStockReport"] = dtStockReport;
            List<System.Collections.ArrayList> StockReport = new List<System.Collections.ArrayList>();
            foreach (DataRow dataRow in dtStockReport.Rows)
            {
                System.Collections.ArrayList values = new System.Collections.ArrayList();
                foreach (object value in dataRow.ItemArray)
                    values.Add(value);
                StockReport.Add(values);
            }
            var model = Enumerable.Range(0, dtStockReport.Rows.Count).Select(x => new StockReportDrilldown
            {
                ITEMCTRID = dtStockReport.Rows[x]["ITEMCTRID"].ToString(),
                ITEMID = dtStockReport.Rows[x]["ITEMID"].ToString(),
                SUBITEMID = dtStockReport.Rows[x]["SUBITEMID"].ToString(),
                COUNTER = dtStockReport.Rows[x]["COUNTER"].ToString(),
                ITEM = dtStockReport.Rows[x]["ITEMNAME"].ToString(),
                SUBITEM = dtStockReport.Rows[x]["SUBITEMNAME"].ToString(),
                CPCS = dtStockReport.Rows[x]["CPCS"].ToString(),
                CNETWT = dtStockReport.Rows[x]["CNETWT"].ToString(),
            });
            // var model = StockReport;
            return Json(new
            {
                aaData = model
            }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult GetStockReportchild(String ItemCTRID, String ITEMID, String SUBITEMID)
        {
            DataTable dtStockReportChild = BL.rptStockReportchild(ItemCTRID.ToString(), ITEMID.ToString(), SUBITEMID.ToString());
            Session["dtStockReport"] = dtStockReportChild;
            String ChildTableStart = "<div class=\"innerDetails\" > <table style=\"width: 100%;border: 0px; border-color: green; border-style: solid;\"><tr><td align=\"center\" > <table cellpadding=\"5\" cellspacing=\"0\"  border=\"1\" style=\"width: 80%;border: 0px; border-color: red; border-style: solid; padding-left:50px; font-family:Book Antiqua; width:800px;font-size:small \"> <tr style=\"font-weight:bold;  width:800px; color:black; \"><td>RECDATE</td><td>TAGNO</td><td align=\"center\">CPCS</td><td align=\"center\">CNETWT</td><td align=\"center\">AgeingDays</td></tr>";
            String ChildTableContent = "";
            for (int x = 0; x < dtStockReportChild.Rows.Count; x++)
            {
                if (x % 2 == 0)
                {
                    ChildTableContent = ChildTableContent + "<tr style=\" background-color:white; color:black; \"><td td align=left>"
                        + dtStockReportChild.Rows[x]["RECDATE"].ToString()
                        + "</td><td align=left>" + dtStockReportChild.Rows[x]["TAGNO"].ToString()
                        + "</td><td align=center>" + dtStockReportChild.Rows[x]["CPCS"].ToString()
                        + "</td><td align=center>" + dtStockReportChild.Rows[x]["CNETWT"].ToString()
                        + "</td><td align=center>" + dtStockReportChild.Rows[x]["AgeingDays"].ToString()
                        + "</tr>";
                }
                else
                {
                    ChildTableContent = ChildTableContent + "<tr style=\" background-color:#E6ECEF; color:black; \"><td td align=left>"
                         + dtStockReportChild.Rows[x]["RECDATE"].ToString()
                        + "</td><td align=left>" + dtStockReportChild.Rows[x]["TAGNO"].ToString()
                        + "</td><td align=center>" + dtStockReportChild.Rows[x]["CPCS"].ToString()
                        + "</td><td align=center>" + dtStockReportChild.Rows[x]["CNETWT"].ToString()
                        + "</td><td align=center>" + dtStockReportChild.Rows[x]["AgeingDays"].ToString()
                        + "</tr>";
                }
            }

            String ChildTableEnd = "</table></th> </td></tr></table></div>";
            String complete = ChildTableStart + ChildTableContent + ChildTableEnd;
            return Json(new
            {
                complete = complete
            }, JsonRequestBehavior.AllowGet);

        }

        public ActionResult BtnDowloadStockReport()
        {
            DataTable dtExcel = Session["dtStockReport"] as DataTable;
            Stream stream = new System.IO.MemoryStream();

            if (dtExcel != null && dtExcel.Rows.Count > 0)
            {
                Aspose.Cells.License license = new Aspose.Cells.License();
                license.SetLicense("Aspose.Cells.lic");
                Workbook workbook = new Workbook();

                Worksheet sheetspend = workbook.Worksheets[0];
                sheetspend.Name = "Stock Report";
                Cells cells = sheetspend.Cells;

                cells.ImportDataTable(dtExcel, true, 0, 0, dtExcel.Rows.Count, dtExcel.Columns.Count);
                workbook.Save(stream, FileFormatType.Excel2007Xlsx);
                stream.Position = 0;
            }

            return File(stream, "application/vnd.ms-excel", "Stock Report.Xlsx");

            //return Json(result, JsonRequestBehavior.AllowGet);
        }



        //FloorWise Sale

        //public ActionResult ChartSaleAndStockValueReport(String FromDate, String ToDate)
        //{
        //    DateTime startDate = Convert.ToDateTime(FromDate);
        //    DateTime EndDate = Convert.ToDateTime(ToDate);
        //    DataSet dsSalesandStockrpt = BL.rptSaleAndStockValue(startDate, EndDate);
        //    DataTable dtSalesandStockrpt = dsSalesandStockrpt.Tables[0];
        //    DataTable dtSalesandStocktotal = dsSalesandStockrpt.Tables[1];
        //    Session["dtEstCntrpt"] = dtSalesandStockrpt;
        //    List<string> categories = new List<string>();
        //    List<double> SaleAmt = new List<double>();
        //    List<double> SalesValue = new List<double>();
        //    List<double> SalesTurnovr = new List<double>();

        //    for (int j = 0; j < dtSalesandStockrpt.Rows.Count; j++)
        //    {
        //        categories.Add(dtSalesandStockrpt.Rows[j][1].ToString());
        //    }
        //    for (int j = 0; j < dtSalesandStockrpt.Rows.Count; j++)
        //    {
        //        SaleAmt.Add(Convert.ToDouble(dtSalesandStockrpt.Rows[j][2].ToString()));
        //    }
        //    for (int j = 0; j < dtSalesandStockrpt.Rows.Count; j++)
        //    {
        //        SalesValue.Add(Convert.ToDouble(dtSalesandStockrpt.Rows[j][4].ToString()));
        //    }
        //    for (int j = 0; j < dtSalesandStockrpt.Rows.Count; j++)
        //    {
        //        SalesTurnovr.Add(Convert.ToDouble(dtSalesandStockrpt.Rows[j][6].ToString()));
        //    }

        //    List<double> SalesTotal = new List<double>();
        //    List<double> CLStockTotal = new List<double>();

        //    for (int j = 0; j < dtSalesandStocktotal.Rows.Count; j++)
        //    {
        //        SalesTotal.Add(Convert.ToDouble(dtSalesandStocktotal.Rows[j][0].ToString()));
        //    }
        //    for (int j = 0; j < dtSalesandStocktotal.Rows.Count; j++)
        //    {
        //        CLStockTotal.Add(Convert.ToDouble(dtSalesandStocktotal.Rows[j][1].ToString()));
        //    }

        //    var SalesAmt = SaleAmt;
        //    var SaleValue = SalesValue;
        //    var SaleTurnovr = SalesTurnovr;
        //    var XAxis = categories;

        //    var SalesTOT = SalesTotal;
        //    var CLStockTot = CLStockTotal;

        //    return Json(new
        //    {
        //        aaDataSalesAmt = SalesAmt,
        //        aaDataSalesValue = SaleValue,
        //        aaDataSalesTurnOvr = SaleTurnovr,
        //        aaDataAxis = XAxis,

        //        aaDataSalesTotal = SalesTOT,
        //        aaDataClStockTotal = CLStockTot,

        //    }, JsonRequestBehavior.AllowGet);
        //}

        //Sales Person Performance
        public ActionResult SalesPersonPerformance()
        {
            return View();
        }

        public ActionResult GetSalesPerformanceFulldata(DateTime Fromdate, DateTime Todate)
        {
            DataTable DTSalesPerformanceFulldata = BL.SalesPersonPerform(Fromdate, Todate);

            List<System.Collections.ArrayList> SalesPerformanceFulldata = new List<System.Collections.ArrayList>();
            foreach (DataRow dataRow in DTSalesPerformanceFulldata.Rows)
            {
                System.Collections.ArrayList values = new System.Collections.ArrayList();
                foreach (object value in dataRow.ItemArray)
                    values.Add(value);
                SalesPerformanceFulldata.Add(values);
            }
            var model = Enumerable.Range(0, DTSalesPerformanceFulldata.Rows.Count).Select(x => new SalesPersonPerform
            {
                EMPNAME = DTSalesPerformanceFulldata.Rows[x]["EMPNAME"].ToString(),
                TRANNO = DTSalesPerformanceFulldata.Rows[x]["TRANNO_CNT"].ToString(),
                NETWT = DTSalesPerformanceFulldata.Rows[x]["NETWT"].ToString(),
                AMOUNT = DTSalesPerformanceFulldata.Rows[x]["AMOUNT"].ToString(),

            });
            // var model = StockReport;
            return Json(new
            {
                aaData = model
            }, JsonRequestBehavior.AllowGet);

        }

        //StoreWise Sale//

        public ActionResult StoreWiseSales()
        {
            return View();
        }

        // ALLCHITS

        public ActionResult FloorwiseChit()
        {
            return View();
        }

        //public ActionResult Dashboardchit()
        //{
        //    DataTable DtdashboardChit = BL.dashboardChit();
        //    Session["DtdashboardChit"] = DtdashboardChit;
        //    List<System.Collections.ArrayList> Dashboardchitrpt = new List<System.Collections.ArrayList>();
        //    foreach (DataRow dataRow in DtdashboardChit.Rows)
        //    {
        //        System.Collections.ArrayList values = new System.Collections.ArrayList();
        //        foreach (object value in dataRow.ItemArray)
        //            values.Add(value);
        //        Dashboardchitrpt.Add(values);
        //    }
        //    var dtDashboardchitrpt = Dashboardchitrpt;
        //    return Json(new
        //    {
        //        aaDataDashboardchitrpt = dtDashboardchitrpt,

        //    }, JsonRequestBehavior.AllowGet);
        //}

        public ActionResult floorchit(DateTime fromdate, DateTime todate)
        {
            DataTable dsAllChit = BL.DrilldownChit(fromdate, todate);
            Session["dsAllChit"] = dsAllChit;
            List<System.Collections.ArrayList> chitrpt = new List<System.Collections.ArrayList>();
            foreach (DataRow dataRow in dsAllChit.Rows)
            {
                System.Collections.ArrayList values = new System.Collections.ArrayList();
                foreach (object value in dataRow.ItemArray)
                    values.Add(value);
                chitrpt.Add(values);
            }
            var model = Enumerable.Range(0, dsAllChit.Rows.Count).Select(x => new FloorChitDrilldown
            {
                SCHEMENAME = dsAllChit.Rows[x]["SCHEMENAME"].ToString(),
                STATUS = dsAllChit.Rows[x]["STATUS"].ToString(),
                CNT = dsAllChit.Rows[x]["CNT"].ToString(),
                AMOUNT = dsAllChit.Rows[x]["AMOUNT"].ToString(),
            });

            return Json(new
            {
                aaData = model,

            }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult ALLCHITS(String FromDate, String ToDate)
        {
            FromDate = "2014-01-01";
            ToDate = "2014-01-01";
            DateTime startDate = Convert.ToDateTime(FromDate);
            DateTime EndDate = Convert.ToDateTime(ToDate);
            DataSet dsAllChit = BL.Allchit(startDate, EndDate);
            Session["dsAllChit"] = dsAllChit;

            // total chit data
            DataTable dtchitmylapore = dsAllChit.Tables[0];
            DataTable dtchittnagar = dsAllChit.Tables[1];

            List<double> chitTotalML = new List<double>();
            List<string> categoriesTotalML = new List<string>();

            List<double> chitTotalTN = new List<double>();
            List<string> categoriesTotalTN = new List<string>();

            for (int j = 0; j < dtchitmylapore.Rows.Count; j++)
            {
                categoriesTotalML.Add(dtchitmylapore.Rows[j][0].ToString());
            }
            for (int j = 0; j < dtchitmylapore.Rows.Count; j++)
            {
                chitTotalML.Add(Convert.ToDouble(dtchitmylapore.Rows[j][1].ToString()));
            }

            for (int j = 0; j < dtchittnagar.Rows.Count; j++)
            {
                categoriesTotalTN.Add(dtchittnagar.Rows[j][0].ToString());
            }
            for (int j = 0; j < dtchittnagar.Rows.Count; j++)
            {
                chitTotalTN.Add(Convert.ToDouble(dtchittnagar.Rows[j][1].ToString()));
            }

            List<System.Collections.ArrayList> totchitML = new List<System.Collections.ArrayList>();
            foreach (DataRow dataRow in dtchitmylapore.Rows)
            {
                System.Collections.ArrayList values = new System.Collections.ArrayList();
                foreach (object value in dataRow.ItemArray)
                    values.Add(value);
                totchitML.Add(values);
            }

            List<System.Collections.ArrayList> totchitTN = new List<System.Collections.ArrayList>();
            foreach (DataRow dataRow in dtchittnagar.Rows)
            {
                System.Collections.ArrayList values = new System.Collections.ArrayList();
                foreach (object value in dataRow.ItemArray)
                    values.Add(value);
                totchitTN.Add(values);
            }
            var YAxismlTotal = totchitML;
            var XAxismlTotal = categoriesTotalML;
            var YAxistnTotal = totchitTN;
            var XAxistnTotal = categoriesTotalTN;

            // new chit data
            DataTable dtNewChitML = dsAllChit.Tables[2];
            DataTable dtNewChitTN = dsAllChit.Tables[3];

            List<string> categoriesnewML = new List<string>();
            List<double> newchitAMTML = new List<double>();
            List<double> newchitCNTML = new List<double>();

            List<string> categoriesnewTN = new List<string>();
            List<double> newchitAMTTN = new List<double>();
            List<double> newchitCNTTN = new List<double>();


            for (int j = 0; j < dtNewChitML.Rows.Count; j++)
            {
                categoriesnewML.Add(dtNewChitML.Rows[j][0].ToString());
            }
            for (int j = 0; j < dtNewChitML.Rows.Count; j++)
            {
                newchitAMTML.Add(Convert.ToDouble(dtNewChitML.Rows[j][1].ToString()));
            }
            for (int j = 0; j < dtNewChitML.Rows.Count; j++)
            {
                newchitCNTML.Add(Convert.ToDouble(dtNewChitML.Rows[j][2].ToString()));
            }


            for (int j = 0; j < dtNewChitTN.Rows.Count; j++)
            {
                categoriesnewTN.Add(dtNewChitTN.Rows[j][0].ToString());
            }
            for (int j = 0; j < dtNewChitTN.Rows.Count; j++)
            {
                newchitAMTTN.Add(Convert.ToDouble(dtNewChitTN.Rows[j][1].ToString()));
            }
            for (int j = 0; j < dtNewChitTN.Rows.Count; j++)
            {
                newchitCNTTN.Add(Convert.ToDouble(dtNewChitTN.Rows[j][2].ToString()));
            }

            List<System.Collections.ArrayList> NEWCHITMLData = new List<System.Collections.ArrayList>();
            foreach (DataRow dataRow in dtNewChitML.Rows)
            {
                System.Collections.ArrayList values = new System.Collections.ArrayList();
                foreach (object value in dataRow.ItemArray)
                    values.Add(value);
                NEWCHITMLData.Add(values);
            }
            List<System.Collections.ArrayList> NEWCHITTNData = new List<System.Collections.ArrayList>();
            foreach (DataRow dataRow in dtNewChitTN.Rows)
            {
                System.Collections.ArrayList values = new System.Collections.ArrayList();
                foreach (object value in dataRow.ItemArray)
                    values.Add(value);
                NEWCHITTNData.Add(values);
            }
            var YAxismlNew = NEWCHITMLData;
            var XAxismlNew = categoriesnewML;
            var YAxistnNew = NEWCHITTNData;
            var XAxistnNew = categoriesnewTN;

            // matured data
            DataTable dtMaturedChitML = dsAllChit.Tables[4];
            DataTable dtMaturedChitTN = dsAllChit.Tables[5];

            List<string> MaturedcategoriesML = new List<string>();
            List<double> MaturedchitAMTML = new List<double>();
            List<double> MaturedchitCNTML = new List<double>();
            List<double> MaturedchitTotalAmtML = new List<double>();

            List<string> MaturedcategoriesTN = new List<string>();
            List<double> MaturedchitAMTTN = new List<double>();
            List<double> MaturedchitCNTTN = new List<double>();
            List<double> MaturedchitTotalAmtTN = new List<double>();


            for (int j = 0; j < dtMaturedChitML.Rows.Count; j++)
            {
                MaturedcategoriesML.Add(dtMaturedChitML.Rows[j][0].ToString());
            }
            for (int j = 0; j < dtMaturedChitML.Rows.Count; j++)
            {
                MaturedchitAMTML.Add(Convert.ToDouble(dtMaturedChitML.Rows[j][1].ToString()));
            }
            for (int j = 0; j < dtMaturedChitML.Rows.Count; j++)
            {
                MaturedchitCNTML.Add(Convert.ToDouble(dtMaturedChitML.Rows[j][3].ToString()));
            }
            for (int j = 0; j < dtMaturedChitML.Rows.Count; j++)
            {
                MaturedchitTotalAmtML.Add(Convert.ToDouble(dtMaturedChitML.Rows[j][2].ToString()));
            }


            for (int j = 0; j < dtMaturedChitTN.Rows.Count; j++)
            {
                MaturedcategoriesTN.Add(dtMaturedChitTN.Rows[j][0].ToString());
            }
            for (int j = 0; j < dtMaturedChitTN.Rows.Count; j++)
            {
                MaturedchitAMTTN.Add(Convert.ToDouble(dtMaturedChitTN.Rows[j][1].ToString()));
            }
            for (int j = 0; j < dtMaturedChitTN.Rows.Count; j++)
            {
                MaturedchitCNTTN.Add(Convert.ToDouble(dtMaturedChitTN.Rows[j][3].ToString()));
            }
            for (int j = 0; j < dtMaturedChitTN.Rows.Count; j++)
            {
                MaturedchitTotalAmtTN.Add(Convert.ToDouble(dtMaturedChitTN.Rows[j][2].ToString()));
            }

            List<System.Collections.ArrayList> MaturedCHITMLData = new List<System.Collections.ArrayList>();
            foreach (DataRow dataRow in dtNewChitML.Rows)
            {
                System.Collections.ArrayList values = new System.Collections.ArrayList();
                foreach (object value in dataRow.ItemArray)
                    values.Add(value);
                MaturedCHITMLData.Add(values);
            }
            List<System.Collections.ArrayList> MaturedCHITTNData = new List<System.Collections.ArrayList>();
            foreach (DataRow dataRow in dtNewChitTN.Rows)
            {
                System.Collections.ArrayList values = new System.Collections.ArrayList();
                foreach (object value in dataRow.ItemArray)
                    values.Add(value);
                MaturedCHITTNData.Add(values);
            }
            var YAxismlMatured = MaturedCHITMLData;
            var XAxismlMatured = MaturedcategoriesML;
            var YAxistnMatured = MaturedCHITTNData;
            var XAxistnMatured = MaturedcategoriesTN;

            // Discontinued data
            DataTable dtDiscontinuedChitML = dsAllChit.Tables[6];
            DataTable dtDiscontinuedChitTN = dsAllChit.Tables[7];

            List<string> DiscontinuedcategoriesML = new List<string>();
            List<double> DiscontinuedchitAMTML = new List<double>();
            List<double> DiscontinuedchitCNTML = new List<double>();
            List<double> DiscontinuedchitTotalAmtML = new List<double>();

            List<string> DiscontinuedcategoriesTN = new List<string>();
            List<double> DiscontinuedchitAMTTN = new List<double>();
            List<double> DiscontinuedchitCNTTN = new List<double>();
            List<double> DiscontinuedchitTotalAmtTN = new List<double>();


            for (int j = 0; j < dtDiscontinuedChitML.Rows.Count; j++)
            {
                DiscontinuedcategoriesML.Add(dtDiscontinuedChitML.Rows[j][0].ToString());
            }
            for (int j = 0; j < dtDiscontinuedChitML.Rows.Count; j++)
            {
                DiscontinuedchitAMTML.Add(Convert.ToDouble(dtDiscontinuedChitML.Rows[j][1].ToString()));
            }
            for (int j = 0; j < dtDiscontinuedChitML.Rows.Count; j++)
            {
                DiscontinuedchitCNTML.Add(Convert.ToDouble(dtDiscontinuedChitML.Rows[j][3].ToString()));
            }
            for (int j = 0; j < dtDiscontinuedChitML.Rows.Count; j++)
            {
                DiscontinuedchitTotalAmtML.Add(Convert.ToDouble(dtDiscontinuedChitML.Rows[j][2].ToString()));
            }


            for (int j = 0; j < dtDiscontinuedChitTN.Rows.Count; j++)
            {
                DiscontinuedcategoriesTN.Add(dtDiscontinuedChitTN.Rows[j][0].ToString());
            }
            for (int j = 0; j < dtDiscontinuedChitTN.Rows.Count; j++)
            {
                DiscontinuedchitAMTTN.Add(Convert.ToDouble(dtDiscontinuedChitTN.Rows[j][1].ToString()));
            }
            for (int j = 0; j < dtDiscontinuedChitTN.Rows.Count; j++)
            {
                DiscontinuedchitCNTTN.Add(Convert.ToDouble(dtDiscontinuedChitTN.Rows[j][3].ToString()));
            }
            for (int j = 0; j < dtDiscontinuedChitTN.Rows.Count; j++)
            {
                DiscontinuedchitTotalAmtTN.Add(Convert.ToDouble(dtDiscontinuedChitTN.Rows[j][2].ToString()));
            }
            List<System.Collections.ArrayList> DiscontinuedCHITMLData = new List<System.Collections.ArrayList>();
            foreach (DataRow dataRow in dtNewChitML.Rows)
            {
                System.Collections.ArrayList values = new System.Collections.ArrayList();
                foreach (object value in dataRow.ItemArray)
                    values.Add(value);
                DiscontinuedCHITMLData.Add(values);
            }
            List<System.Collections.ArrayList> DiscontinuedCHITTNData = new List<System.Collections.ArrayList>();
            foreach (DataRow dataRow in dtNewChitTN.Rows)
            {
                System.Collections.ArrayList values = new System.Collections.ArrayList();
                foreach (object value in dataRow.ItemArray)
                    values.Add(value);
                DiscontinuedCHITTNData.Add(values);
            }
            var YAxismlDiscontinued = DiscontinuedCHITMLData;
            var XAxismlDiscontinued = DiscontinuedcategoriesML;
            var YAxistnDiscontinued = DiscontinuedCHITTNData;
            var XAxistnDiscontinued = DiscontinuedcategoriesTN;
            return Json(new
            {
                aaYAxismlTotal = YAxismlTotal,
                aaXAxismlTotal = XAxismlTotal,
                aaYAxistnTotal = YAxistnTotal,
                aaXAxistnTotal = XAxistnTotal,

                aaYAxismlNew = YAxismlNew,
                aaXAxismlNew = XAxismlNew,
                aaYAxistnNew = YAxistnNew,
                aaXAxistnNew = XAxistnNew,
                aaDatachitAMTMLNew = newchitAMTML,
                aaDatachitCNTMLNew = newchitCNTML,
                aaDatachitAMTTNNew = newchitAMTTN,
                aaDatachitCNTTNNew = newchitCNTTN,

                aaYAxismlMatured = YAxismlMatured,
                aaXAxismlMatured = XAxismlMatured,
                aaYAxistnMatured = YAxistnMatured,
                aaXAxistnMatured = XAxistnMatured,
                aaDatachitAMTMLMatured = MaturedchitAMTML,
                aaDatachitCNTMLMatured = MaturedchitCNTML,
                aaDatachitTotAMTMLMatured = MaturedchitTotalAmtML,
                aaDatachitAMTTNMatured = MaturedchitAMTTN,
                aaDatachitCNTTNMatured = MaturedchitCNTTN,
                aaDatachitTotAMTTNMatured = MaturedchitTotalAmtTN,

                aaYAxismlDiscontinued = YAxismlDiscontinued,
                aaXAxismlDiscontinued = XAxismlDiscontinued,
                aaYAxistnDiscontinued = YAxistnDiscontinued,
                aaXAxistnDiscontinued = XAxistnDiscontinued,
                aaDatachitAMTMLDiscontinued = DiscontinuedchitAMTML,
                aaDatachitCNTMLDiscontinued = DiscontinuedchitCNTML,
                aaDatachitTotAMTMLDiscontinued = DiscontinuedchitTotalAmtML,
                aaDatachitAMTTNDiscontinued = DiscontinuedchitAMTTN,
                aaDatachitCNTTNDiscontinued = DiscontinuedchitCNTTN,
                aaDatachitTotAMTTNDiscontinued = DiscontinuedchitTotalAmtTN


            }, JsonRequestBehavior.AllowGet);
        }

        //Trend in Sales starts

        public ActionResult TrendinSales()
        {
            return View();
        }

        //Order Summary//

        public ActionResult OrderSummaryPage()
        {
            return View();
        }

        //Functions for Dashboard - Starts

        public ActionResult Orderdetails()
        {
            //fromdate = "2014-09-01";
            //todate = "2014-09-27";
            //DateTime FROMDate = Convert.ToDateTime(fromdate);
            //DateTime TODate = Convert.ToDateTime(todate);
            DataSet dsOrdersummary = BL.Ordersummary();
            DataTable dtOrdersummarytb0 = dsOrdersummary.Tables[0];
            DataTable dtOrdersummarytb1 = dsOrdersummary.Tables[1];
            DataTable dtOrdersummarytb2 = dsOrdersummary.Tables[2];
            DataTable dtOrdersummarytb3 = dsOrdersummary.Tables[3];

            Session["dtOrdersummarytb1"] = dtOrdersummarytb1;

            List<System.Collections.ArrayList> Ordersummarytb0 = new List<System.Collections.ArrayList>();
            foreach (DataRow dataRow in dtOrdersummarytb0.Rows)
            {
                System.Collections.ArrayList values = new System.Collections.ArrayList();
                foreach (object value in dataRow.ItemArray)
                    values.Add(value);
                Ordersummarytb0.Add(values);
            }
            List<System.Collections.ArrayList> Ordersummarytb1 = new List<System.Collections.ArrayList>();
            foreach (DataRow dataRow in dtOrdersummarytb1.Rows)
            {
                System.Collections.ArrayList values = new System.Collections.ArrayList();
                foreach (object value in dataRow.ItemArray)
                    values.Add(value);
                Ordersummarytb1.Add(values);
            }
            List<System.Collections.ArrayList> Ordersummarytb2 = new List<System.Collections.ArrayList>();
            foreach (DataRow dataRow in dtOrdersummarytb2.Rows)
            {
                System.Collections.ArrayList values = new System.Collections.ArrayList();
                foreach (object value in dataRow.ItemArray)
                    values.Add(value);
                Ordersummarytb2.Add(values);
            }
            List<System.Collections.ArrayList> Ordersummarytb3 = new List<System.Collections.ArrayList>();
            foreach (DataRow dataRow in dtOrdersummarytb3.Rows)
            {
                System.Collections.ArrayList values = new System.Collections.ArrayList();
                foreach (object value in dataRow.ItemArray)
                    values.Add(value);
                Ordersummarytb3.Add(values);
            }
            var dtOrdersumtb0 = Ordersummarytb0;
            var dtOrdersumtb1 = Ordersummarytb1;
            var dtOrdersumtb2 = Ordersummarytb2;
            var dtOrdersumtb3 = Ordersummarytb3;
            return Json(new
            {
                aaDataOrdersummaryTB0 = dtOrdersumtb0,
                aaDataOrdersummaryTB1 = dtOrdersumtb1,
                aaDataOrdersummaryTB2 = dtOrdersumtb2,
                aaDataOrdersummaryTB3 = dtOrdersumtb3,

            }, JsonRequestBehavior.AllowGet);

        }

        public ActionResult SalesPerformance()
        {
            //Tdate = "2014-03-31";
            //DateTime EndDate = Convert.ToDateTime(Tdate);
            DataSet dsSalesPerformancerpt = BL.rptSalesPerformance();
            DataTable dtSalesPerformancerptTop10 = dsSalesPerformancerpt.Tables[0];
            DataTable dtSalesPerformance = dsSalesPerformancerpt.Tables[1];
            Session["dtSalesPerformance"] = dtSalesPerformance;
            List<System.Collections.ArrayList> SalesPerformanceTop10 = new List<System.Collections.ArrayList>();
            foreach (DataRow dataRow in dtSalesPerformancerptTop10.Rows)
            {
                System.Collections.ArrayList values = new System.Collections.ArrayList();
                foreach (object value in dataRow.ItemArray)
                    values.Add(value);
                SalesPerformanceTop10.Add(values);
            }
            var dtSalesPerformanceTop10 = SalesPerformanceTop10;

            List<double> totalcnt = new List<double>();
            for (int j = 0; j < dtSalesPerformancerptTop10.Rows.Count; j++)
            {
                totalcnt.Add(Convert.ToDouble(dtSalesPerformancerptTop10.Rows[j][1].ToString()));
            }

            var Salestotalcnt = totalcnt;
            return Json(new
            {
                aaDataSalestotalcnt = Salestotalcnt,
                aaDataSalesPerformanceTop10 = dtSalesPerformanceTop10,

            }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Dashboardchit()
        {
            DataTable DtdashboardChit = BL.dashboardChit();
            Session["DtdashboardChit"] = DtdashboardChit;
            List<System.Collections.ArrayList> Dashboardchitrpt = new List<System.Collections.ArrayList>();
            foreach (DataRow dataRow in DtdashboardChit.Rows)
            {
                System.Collections.ArrayList values = new System.Collections.ArrayList();
                foreach (object value in dataRow.ItemArray)
                    values.Add(value);
                Dashboardchitrpt.Add(values);
            }
            var dtDashboardchitrpt = Dashboardchitrpt;
            List<string> CHITDATA = new List<string>();
            List<double> AMOUNT = new List<double>();
            List<double> CNT = new List<double>();

            for (int j = 0; j < DtdashboardChit.Rows.Count; j++)
            {
                CHITDATA.Add(DtdashboardChit.Rows[j][0].ToString());
            }
            for (int j = 0; j < DtdashboardChit.Rows.Count; j++)
            {
                AMOUNT.Add(Convert.ToDouble(DtdashboardChit.Rows[j][1].ToString()));
            }
            for (int j = 0; j < DtdashboardChit.Rows.Count; j++)
            {
                CNT.Add(Convert.ToDouble(DtdashboardChit.Rows[j][2].ToString()));
            }
            var CHTDATA = CHITDATA;
            var CHTAMT = AMOUNT;
            var CHTCNT = CNT;
            return Json(new
            {
                aaDataDashboardchitrpt = dtDashboardchitrpt,
                aaDatachtdata = CHTDATA,
                aadatachtamt = CHTAMT,
                aadatachtcnt = CHTCNT,

            }, JsonRequestBehavior.AllowGet);
        }

        //Top10 Counterwise sales Start//
        public ActionResult Top10CounterSales()
        {
            DataTable dtTop10CounterSales = BL.getTop10CounterSales();
            DataView view = new DataView(dtTop10CounterSales);
            List<System.Collections.ArrayList> Top10CounterSalesd = new List<System.Collections.ArrayList>();
            foreach (DataRow dataRow in dtTop10CounterSales.Rows)
            {
                System.Collections.ArrayList values = new System.Collections.ArrayList();
                foreach (object value in dataRow.ItemArray)
                    values.Add(value);
                Top10CounterSalesd.Add(values);
            }
            var Top10CounterSales = Top10CounterSalesd;
            return Json(new
            {
                aaDataTop10CounterSales = Top10CounterSales
            }, JsonRequestBehavior.AllowGet);
        }
        //End//

        // Stock Availabilty status -Starts
        public ActionResult StockAvailabilty()
        {
            DataTable dtStockAvailabilty = BL.rptStockAvailabilty();
            Session["dtStockAvailabilty"] = dtStockAvailabilty;
            List<System.Collections.ArrayList> StockAvailable = new List<System.Collections.ArrayList>();
            foreach (DataRow dataRow in dtStockAvailabilty.Rows)
            {
                System.Collections.ArrayList values = new System.Collections.ArrayList();
                foreach (object value in dataRow.ItemArray)
                    values.Add(value);
                StockAvailable.Add(values);
            }
            var dtStockAvailable = StockAvailable;
            return Json(new
            {
                aaDataStockAvailable = dtStockAvailable,
                aaDataStockLabels = dtStockAvailable

            }, JsonRequestBehavior.AllowGet);
        }
        // Stock Availabilty status -End

        //Dashdoard Floorwise MetalSales starts//
        public ActionResult DashdoardFloorwiseMetalSales()
        {
            DataTable dtFloorwiseMetalSales = BL.FloorwiseMetalSales();
            List<System.Collections.ArrayList> FloorwiseMetalSales = new List<System.Collections.ArrayList>();
            foreach (DataRow dataRow in dtFloorwiseMetalSales.Rows)
            {
                System.Collections.ArrayList values = new System.Collections.ArrayList();
                foreach (object value in dataRow.ItemArray)
                    values.Add(value);
                FloorwiseMetalSales.Add(values);
            }
            var dtFloorwiseMetalSal = FloorwiseMetalSales;
            return Json(new
            {
                aaDataFloorwiseMetalSales = dtFloorwiseMetalSal,

            }, JsonRequestBehavior.AllowGet);
        }
        //Dashdoard Floorwise MetalSales ends//

        //Daily Sales Vs Target(Silvermine) Starts//
        public ActionResult DailySalesTargetSIL()
        {
            DataTable dtSalesTargetSILVER = BL.SalesTargetSILVER();
            List<System.Collections.ArrayList> SalesTargetSILVER = new List<System.Collections.ArrayList>();
            foreach (DataRow dataRow in dtSalesTargetSILVER.Rows)
            {
                System.Collections.ArrayList values = new System.Collections.ArrayList();
                foreach (object value in dataRow.ItemArray)
                    values.Add(value);
                SalesTargetSILVER.Add(values);
            }
            var dtSalesTargetSILV = SalesTargetSILVER;
            return Json(new
            {
                aaDataSalesTargetSILVER = dtSalesTargetSILV,

            }, JsonRequestBehavior.AllowGet);
        }
        //Daily Sales Vs Target(Silvermine) End//

        public ActionResult DashboardTrendinSales()
        {
            DataTable dtTrendinSales = BL.TrendinSales();
            Session["dtTrendinSales"] = dtTrendinSales;
            List<System.Collections.ArrayList> TrendinSalesrpt = new List<System.Collections.ArrayList>();
            foreach (DataRow dataRow in dtTrendinSales.Rows)
            {
                System.Collections.ArrayList values = new System.Collections.ArrayList();
                foreach (object value in dataRow.ItemArray)
                    values.Add(value);
                TrendinSalesrpt.Add(values);
            }
            var dtTrendinSalesrpt = TrendinSalesrpt;
            return Json(new
            {
                aaDataTrendinSalesrpt = dtTrendinSalesrpt,

            }, JsonRequestBehavior.AllowGet);

        }

        public ActionResult Estimation()
        {
            DataTable estim = BL.rptEstimationCharts();
            List<System.Collections.ArrayList> EstimationReport = new List<System.Collections.ArrayList>();
            foreach (DataRow dataRow in estim.Rows)
            {
                System.Collections.ArrayList values = new System.Collections.ArrayList();
                foreach (object value in dataRow.ItemArray)
                    values.Add(value);
                EstimationReport.Add(values);
            }
            var EstimationRpt = EstimationReport;
            return Json(new
            {
                aaDataEstimationRpt = EstimationRpt,
            }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult SecondQTRTarget()
        {
            DataSet dsSecondQTRTarget = BL.getSecondQTRTarget();
            DataTable dtSecondQTRTarget = dsSecondQTRTarget.Tables[0];
            Session["dtFirstQTRTarget"] = dtSecondQTRTarget;
            DataView view = new DataView(dtSecondQTRTarget);
            List<System.Collections.ArrayList> SalesVsTarget = new List<System.Collections.ArrayList>();
            foreach (DataRow dataRow in dtSecondQTRTarget.Rows)
            {
                System.Collections.ArrayList values = new System.Collections.ArrayList();
                foreach (object value in dataRow.ItemArray)
                    values.Add(value);
                SalesVsTarget.Add(values);
            }
            var SalVsTargTable = SalesVsTarget;
            return Json(new
            {
                aaDataSalesVsTarget = SalVsTargTable
            }, JsonRequestBehavior.AllowGet);
        }

        //Special APPROVALS - Starts
        public ActionResult SpecialApprovals()
        {

            DataSet dsSpecialApprovals = BL.rptSpecialApprovals();
            DataTable dtSpecialApprovals = dsSpecialApprovals.Tables[0];
            Session["dtSpecialApprovals"] = dtSpecialApprovals;

            DataTable dtSalesReturns = BL.rptSalesReturns();

            List<System.Collections.ArrayList> SpecialApproval = new List<System.Collections.ArrayList>();
            foreach (DataRow dataRow in dtSpecialApprovals.Rows)
            {
                System.Collections.ArrayList values = new System.Collections.ArrayList();
                foreach (object value in dataRow.ItemArray)
                    values.Add(value);
                SpecialApproval.Add(values);
            }
            var dtSpecialApproval = SpecialApproval;
            List<System.Collections.ArrayList> SalesReturns = new List<System.Collections.ArrayList>();
            foreach (DataRow dataRow in dtSalesReturns.Rows)
            {
                System.Collections.ArrayList values = new System.Collections.ArrayList();
                foreach (object value in dataRow.ItemArray)
                    values.Add(value);
                SalesReturns.Add(values);
            }
            var dtSalesReturn = SalesReturns;
            return Json(new
            {
                aaDataSpecialApproval = dtSpecialApproval,
                aaDataSalesReturns = dtSalesReturn,

            }, JsonRequestBehavior.AllowGet);

        }
        //Special APPROVALS - End

        public ActionResult ComparisonTop10Sales(String MetalID, String FromDate, String ToDate)
        {
            FromDate = "2014-10-09";
            ToDate = "2014-10-09";
            MetalID = "GOLD";
            DateTime startDate = Convert.ToDateTime(FromDate);
            DateTime EndDate = Convert.ToDateTime(ToDate);
            DataSet dsComparisonTop10Sal = BL.rptSalesComparisonTop10Sales(MetalID, startDate, EndDate);
            Session["dsComparisonTop10Sal"] = dsComparisonTop10Sal;
            DataTable dtSalesComparisonPieChartML = dsComparisonTop10Sal.Tables[0];
            DataTable dtSalesComparisonTableML = dsComparisonTop10Sal.Tables[1];


            List<string> categorieschartML = new List<string>();
            List<double> AmtML = new List<double>();

            for (int j = 0; j < dtSalesComparisonPieChartML.Rows.Count; j++)
            {
                categorieschartML.Add(dtSalesComparisonPieChartML.Rows[j][1].ToString());
            }
            for (int j = 0; j < dtSalesComparisonPieChartML.Rows.Count; j++)
            {
                AmtML.Add(Convert.ToDouble(dtSalesComparisonPieChartML.Rows[j][2].ToString()));
            }

            List<System.Collections.ArrayList> SalesComparisonChartML = new List<System.Collections.ArrayList>();
            foreach (DataRow dataRow in dtSalesComparisonPieChartML.Rows)
            {
                System.Collections.ArrayList values = new System.Collections.ArrayList();
                foreach (object value in dataRow.ItemArray)
                    values.Add(value);
                SalesComparisonChartML.Add(values);
            }

            List<System.Collections.ArrayList> SalesComparisonTableML = new List<System.Collections.ArrayList>();
            foreach (DataRow dataRow in dtSalesComparisonTableML.Rows)
            {
                System.Collections.ArrayList values = new System.Collections.ArrayList();
                foreach (object value in dataRow.ItemArray)
                    values.Add(value);
                SalesComparisonTableML.Add(values);
            }


            var ComparisonSalTableML = SalesComparisonTableML;
            var ComparisonSalPiechartML = SalesComparisonChartML;

            var categoriesML = categorieschartML;
            var AmountML = AmtML;

            return Json(new
            {
                aaDataMLchart = ComparisonSalPiechartML,
                aaDataMLTAble = ComparisonSalTableML,
                aaDataAmountML = AmountML

            }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult FloorwiseSaless()
        {
            DataTable FloorwiseSal = BL.rptFloorSale();
            Session["FloorwiseSal"] = FloorwiseSal;
            List<System.Collections.ArrayList> FloorSale = new List<System.Collections.ArrayList>();
            foreach (DataRow dataRow in FloorwiseSal.Rows)
            {
                System.Collections.ArrayList values = new System.Collections.ArrayList();
                foreach (object value in dataRow.ItemArray)
                    values.Add(value);
                FloorSale.Add(values);
            }
            var dtFloorSale = FloorSale;
            List<string> categories = new List<string>();
            List<double> SaleAmt = new List<double>();
            for (int j = 0; j < FloorwiseSal.Rows.Count; j++)
            {
                categories.Add(FloorwiseSal.Rows[j][1].ToString());
            }
            for (int j = 0; j < FloorwiseSal.Rows.Count; j++)
            {
                SaleAmt.Add(Convert.ToDouble(FloorwiseSal.Rows[j][4].ToString()));
            }
            var XAxis = categories;
            var SalesAmt = SaleAmt;
            return Json(new
            {
                aaDataxaxis = XAxis,
                aaDatasaleamt = SalesAmt,
                aaDataFloorSale = dtFloorSale,


            }, JsonRequestBehavior.AllowGet);
        }

        //Functions for Dashboard - End

        //Function For Dashdoard Table - Starts

        // floorwise metal starts//
        public ActionResult FloorwiseMetalTab()
        {
            DataTable dtFloorwiseMetalTab = BL.FloorwiseMetalTab();
            List<System.Collections.ArrayList> dtfloorwisemet = new List<System.Collections.ArrayList>();
            foreach (DataRow dataRow in dtFloorwiseMetalTab.Rows)
            {
                System.Collections.ArrayList values = new System.Collections.ArrayList();
                foreach (object value in dataRow.ItemArray)
                    values.Add(value);
                dtfloorwisemet.Add(values);
            }
            var dtfloorwisemetal = dtfloorwisemet;
            return Json(new
            {
                aaDatafloorwisemetal = dtfloorwisemetal,
            }, JsonRequestBehavior.AllowGet);
        }
        // floorwise metal end//

        // Stock Availabilty status Table Starts
        public ActionResult StockAvailabiltyTable()
        {
            DataTable dtStockAvailabilty = BL.rptStockAvailabiltyTable();
            //Session["dtStockAvailabilty"] = dtStockAvailabilty;
            List<System.Collections.ArrayList> StockAvailable = new List<System.Collections.ArrayList>();
            foreach (DataRow dataRow in dtStockAvailabilty.Rows)
            {
                System.Collections.ArrayList values = new System.Collections.ArrayList();
                foreach (object value in dataRow.ItemArray)
                    values.Add(value);
                StockAvailable.Add(values);
            }
            var dtStockAvailable = StockAvailable;
            return Json(new
            {
                aaDataStockAvailable = dtStockAvailable,
                aaDataStockLabels = dtStockAvailable

            }, JsonRequestBehavior.AllowGet);
        }
        // Stock Availabilty status Table End

        //Function For Dashdoard Table - End


        public ActionResult Ordersummaryfullreport(DateTime fromdate, DateTime todate)
        {
            DataSet dsorder = BL.Ordersummaryfullrept(fromdate, todate);
            DataTable dtOrdersummaryrpt = dsorder.Tables[1];
            Session["dtOrdersummaryrpt"] = dtOrdersummaryrpt;
            List<System.Collections.ArrayList> Ordersummaryrpt = new List<System.Collections.ArrayList>();
            foreach (DataRow dataRow in dtOrdersummaryrpt.Rows)
            {
                System.Collections.ArrayList values = new System.Collections.ArrayList();
                foreach (object value in dataRow.ItemArray)
                    values.Add(value);
                Ordersummaryrpt.Add(values);
            }
            var model = Enumerable.Range(0, dtOrdersummaryrpt.Rows.Count).Select(x => new OrderSummaryDrilldown
            {
                ORDERNO = dtOrdersummaryrpt.Rows[x]["ORDERNO"].ToString(),
                CUSNAME = dtOrdersummaryrpt.Rows[x]["CUSNAME"].ToString(),
                EMPNAME = dtOrdersummaryrpt.Rows[x]["EMPNAME"].ToString(),
                ITEM = dtOrdersummaryrpt.Rows[x]["ITEM"].ToString(),
                SUBITEM = dtOrdersummaryrpt.Rows[x]["SUBITEM"].ToString(),
                ORDERNAME = dtOrdersummaryrpt.Rows[x]["ORDERNAME"].ToString(),
                ORDATE = dtOrdersummaryrpt.Rows[x]["ORDATE"].ToString(),
                REMDATE = dtOrdersummaryrpt.Rows[x]["REMDATE"].ToString(),
                DUEDATE = dtOrdersummaryrpt.Rows[x]["DUEDATE"].ToString(),
                DELIVERYDATE = dtOrdersummaryrpt.Rows[x]["DELIVERYDATE"].ToString(),
                STATUS = dtOrdersummaryrpt.Rows[x]["STATUS"].ToString(),
                PCS = dtOrdersummaryrpt.Rows[x]["PCS"].ToString(),
                NETWT = dtOrdersummaryrpt.Rows[x]["NETWT"].ToString(),
                DIAPCS = dtOrdersummaryrpt.Rows[x]["DIAPCS"].ToString(),
                DIAWT = dtOrdersummaryrpt.Rows[x]["DIAWT"].ToString(),
                RATE = dtOrdersummaryrpt.Rows[x]["RATE"].ToString(),
                VALUE = dtOrdersummaryrpt.Rows[x]["VALUE"].ToString(),
                ADVANCE = dtOrdersummaryrpt.Rows[x]["ADVANCE"].ToString(),
                DESIGNER = dtOrdersummaryrpt.Rows[x]["DESIGNER"].ToString(),
                METAL = dtOrdersummaryrpt.Rows[x]["METAL"].ToString(),
            });
            return Json(new
            {
                aaData = model,

            }, JsonRequestBehavior.AllowGet);
        }

        //End
        //Special Approvals starts
        public ActionResult SpecialApprovalpage()
        {
            return View();
        }

        public ActionResult Approvallist(DateTime fromdate, DateTime todate)
        {
            DataSet dsSpecialApprovals = BL.SpecialApprove(fromdate, todate);
            DataTable dtSpecialApprove = dsSpecialApprovals.Tables[1];
            Session["dtSpecialApprove"] = dtSpecialApprove;
            List<System.Collections.ArrayList> Approval = new List<System.Collections.ArrayList>();
            foreach (DataRow dataRow in dtSpecialApprove.Rows)
            {
                System.Collections.ArrayList values = new System.Collections.ArrayList();
                foreach (object value in dataRow.ItemArray)
                    values.Add(value);
                Approval.Add(values);
            }
            var model = Enumerable.Range(0, dtSpecialApprove.Rows.Count).Select(x => new SpecialApprovalDrilldown
            {
                EMPLOYEE = dtSpecialApprove.Rows[x]["PNAME"].ToString(),
                ITEMNAME = dtSpecialApprove.Rows[x]["ITEMNAME"].ToString(),
                TOTAL_COUNT = dtSpecialApprove.Rows[x]["TOTAL_COUNT"].ToString(),
                PCS = dtSpecialApprove.Rows[x]["PCS"].ToString(),
                NETWT = dtSpecialApprove.Rows[x]["NETWT"].ToString(),
                AMOUNT = dtSpecialApprove.Rows[x]["AMOUNT"].ToString(),
            });
            return Json(new
            {
                aaData = model,

            }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult SalesReturn()
        {
            return View();
        }

        public ActionResult SalesReturnlist(DateTime fromdate, DateTime todate)
        {
            DataTable dtSalesReturn = BL.Salesreturn(fromdate, todate);
            Session["dtSalesReturn"] = dtSalesReturn;
            List<System.Collections.ArrayList> SalesRet = new List<System.Collections.ArrayList>();
            foreach (DataRow dataRow in dtSalesReturn.Rows)
            {
                System.Collections.ArrayList values = new System.Collections.ArrayList();
                foreach (object value in dataRow.ItemArray)
                    values.Add(value);
                SalesRet.Add(values);
            }
            var model = Enumerable.Range(0, dtSalesReturn.Rows.Count).Select(x => new SalesReturnDrilldown
            {
                TRANNO = dtSalesReturn.Rows[x]["TRANNO"].ToString(),
                CUSTOMER = dtSalesReturn.Rows[x]["CUSNAME"].ToString(),
                ITEM = dtSalesReturn.Rows[x]["ITEMNAME"].ToString(),
                NETWT = dtSalesReturn.Rows[x]["NETWT"].ToString(),
                AMOUNT = dtSalesReturn.Rows[x]["AMOUNT"].ToString(),
            });
            return Json(new
            {
                aaData = model,

            }, JsonRequestBehavior.AllowGet);
        }


        //Finance Bank Credit Limit - START
        public ActionResult BankCreditLimit()
        {

            DataTable dtBankCreditLimit = BL.getBankCreditLimit();

            DataView view = new DataView(dtBankCreditLimit);
            List<System.Collections.ArrayList> BankCreditLimitlist = new List<System.Collections.ArrayList>();
            foreach (DataRow dataRow in dtBankCreditLimit.Rows)
            {
                System.Collections.ArrayList values = new System.Collections.ArrayList();
                foreach (object value in dataRow.ItemArray)
                    values.Add(value);
                BankCreditLimitlist.Add(values);
            }
            var BankCreditLimitTable = BankCreditLimitlist;
            return Json(new
            {
                aaDataBankCreditLimit = BankCreditLimitTable
            }, JsonRequestBehavior.AllowGet);
        }
        //Finance Bank Credit Limit - END

        //HR DASHBOARD STARTS//
        public ActionResult SalesPersonPerformanceHR()
        {
            return View();
        }

        //Functions for HR Dashboard = Start//

        public ActionResult SalesPerformHR()
        {
            DataSet dsSalesPerformancerptHR = BL.rptSalesPerformanceHR();
            DataTable dtSalesPerformancerptTop10HR = dsSalesPerformancerptHR.Tables[0];
            DataTable dtSalesPerformanceHR = dsSalesPerformancerptHR.Tables[1];
            Session["dtSalesPerformanceHR"] = dtSalesPerformanceHR;
            List<System.Collections.ArrayList> SalesPerformanceTop10HR = new List<System.Collections.ArrayList>();
            foreach (DataRow dataRow in dtSalesPerformancerptTop10HR.Rows)
            {
                System.Collections.ArrayList values = new System.Collections.ArrayList();
                foreach (object value in dataRow.ItemArray)
                    values.Add(value);
                SalesPerformanceTop10HR.Add(values);
            }
            var dtSalesPerformanceTop10HR = SalesPerformanceTop10HR;

            List<double> totalSalecnt = new List<double>();
            for (int j = 0; j < dtSalesPerformancerptTop10HR.Rows.Count; j++)
            {
                totalSalecnt.Add(Convert.ToDouble(dtSalesPerformancerptTop10HR.Rows[j][1].ToString()));
            }

            var SalestotalcntHR = totalSalecnt;
            return Json(new
            {
                aaDataSalestotalcntHR = SalestotalcntHR,
                aaDataSalesPerformanceTop10HR = dtSalesPerformanceTop10HR,

            }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult DASHBOARDCHITHR()
        {
            DataSet dsTOP10chitHR = BL.rptTOP10chitHR();
            DataTable dtTOP10chitHR = dsTOP10chitHR.Tables[0];
            DataTable dtfullchitHR = dsTOP10chitHR.Tables[1];
            Session["dtfullchitHR"] = dtfullchitHR;
            List<System.Collections.ArrayList> TOP10chitHR = new List<System.Collections.ArrayList>();
            foreach (DataRow dataRow in dtTOP10chitHR.Rows)
            {
                System.Collections.ArrayList values = new System.Collections.ArrayList();
                foreach (object value in dataRow.ItemArray)
                    values.Add(value);
                TOP10chitHR.Add(values);
            }
            var dtTOP10chitdetailsHR = TOP10chitHR;

            List<double> totalSalecntHR = new List<double>();
            for (int j = 0; j < dtTOP10chitHR.Rows.Count; j++)
            {
                totalSalecntHR.Add(Convert.ToDouble(dtTOP10chitHR.Rows[j][1].ToString()));
            }

            var SalestotalcntHR = totalSalecntHR;
            return Json(new
            {
                aaDataSalescntHR = SalestotalcntHR,
                aaDataTOP10chitdetailsHR = dtTOP10chitdetailsHR,

            }, JsonRequestBehavior.AllowGet);

        }

        public ActionResult DASHBOARDEstimationHR()
        {
            DataSet DSEstimationHR = BL.rptEstimationHR();
            DataTable estimHR = DSEstimationHR.Tables[0];
            DataTable estimdataHR = DSEstimationHR.Tables[1];
            Session["estimdataHR"] = estimdataHR;
            List<System.Collections.ArrayList> EstimationReportHR = new List<System.Collections.ArrayList>();
            foreach (DataRow dataRow in estimHR.Rows)
            {
                System.Collections.ArrayList values = new System.Collections.ArrayList();
                foreach (object value in dataRow.ItemArray)
                    values.Add(value);
                EstimationReportHR.Add(values);
            }
            var EstimationRpt = EstimationReportHR;
            return Json(new
            {
                aaDataEstimationRptHR = EstimationRpt,
            }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult DASHBOARDEstimationnosaleHR()
        {
            DataSet DSEstimationHR1 = BL.rptEstimationnosalHR();
            DataTable estimHR1 = DSEstimationHR1.Tables[0];
            DataTable estimdataHR1 = DSEstimationHR1.Tables[1];
            Session["estimdataHR1"] = estimdataHR1;
            List<System.Collections.ArrayList> EstimationReportHR1 = new List<System.Collections.ArrayList>();
            foreach (DataRow dataRow in estimHR1.Rows)
            {
                System.Collections.ArrayList values = new System.Collections.ArrayList();
                foreach (object value in dataRow.ItemArray)
                    values.Add(value);
                EstimationReportHR1.Add(values);
            }
            var EstimationRpt1 = EstimationReportHR1;
            return Json(new
            {
                aaDataEstimationRptHR1 = EstimationRpt1,
            }, JsonRequestBehavior.AllowGet);
        }

        //Functions for HR Dashboard = End//

        //Functions for HR Dashboard Table - Start//

        public ActionResult GetChitFulldataHR()
        {
            DataSet dsTOP10chitHR = BL.rptTOP10chitHR();
            DataTable DTChitFulldataHR = dsTOP10chitHR.Tables[1];
            List<System.Collections.ArrayList> ChitFulldataHR = new List<System.Collections.ArrayList>();
            foreach (DataRow dataRow in DTChitFulldataHR.Rows)
            {
                System.Collections.ArrayList values = new System.Collections.ArrayList();
                foreach (object value in dataRow.ItemArray)
                    values.Add(value);
                ChitFulldataHR.Add(values);
            }

            var model = ChitFulldataHR;
            return Json(new
            {
                aaChitDataHR = model
            }, JsonRequestBehavior.AllowGet);

        }

        public ActionResult GetSalesPerformanceFulldataHR()
        {
            DataSet dsSalesPerformancerptHR = BL.rptSalesPerformanceHR();
            DataTable DTSalesPerformanceFulldataHR = dsSalesPerformancerptHR.Tables[1];
            List<System.Collections.ArrayList> SalesPerformanceFulldataHR = new List<System.Collections.ArrayList>();
            foreach (DataRow dataRow in DTSalesPerformanceFulldataHR.Rows)
            {
                System.Collections.ArrayList values = new System.Collections.ArrayList();
                foreach (object value in dataRow.ItemArray)
                    values.Add(value);
                SalesPerformanceFulldataHR.Add(values);
            }
            var model = Enumerable.Range(0, DTSalesPerformanceFulldataHR.Rows.Count).Select(x => new SalesPersonPerformHR
            {
                EMPNAME = DTSalesPerformanceFulldataHR.Rows[x]["EMPNAME"].ToString(),
                SALENETWT = DTSalesPerformanceFulldataHR.Rows[x]["SALENETWT"].ToString(),
                SALECOUNT = DTSalesPerformanceFulldataHR.Rows[x]["SALECOUNT"].ToString(),
                SALEDIAWT = DTSalesPerformanceFulldataHR.Rows[x]["SALEDIAWT"].ToString(),
                SALEAMOUNT = DTSalesPerformanceFulldataHR.Rows[x]["SALEAMOUNT"].ToString(),
                NOSALENETWT = DTSalesPerformanceFulldataHR.Rows[x]["NOSALENETWT"].ToString(),
                NOSALECOUNT = DTSalesPerformanceFulldataHR.Rows[x]["NOSALECOUNT"].ToString(),
                NOSALEDIAWT = DTSalesPerformanceFulldataHR.Rows[x]["NOSALEDIAWT"].ToString(),
                NOSALEAMOUNT = DTSalesPerformanceFulldataHR.Rows[x]["NOSALEAMOUNT"].ToString(),
            });
            // var model = StockReport;
            return Json(new
            {
                aaData = model,
            }, JsonRequestBehavior.AllowGet);

        }

        //Functions for HR Dashboard Table - End//

        public ActionResult drilldownSalesrpt(DateTime fromdate, DateTime todate)
        {
            DataTable dtdrilldown = BL.drilldownsalesperformance(fromdate, todate);
            List<System.Collections.ArrayList> SalesPerformanceDrilldown = new List<System.Collections.ArrayList>();
            foreach (DataRow dataRow in dtdrilldown.Rows)
            {
                System.Collections.ArrayList values = new System.Collections.ArrayList();
                foreach (object value in dataRow.ItemArray)
                    values.Add(value);
                SalesPerformanceDrilldown.Add(values);
            }
            var dtSalesPerformancedrilldown = SalesPerformanceDrilldown;
            return Json(new
            {
                aaDatadrilldownSales = dtSalesPerformancedrilldown
            }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult FloorWiseChitHR()
        {
            return View();
        }







        public ActionResult EstimationConversionHR()
        {
            return View();
        }

        //HR DASHBOARD End
        //naresh hr starts




        public ActionResult drilldownFloorwiseChit(DateTime fromdate, DateTime todate)
        {
            DataTable dtdrilldownFloorwiseChit = BL.drilldownFloorwise(fromdate, todate);
            List<System.Collections.ArrayList> FloorwiseChitDrilldown = new List<System.Collections.ArrayList>();
            foreach (DataRow dataRow in dtdrilldownFloorwiseChit.Rows)
            {
                System.Collections.ArrayList values = new System.Collections.ArrayList();
                foreach (object value in dataRow.ItemArray)
                    values.Add(value);
                FloorwiseChitDrilldown.Add(values);
            }
            var model = Enumerable.Range(0, dtdrilldownFloorwiseChit.Rows.Count).Select(x => new Chithr
           {
               EMPNAME = dtdrilldownFloorwiseChit.Rows[x]["EMPNAME"].ToString(),
               AMOUNT = dtdrilldownFloorwiseChit.Rows[x]["AMOUNT"].ToString(),
               CHITCOUNT = dtdrilldownFloorwiseChit.Rows[x]["CHITCOUNT"].ToString(),
           });

            return Json(new
            {
                aaData = model
            }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult drilldownEstimation(DateTime fromdate, DateTime todate)
        {
            DataTable dtdrilldownest = BL.drilldownEstimation(fromdate, todate);
            List<System.Collections.ArrayList> EstimationDrilldown = new List<System.Collections.ArrayList>();
            foreach (DataRow dataRow in dtdrilldownest.Rows)
            {
                System.Collections.ArrayList values = new System.Collections.ArrayList();
                foreach (object value in dataRow.ItemArray)
                    values.Add(value);
                EstimationDrilldown.Add(values);
            }
            var model = Enumerable.Range(0, dtdrilldownest.Rows.Count).Select(x => new EstimationHR
            {
                EMPNAME = dtdrilldownest.Rows[x]["EMPNAME"].ToString(),
                ESTIMATION = dtdrilldownest.Rows[x]["ESTIMATION"].ToString(),
                SALENETWT = dtdrilldownest.Rows[x]["SALENETWT"].ToString(),
                SALECOUNT = dtdrilldownest.Rows[x]["SALECOUNT"].ToString(),
                SALEDIAWT = dtdrilldownest.Rows[x]["SALEDIAWT"].ToString(),
                SALEAMOUNT = dtdrilldownest.Rows[x]["SALEAMOUNT"].ToString(),
                NOSALENETWT = dtdrilldownest.Rows[x]["NOSALENETWT"].ToString(),
                NOSALECOUNT = dtdrilldownest.Rows[x]["NOSALECOUNT"].ToString(),
                NOSALEDIAWT = dtdrilldownest.Rows[x]["NOSALEDIAWT"].ToString(),
                NOSALEAMOUNT = dtdrilldownest.Rows[x]["NOSALEAMOUNT"].ToString(),
            });
            return Json(new
            {
                aaData = model,
            }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetSalesPerformanceFulldataHRdrill(DateTime fromdate, DateTime todate)
        {
            DataSet dsSalesPerformancerptHR = BL.rptSalesPerformanceHRdrill(fromdate, todate);
            DataTable DTSalesPerformanceFulldataHR = dsSalesPerformancerptHR.Tables[1];
            List<System.Collections.ArrayList> SalesPerformanceFulldataHR = new List<System.Collections.ArrayList>();
            foreach (DataRow dataRow in DTSalesPerformanceFulldataHR.Rows)
            {
                System.Collections.ArrayList values = new System.Collections.ArrayList();
                foreach (object value in dataRow.ItemArray)
                    values.Add(value);
                SalesPerformanceFulldataHR.Add(values);
            }
            var model = Enumerable.Range(0, DTSalesPerformanceFulldataHR.Rows.Count).Select(x => new SalesPersonPerformHRdrill
            {
                EMPNAME = DTSalesPerformanceFulldataHR.Rows[x]["EMPNAME"].ToString(),
                SALENETWT = DTSalesPerformanceFulldataHR.Rows[x]["SALENETWT"].ToString(),
                SALECOUNT = DTSalesPerformanceFulldataHR.Rows[x]["SALECOUNT"].ToString(),
                SALEDIAWT = DTSalesPerformanceFulldataHR.Rows[x]["SALEDIAWT"].ToString(),
                SALEAMOUNT = DTSalesPerformanceFulldataHR.Rows[x]["SALEAMOUNT"].ToString(),
                //NOSALENETWT = DTSalesPerformanceFulldataHR.Rows[x]["NOSALENETWT"].ToString(),
                //NOSALECOUNT = DTSalesPerformanceFulldataHR.Rows[x]["NOSALECOUNT"].ToString(),
                //NOSALEDIAWT = DTSalesPerformanceFulldataHR.Rows[x]["NOSALEDIAWT"].ToString(),
                //NOSALEAMOUNT = DTSalesPerformanceFulldataHR.Rows[x]["NOSALEAMOUNT"].ToString(),
            });
            // var model = StockReport;
            return Json(new
            {
                aaData = model,
            }, JsonRequestBehavior.AllowGet);

        }
        public ActionResult drilldownEstimationnosal(DateTime fromdate, DateTime todate)
        {
            DataTable dtdrilldownEstNoSale = BL.drilldownEstimationnosal(fromdate, todate);
            List<System.Collections.ArrayList> EstimationDrilldown = new List<System.Collections.ArrayList>();
            foreach (DataRow dataRow in dtdrilldownEstNoSale.Rows)
            {
                System.Collections.ArrayList values = new System.Collections.ArrayList();
                foreach (object value in dataRow.ItemArray)
                    values.Add(value);
                EstimationDrilldown.Add(values);
            }
            var model = Enumerable.Range(0, dtdrilldownEstNoSale.Rows.Count).Select(x => new EstimationnosalHR
            {
                EMPNAME = dtdrilldownEstNoSale.Rows[x]["EMPNAME"].ToString(),
                SALENETWT = dtdrilldownEstNoSale.Rows[x]["SALENETWT"].ToString(),
                SALECOUNT = dtdrilldownEstNoSale.Rows[x]["SALECOUNT"].ToString(),
                SALEDIAWT = dtdrilldownEstNoSale.Rows[x]["SALEDIAWT"].ToString(),
                SALEAMOUNT = dtdrilldownEstNoSale.Rows[x]["SALEAMOUNT"].ToString(),
                NOSALENETWT = dtdrilldownEstNoSale.Rows[x]["NOSALENETWT"].ToString(),
                NOSALECOUNT = dtdrilldownEstNoSale.Rows[x]["NOSALECOUNT"].ToString(),
                NOSALEDIAWT = dtdrilldownEstNoSale.Rows[x]["NOSALEDIAWT"].ToString(),
                NOSALEAMOUNT = dtdrilldownEstNoSale.Rows[x]["NOSALEAMOUNT"].ToString(),
            });
            // var model = StockReport;
            return Json(new
            {
                aaData = model,
            }, JsonRequestBehavior.AllowGet);
        }



        //naresh hr ends
        //MANAGEMENT SCREEN STARTS//        

        //Functions For Dashboard Table - Starts

        public ActionResult SecondQTRTargetYTD()
        {
            DataSet dsSecondQTRTarget = BL.getSecondQTRTargetYTD();
            DataTable dtSecondQTRTarget = dsSecondQTRTarget.Tables[0];
            Session["dtFirstQTRTarget"] = dtSecondQTRTarget;
            DataView view = new DataView(dtSecondQTRTarget);
            List<System.Collections.ArrayList> SalesVsTarget = new List<System.Collections.ArrayList>();
            foreach (DataRow dataRow in dtSecondQTRTarget.Rows)
            {
                System.Collections.ArrayList values = new System.Collections.ArrayList();
                foreach (object value in dataRow.ItemArray)
                    values.Add(value);
                SalesVsTarget.Add(values);
            }
            var SalVsTargTable = SalesVsTarget;
            return Json(new
            {
                aaDataSalesVsTarget = SalVsTargTable
            }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Top10CounterSalesYTD()
        {
            DataTable dtTop10CounterSalesYTD = BL.getTop10CounterSalesYTD();
            DataView view = new DataView(dtTop10CounterSalesYTD);
            List<System.Collections.ArrayList> Top10CounterSales = new List<System.Collections.ArrayList>();
            foreach (DataRow dataRow in dtTop10CounterSalesYTD.Rows)
            {
                System.Collections.ArrayList values = new System.Collections.ArrayList();
                foreach (object value in dataRow.ItemArray)
                    values.Add(value);
                Top10CounterSales.Add(values);
            }
            var Top10CounterSalesYTD = Top10CounterSales;
            return Json(new
            {
                aaDataTop10CounterSalesYTD = Top10CounterSalesYTD
            }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult FloorwiseSalessYTD()
        {
            DataTable FloorwiseSal = BL.rptFloorSaleYTD();
            Session["FloorwiseSal"] = FloorwiseSal;
            List<System.Collections.ArrayList> FloorSale = new List<System.Collections.ArrayList>();
            foreach (DataRow dataRow in FloorwiseSal.Rows)
            {
                System.Collections.ArrayList values = new System.Collections.ArrayList();
                foreach (object value in dataRow.ItemArray)
                    values.Add(value);
                FloorSale.Add(values);
            }
            var dtFloorSale = FloorSale;
            List<string> categories = new List<string>();
            List<double> SaleAmt = new List<double>();
            for (int j = 0; j < FloorwiseSal.Rows.Count; j++)
            {
                categories.Add(FloorwiseSal.Rows[j][1].ToString());
            }
            for (int j = 0; j < FloorwiseSal.Rows.Count; j++)
            {
                SaleAmt.Add(Convert.ToDouble(FloorwiseSal.Rows[j][4].ToString()));
            }
            var XAxis = categories;
            var SalesAmt = SaleAmt;
            return Json(new
            {
                aaDataxaxis = XAxis,
                aaDatasaleamt = SalesAmt,
                aaDataFloorSale = dtFloorSale,


            }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult DashboardchitYTD()
        {
            DataTable DtdashboardChit = BL.dashboardChitYTD();
            Session["DtdashboardChit"] = DtdashboardChit;
            List<System.Collections.ArrayList> Dashboardchitrpt = new List<System.Collections.ArrayList>();
            foreach (DataRow dataRow in DtdashboardChit.Rows)
            {
                System.Collections.ArrayList values = new System.Collections.ArrayList();
                foreach (object value in dataRow.ItemArray)
                    values.Add(value);
                Dashboardchitrpt.Add(values);
            }
            var dtDashboardchitrpt = Dashboardchitrpt;
            List<string> CHITDATA = new List<string>();
            List<double> AMOUNT = new List<double>();
            List<double> CNT = new List<double>();

            for (int j = 0; j < DtdashboardChit.Rows.Count; j++)
            {
                CHITDATA.Add(DtdashboardChit.Rows[j][0].ToString());
            }
            for (int j = 0; j < DtdashboardChit.Rows.Count; j++)
            {
                AMOUNT.Add(Convert.ToDouble(DtdashboardChit.Rows[j][1].ToString()));
            }
            for (int j = 0; j < DtdashboardChit.Rows.Count; j++)
            {
                CNT.Add(Convert.ToDouble(DtdashboardChit.Rows[j][2].ToString()));
            }
            var CHTDATA = CHITDATA;
            var CHTAMT = AMOUNT;
            var CHTCNT = CNT;
            return Json(new
            {
                aaDataDashboardchitrpt = dtDashboardchitrpt,
                aaDatachtdata = CHTDATA,
                aadatachtamt = CHTAMT,
                aadatachtcnt = CHTCNT,
            }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult SpecialApprovalsYTD()
        {

            DataSet dsSpecialApprovals = BL.rptSpecialApprovalsYTD();
            DataTable dtSpecialApprovals = dsSpecialApprovals.Tables[0];
            Session["dtSpecialApprovals"] = dtSpecialApprovals;

            DataTable dtSalesReturns = BL.rptSalesReturnsYTD();

            List<System.Collections.ArrayList> SpecialApproval = new List<System.Collections.ArrayList>();
            foreach (DataRow dataRow in dtSpecialApprovals.Rows)
            {
                System.Collections.ArrayList values = new System.Collections.ArrayList();
                foreach (object value in dataRow.ItemArray)
                    values.Add(value);
                SpecialApproval.Add(values);
            }
            var dtSpecialApproval = SpecialApproval;
            List<System.Collections.ArrayList> SalesReturns = new List<System.Collections.ArrayList>();
            foreach (DataRow dataRow in dtSalesReturns.Rows)
            {
                System.Collections.ArrayList values = new System.Collections.ArrayList();
                foreach (object value in dataRow.ItemArray)
                    values.Add(value);
                SalesReturns.Add(values);
            }
            var dtSalesReturn = SalesReturns;
            return Json(new
            {
                aaDataSpecialApproval = dtSpecialApproval,
                aaDataSalesReturns = dtSalesReturn,

            }, JsonRequestBehavior.AllowGet);

        }

        public ActionResult EstimationYTD()
        {
            DataTable estim = BL.rptEstimationChartsYTD();
            List<System.Collections.ArrayList> EstimationReport = new List<System.Collections.ArrayList>();
            foreach (DataRow dataRow in estim.Rows)
            {
                System.Collections.ArrayList values = new System.Collections.ArrayList();
                foreach (object value in dataRow.ItemArray)
                    values.Add(value);
                EstimationReport.Add(values);
            }
            var EstimationRpt = EstimationReport;
            return Json(new
            {
                aaDataEstimationRpt = EstimationRpt,
            }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult OrderdetailsYTD()
        {
            //fromdate = "2014-09-01";
            //todate = "2014-09-27";
            //DateTime FROMDate = Convert.ToDateTime(fromdate);
            //DateTime TODate = Convert.ToDateTime(todate);
            DataSet dsOrdersummary = BL.OrdersummaryYTD();
            DataTable dtOrdersummarytb0 = dsOrdersummary.Tables[0];
            DataTable dtOrdersummarytb1 = dsOrdersummary.Tables[1];
            DataTable dtOrdersummarytb2 = dsOrdersummary.Tables[2];
            DataTable dtOrdersummarytb3 = dsOrdersummary.Tables[3];

            Session["dtOrdersummarytb1"] = dtOrdersummarytb1;

            List<System.Collections.ArrayList> Ordersummarytb0 = new List<System.Collections.ArrayList>();
            foreach (DataRow dataRow in dtOrdersummarytb0.Rows)
            {
                System.Collections.ArrayList values = new System.Collections.ArrayList();
                foreach (object value in dataRow.ItemArray)
                    values.Add(value);
                Ordersummarytb0.Add(values);
            }
            List<System.Collections.ArrayList> Ordersummarytb1 = new List<System.Collections.ArrayList>();
            foreach (DataRow dataRow in dtOrdersummarytb1.Rows)
            {
                System.Collections.ArrayList values = new System.Collections.ArrayList();
                foreach (object value in dataRow.ItemArray)
                    values.Add(value);
                Ordersummarytb1.Add(values);
            }
            List<System.Collections.ArrayList> Ordersummarytb2 = new List<System.Collections.ArrayList>();
            foreach (DataRow dataRow in dtOrdersummarytb2.Rows)
            {
                System.Collections.ArrayList values = new System.Collections.ArrayList();
                foreach (object value in dataRow.ItemArray)
                    values.Add(value);
                Ordersummarytb2.Add(values);
            }
            List<System.Collections.ArrayList> Ordersummarytb3 = new List<System.Collections.ArrayList>();
            foreach (DataRow dataRow in dtOrdersummarytb3.Rows)
            {
                System.Collections.ArrayList values = new System.Collections.ArrayList();
                foreach (object value in dataRow.ItemArray)
                    values.Add(value);
                Ordersummarytb3.Add(values);
            }
            var dtOrdersumtb0 = Ordersummarytb0;
            var dtOrdersumtb1 = Ordersummarytb1;
            var dtOrdersumtb2 = Ordersummarytb2;
            var dtOrdersumtb3 = Ordersummarytb3;
            return Json(new
            {
                aaDataOrdersummaryTB0 = dtOrdersumtb0,
                aaDataOrdersummaryTB1 = dtOrdersumtb1,
                aaDataOrdersummaryTB2 = dtOrdersumtb2,
                aaDataOrdersummaryTB3 = dtOrdersumtb3,

            }, JsonRequestBehavior.AllowGet);

        }

        public ActionResult SalesPerformanceYTD()
        {
            //Tdate = "2014-03-31";
            //DateTime EndDate = Convert.ToDateTime(Tdate);
            DataSet dsSalesPerformancerpt = BL.rptSalesPerformanceYTD();
            DataTable dtSalesPerformancerptTop10 = dsSalesPerformancerpt.Tables[0];
            DataTable dtSalesPerformance = dsSalesPerformancerpt.Tables[1];
            Session["dtSalesPerformance"] = dtSalesPerformance;
            List<System.Collections.ArrayList> SalesPerformanceTop10 = new List<System.Collections.ArrayList>();
            foreach (DataRow dataRow in dtSalesPerformancerptTop10.Rows)
            {
                System.Collections.ArrayList values = new System.Collections.ArrayList();
                foreach (object value in dataRow.ItemArray)
                    values.Add(value);
                SalesPerformanceTop10.Add(values);
            }
            var dtSalesPerformanceTop10 = SalesPerformanceTop10;

            List<double> totalcnt = new List<double>();
            for (int j = 0; j < dtSalesPerformancerptTop10.Rows.Count; j++)
            {
                totalcnt.Add(Convert.ToDouble(dtSalesPerformancerptTop10.Rows[j][1].ToString()));
            }

            var Salestotalcnt = totalcnt;
            return Json(new
            {
                aaDataSalestotalcnt = Salestotalcnt,
                aaDataSalesPerformanceTop10 = dtSalesPerformanceTop10,

            }, JsonRequestBehavior.AllowGet);

        }

        public ActionResult SalePurchase()
        {
            DataTable dtgetSalePurchase = BL.getSalePurchase();
            List<System.Collections.ArrayList> dtgetSalePurchaselist = new List<System.Collections.ArrayList>();
            foreach (DataRow dataRow in dtgetSalePurchase.Rows)
            {
                System.Collections.ArrayList values = new System.Collections.ArrayList();
                foreach (object value in dataRow.ItemArray)
                    values.Add(value);
                dtgetSalePurchaselist.Add(values);
            }
            var dtgetSalePurc = dtgetSalePurchaselist;
            List<string> Week = new List<string>();
            List<double> SALEAMT = new List<double>();
            List<double> PURAMT = new List<double>();
            List<double> PRICE = new List<double>();
            List<string> DATERANGE = new List<string>();

            for (int j = 0; j < dtgetSalePurchase.Rows.Count; j++)
            {
                Week.Add(dtgetSalePurchase.Rows[j][0].ToString());
            }
            for (int j = 0; j < dtgetSalePurchase.Rows.Count; j++)
            {
                SALEAMT.Add(Convert.ToDouble(dtgetSalePurchase.Rows[j][1].ToString()));
            }
            for (int j = 0; j < dtgetSalePurchase.Rows.Count; j++)
            {
                PURAMT.Add(Convert.ToDouble(dtgetSalePurchase.Rows[j][2].ToString()));
            }
            for (int j = 0; j < dtgetSalePurchase.Rows.Count; j++)
            {
                PRICE.Add(Convert.ToDouble(dtgetSalePurchase.Rows[j][3].ToString()));
            }
            for (int j = 0; j < dtgetSalePurchase.Rows.Count; j++)
            {
                DATERANGE.Add(dtgetSalePurchase.Rows[j][4].ToString());
            }

            var weekid = Week;
            var sale = SALEAMT;
            var purchase = PURAMT;
            var rate = PRICE;
            var dateran = DATERANGE;
            return Json(new
            {
                aaDatagetSalePurcdata = dtgetSalePurc,
                aaDataweekid = weekid,
                aaDatasale = sale,
                aaDatapurchase = purchase,
                aaDatarate = rate,
                aaDatadate = dateran,
            }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult DailySalesTargetSILYTD()
        {
            DataTable dtSalesTargetSILVERYTD = BL.SalesTargetSILVERYTD();
            List<System.Collections.ArrayList> SalesTargetSILVERYTD = new List<System.Collections.ArrayList>();
            foreach (DataRow dataRow in dtSalesTargetSILVERYTD.Rows)
            {
                System.Collections.ArrayList values = new System.Collections.ArrayList();
                foreach (object value in dataRow.ItemArray)
                    values.Add(value);
                SalesTargetSILVERYTD.Add(values);
            }
            var dtSalesTargetSILVYTD = SalesTargetSILVERYTD;
            return Json(new
            {
                aaDataSalesTargetSILVERYTD = dtSalesTargetSILVYTD,

            }, JsonRequestBehavior.AllowGet);
        }

        //Functions For Dashboard Table - End

        //public ActionResult DashboardchitYTD()
        //{
        //    DataTable DtdashboardChit = BL.dashboardChitYTD();
        //    Session["DtdashboardChit"] = DtdashboardChit;
        //    List<System.Collections.ArrayList> Dashboardchitrpt = new List<System.Collections.ArrayList>();
        //    foreach (DataRow dataRow in DtdashboardChit.Rows)
        //    {
        //        System.Collections.ArrayList values = new System.Collections.ArrayList();
        //        foreach (object value in dataRow.ItemArray)
        //            values.Add(value);
        //        Dashboardchitrpt.Add(values);
        //    }
        //    var dtDashboardchitrpt = Dashboardchitrpt;
        //    return Json(new
        //    {
        //        aaDataDashboardchitrpt = dtDashboardchitrpt,

        //    }, JsonRequestBehavior.AllowGet);
        //}        

        public ActionResult ComparisonTop10SalesYTD(String MetalID, String FromDate, String ToDate)
        {
            FromDate = "2014-04-01";
            ToDate = "2014-10-16";
            MetalID = "GOLD";
            DateTime startDate = Convert.ToDateTime(FromDate);
            DateTime EndDate = Convert.ToDateTime(ToDate);
            DataSet dsComparisonTop10Sal = BL.rptSalesComparisonTop10SalesYTD(MetalID, startDate, EndDate);
            Session["dsComparisonTop10Sal"] = dsComparisonTop10Sal;
            DataTable dtSalesComparisonPieChartML = dsComparisonTop10Sal.Tables[0];
            DataTable dtSalesComparisonTableML = dsComparisonTop10Sal.Tables[1];


            List<string> categorieschartML = new List<string>();
            List<double> AmtML = new List<double>();

            for (int j = 0; j < dtSalesComparisonPieChartML.Rows.Count; j++)
            {
                categorieschartML.Add(dtSalesComparisonPieChartML.Rows[j][1].ToString());
            }
            for (int j = 0; j < dtSalesComparisonPieChartML.Rows.Count; j++)
            {
                AmtML.Add(Convert.ToDouble(dtSalesComparisonPieChartML.Rows[j][2].ToString()));
            }

            List<System.Collections.ArrayList> SalesComparisonChartML = new List<System.Collections.ArrayList>();
            foreach (DataRow dataRow in dtSalesComparisonPieChartML.Rows)
            {
                System.Collections.ArrayList values = new System.Collections.ArrayList();
                foreach (object value in dataRow.ItemArray)
                    values.Add(value);
                SalesComparisonChartML.Add(values);
            }

            List<System.Collections.ArrayList> SalesComparisonTableML = new List<System.Collections.ArrayList>();
            foreach (DataRow dataRow in dtSalesComparisonTableML.Rows)
            {
                System.Collections.ArrayList values = new System.Collections.ArrayList();
                foreach (object value in dataRow.ItemArray)
                    values.Add(value);
                SalesComparisonTableML.Add(values);
            }


            var ComparisonSalTableML = SalesComparisonTableML;
            var ComparisonSalPiechartML = SalesComparisonChartML;

            var categoriesML = categorieschartML;
            var AmountML = AmtML;

            return Json(new
            {
                aaDataMLchart = ComparisonSalPiechartML,
                aaDataMLTAble = ComparisonSalTableML,
                aaDataAmountML = AmountML

            }, JsonRequestBehavior.AllowGet);
        }

        //SalesPurchasePage

        public ActionResult SalesPurchasePage()
        {
            return View();
        }

        //Billing - Naresh Start

        //Naresh - YDT Comparision START

        public ActionResult YDTComparision(String SinDate)
        {
            //SinDate = "2014-03-17";
            //DateTime SingleDate = Convert.ToDateTime(SinDate);
            DataSet dsYDTComparision = BL.getYDTComparision();
            DataTable dtYDTComparision = dsYDTComparision.Tables[0];
            DataTable dtYDTComparision1 = dsYDTComparision.Tables[1];
            DataTable dtYDTComparision2 = dsYDTComparision.Tables[2];
            DataView view = new DataView(dtYDTComparision);
            List<System.Collections.ArrayList> YDTComparision = new List<System.Collections.ArrayList>();
            foreach (DataRow dataRow in dtYDTComparision.Rows)
            {
                System.Collections.ArrayList values = new System.Collections.ArrayList();
                foreach (object value in dataRow.ItemArray)
                    values.Add(value);
                YDTComparision.Add(values);
            }
            List<System.Collections.ArrayList> YDTComparision1 = new List<System.Collections.ArrayList>();
            foreach (DataRow dataRow in dtYDTComparision1.Rows)
            {
                System.Collections.ArrayList values = new System.Collections.ArrayList();
                foreach (object value in dataRow.ItemArray)
                    values.Add(value);
                YDTComparision1.Add(values);
            }
            List<System.Collections.ArrayList> YDTComparision2 = new List<System.Collections.ArrayList>();
            foreach (DataRow dataRow in dtYDTComparision2.Rows)
            {
                System.Collections.ArrayList values = new System.Collections.ArrayList();
                foreach (object value in dataRow.ItemArray)
                    values.Add(value);
                YDTComparision2.Add(values);
            }
            var YDTComp = YDTComparision;
            var YDTComp1 = YDTComparision1;
            var YDTComp2 = YDTComparision2;
            return Json(new
            {
                aaDataYDTComparision = YDTComp,
                aaDataYDTComparision1 = YDTComp1,
                aaDataYDTComparision2 = YDTComp2,
            }, JsonRequestBehavior.AllowGet);
        }

        //Naresh - YDT Comparision END

        //Naresh - chit START

        public ActionResult CHITNEW_MTD_YTD(String SinDate)
        {
            SinDate = "2014-03-17";
            DateTime SDate = Convert.ToDateTime(SinDate);
            DataSet dsCHITNEW_MTD_YTD = BL.getCHITNEW_MTD_YTD();
            DataTable dtCHITNEW_MTD_YTD = dsCHITNEW_MTD_YTD.Tables[0];
            DataView view = new DataView(dtCHITNEW_MTD_YTD);
            List<System.Collections.ArrayList> CHITNEW_MTD_YTD = new List<System.Collections.ArrayList>();
            foreach (DataRow dataRow in dtCHITNEW_MTD_YTD.Rows)
            {
                System.Collections.ArrayList values = new System.Collections.ArrayList();
                foreach (object value in dataRow.ItemArray)
                    values.Add(value);
                CHITNEW_MTD_YTD.Add(values);
            }
            var CHITNEW = CHITNEW_MTD_YTD;
            return Json(new
            {
                aaDataCHITNEW_MTD_YTD = CHITNEW
            }, JsonRequestBehavior.AllowGet);
        }

        //Naresh - chit END


        //End
        //Naresh - TOTALSALEVSPURCHASE START

        public ActionResult TOTALSALEVSPURCHASE(String SinDate)
        {
            SinDate = "2013-04-17";
            DateTime SDate = Convert.ToDateTime(SinDate);
            DataSet dsTOTALSALEVSPURCHASE = BL.getTOTALSALEVSPURCHASE();
            DataTable dtTOTALSALEVSPURCHASE = dsTOTALSALEVSPURCHASE.Tables[0];
            DataView view = new DataView(dtTOTALSALEVSPURCHASE);
            List<System.Collections.ArrayList> TOTALSALEVSPURCHASE = new List<System.Collections.ArrayList>();
            foreach (DataRow dataRow in dtTOTALSALEVSPURCHASE.Rows)
            {
                System.Collections.ArrayList values = new System.Collections.ArrayList();
                foreach (object value in dataRow.ItemArray)
                    values.Add(value);
                TOTALSALEVSPURCHASE.Add(values);
            }
            var totsal = TOTALSALEVSPURCHASE;
            return Json(new
            {
                aaDataTOTALSALEVSPURCHASE = totsal
            }, JsonRequestBehavior.AllowGet);
        }

        //Naresh - TOTALSALEVSPURCHASE END

        //Naresh - CREDIT_APP_OUT START

        public ActionResult CREDIT_APP_OUT(String SinDate)
        {
            SinDate = "2014-03-17";
            DateTime SDate = Convert.ToDateTime(SinDate);
            DataSet dsCREDIT_APP_OUT = BL.getCREDIT_APP_OUT();
            DataTable dtCREDIT_APP_OUT = dsCREDIT_APP_OUT.Tables[0];
            DataView view = new DataView(dtCREDIT_APP_OUT);
            List<System.Collections.ArrayList> CREDIT_APP_OUT = new List<System.Collections.ArrayList>();
            foreach (DataRow dataRow in dtCREDIT_APP_OUT.Rows)
            {
                System.Collections.ArrayList values = new System.Collections.ArrayList();
                foreach (object value in dataRow.ItemArray)
                    values.Add(value);
                CREDIT_APP_OUT.Add(values);
            }
            var app = CREDIT_APP_OUT;
            return Json(new
            {
                aaDataCREDIT_APP_OUT = app
            }, JsonRequestBehavior.AllowGet);
        }

        //Naresh - CREDIT_APP_OUT END
        //Naresh - FLOORWISE_METALSALE START

        public ActionResult FLOORWISE_METALSALE(String SinDate)
        {
            SinDate = "2014-03-17";
            DateTime SDate = Convert.ToDateTime(SinDate);
            DataSet dsFLOORWISE_METALSALE = BL.getFLOORWISE_METALSALE();
            DataTable dtFLOORWISE_METALSALE = dsFLOORWISE_METALSALE.Tables[0];
            DataView view = new DataView(dtFLOORWISE_METALSALE);
            List<System.Collections.ArrayList> FLOORWISE_METALSALE = new List<System.Collections.ArrayList>();
            foreach (DataRow dataRow in dtFLOORWISE_METALSALE.Rows)
            {
                System.Collections.ArrayList values = new System.Collections.ArrayList();
                foreach (object value in dataRow.ItemArray)
                    values.Add(value);
                FLOORWISE_METALSALE.Add(values);
            }
            var floorwise = FLOORWISE_METALSALE;
            return Json(new
            {
                aaDataFLOORWISE_METALSALE = floorwise
            }, JsonRequestBehavior.AllowGet);
        }

        //Naresh - FLOORWISE_METALSALE END
        //Naresh - CARD_CHQ_SALERETURN START

        public ActionResult CARD_CHQ_SALERETURN(String SinDate)
        {
            SinDate = "2014-03-17";
            DateTime SDate = Convert.ToDateTime(SinDate);
            DataSet dsCARD_CHQ_SALERETURN = BL.getCARD_CHQ_SALERETURN();
            DataTable dtCARD_CHQ_SALERETURN = dsCARD_CHQ_SALERETURN.Tables[0];
            DataView view = new DataView(dtCARD_CHQ_SALERETURN);
            List<System.Collections.ArrayList> CARD_CHQ_SALERETURN = new List<System.Collections.ArrayList>();
            foreach (DataRow dataRow in dtCARD_CHQ_SALERETURN.Rows)
            {
                System.Collections.ArrayList values = new System.Collections.ArrayList();
                foreach (object value in dataRow.ItemArray)
                    values.Add(value);
                CARD_CHQ_SALERETURN.Add(values);
            }
            var floorwise = CARD_CHQ_SALERETURN;
            return Json(new
            {
                aaDataCARD_CHQ_SALERETURN = floorwise
            }, JsonRequestBehavior.AllowGet);
        }

        //Naresh - CARD_CHQ_SALERETURN END
        //Naresh - orderdiamond START

        public ActionResult orderdiamond(String SinDate)
        {
            SinDate = "2014-03-17";
            DateTime SDate = Convert.ToDateTime(SinDate);
            DataSet dsorderdiamond = BL.getorderdiamond();
            DataTable dtorderdiamond = dsorderdiamond.Tables[0];
            DataView view = new DataView(dtorderdiamond);
            List<System.Collections.ArrayList> orderdiamond = new List<System.Collections.ArrayList>();
            foreach (DataRow dataRow in dtorderdiamond.Rows)
            {
                System.Collections.ArrayList values = new System.Collections.ArrayList();
                foreach (object value in dataRow.ItemArray)
                    values.Add(value);
                orderdiamond.Add(values);
            }
            var orddimond = orderdiamond;
            return Json(new
            {
                aaDataorderdiamond = orddimond
            }, JsonRequestBehavior.AllowGet);
        }

        //Naresh - orderdiamond END
        //Naresh - ordergold START

        public ActionResult ordergold(String SinDate)
        {
            SinDate = "2014-03-17";
            DateTime SDate = Convert.ToDateTime(SinDate);
            DataSet dsordergold = BL.getordergold();
            DataTable dtordergold = dsordergold.Tables[0];
            DataView view = new DataView(dtordergold);
            List<System.Collections.ArrayList> ordergold = new List<System.Collections.ArrayList>();
            foreach (DataRow dataRow in dtordergold.Rows)
            {
                System.Collections.ArrayList values = new System.Collections.ArrayList();
                foreach (object value in dataRow.ItemArray)
                    values.Add(value);
                ordergold.Add(values);
            }
            var ordGOLD = ordergold;
            return Json(new
            {
                aaDataordergold = ordGOLD
            }, JsonRequestBehavior.AllowGet);
        }

        //Naresh - ordergold END
        //Naresh - ordersilver START

        public ActionResult ordersilver(String SinDate)
        {
            SinDate = "2014-03-17";
            DateTime SDate = Convert.ToDateTime(SinDate);
            DataSet dsordersilver = BL.getordersilver();
            DataTable dtordersilver = dsordersilver.Tables[0];
            DataView view = new DataView(dtordersilver);
            List<System.Collections.ArrayList> ordersilver = new List<System.Collections.ArrayList>();
            foreach (DataRow dataRow in dtordersilver.Rows)
            {
                System.Collections.ArrayList values = new System.Collections.ArrayList();
                foreach (object value in dataRow.ItemArray)
                    values.Add(value);
                ordersilver.Add(values);
            }
            var ordsilver = ordersilver;
            return Json(new
            {
                aaDataordersilver = ordsilver
            }, JsonRequestBehavior.AllowGet);
        }

        //Naresh - ordersilver END
        //Naresh - orderpending START

        public ActionResult orderpending(String SinDate)
        {
            SinDate = "2014-03-17";
            DateTime SDate = Convert.ToDateTime(SinDate);
            DataSet dsorderpending = BL.getorderpending();
            DataTable dtorderpending = dsorderpending.Tables[0];
            DataView view = new DataView(dtorderpending);
            List<System.Collections.ArrayList> orderpending = new List<System.Collections.ArrayList>();
            foreach (DataRow dataRow in dtorderpending.Rows)
            {
                System.Collections.ArrayList values = new System.Collections.ArrayList();
                foreach (object value in dataRow.ItemArray)
                    values.Add(value);
                orderpending.Add(values);
            }
            var ordpending = orderpending;
            return Json(new
            {
                aaDataorderpending = ordpending
            }, JsonRequestBehavior.AllowGet);
        }

        //Naresh - orderpending END
        //Naresh - orderoverdue START

        public ActionResult orderoverdue(String SinDate)
        {
            SinDate = "2013-07-02";
            DateTime SDate = Convert.ToDateTime(SinDate);
            DataSet dsorderoverdue = BL.getorderoverdue();
            DataTable dtorderoverdue = dsorderoverdue.Tables[0];
            DataView view = new DataView(dtorderoverdue);
            List<System.Collections.ArrayList> orderoverdue = new List<System.Collections.ArrayList>();
            foreach (DataRow dataRow in dtorderoverdue.Rows)
            {
                System.Collections.ArrayList values = new System.Collections.ArrayList();
                foreach (object value in dataRow.ItemArray)
                    values.Add(value);
                orderoverdue.Add(values);
            }
            var ordpending = orderoverdue;
            return Json(new
            {
                aaDataorderoverdue = ordpending
            }, JsonRequestBehavior.AllowGet);
        }

        //Naresh - orderoverdue END
        //stack chart



        public ActionResult dashboardtotsal(String SinDate)
        {
            SinDate = "2013-04-17";
            DateTime SDate = Convert.ToDateTime(SinDate);
            DataSet dsdashboardtotsal = BL.dashboardtotsal1();
            DataTable dtdashboardtotsal = dsdashboardtotsal.Tables[0];
            DataView view = new DataView(dtdashboardtotsal);
            List<System.Collections.ArrayList> dashboardtotsal = new List<System.Collections.ArrayList>();
            foreach (DataRow dataRow in dtdashboardtotsal.Rows)
            {
                System.Collections.ArrayList values = new System.Collections.ArrayList();
                foreach (object value in dataRow.ItemArray)
                    values.Add(value);
                dashboardtotsal.Add(values);
            }
            var dtdashboardtotsalrpt = dashboardtotsal;
            return Json(new
            {
                aaDatadashboardtotsalrpt = dtdashboardtotsalrpt
            }, JsonRequestBehavior.AllowGet);
        }

        //linechart

        public ActionResult dashboardYearComp(String SinDate)
        {
            SinDate = "2014-08-17";
            DateTime SDate = Convert.ToDateTime(SinDate);
            DataSet dsdashboardytdcomp = BL.dashboardytdcomp();
            DataTable dtdashboardytdcomp = dsdashboardytdcomp.Tables[0];
            DataTable dtdashboardytdcomp1 = dsdashboardytdcomp.Tables[1];
            DataTable dtdashboardytdcomp2 = dsdashboardytdcomp.Tables[2];
            DataView view = new DataView(dtdashboardytdcomp);
            List<System.Collections.ArrayList> dashboardytdcomp = new List<System.Collections.ArrayList>();
            foreach (DataRow dataRow in dtdashboardytdcomp.Rows)
            {
                System.Collections.ArrayList values = new System.Collections.ArrayList();
                foreach (object value in dataRow.ItemArray)
                    values.Add(value);
                dashboardytdcomp.Add(values);
            }
            List<System.Collections.ArrayList> dashboardytdcomp1 = new List<System.Collections.ArrayList>();
            foreach (DataRow dataRow in dtdashboardytdcomp1.Rows)
            {
                System.Collections.ArrayList values = new System.Collections.ArrayList();
                foreach (object value in dataRow.ItemArray)
                    values.Add(value);
                dashboardytdcomp1.Add(values);
            }
            List<System.Collections.ArrayList> dashboardytdcomp2 = new List<System.Collections.ArrayList>();
            foreach (DataRow dataRow in dtdashboardytdcomp2.Rows)
            {
                System.Collections.ArrayList values = new System.Collections.ArrayList();
                foreach (object value in dataRow.ItemArray)
                    values.Add(value);
                dashboardytdcomp2.Add(values);
            }
            var dtdashboardytdcomprpt = dashboardytdcomp;
            var dtdashboardytdcomprpt1 = dashboardytdcomp1;
            var dtdashboardytdcomprpt2 = dashboardytdcomp2;
            return Json(new
            {
                aaDatadashboardytdcomprpt = dtdashboardytdcomprpt,
                aaDatadashboardytdcomprpt1 = dtdashboardytdcomprpt1,
                aaDatadashboardytdcomprpt2 = dtdashboardytdcomprpt2
            }, JsonRequestBehavior.AllowGet);
        }

        // Sparkline Bar Chart for chq,cash sale return starts


        public ActionResult chitchqsaleret(String date)
        {
            date = "2014-03-20";
            DateTime SDate = Convert.ToDateTime(date);
            DataTable dtchitchqsaleret = BL.rptchitchqsaleret();
            Session["dtchitchqsaleret"] = dtchitchqsaleret;
            List<System.Collections.ArrayList> chitchqsaleret = new List<System.Collections.ArrayList>();
            foreach (DataRow dataRow in dtchitchqsaleret.Rows)
            {
                System.Collections.ArrayList values = new System.Collections.ArrayList();
                foreach (object value in dataRow.ItemArray)
                    values.Add(value);
                chitchqsaleret.Add(values);
            }
            var dtchitchqsaleret1 = chitchqsaleret;
            return Json(new
            {
                aaDatachitchqsaleret = dtchitchqsaleret1,


            }, JsonRequestBehavior.AllowGet);
        }

        // Sparkline Bar Chart for chq,cash sale return ends

        //chart floorwise metal sale 
        public ActionResult FloorwisemetalSalesss1(String ToDate)
        {

            ToDate = "2013-04-17";

            DateTime EndDate = Convert.ToDateTime(ToDate);
            DataSet dsSalesrpt = BL.chartfloorwisemetal();
            DataTable dtFLOORWISE_METALSALE = dsSalesrpt.Tables[0];
            DataTable dtSalesgoldrpt = dsSalesrpt.Tables[1];
            DataTable dtSalessilver = dsSalesrpt.Tables[2];
            DataTable dtSalesdiamond = dsSalesrpt.Tables[3];
            DataTable dtSalesplatinum = dsSalesrpt.Tables[4];
            DataTable dtSaleslch = dsSalesrpt.Tables[5];
            DataTable dtSalesoth = dsSalesrpt.Tables[6];
            //    Session["dtEstCntrpt"] = dtSalesgoldrpt;
            List<string> floorname11 = new List<string>();
            List<string> item11 = new List<string>();
            List<double> quantity11 = new List<double>();
            List<double> amount11 = new List<double>();

            for (int j = 0; j < dtFLOORWISE_METALSALE.Rows.Count; j++)
            {
                floorname11.Add(dtFLOORWISE_METALSALE.Rows[j][0].ToString());
            }
            for (int j = 0; j < dtFLOORWISE_METALSALE.Rows.Count; j++)
            {
                item11.Add(dtFLOORWISE_METALSALE.Rows[j][1].ToString());
            }
            for (int j = 0; j < dtFLOORWISE_METALSALE.Rows.Count; j++)
            {
                quantity11.Add(Convert.ToDouble(dtFLOORWISE_METALSALE.Rows[j][2].ToString()));
            }
            for (int j = 0; j < dtFLOORWISE_METALSALE.Rows.Count; j++)
            {
                amount11.Add(Convert.ToDouble(dtFLOORWISE_METALSALE.Rows[j][3].ToString()));
            }

            List<System.Collections.ArrayList> dtfloorSalesChartML1 = new List<System.Collections.ArrayList>();
            foreach (DataRow dataRow in dtFLOORWISE_METALSALE.Rows)
            {
                System.Collections.ArrayList values = new System.Collections.ArrayList();
                foreach (object value in dataRow.ItemArray)
                    values.Add(value);
                dtfloorSalesChartML1.Add(values);
            }

            List<string> floorname = new List<string>();
            List<double> amount = new List<double>();

            for (int j = 0; j < dtSalesgoldrpt.Rows.Count; j++)
            {
                floorname.Add(dtSalesgoldrpt.Rows[j][0].ToString());
            }
            for (int j = 0; j < dtSalesgoldrpt.Rows.Count; j++)
            {
                amount.Add(Convert.ToDouble(dtSalesgoldrpt.Rows[j][3].ToString()));
            }

            List<System.Collections.ArrayList> dtSalesChartML = new List<System.Collections.ArrayList>();
            foreach (DataRow dataRow in dtSalesgoldrpt.Rows)
            {
                System.Collections.ArrayList values = new System.Collections.ArrayList();
                foreach (object value in dataRow.ItemArray)
                    values.Add(value);
                dtSalesChartML.Add(values);
            }

            List<string> floorname1 = new List<string>();
            List<double> amount1 = new List<double>();

            for (int j = 0; j < dtSalessilver.Rows.Count; j++)
            {
                floorname1.Add(dtSalessilver.Rows[j][0].ToString());
            }
            for (int j = 0; j < dtSalessilver.Rows.Count; j++)
            {
                amount1.Add(Convert.ToDouble(dtSalessilver.Rows[j][3].ToString()));
            }
            List<System.Collections.ArrayList> dtSalesChartMLs = new List<System.Collections.ArrayList>();
            foreach (DataRow dataRow in dtSalessilver.Rows)
            {
                System.Collections.ArrayList values = new System.Collections.ArrayList();
                foreach (object value in dataRow.ItemArray)
                    values.Add(value);
                dtSalesChartMLs.Add(values);
            }

            List<string> floornamed = new List<string>();
            List<double> amountd = new List<double>();

            for (int j = 0; j < dtSalesdiamond.Rows.Count; j++)
            {
                floornamed.Add(dtSalesdiamond.Rows[j][0].ToString());
            }
            for (int j = 0; j < dtSalesdiamond.Rows.Count; j++)
            {
                amountd.Add(Convert.ToDouble(dtSalesdiamond.Rows[j][3].ToString()));
            }
            List<System.Collections.ArrayList> dtSalesChartMLd = new List<System.Collections.ArrayList>();
            foreach (DataRow dataRow in dtSalesdiamond.Rows)
            {
                System.Collections.ArrayList values = new System.Collections.ArrayList();
                foreach (object value in dataRow.ItemArray)
                    values.Add(value);
                dtSalesChartMLd.Add(values);
            }

            List<string> floornamep = new List<string>();
            List<double> amountp = new List<double>();

            for (int j = 0; j < dtSalesplatinum.Rows.Count; j++)
            {
                floornamep.Add(dtSalesplatinum.Rows[j][0].ToString());
            }
            for (int j = 0; j < dtSalesplatinum.Rows.Count; j++)
            {
                amountp.Add(Convert.ToDouble(dtSalesplatinum.Rows[j][3].ToString()));
            }
            List<System.Collections.ArrayList> dtSalesChartMLp = new List<System.Collections.ArrayList>();
            foreach (DataRow dataRow in dtSalesplatinum.Rows)
            {
                System.Collections.ArrayList values = new System.Collections.ArrayList();
                foreach (object value in dataRow.ItemArray)
                    values.Add(value);
                dtSalesChartMLp.Add(values);
            }
            List<string> floornamel = new List<string>();
            List<double> amountl = new List<double>();

            for (int j = 0; j < dtSaleslch.Rows.Count; j++)
            {
                floornamel.Add(dtSaleslch.Rows[j][0].ToString());
            }
            for (int j = 0; j < dtSaleslch.Rows.Count; j++)
            {
                amountl.Add(Convert.ToDouble(dtSaleslch.Rows[j][3].ToString()));
            }
            List<System.Collections.ArrayList> dtSalesChartMLl = new List<System.Collections.ArrayList>();
            foreach (DataRow dataRow in dtSaleslch.Rows)
            {
                System.Collections.ArrayList values = new System.Collections.ArrayList();
                foreach (object value in dataRow.ItemArray)
                    values.Add(value);
                dtSalesChartMLl.Add(values);
            }
            List<string> floornameo = new List<string>();
            List<double> amounto = new List<double>();

            for (int j = 0; j < dtSalesoth.Rows.Count; j++)
            {
                floornameo.Add(dtSalesoth.Rows[j][0].ToString());
            }
            for (int j = 0; j < dtSalesoth.Rows.Count; j++)
            {
                amounto.Add(Convert.ToDouble(dtSalesoth.Rows[j][3].ToString()));
            }
            List<System.Collections.ArrayList> dtSalesChartMLo = new List<System.Collections.ArrayList>();
            foreach (DataRow dataRow in dtSalesoth.Rows)
            {
                System.Collections.ArrayList values = new System.Collections.ArrayList();
                foreach (object value in dataRow.ItemArray)
                    values.Add(value);
                dtSalesChartMLo.Add(values);
            }
            var dtfloorSalesChartML = dtfloorSalesChartML1;
            var dtfloorsaleChartMLchartML = dtSalesChartML;
            var dtfloorsaleChartMLchartMLs = dtSalesChartMLs;
            var dtfloorsaleChartMLchartMLd = dtSalesChartMLd;
            var dtfloorsaleChartMLchartMLp = dtSalesChartMLp;
            var dtfloorsaleChartMLchartMLl = dtSalesChartMLl;
            var dtfloorsaleChartMLchartMLo = dtSalesChartMLo;
            var SalesAmt = amount;
            var XAxis = floorname;
            var SalesAmt1 = amount1;
            var XAxis1 = floorname1;
            var SalesAmtd = amountd;
            var XAxisd = floornamed;
            var SalesAmtp = amountp;
            var XAxisp = floornamep;
            var SalesAmtl = amountl;
            var XAxisl = floornamel;
            var SalesAmto = amounto;
            var XAxiso = floornameo;




            return Json(new
            {
                aaDataFLOORWISE_METALSALE = dtfloorSalesChartML,
                aaDatafulltable = dtfloorsaleChartMLchartML,
                aaDatafulltables = dtfloorsaleChartMLchartMLs,
                aaDatafulltabled = dtfloorsaleChartMLchartMLd,
                aaDatafulltablep = dtfloorsaleChartMLchartMLp,
                aaDatafulltablel = dtfloorsaleChartMLchartMLl,
                aaDatafulltableo = dtfloorsaleChartMLchartMLo,
                aaDataSalesAmt = SalesAmt,
                aaDataAxis = XAxis,
                aaDataSalesAmt1 = SalesAmt1,
                aaDataAxis1 = XAxis1,
                aaDataSalesAmtd = SalesAmtd,
                aaDataAxisd = XAxisd,
                aaDataSalesAmtp = SalesAmtp,
                aaDataAxisp = XAxisp,
                aaDataSalesAmtl = SalesAmtl,
                aaDataAxisl = XAxisl,
                aaDataSalesAmto = SalesAmto,
                aaDataAxiso = XAxiso,
            }, JsonRequestBehavior.AllowGet);
        }
        //chart floorwise metal sale ends 

        //Billing - Naresh End


        // Chit Collection Starts//

        public ActionResult DashboardChitRpt()
        {
            return View();
        }

        public ActionResult DashboardChitTable()
        {
            return View();
        }

        public ActionResult DashboardChitCollection()
        {
            DataTable dtTableChitCollection = BL.TableChitCollection();
            List<System.Collections.ArrayList> chitcollec = new List<System.Collections.ArrayList>();
            foreach (DataRow dataRow in dtTableChitCollection.Rows)
            {
                System.Collections.ArrayList values = new System.Collections.ArrayList();
                foreach (object value in dataRow.ItemArray)
                    values.Add(value);
                chitcollec.Add(values);
            }
            var dtchitcollec = chitcollec;
            return Json(new
            {
                aaDatadtchitcollec = dtchitcollec,

            }, JsonRequestBehavior.AllowGet);
        }



        public ActionResult DashboardPDC()
        {
            DataTable dtChitPDCRemainder = BL.ChitPDCRemainder();
            List<System.Collections.ArrayList> PDCRemainder = new List<System.Collections.ArrayList>();
            foreach (DataRow dataRow in dtChitPDCRemainder.Rows)
            {
                System.Collections.ArrayList values = new System.Collections.ArrayList();
                foreach (object value in dataRow.ItemArray)
                    values.Add(value);
                PDCRemainder.Add(values);
            }
            var dtPDCRemainder = PDCRemainder;
            return Json(new
            {
                aaDataPDCRemainder = dtPDCRemainder,

            }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult ChitCustomerInfo()
        {
            return View();
        }

        public ActionResult ChitStatusReminder()
        {
            return View();
        }

        public ActionResult PDCChequeReminder()
        {
            return View();
        }

        public ActionResult PDCChequeDetails(DateTime fromdate, DateTime todate)
        {
            DataTable dtChitPDCRemainderDrilldown = BL.ChitPDCRemainderdrilldown(fromdate, todate);
            List<System.Collections.ArrayList> PDCRemainderdrilldwn = new List<System.Collections.ArrayList>();
            foreach (DataRow dataRow in dtChitPDCRemainderDrilldown.Rows)
            {
                System.Collections.ArrayList values = new System.Collections.ArrayList();
                foreach (object value in dataRow.ItemArray)
                    values.Add(value);
                PDCRemainderdrilldwn.Add(values);
            }
            var model = Enumerable.Range(0, dtChitPDCRemainderDrilldown.Rows.Count).Select(x => new PDCCheque
            {
                PDCRECEIPTNO = dtChitPDCRemainderDrilldown.Rows[x]["PDCRECEIPTNO"].ToString(),
                PDCRECEIPTDATE = dtChitPDCRemainderDrilldown.Rows[x]["PDCRECEIPTDATE"].ToString(),
                GROUPCODE = dtChitPDCRemainderDrilldown.Rows[x]["GROUPCODE"].ToString(),
                REGNO = dtChitPDCRemainderDrilldown.Rows[x]["REGNO"].ToString(),
                CHEQUENO = dtChitPDCRemainderDrilldown.Rows[x]["CHEQUENO"].ToString(),
                CHEQUEDATE = dtChitPDCRemainderDrilldown.Rows[x]["CHEQUEDATE"].ToString(),
                CHEQUEBANK = dtChitPDCRemainderDrilldown.Rows[x]["CHEQUEBANK"].ToString(),
                CHEQUEAMOUNT = dtChitPDCRemainderDrilldown.Rows[x]["CHEQUEAMOUNT"].ToString(),
                status = dtChitPDCRemainderDrilldown.Rows[x]["status"].ToString(),

            });
            return Json(new
            {
                aaData = model,
            }, JsonRequestBehavior.AllowGet);
        }

        //End                     

        //Dashdoard Floorwise MetalSales YTD starts//
        public ActionResult DashdoardFloorwiseMetalSalesYTD()
        {
            DataTable dtFloorwiseMetalSalesYTD = BL.FloorwiseMetalSalesYTD();
            List<System.Collections.ArrayList> FloorwiseMetalSalesYTD = new List<System.Collections.ArrayList>();
            foreach (DataRow dataRow in dtFloorwiseMetalSalesYTD.Rows)
            {
                System.Collections.ArrayList values = new System.Collections.ArrayList();
                foreach (object value in dataRow.ItemArray)
                    values.Add(value);
                FloorwiseMetalSalesYTD.Add(values);
            }
            var dtFloorwiseMetalSalYTD = FloorwiseMetalSalesYTD;
            return Json(new
            {
                aaDataFloorwiseMetalSalesYTD = dtFloorwiseMetalSalYTD,

            }, JsonRequestBehavior.AllowGet);
        }
        //Dashdoard Floorwise MetalSales YTD ends//

        //pdc starts
        public ActionResult PDCChequepend()
        {
            DataTable dtPDC = BL.PDCCheque();
            List<System.Collections.ArrayList> dtPDCPEND = new List<System.Collections.ArrayList>();
            foreach (DataRow dataRow in dtPDC.Rows)
            {
                System.Collections.ArrayList values = new System.Collections.ArrayList();
                foreach (object value in dataRow.ItemArray)
                    values.Add(value);
                dtPDCPEND.Add(values);
            }
            var dtPDCpending = dtPDCPEND;
            List<string> STATUS = new List<string>();
            List<double> CHEQUEAMOUNT = new List<double>();
            List<double> CNT = new List<double>();

            for (int j = 0; j < dtPDC.Rows.Count; j++)
            {
                STATUS.Add(dtPDC.Rows[j][0].ToString());
            }
            for (int j = 0; j < dtPDC.Rows.Count; j++)
            {
                CHEQUEAMOUNT.Add(Convert.ToDouble(dtPDC.Rows[j][1].ToString()));
            }
            for (int j = 0; j < dtPDC.Rows.Count; j++)
            {
                CNT.Add(Convert.ToDouble(dtPDC.Rows[j][2].ToString()));
            }


            var STATUS1 = STATUS;
            var CHEQUEAMOUNT1 = CHEQUEAMOUNT;
            var CNT1 = CNT;

            return Json(new
            {
                aaDataPDCpending = dtPDCpending,
                aaDataSTATUS1 = STATUS1,
                aaDataAMT1 = CHEQUEAMOUNT1,
                aaDataCOUNT = CNT1,

            }, JsonRequestBehavior.AllowGet);
        }

        // Floorwise metal YTD starts//
        public ActionResult FloorwiseMetalTable()
        {
            DataTable dtFloorwiseMetalTable = BL.FloorwiseMetalTable();
            List<System.Collections.ArrayList> dtfloorwisemet = new List<System.Collections.ArrayList>();
            foreach (DataRow dataRow in dtFloorwiseMetalTable.Rows)
            {
                System.Collections.ArrayList values = new System.Collections.ArrayList();
                foreach (object value in dataRow.ItemArray)
                    values.Add(value);
                dtfloorwisemet.Add(values);
            }
            var dtfloorwisemetal = dtfloorwisemet;
            return Json(new
            {
                aaDatafloorwisemetal = dtfloorwisemetal,
            }, JsonRequestBehavior.AllowGet);
        }
        // Floorwise metal YTD end//




        //Floorwise metal drilldown starts//
        public ActionResult FloorwiseMetalSales()
        {
            return View();
        }
        public ActionResult FloorwiseSaleMetal(DateTime fromdate, DateTime todate)
        {
            DataTable dtFloorwiseSaleMetal = BL.FloorwiseSaleMetal(fromdate, todate);
            Session["dtFloorwiseSaleMetal"] = dtFloorwiseSaleMetal;
            List<System.Collections.ArrayList> FloorwiseSaleMet = new List<System.Collections.ArrayList>();
            foreach (DataRow dataRow in dtFloorwiseSaleMetal.Rows)
            {
                System.Collections.ArrayList values = new System.Collections.ArrayList();
                foreach (object value in dataRow.ItemArray)
                    values.Add(value);
                FloorwiseSaleMet.Add(values);
            }
            var model = Enumerable.Range(0, dtFloorwiseSaleMetal.Rows.Count).Select(x => new FloorwiseSaleMetalDrilldown
            {
                FLOORNAME = dtFloorwiseSaleMetal.Rows[x]["FLOORNAME"].ToString(),
                GOLD = dtFloorwiseSaleMetal.Rows[x]["GOLD"].ToString(),
                SILVER = dtFloorwiseSaleMetal.Rows[x]["SILVER"].ToString(),
                DIAMOND = dtFloorwiseSaleMetal.Rows[x]["DIAMOND"].ToString(),
                OTHERS = dtFloorwiseSaleMetal.Rows[x]["OTHERS"].ToString(),
            });
            return Json(new
            {
                aaData = model,

            }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult DailyChitCollection()
        {
            return View();
        }

        //Top10counterwise sales
        public ActionResult Top10Counterwisesales()
        {
            return View();
        }
        public ActionResult GetSalesCounterWisedata(DateTime FromDate, DateTime ToDate)
        {
            DataTable DTSalesCounterWisedata = BL.drilldownCounterwise(FromDate, ToDate);
            Session["DTSalesCounterWisedata"] = DTSalesCounterWisedata;
            List<System.Collections.ArrayList> SalesCounterWisedata = new List<System.Collections.ArrayList>();
            foreach (DataRow dataRow in DTSalesCounterWisedata.Rows)
            {
                System.Collections.ArrayList values = new System.Collections.ArrayList();
                foreach (object value in dataRow.ItemArray)
                    values.Add(value);
                SalesCounterWisedata.Add(values);
            }
            // var dtSalesCounterWise = SalesCounterWisedata;
            var model = Enumerable.Range(0, DTSalesCounterWisedata.Rows.Count).Select(x => new CounterwisesalesDrilldown
            {
                COUNTERNAME = DTSalesCounterWisedata.Rows[x]["COUNTERNAME"].ToString(),
                NETWT = DTSalesCounterWisedata.Rows[x]["NETWT"].ToString(),
                AMOUNT = DTSalesCounterWisedata.Rows[x]["AMOUNT"].ToString(),
            });
            return Json(new
            {
                aaData = model,

            }, JsonRequestBehavior.AllowGet);

        }

        public ActionResult drilldownSalePurchase(DateTime fromdate, DateTime todate)
        {
            DataTable dtSalePurchase = BL.drilldownSalePurchase(fromdate, todate);
            Session["dtSalePurchase"] = dtSalePurchase;
            List<System.Collections.ArrayList> FloorwiseSaleMet = new List<System.Collections.ArrayList>();
            foreach (DataRow dataRow in dtSalePurchase.Rows)
            {
                System.Collections.ArrayList values = new System.Collections.ArrayList();
                foreach (object value in dataRow.ItemArray)
                    values.Add(value);
                FloorwiseSaleMet.Add(values);
            }
            var model = Enumerable.Range(0, dtSalePurchase.Rows.Count).Select(x => new SalePurchaseDrilldown
            {
                WEEKID = dtSalePurchase.Rows[x]["WEEKID"].ToString(),
                SALEAMOUNT = dtSalePurchase.Rows[x]["SALEAMOUNT"].ToString(),
                PURCHASEAMOUNT = dtSalePurchase.Rows[x]["PURCHASEAMOUNT"].ToString(),
                PRICE = dtSalePurchase.Rows[x]["PRICE"].ToString(),
                DATERANGE = dtSalePurchase.Rows[x]["DATERANGE"].ToString(),
            });
            return Json(new
            {
                aaData = model,

            }, JsonRequestBehavior.AllowGet);
        }

        // DailySalesVsTarget SILVERMINE starts

        public ActionResult getDailySalesTargetSILVERshowroom(DateTime fromdate, DateTime todate)
        {
            DataTable dtDailySalesTargetSILVERshowroom = BL.getDailysalesSILVERshowroom(fromdate, todate);

            List<System.Collections.ArrayList> DailySalesTargetSILVERshowroom = new List<System.Collections.ArrayList>();
            foreach (DataRow dataRow in dtDailySalesTargetSILVERshowroom.Rows)
            {
                System.Collections.ArrayList values = new System.Collections.ArrayList();
                foreach (object value in dataRow.ItemArray)
                    values.Add(value);
                DailySalesTargetSILVERshowroom.Add(values);
            }
            var model = Enumerable.Range(0, dtDailySalesTargetSILVERshowroom.Rows.Count).Select(x => new DailysalesSILVERShowroomDrilldown
            {
                ITEM = dtDailySalesTargetSILVERshowroom.Rows[x]["ITEM"].ToString(),
                DAILYTARGET = dtDailySalesTargetSILVERshowroom.Rows[x]["DAILYTARGET"].ToString(),
                NETWT = dtDailySalesTargetSILVERshowroom.Rows[x]["NETWT"].ToString(),
                DAILYTARGETPER = dtDailySalesTargetSILVERshowroom.Rows[x]["DAILYTARGETPER"].ToString(),
                CNETWT = dtDailySalesTargetSILVERshowroom.Rows[x]["CNETWT"].ToString()
            });
            return Json(new
            {
                aaData = model,

            }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult getDailySalesTargetSILVERmgt(DateTime fromdate, DateTime todate)
        {
            DataTable dtDailySalesTargetSILVERmgt = BL.getDailysalesSILVERmgt(fromdate, todate);

            List<System.Collections.ArrayList> DailySalesTargetSILVERmgt = new List<System.Collections.ArrayList>();
            foreach (DataRow dataRow in dtDailySalesTargetSILVERmgt.Rows)
            {
                System.Collections.ArrayList values = new System.Collections.ArrayList();
                foreach (object value in dataRow.ItemArray)
                    values.Add(value);
                DailySalesTargetSILVERmgt.Add(values);
            }
            var model = Enumerable.Range(0, dtDailySalesTargetSILVERmgt.Rows.Count).Select(x => new DailysalesSILVERmgtDrilldown
            {
                ITEM = dtDailySalesTargetSILVERmgt.Rows[x]["ITEM"].ToString(),
                ANNUALTARGET = dtDailySalesTargetSILVERmgt.Rows[x]["ANNUALTARGET"].ToString(),
                NETWT = dtDailySalesTargetSILVERmgt.Rows[x]["NETWT"].ToString(),
                ANNUALTARGETPER = dtDailySalesTargetSILVERmgt.Rows[x]["ANNUALTARGETPER"].ToString(),
                CNETWT = dtDailySalesTargetSILVERmgt.Rows[x]["CNETWT"].ToString()
            });
            return Json(new
            {
                aaData = model,

            }, JsonRequestBehavior.AllowGet);

        }
        //END//

        //Daily chit collection-New chit starts//

        public ActionResult ChitDailyCollections()
        {
            DataSet DSChitDailyCollections = BL.ChitDailyCollections();
            DataTable DTChitDailyCollectionsTB0 = DSChitDailyCollections.Tables[0];

            List<System.Collections.ArrayList> DTDailyCollectionsTB0 = new List<System.Collections.ArrayList>();
            foreach (DataRow dataRow in DTChitDailyCollectionsTB0.Rows)
            {
                System.Collections.ArrayList values = new System.Collections.ArrayList();
                foreach (object value in dataRow.ItemArray)
                    values.Add(value);
                DTDailyCollectionsTB0.Add(values);
            }

            var model = Enumerable.Range(0, DTChitDailyCollectionsTB0.Rows.Count).Select(x => new DailyChitCollectionDrilldown
            {
                PNAME = DTChitDailyCollectionsTB0.Rows[x]["PNAME"].ToString(),
                PERSONALID = DTChitDailyCollectionsTB0.Rows[x]["PERSONALID"].ToString(),
                GROUPCODE = DTChitDailyCollectionsTB0.Rows[x]["GROUPCODE"].ToString(),
                SCHEMENAME = DTChitDailyCollectionsTB0.Rows[x]["SCHEMENAME"].ToString(),
                JOINDATE = DTChitDailyCollectionsTB0.Rows[x]["JOINDATE"].ToString(),
                REGNO = DTChitDailyCollectionsTB0.Rows[x]["REGNO"].ToString(),
                AMOUNT = DTChitDailyCollectionsTB0.Rows[x]["AMOUNT"].ToString()
            });
            return Json(new
            {
                aaData = model,

            }, JsonRequestBehavior.AllowGet);

        }

        //Daily chit collection-Existing chit starts//
        public ActionResult ExistingChitCollection()
        {
            return View();
        }

        public ActionResult OnlineChitCollection()
        {
            return View();
        }

        public ActionResult ChitDailyCollections1()
        {
            DataSet DSChitDailyCollections = BL.ChitDailyCollections();

            DataTable DTChitDailyCollectionsTB1 = DSChitDailyCollections.Tables[1];

            List<System.Collections.ArrayList> DTDailyCollectionsTB1 = new List<System.Collections.ArrayList>();
            foreach (DataRow dataRow in DTChitDailyCollectionsTB1.Rows)
            {
                System.Collections.ArrayList values = new System.Collections.ArrayList();
                foreach (object value in dataRow.ItemArray)
                    values.Add(value);
                DTDailyCollectionsTB1.Add(values);
            }

            var model = Enumerable.Range(0, DTChitDailyCollectionsTB1.Rows.Count).Select(x => new DailyChitCollection1Drilldown
            {
                PNAME = DTChitDailyCollectionsTB1.Rows[x]["PNAME"].ToString(),
                PERSONALID = DTChitDailyCollectionsTB1.Rows[x]["PERSONALID"].ToString(),
                GROUPCODE = DTChitDailyCollectionsTB1.Rows[x]["GROUPCODE"].ToString(),
                SCHEMENAME = DTChitDailyCollectionsTB1.Rows[x]["SCHEMENAME"].ToString(),
                JOINDATE = DTChitDailyCollectionsTB1.Rows[x]["JOINDATE"].ToString(),
                RDATE = DTChitDailyCollectionsTB1.Rows[x]["RDATE"].ToString(),
                REGNO = DTChitDailyCollectionsTB1.Rows[x]["REGNO"].ToString(),
                AMOUNT = DTChitDailyCollectionsTB1.Rows[x]["AMOUNT"].ToString()
            });
            return Json(new
            {
                aaData = model,

            }, JsonRequestBehavior.AllowGet);

        }

        //Daily chit collection-OnlineTransaction starts//
        public ActionResult ChitDailyCollections2()
        {
            DataSet DSChitDailyCollections = BL.ChitDailyCollections();

            DataTable DTChitDailyCollectionsTB2 = DSChitDailyCollections.Tables[2];

            List<System.Collections.ArrayList> DTDailyCollectionsTB2 = new List<System.Collections.ArrayList>();
            foreach (DataRow dataRow in DTChitDailyCollectionsTB2.Rows)
            {
                System.Collections.ArrayList values = new System.Collections.ArrayList();
                foreach (object value in dataRow.ItemArray)
                    values.Add(value);
                DTDailyCollectionsTB2.Add(values);
            }

            var model = Enumerable.Range(0, DTChitDailyCollectionsTB2.Rows.Count).Select(x => new DailyChitCollection2Drilldown
            {
                PNAME = DTChitDailyCollectionsTB2.Rows[x]["PNAME"].ToString(),
                PERSONALID = DTChitDailyCollectionsTB2.Rows[x]["PERSONALID"].ToString(),
                GROUPCODE = DTChitDailyCollectionsTB2.Rows[x]["GROUPCODE"].ToString(),
                SCHEMENAME = DTChitDailyCollectionsTB2.Rows[x]["SCHEMENAME"].ToString(),
                JOINDATE = DTChitDailyCollectionsTB2.Rows[x]["JOINDATE"].ToString(),
                RDATE = DTChitDailyCollectionsTB2.Rows[x]["RDATE"].ToString(),
                REGNO = DTChitDailyCollectionsTB2.Rows[x]["REGNO"].ToString(),
                AMOUNT = DTChitDailyCollectionsTB2.Rows[x]["AMOUNT"].ToString()
            });
            return Json(new
            {
                aaData = model,

            }, JsonRequestBehavior.AllowGet);

        }

        //ChitDailyCollections ends
        //USER MASTER - Starts //

        public ActionResult UserMasterSample()
        {
            return View();
        }       

        public ActionResult UserDetails()
        {
            DataTable dtUserDetails = BL.rptUserDetails();
            Session["dtAllUsers"] = dtUserDetails;
            List<System.Collections.ArrayList> dtUSER = new List<System.Collections.ArrayList>();
            foreach (DataRow dataRow in dtUserDetails.Rows)
            {
                System.Collections.ArrayList values = new System.Collections.ArrayList();
                foreach (object value in dataRow.ItemArray)
                    values.Add(value);
                dtUSER.Add(values);
            }
            var model = Enumerable.Range(0, dtUserDetails.Rows.Count).Select(x => new UserMaster
            {
                ID = dtUserDetails.Rows[x]["ID"].ToString(),
                UserName = dtUserDetails.Rows[x]["UserName"].ToString(),
                Email = dtUserDetails.Rows[x]["Email"].ToString(),
                Phone = dtUserDetails.Rows[x]["Phone"].ToString(),
                Phone2 = dtUserDetails.Rows[x]["Phone2"].ToString(),
                FirstName = dtUserDetails.Rows[x]["FirstName"].ToString(),
                LastName = dtUserDetails.Rows[x]["LastName"].ToString(),
                ACTIVE = dtUserDetails.Rows[x]["ACTIVE"].ToString(),
                UserTypeName = dtUserDetails.Rows[x]["UserTypeName"].ToString(),

            });
            return Json(new
            {
                aaData = model,

            }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult UserDelete(String Id)
        {
            Int32 id = BL.DeleteUSer(Convert.ToInt32(Id));

            if (id == 1)
            {
                var su = id.ToString();
                return Json(su);
            }
            else
            {
                var spa = "Some problem occured";
                return Json(spa);
            }
        }

        String Ids;
        String CIds;
        String utypes;
        String ACT;
        String A_Ids;
        String A_CIds;
        String A_utypes;
        String A_ACT;

        public ActionResult SampleEditUser(String Username, String Email, String Pass, String FName, String LName, String Phone,
            String Phone2, String Active, String UserType)
        {
            String CompanyId = "1";
            Session["CompanyID"] = CompanyId;
            String UserID = "54";
            String E_companyname = (string)Session["CompanyID"];
            DataTable dt = Session["dtAllUsers"] as DataTable;

            IEnumerable<DataRow> q_User_ID = from order in dt.AsEnumerable()
                                             where order.Field<String>("Email") == Email
                                             //&& order.Field<String>("CompanyName") == E_companyname
                                             select order;

            foreach (DataRow dr in q_User_ID)
            {
                Ids = dr[0].ToString();
            }

            CIds = (string)Session["CompanyID"];
            if (Active == "True") { ACT = "1"; }
            if (Active == "False") { ACT = "0"; }
            if (UserType == "Showroom") { utypes = "6"; }
            if (UserType == "Chit") { utypes = "11"; }
            if (UserType == "Billing") { utypes = "12"; }
            if (UserType == "Testing") { utypes = "15"; }
            if (UserType == "Testing1") { utypes = "16"; }
            int ID = BL.InsertUpdateUser(Ids, Username, "", Email, Phone, Phone2, FName, LName, CIds, utypes, ACT, Convert.ToInt32(UserID));
            Session["EditUserID"] = "";
            if (ID != -1)
            {
                var ss = 1;
                return Json(ss);
            }
            else
            {
                var se = 2;
                return Json(se);
            }
        }

        public ActionResult SampleAddNewUser(String Username, String Email, String Pass, String FName, String LName, String Phone, String Phone2, String Active, String UserType)
        {
            String UserID = "47";
            String CompanyId = "1";
            Session["CompanyID"] = CompanyId;
            String A_companyname = "1";
            DataTable dt = Session["dtAllUsers"] as DataTable;

            IEnumerable<DataRow> q_User_ID = from order in dt.AsEnumerable()
                                             where order.Field<String>("Email") == Email
                                             && order.Field<String>("CompanyName") == A_companyname
                                             select order;

            foreach (DataRow dr in q_User_ID)
            {
                Ids = dr[0].ToString();
            }
            A_CIds = (string)Session["CompanyID"];

            if (Active == "Active") { A_ACT = "1"; }
            if (Active == "InActive") { A_ACT = "0"; }
            if (UserType == "Showroom") { A_utypes = "6"; }
            if (UserType == "Chit") { A_utypes = "11"; }
            if (UserType == "Billing") { A_utypes = "12"; }
            int ID = BL.InsertUpdateUser("Insert", Username, Pass, Email, Phone, Phone2, FName, LName, A_CIds, A_utypes, A_ACT, Convert.ToInt32(UserID));//HashPass
            if (ID == -1)
            {
                var su = "2";
                return Json(su);
            }
            else
            {
                var spa = "1";
                return Json(spa);
            }
        }
    }
        //USER MASTER - Ends //
}
