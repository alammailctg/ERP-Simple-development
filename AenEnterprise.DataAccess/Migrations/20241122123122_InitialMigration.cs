using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AenEnterprise.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ProductionOrders",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.UpdateData(
                table: "Branches",
                keyColumn: "BranchId",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 22, 18, 31, 15, 990, DateTimeKind.Local).AddTicks(6251));

            migrationBuilder.UpdateData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ExpiryDate", "IncorporationDate" },
                values: new object[] { new DateTime(2019, 11, 22, 18, 31, 16, 44, DateTimeKind.Local).AddTicks(238), new DateTime(2029, 11, 22, 18, 31, 16, 44, DateTimeKind.Local).AddTicks(241), new DateTime(2019, 11, 22, 18, 31, 16, 44, DateTimeKind.Local).AddTicks(203) });

            migrationBuilder.UpdateData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "ExpiryDate", "IncorporationDate" },
                values: new object[] { new DateTime(2019, 11, 22, 18, 31, 16, 44, DateTimeKind.Local).AddTicks(255), new DateTime(2029, 11, 22, 18, 31, 16, 44, DateTimeKind.Local).AddTicks(257), new DateTime(2019, 11, 22, 18, 31, 16, 44, DateTimeKind.Local).AddTicks(253) });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 22, 18, 31, 15, 843, DateTimeKind.Local).AddTicks(1468));

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 22, 18, 31, 15, 843, DateTimeKind.Local).AddTicks(1516));

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 22, 18, 31, 15, 843, DateTimeKind.Local).AddTicks(1519));

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 22, 18, 31, 15, 843, DateTimeKind.Local).AddTicks(1523));

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 22, 18, 31, 15, 843, DateTimeKind.Local).AddTicks(1525));

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 22, 18, 31, 15, 843, DateTimeKind.Local).AddTicks(1528));

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 22, 18, 31, 15, 843, DateTimeKind.Local).AddTicks(1530));

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 22, 18, 31, 15, 843, DateTimeKind.Local).AddTicks(1536));

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 22, 18, 31, 15, 843, DateTimeKind.Local).AddTicks(1539));

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 22, 18, 31, 15, 843, DateTimeKind.Local).AddTicks(1541));

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 22, 18, 31, 15, 843, DateTimeKind.Local).AddTicks(1544));

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 22, 18, 31, 15, 843, DateTimeKind.Local).AddTicks(1546));

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 22, 18, 31, 15, 843, DateTimeKind.Local).AddTicks(1548));

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 22, 18, 31, 15, 843, DateTimeKind.Local).AddTicks(1551));

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 22, 18, 31, 15, 843, DateTimeKind.Local).AddTicks(1553));

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 22, 18, 31, 15, 843, DateTimeKind.Local).AddTicks(1555));

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 22, 18, 31, 15, 843, DateTimeKind.Local).AddTicks(1557));

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 22, 18, 31, 15, 843, DateTimeKind.Local).AddTicks(1560));

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 22, 18, 31, 15, 843, DateTimeKind.Local).AddTicks(1563));

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 22, 18, 31, 15, 843, DateTimeKind.Local).AddTicks(1566));

            migrationBuilder.UpdateData(
                table: "DemandPlannings",
                keyColumn: "Id",
                keyValue: 1,
                column: "ForecastDate",
                value: new DateTime(2024, 11, 22, 12, 31, 15, 859, DateTimeKind.Utc).AddTicks(2050));

            migrationBuilder.UpdateData(
                table: "DemandPlannings",
                keyColumn: "Id",
                keyValue: 2,
                column: "ForecastDate",
                value: new DateTime(2024, 11, 22, 12, 31, 15, 859, DateTimeKind.Utc).AddTicks(2057));

            migrationBuilder.UpdateData(
                table: "JournalEntries",
                keyColumn: "JournalEntryId",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 22, 18, 31, 15, 959, DateTimeKind.Local).AddTicks(4780));

            migrationBuilder.UpdateData(
                table: "JournalEntries",
                keyColumn: "JournalEntryId",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 22, 18, 31, 15, 959, DateTimeKind.Local).AddTicks(4786));

            migrationBuilder.UpdateData(
                table: "JournalEntryLines",
                keyColumn: "JournalEntryLineId",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 22, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "JournalEntryLines",
                keyColumn: "JournalEntryLineId",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 22, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "LedgerPostings",
                keyColumn: "LedgerPostingId",
                keyValue: 1,
                column: "PostingDate",
                value: new DateTime(2024, 11, 22, 18, 31, 15, 961, DateTimeKind.Local).AddTicks(4186));

            migrationBuilder.UpdateData(
                table: "LedgerPostings",
                keyColumn: "LedgerPostingId",
                keyValue: 2,
                column: "PostingDate",
                value: new DateTime(2024, 11, 22, 18, 31, 15, 961, DateTimeKind.Local).AddTicks(4208));

            migrationBuilder.UpdateData(
                table: "PerformanceReviews",
                keyColumn: "Id",
                keyValue: 1,
                column: "ReviewDate",
                value: new DateTime(2024, 11, 22, 18, 31, 15, 963, DateTimeKind.Local).AddTicks(7491));

            migrationBuilder.UpdateData(
                table: "PortalAccesses",
                keyColumn: "PortalAccessID",
                keyValue: 1,
                column: "LastLoginDate",
                value: new DateTime(2024, 11, 22, 18, 31, 15, 963, DateTimeKind.Local).AddTicks(8853));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2024, 11, 22, 12, 31, 15, 986, DateTimeKind.Utc).AddTicks(3101), new DateTime(2024, 11, 22, 12, 31, 15, 986, DateTimeKind.Utc).AddTicks(3103) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2024, 11, 22, 12, 31, 15, 986, DateTimeKind.Utc).AddTicks(3107), new DateTime(2024, 11, 22, 12, 31, 15, 986, DateTimeKind.Utc).AddTicks(3108) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2024, 11, 22, 12, 31, 15, 986, DateTimeKind.Utc).AddTicks(3110), new DateTime(2024, 11, 22, 12, 31, 15, 986, DateTimeKind.Utc).AddTicks(3111) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2024, 11, 22, 12, 31, 15, 986, DateTimeKind.Utc).AddTicks(3112), new DateTime(2024, 11, 22, 12, 31, 15, 986, DateTimeKind.Utc).AddTicks(3114) });

            migrationBuilder.UpdateData(
                table: "TalentAcquisitions",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ApplicationDate", "InterviewDate" },
                values: new object[] { new DateTime(2024, 9, 22, 18, 31, 15, 976, DateTimeKind.Local).AddTicks(8863), new DateTime(2024, 10, 22, 18, 31, 15, 976, DateTimeKind.Local).AddTicks(8909) });

            migrationBuilder.UpdateData(
                table: "TalentAcquisitions",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ApplicationDate", "InterviewDate" },
                values: new object[] { new DateTime(2024, 8, 22, 18, 31, 15, 976, DateTimeKind.Local).AddTicks(8916), new DateTime(2024, 9, 22, 18, 31, 15, 976, DateTimeKind.Local).AddTicks(8917) });

            migrationBuilder.UpdateData(
                table: "TimeTrackings",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CheckInTime", "CheckOutTime" },
                values: new object[] { new DateTime(2024, 11, 22, 10, 31, 15, 977, DateTimeKind.Local).AddTicks(1791), new DateTime(2024, 11, 22, 18, 31, 15, 977, DateTimeKind.Local).AddTicks(1816) });

            migrationBuilder.UpdateData(
                table: "Trainings",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CompletionDate", "TrainingStartDate" },
                values: new object[] { new DateTime(2024, 12, 22, 18, 31, 15, 977, DateTimeKind.Local).AddTicks(4050), new DateTime(2024, 11, 22, 18, 31, 15, 977, DateTimeKind.Local).AddTicks(4041) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "TokenCreated", "TokenExpires" },
                values: new object[] { new DateTime(2024, 11, 22, 12, 31, 15, 985, DateTimeKind.Utc).AddTicks(8653), new DateTime(2024, 11, 29, 12, 31, 15, 985, DateTimeKind.Utc).AddTicks(8656) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Branches",
                keyColumn: "BranchId",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 20, 12, 47, 4, 403, DateTimeKind.Local).AddTicks(5490));

            migrationBuilder.UpdateData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ExpiryDate", "IncorporationDate" },
                values: new object[] { new DateTime(2019, 11, 20, 12, 47, 4, 413, DateTimeKind.Local).AddTicks(7876), new DateTime(2029, 11, 20, 12, 47, 4, 413, DateTimeKind.Local).AddTicks(7879), new DateTime(2019, 11, 20, 12, 47, 4, 413, DateTimeKind.Local).AddTicks(7849) });

            migrationBuilder.UpdateData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "ExpiryDate", "IncorporationDate" },
                values: new object[] { new DateTime(2019, 11, 20, 12, 47, 4, 413, DateTimeKind.Local).AddTicks(7895), new DateTime(2029, 11, 20, 12, 47, 4, 413, DateTimeKind.Local).AddTicks(7896), new DateTime(2019, 11, 20, 12, 47, 4, 413, DateTimeKind.Local).AddTicks(7891) });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 20, 12, 47, 4, 380, DateTimeKind.Local).AddTicks(8839));

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 20, 12, 47, 4, 380, DateTimeKind.Local).AddTicks(8863));

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 20, 12, 47, 4, 380, DateTimeKind.Local).AddTicks(8867));

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 20, 12, 47, 4, 380, DateTimeKind.Local).AddTicks(8871));

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 20, 12, 47, 4, 380, DateTimeKind.Local).AddTicks(8874));

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 20, 12, 47, 4, 380, DateTimeKind.Local).AddTicks(8877));

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 20, 12, 47, 4, 380, DateTimeKind.Local).AddTicks(8880));

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 20, 12, 47, 4, 380, DateTimeKind.Local).AddTicks(8882));

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 20, 12, 47, 4, 380, DateTimeKind.Local).AddTicks(8885));

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 20, 12, 47, 4, 380, DateTimeKind.Local).AddTicks(8888));

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 20, 12, 47, 4, 380, DateTimeKind.Local).AddTicks(8891));

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 20, 12, 47, 4, 380, DateTimeKind.Local).AddTicks(8894));

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 20, 12, 47, 4, 380, DateTimeKind.Local).AddTicks(8897));

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 20, 12, 47, 4, 380, DateTimeKind.Local).AddTicks(8900));

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 20, 12, 47, 4, 380, DateTimeKind.Local).AddTicks(8903));

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 20, 12, 47, 4, 380, DateTimeKind.Local).AddTicks(8906));

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 20, 12, 47, 4, 380, DateTimeKind.Local).AddTicks(8908));

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 20, 12, 47, 4, 380, DateTimeKind.Local).AddTicks(8911));

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 20, 12, 47, 4, 380, DateTimeKind.Local).AddTicks(8914));

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 20, 12, 47, 4, 380, DateTimeKind.Local).AddTicks(8917));

            migrationBuilder.UpdateData(
                table: "DemandPlannings",
                keyColumn: "Id",
                keyValue: 1,
                column: "ForecastDate",
                value: new DateTime(2024, 11, 20, 6, 47, 4, 381, DateTimeKind.Utc).AddTicks(3412));

            migrationBuilder.UpdateData(
                table: "DemandPlannings",
                keyColumn: "Id",
                keyValue: 2,
                column: "ForecastDate",
                value: new DateTime(2024, 11, 20, 6, 47, 4, 381, DateTimeKind.Utc).AddTicks(3416));

            migrationBuilder.UpdateData(
                table: "JournalEntries",
                keyColumn: "JournalEntryId",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 20, 12, 47, 4, 386, DateTimeKind.Local).AddTicks(7939));

            migrationBuilder.UpdateData(
                table: "JournalEntries",
                keyColumn: "JournalEntryId",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 20, 12, 47, 4, 386, DateTimeKind.Local).AddTicks(8010));

            migrationBuilder.UpdateData(
                table: "JournalEntryLines",
                keyColumn: "JournalEntryLineId",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 20, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "JournalEntryLines",
                keyColumn: "JournalEntryLineId",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 20, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "LedgerPostings",
                keyColumn: "LedgerPostingId",
                keyValue: 1,
                column: "PostingDate",
                value: new DateTime(2024, 11, 20, 12, 47, 4, 387, DateTimeKind.Local).AddTicks(8098));

            migrationBuilder.UpdateData(
                table: "LedgerPostings",
                keyColumn: "LedgerPostingId",
                keyValue: 2,
                column: "PostingDate",
                value: new DateTime(2024, 11, 20, 12, 47, 4, 387, DateTimeKind.Local).AddTicks(8118));

            migrationBuilder.UpdateData(
                table: "PerformanceReviews",
                keyColumn: "Id",
                keyValue: 1,
                column: "ReviewDate",
                value: new DateTime(2024, 11, 20, 12, 47, 4, 389, DateTimeKind.Local).AddTicks(3365));

            migrationBuilder.UpdateData(
                table: "PortalAccesses",
                keyColumn: "PortalAccessID",
                keyValue: 1,
                column: "LastLoginDate",
                value: new DateTime(2024, 11, 20, 12, 47, 4, 389, DateTimeKind.Local).AddTicks(4440));

            migrationBuilder.InsertData(
                table: "ProductionOrders",
                columns: new[] { "Id", "AssignedToId", "BranchId", "CreatedDate", "DirectLaborCost", "InitialProductCost", "InitiatorId", "LastDateOfUpdate", "OrderPriorityId", "OtherInitialCosts", "ProductionEndDate", "ProductionOrderNo", "ProductionStartDate", "PurchaseCost", "Remarks", "ResourceId" },
                values: new object[] { 1, 2, 1, new DateTime(2024, 11, 20, 0, 0, 0, 0, DateTimeKind.Local), 0m, 1000m, 1, new DateTime(2024, 11, 20, 0, 0, 0, 0, DateTimeKind.Local), 1, 0m, new DateTime(2024, 11, 25, 0, 0, 0, 0, DateTimeKind.Local), "PO-001", new DateTime(2024, 11, 20, 0, 0, 0, 0, DateTimeKind.Local), 0m, "Initial Production Order", 1 });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2024, 11, 20, 6, 47, 4, 401, DateTimeKind.Utc).AddTicks(5489), new DateTime(2024, 11, 20, 6, 47, 4, 401, DateTimeKind.Utc).AddTicks(5492) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2024, 11, 20, 6, 47, 4, 401, DateTimeKind.Utc).AddTicks(5496), new DateTime(2024, 11, 20, 6, 47, 4, 401, DateTimeKind.Utc).AddTicks(5497) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2024, 11, 20, 6, 47, 4, 401, DateTimeKind.Utc).AddTicks(5500), new DateTime(2024, 11, 20, 6, 47, 4, 401, DateTimeKind.Utc).AddTicks(5500) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2024, 11, 20, 6, 47, 4, 401, DateTimeKind.Utc).AddTicks(5502), new DateTime(2024, 11, 20, 6, 47, 4, 401, DateTimeKind.Utc).AddTicks(5503) });

            migrationBuilder.UpdateData(
                table: "TalentAcquisitions",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ApplicationDate", "InterviewDate" },
                values: new object[] { new DateTime(2024, 9, 20, 12, 47, 4, 397, DateTimeKind.Local).AddTicks(403), new DateTime(2024, 10, 20, 12, 47, 4, 397, DateTimeKind.Local).AddTicks(437) });

            migrationBuilder.UpdateData(
                table: "TalentAcquisitions",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ApplicationDate", "InterviewDate" },
                values: new object[] { new DateTime(2024, 8, 20, 12, 47, 4, 397, DateTimeKind.Local).AddTicks(447), new DateTime(2024, 9, 20, 12, 47, 4, 397, DateTimeKind.Local).AddTicks(448) });

            migrationBuilder.UpdateData(
                table: "TimeTrackings",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CheckInTime", "CheckOutTime" },
                values: new object[] { new DateTime(2024, 11, 20, 4, 47, 4, 397, DateTimeKind.Local).AddTicks(2033), new DateTime(2024, 11, 20, 12, 47, 4, 397, DateTimeKind.Local).AddTicks(2048) });

            migrationBuilder.UpdateData(
                table: "Trainings",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CompletionDate", "TrainingStartDate" },
                values: new object[] { new DateTime(2024, 12, 20, 12, 47, 4, 397, DateTimeKind.Local).AddTicks(3451), new DateTime(2024, 11, 20, 12, 47, 4, 397, DateTimeKind.Local).AddTicks(3445) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "TokenCreated", "TokenExpires" },
                values: new object[] { new DateTime(2024, 11, 20, 6, 47, 4, 401, DateTimeKind.Utc).AddTicks(2909), new DateTime(2024, 11, 27, 6, 47, 4, 401, DateTimeKind.Utc).AddTicks(2913) });
        }
    }
}
