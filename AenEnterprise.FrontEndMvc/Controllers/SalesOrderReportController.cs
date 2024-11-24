
using AenEnterprise.ServiceImplementations.Interface;
using AspNetCore.Reporting;
using AspNetCore.Reporting.ReportExecutionService;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;

namespace AenEnterprise.FrontEndMvc.Controllers
{
    public class SalesOrderReportController : Controller
    {
        private readonly BaseGenerateReport _baseGenerateReport;

        public SalesOrderReportController(IWebHostEnvironment env, ISalesOrderService salesOrderService)
        {
            _baseGenerateReport = new BaseGenerateReport(env);
        }

        public FileContentResult GetCustomerOrderDetailsById(int customerId)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
            new SqlParameter("@CustomerId", SqlDbType.Int) { Value = customerId }
            };

            // Call the instance method on _baseGenerateReport
            return _baseGenerateReport.GenerateReport("spGetCustomerOrderDetails", parameters, "AenDbEnterpriseDataSet", "CustomerOrderDetails.rdlc", "AenDbEnterpriseDataSet");
        }

        public FileContentResult GetSalesOrderById(int salesOrderId)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
        new SqlParameter("@SalesOrderId", SqlDbType.Int) { Value = salesOrderId }
            };

            string query = @"
     SELECT SalesOrders.Id, SalesOrders.SalesOrderNo, SalesOrders.OrderedDate, Customers.Name AS CustomerName, 
            OrderItems.Id AS ItemId, OrderItems.Price, OrderItems.Quantity, Products.Name AS ProductName, 
            Unit.Name AS UnitName, OrderItems.NetAmount, OrderItems.DiscountPercent
     FROM SalesOrders 
     INNER JOIN OrderItems ON SalesOrders.Id = OrderItems.SalesOrderId
     INNER JOIN Products ON OrderItems.ProductId = Products.Id
     INNER JOIN Customers ON SalesOrders.CustomerId = Customers.Id
     INNER JOIN Unit ON OrderItems.UnitId = Unit.Id
     WHERE SalesOrders.Id = @SalesOrderId;";

            // Call the instance method on _baseGenerateReport
            return _baseGenerateReport.GenerateReport(query, parameters, "DataSetSales", "SalesOrderDetails.rdlc", "DataSetSales");
        }


        public FileContentResult GetInvoiceBySalesOrderId(int invoiceId)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
            new SqlParameter("@InvoiceId", SqlDbType.Int) { Value =invoiceId }
            };

            // Call the instance method on _baseGenerateReport
            return _baseGenerateReport.GenerateReport("spGetInvoiceBySalesOrderId", parameters, "DataSetSales", "InvoiceDetails.rdlc", "DataSetSales");
        }


        public FileContentResult GetDeliveryOrderBySalesOrderId(int deliveryOrderId)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
            new SqlParameter("@DeliveryOrderId", SqlDbType.Int) { Value =deliveryOrderId}
            };

            return _baseGenerateReport.GenerateReport("spGetDeliveryOrderById", parameters, "DataSetDeliveryOrder", "DeliveryOrderById.rdlc", "DataSetDeliveryOrder");
        }




        //public FileContentResult GetDeliveryOrderBySalesOrderId(int salesOrderId)
        //{
        //    string query = "SELECT * FROM spGetDeliveryOrderBySalesOrderId WHERE @SalesOrderId=" + salesOrderId;

        //    using (SqlConnection conn = new SqlConnection(connectionString))
        //    {
        //        conn.Open();
        //        using (SqlCommand cmd = new SqlCommand("spGetDeliveryOrderBySalesOrderId", conn))
        //        {
        //            cmd.CommandType = CommandType.StoredProcedure; ;
        //            cmd.Parameters.Add("@SalesOrderId", SqlDbType.Int).Value = salesOrderId;
        //            using (SqlDataAdapter sqlAdapt = new SqlDataAdapter(cmd))
        //            {

        //                string mimeType = "application/pdf";
        //                string reportPath = _env.WebRootPath + "\\Reports\\DeliveryOrderDetails.rdlc";
        //                var localReport = new LocalReport(reportPath);

        //                try
        //                {
        //                    // Fetch data from the database and fill a DataTable
        //                    DataTable dataTable = new DataTable();
        //                    sqlAdapt.Fill(dataTable);

        //                    localReport.AddDataSource("DataSetSales", dataTable);

        //                    var result = localReport.Execute(RenderType.Pdf, 1, null, mimeType);
        //                    return File(result.MainStream, mimeType);

        //                    //this line if I want open report in current page
        //                    //return File(result.MainStream, mimeType, "SalesOrderReport.pdf");
        //                }
        //                catch (Exception ex)
        //                {
        //                    // Log exceptions to a file or preferred logging mechanism
        //                    Console.WriteLine("Error: " + ex.Message);
        //                    throw; // Propagate the exception if needed
        //                }
        //            }
        //        }

        //    }
        //}
        //public FileContentResult SalesOrderDetails()
        //{
        //    string query = "SELECT * FROM View_GetAllSalesOrderWithOrderItems";
        //    using (SqlConnection conn = new SqlConnection(connectionString))
        //    {
        //        conn.Open();
        //        using (SqlDataAdapter sqlAdapt = new SqlDataAdapter(query, conn))
        //        {
        //            string mimeType = "application/pdf";
        //            string reportPath = _env.WebRootPath + "\\Reports\\SalesOrderDetails.rdlc";
        //            var localReport = new LocalReport(reportPath);

        //            try
        //            {
        //                // Fetch data from the database and fill a DataTable
        //                DataTable dataTable = new DataTable();
        //                sqlAdapt.Fill(dataTable);



        //                localReport.AddDataSource("DataSetInvoice", dataTable);

        //                var result = localReport.Execute(RenderType.Pdf, 1, null, mimeType);
        //                return File(result.MainStream, mimeType);
        //            }
        //            catch (Exception ex)
        //            {
        //                // Log exceptions to a file or preferred logging mechanism
        //                Console.WriteLine("Error: " + ex.Message);
        //                throw; // Propagate the exception if needed
        //            }
        //        }
        //    }
        //}
    }
}

