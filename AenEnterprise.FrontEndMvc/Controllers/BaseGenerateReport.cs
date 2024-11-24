using AenEnterprise.ServiceImplementations.Interface;
using AspNetCore.Reporting;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;

namespace AenEnterprise.FrontEndMvc.Controllers
{
    public class BaseGenerateReport : Controller
    {
        string connectionString;
        private readonly IWebHostEnvironment _env;
        

        public BaseGenerateReport(IWebHostEnvironment env)
        {
            connectionString = "Data Source=host.docker.internal;Initial Catalog=AenDbEnterprise;User ID=SA;Password=StrongPassw0rd!;Encrypt=False;TrustServerCertificate=True";
            _env = env;
        }

        // Removed 'static' keyword so it's an instance method
        public FileContentResult GenerateReport(string storedProcedureName, SqlParameter[] parameters, string dataSetName, string reportFileName, string dataSourceName)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(storedProcedureName, conn))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddRange(parameters);

                    using (SqlDataAdapter sqlAdapt = new SqlDataAdapter(cmd))
                    {
                        string mimeType = "application/pdf";
                        string reportPath = _env.WebRootPath + "\\Reports\\" + reportFileName;

                        var localReport = new LocalReport(reportPath);

                        try
                        {
                            // Fetch data from the database and fill a DataTable
                            DataTable dataTable = new DataTable();
                            sqlAdapt.Fill(dataTable);

                            localReport.AddDataSource(dataSourceName, dataTable);

                            // Generate the PDF report
                            var result = localReport.Execute(RenderType.Pdf, 1, null, mimeType);

                            // Return the file using the instance method of Controller
                            return File(result.MainStream, mimeType);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Error: " + ex.Message);
                            throw;
                        }
                    }
                }
            }
        }
    }

}
