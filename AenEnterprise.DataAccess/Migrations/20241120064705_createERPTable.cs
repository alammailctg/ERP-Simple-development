using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AenEnterprise.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class createERPTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AccountTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BankAccounts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Balance = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CustomerRef = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BankAccounts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BenefitsAdministrations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BenefitsAdministrations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BlogCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlogCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RegistrationNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TaxIdentifier = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IndustryType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CompanyAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CompanyEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CompanyPhone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IncorporationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InvoiceAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WebPageAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VATCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VATAreaCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsPrimary = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExpiryDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    AnnualRevenue = table.Column<decimal>(type: "decimal(18,0)", nullable: false),
                    IsPubliclyListed = table.Column<bool>(type: "bit", nullable: false),
                    IsMultipleWareHouse = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CostTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CostTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    MobileNo = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Balance = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LeaveType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LeaveType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OnlineUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LoginTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExpirationTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OnlineUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductionPriority",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductionPriority", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Reconciliations",
                columns: table => new
                {
                    ReconciliationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReconciliationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reconciliations", x => x.ReconciliationId);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RoleDescription = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SalesOrderStatuses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesOrderStatuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Status",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Status", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TalentAcquisitions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Position = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Department = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CandidateName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ApplicationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    InterviewDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TalentAcquisitions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TrialBalances",
                columns: table => new
                {
                    AsOfDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrialBalances", x => x.AsOfDate);
                });

            migrationBuilder.CreateTable(
                name: "Unit",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Unit", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PasswordHash = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    PasswordSalt = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    RefreshToken = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    TokenCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TokenExpires = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Vendors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContactNumber = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vendors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Transactions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    BalanceBefore = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    BalanceAfter = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BankAccountId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transactions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Transactions_BankAccounts_BankAccountId",
                        column: x => x.BankAccountId,
                        principalTable: "BankAccounts",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PublishedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    Author = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Posts_BlogCategories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "BlogCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Branches",
                columns: table => new
                {
                    BranchId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BranchName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BranchAddress = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    City = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    State = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PostalCode = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    BranchEmail = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    BranchPhone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    OpeningDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CompanyId = table.Column<int>(type: "int", nullable: false),
                    ProductionOrderId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Branches", x => x.BranchId);
                    table.ForeignKey(
                        name: "FK_Branches_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Warehouses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WarehouseName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Location = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    CompanyId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Warehouses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Warehouses_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SalesOrders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DeliveryPlane = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SalesOrderNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OrderedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SalesOrderStatusId = table.Column<int>(type: "int", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesOrders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SalesOrders_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SalesOrders_SalesOrderStatuses_SalesOrderStatusId",
                        column: x => x.SalesOrderStatusId,
                        principalTable: "SalesOrderStatuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TrialBalanceLines",
                columns: table => new
                {
                    AccountName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    TotalDebit = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TotalCredit = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TrialBalanceAsOfDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrialBalanceLines", x => x.AccountName);
                    table.ForeignKey(
                        name: "FK_TrialBalanceLines_TrialBalances_TrialBalanceAsOfDate",
                        column: x => x.TrialBalanceAsOfDate,
                        principalTable: "TrialBalances",
                        principalColumn: "AsOfDate",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_UserRoles_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserRoles_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PurchaseOrders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ExpectedDeliveryDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PurchaseDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PurchaseOrderNo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    TotalCostAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DeliveryInstructions = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    PaymentTerms = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    ShippingMethod = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ApprovedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ApprovalDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    VendorId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseOrders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PurchaseOrders_Vendors_VendorId",
                        column: x => x.VendorId,
                        principalTable: "Vendors",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Author = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DatePosted = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    PostId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_Posts_PostId",
                        column: x => x.PostId,
                        principalTable: "Posts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AccountGroups",
                columns: table => new
                {
                    AccountGroupId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccountName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    AccountNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Balance = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    AccountCode = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    AccountTypeId = table.Column<int>(type: "int", nullable: false),
                    CompanyId = table.Column<int>(type: "int", nullable: false),
                    BranchId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountGroups", x => x.AccountGroupId);
                    table.ForeignKey(
                        name: "FK_AccountGroups_AccountTypes_AccountTypeId",
                        column: x => x.AccountTypeId,
                        principalTable: "AccountTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AccountGroups_Branches_BranchId",
                        column: x => x.BranchId,
                        principalTable: "Branches",
                        principalColumn: "BranchId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AccountGroups_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Designation = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DepartmentId = table.Column<int>(type: "int", nullable: false),
                    HireDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ActualSalary = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    HireStatus = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Status = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    AppointmentType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    WorkingType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CompanyId = table.Column<int>(type: "int", nullable: false),
                    BranchId = table.Column<int>(type: "int", nullable: false),
                    JobLocation = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PaymentType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TalentAcquisitionId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employees_Branches_BranchId",
                        column: x => x.BranchId,
                        principalTable: "Branches",
                        principalColumn: "BranchId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Employees_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Employees_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Employees_TalentAcquisitions_TalentAcquisitionId",
                        column: x => x.TalentAcquisitionId,
                        principalTable: "TalentAcquisitions",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "JournalEntries",
                columns: table => new
                {
                    JournalEntryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    JournalEntryNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    EntryDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    JournalName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Partner = table.Column<int>(type: "int", nullable: false),
                    ReferenceNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    CompanyId = table.Column<int>(type: "int", nullable: false),
                    BranchId = table.Column<int>(type: "int", nullable: false),
                    TotalDebit = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TotalCredit = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JournalEntries", x => x.JournalEntryId);
                    table.ForeignKey(
                        name: "FK_JournalEntries_Branches_BranchId",
                        column: x => x.BranchId,
                        principalTable: "Branches",
                        principalColumn: "BranchId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_JournalEntries_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UnitId = table.Column<int>(type: "int", nullable: false),
                    DefaultVatPercent = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PurchasePrice = table.Column<decimal>(type: "decimal(18,0)", nullable: true),
                    CostPrice = table.Column<decimal>(type: "decimal(18,0)", nullable: true),
                    WholesalePrice = table.Column<decimal>(type: "decimal(18,0)", nullable: true),
                    MRP = table.Column<decimal>(type: "decimal(18,0)", nullable: true),
                    TradePrice = table.Column<decimal>(type: "decimal(18,0)", nullable: true),
                    InventoryType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsQuantityMeasureable = table.Column<bool>(type: "bit", nullable: true),
                    FixedAsset = table.Column<bool>(type: "bit", nullable: true),
                    IsPurchaseable = table.Column<bool>(type: "bit", nullable: true),
                    IsSaleable = table.Column<bool>(type: "bit", nullable: true),
                    IsConsumable = table.Column<bool>(type: "bit", nullable: true),
                    RawMaterials = table.Column<bool>(type: "bit", nullable: true),
                    IsInventoryRequired = table.Column<bool>(type: "bit", nullable: true),
                    WarehouseId = table.Column<int>(type: "int", nullable: false),
                    CompanyId = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Category",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Products_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Products_Warehouses_WarehouseId",
                        column: x => x.WarehouseId,
                        principalTable: "Warehouses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Invoices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SalesOrderId = table.Column<int>(type: "int", nullable: false),
                    InvoiceNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OutstandingAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    InvoiceAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invoices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Invoices_SalesOrders_SalesOrderId",
                        column: x => x.SalesOrderId,
                        principalTable: "SalesOrders",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "VendorInvoices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InvoiceAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    InvoiceDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PurchaseOrderId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VendorInvoices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VendorInvoices_PurchaseOrders_PurchaseOrderId",
                        column: x => x.PurchaseOrderId,
                        principalTable: "PurchaseOrders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LedgerPostings",
                columns: table => new
                {
                    LedgerPostingId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PostingDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IsDebit = table.Column<bool>(type: "bit", nullable: false),
                    AccountGroupId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LedgerPostings", x => x.LedgerPostingId);
                    table.ForeignKey(
                        name: "FK_LedgerPostings_AccountGroups_AccountGroupId",
                        column: x => x.AccountGroupId,
                        principalTable: "AccountGroups",
                        principalColumn: "AccountGroupId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Allowances",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    MonthlyCost = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    PaymentType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Allowances", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Allowances_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Benefits",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    MonthlyCost = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    PaymentType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Benefits", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Benefits_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Leaves",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LeaveFrom = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LeaveTo = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DaysOfLeave = table.Column<int>(type: "int", nullable: false),
                    LeaveTypeId = table.Column<int>(type: "int", nullable: false),
                    ReasonForLeave = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    PlaceDuringLeave = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ApplyingDate = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "GETDATE()"),
                    EmployeeId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Leaves", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Leaves_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Leaves_LeaveType_LeaveTypeId",
                        column: x => x.LeaveTypeId,
                        principalTable: "LeaveType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Onboardings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    OnboardingStartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OnboardingEndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DocumentsSubmitted = table.Column<bool>(type: "bit", nullable: false),
                    TrainingCompleted = table.Column<bool>(type: "bit", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Feedback = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Onboardings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Onboardings_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Payrolls",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    PaymentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TaxRate = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TotalPresentHours = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    HourlyRate = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TotalPresentAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TotalOverTimeHours = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TotalOverTimeAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TotalAllowanceAmount = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    TotalBenefitAmount = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    TotalAdvanceAmount = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    GrossSalary = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    NetSalary = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payrolls", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Payrolls_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PerformanceReviews",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    ReviewDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Score = table.Column<int>(type: "int", nullable: false),
                    Feedback = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PerformanceReviews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PerformanceReviews_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PortalAccesses",
                columns: table => new
                {
                    PortalAccessID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeID = table.Column<int>(type: "int", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastLoginDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AccessLevel = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PortalAccesses", x => x.PortalAccessID);
                    table.ForeignKey(
                        name: "FK_PortalAccesses_Employees_EmployeeID",
                        column: x => x.EmployeeID,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductionOrders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductionOrderNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    InitiatorId = table.Column<int>(type: "int", nullable: false),
                    AssignedToId = table.Column<int>(type: "int", nullable: false),
                    BranchId = table.Column<int>(type: "int", nullable: false),
                    ProductionStartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ProductionEndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OrderPriorityId = table.Column<int>(type: "int", nullable: false),
                    Remarks = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastDateOfUpdate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ResourceId = table.Column<int>(type: "int", nullable: false),
                    InitialProductCost = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    PurchaseCost = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    DirectLaborCost = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    OtherInitialCosts = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductionOrders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductionOrders_Branches_BranchId",
                        column: x => x.BranchId,
                        principalTable: "Branches",
                        principalColumn: "BranchId");
                    table.ForeignKey(
                        name: "FK_ProductionOrders_Employees_AssignedToId",
                        column: x => x.AssignedToId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductionOrders_Employees_InitiatorId",
                        column: x => x.InitiatorId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductionOrders_ProductionPriority_OrderPriorityId",
                        column: x => x.OrderPriorityId,
                        principalTable: "ProductionPriority",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Resignation",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Reason = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Resignation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Resignation_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TimeTrackings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    CheckInTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CheckOutTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    WorkHours = table.Column<TimeSpan>(type: "time", nullable: false),
                    TimeOff = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TimeTrackings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TimeTrackings_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Trainings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    CourseName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TrainingStartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CompletionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Certificate = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trainings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Trainings_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "JournalEntryLines",
                columns: table => new
                {
                    JournalEntryLineId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    AccountGroupId = table.Column<int>(type: "int", nullable: false),
                    JournalEntryId = table.Column<int>(type: "int", nullable: false),
                    DebitAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CreditAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JournalEntryLines", x => x.JournalEntryLineId);
                    table.ForeignKey(
                        name: "FK_JournalEntryLines_AccountGroups_AccountGroupId",
                        column: x => x.AccountGroupId,
                        principalTable: "AccountGroups",
                        principalColumn: "AccountGroupId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_JournalEntryLines_JournalEntries_JournalEntryId",
                        column: x => x.JournalEntryId,
                        principalTable: "JournalEntries",
                        principalColumn: "JournalEntryId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DemandPlannings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    ForecastedDemand = table.Column<int>(type: "int", nullable: false),
                    ForecastDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DemandPlannings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DemandPlannings_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsPartiallyApproved = table.Column<bool>(type: "bit", nullable: false),
                    IsFullyApproved = table.Column<bool>(type: "bit", nullable: false),
                    SalesOrderId = table.Column<int>(type: "int", nullable: false),
                    UnitId = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Quantity = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    BalanceQuantity = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    InvoicedQuantity = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    NetAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DiscountPercent = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    InvoicedAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    StatusId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    OrderItemNo = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderItems_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_OrderItems_SalesOrders_SalesOrderId",
                        column: x => x.SalesOrderId,
                        principalTable: "SalesOrders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderItems_Status_StatusId",
                        column: x => x.StatusId,
                        principalTable: "Status",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_OrderItems_Unit_UnitId",
                        column: x => x.UnitId,
                        principalTable: "Unit",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PurchaseItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemCode = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    PurchaseOrderId = table.Column<int>(type: "int", nullable: false),
                    UnitId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DeliveryDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ItemStatus = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PurchaseItems_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PurchaseItems_PurchaseOrders_PurchaseOrderId",
                        column: x => x.PurchaseOrderId,
                        principalTable: "PurchaseOrders",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PurchaseItems_Unit_UnitId",
                        column: x => x.UnitId,
                        principalTable: "Unit",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CreditMemos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreditAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IssueDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    InvoiceId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CreditMemos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CreditMemos_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CreditMemos_Invoices_InvoiceId",
                        column: x => x.InvoiceId,
                        principalTable: "Invoices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DeliveryOrders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SalesOrderId = table.Column<int>(type: "int", nullable: false),
                    InvoiceId = table.Column<int>(type: "int", nullable: false),
                    DeliveryOrderNo = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeliveryOrders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DeliveryOrders_Invoices_InvoiceId",
                        column: x => x.InvoiceId,
                        principalTable: "Invoices",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DeliveryOrders_SalesOrders_SalesOrderId",
                        column: x => x.SalesOrderId,
                        principalTable: "SalesOrders",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PaymentReceipts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PaymentAmount = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    PaymentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    InvoiceId = table.Column<int>(type: "int", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentReceipts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PaymentReceipts_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PaymentReceipts_Invoices_InvoiceId",
                        column: x => x.InvoiceId,
                        principalTable: "Invoices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Payments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PaymentAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PaymentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    VendorInvoiceId = table.Column<int>(type: "int", nullable: false),
                    ReconciliationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Payments_Reconciliations_ReconciliationId",
                        column: x => x.ReconciliationId,
                        principalTable: "Reconciliations",
                        principalColumn: "ReconciliationId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Payments_VendorInvoices_VendorInvoiceId",
                        column: x => x.VendorInvoiceId,
                        principalTable: "VendorInvoices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TrainingSession",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ScheduledDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Completed = table.Column<bool>(type: "bit", nullable: false),
                    comments = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OnboardingId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainingSession", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TrainingSession_Onboardings_OnboardingId",
                        column: x => x.OnboardingId,
                        principalTable: "Onboardings",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AdvancePayments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    AdvanceAgainst = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    ProposalDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    PayrollId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdvancePayments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AdvancePayments_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AdvancePayments_Payrolls_PayrollId",
                        column: x => x.PayrollId,
                        principalTable: "Payrolls",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Attendances",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LeaveTypeId = table.Column<int>(type: "int", nullable: false),
                    Remarks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    RegularHours = table.Column<TimeSpan>(type: "time", nullable: false),
                    WorkingHours = table.Column<TimeSpan>(type: "time", nullable: false),
                    PiecesProduced = table.Column<int>(type: "int", nullable: true),
                    OverTimeHours = table.Column<TimeSpan>(type: "time", nullable: true),
                    CheckInTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    CheckOutTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    PayrollId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attendances", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Attendances_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Attendances_LeaveType_LeaveTypeId",
                        column: x => x.LeaveTypeId,
                        principalTable: "LeaveType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Attendances_Payrolls_PayrollId",
                        column: x => x.PayrollId,
                        principalTable: "Payrolls",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "BillOfMaterials",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductionOrderId = table.Column<int>(type: "int", nullable: false),
                    ProductName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    CreatedById = table.Column<int>(type: "int", nullable: false),
                    ApprovedById = table.Column<int>(type: "int", nullable: false),
                    CreatedEmplyeeId = table.Column<int>(type: "int", nullable: false),
                    ApprovedByEmployeeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BillOfMaterials", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BillOfMaterials_Employees_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BillOfMaterials_ProductionOrders_ProductionOrderId",
                        column: x => x.ProductionOrderId,
                        principalTable: "ProductionOrders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CostTransactions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TransactionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TransactionType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ProductionOrderId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CostTransactions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CostTransactions_ProductionOrders_ProductionOrderId",
                        column: x => x.ProductionOrderId,
                        principalTable: "ProductionOrders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductionCosts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductionOrderId = table.Column<int>(type: "int", nullable: false),
                    CostType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CostAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductionCosts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductionCosts_ProductionOrders_ProductionOrderId",
                        column: x => x.ProductionOrderId,
                        principalTable: "ProductionOrders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductionOrderItems",
                columns: table => new
                {
                    ProductionOrderItemId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    UnitId = table.Column<int>(type: "int", nullable: false),
                    QuantityRequested = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    QuantityProduced = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CostPerUnit = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IsSubmitted = table.Column<bool>(type: "bit", nullable: false),
                    ProductionOrderId = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false, defaultValue: "Pending"),
                    ApprovalStatusId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductionOrderItems", x => x.ProductionOrderItemId);
                    table.ForeignKey(
                        name: "FK_ProductionOrderItems_ProductionOrders_ProductionOrderId",
                        column: x => x.ProductionOrderId,
                        principalTable: "ProductionOrders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductionOrderItems_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ProductionOrderItems_Status_ApprovalStatusId",
                        column: x => x.ApprovalStatusId,
                        principalTable: "Status",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ProductionOrderItems_Unit_UnitId",
                        column: x => x.UnitId,
                        principalTable: "Unit",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ProductionStock",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BatchNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductionOrderId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StockDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StockLocation = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductionStock", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductionStock_ProductionOrders_ProductionOrderId",
                        column: x => x.ProductionOrderId,
                        principalTable: "ProductionOrders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StockLevels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    AvailableQuantity = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DemandPlanningId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StockLevels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StockLevels_DemandPlannings_DemandPlanningId",
                        column: x => x.DemandPlanningId,
                        principalTable: "DemandPlannings",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_StockLevels_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "InvoiceItem",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderItemId = table.Column<int>(type: "int", nullable: false),
                    IsPartiallyApproved = table.Column<bool>(type: "bit", nullable: false),
                    IsFullyApproved = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StatusId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    InvoiceId = table.Column<int>(type: "int", nullable: false),
                    BalanceQuantity = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    InvoiceQuantity = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    InvoiceAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DeliveryQuantity = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    BalanceAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DeliveryAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvoiceItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InvoiceItem_Invoices_InvoiceId",
                        column: x => x.InvoiceId,
                        principalTable: "Invoices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InvoiceItem_OrderItems_OrderItemId",
                        column: x => x.OrderItemId,
                        principalTable: "OrderItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InvoiceItem_Status_StatusId",
                        column: x => x.StatusId,
                        principalTable: "Status",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "DeliveryOrderItem",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeliveryOrderId = table.Column<int>(type: "int", nullable: false),
                    IsPartiallyApproved = table.Column<bool>(type: "bit", nullable: false),
                    IsFullyApproved = table.Column<bool>(type: "bit", nullable: false),
                    StatusId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    BalanceQuantity = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DeliveryQuantity = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DeliveryAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    BalanceAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DispatchQuantity = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DispatchAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    OrderItemId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeliveryOrderItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DeliveryOrderItem_DeliveryOrders_DeliveryOrderId",
                        column: x => x.DeliveryOrderId,
                        principalTable: "DeliveryOrders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DeliveryOrderItem_OrderItems_OrderItemId",
                        column: x => x.OrderItemId,
                        principalTable: "OrderItems",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DeliveryOrderItem_Status_StatusId",
                        column: x => x.StatusId,
                        principalTable: "Status",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "DispatchOrders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DispatcheNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SalesOrderId = table.Column<int>(type: "int", nullable: false),
                    InvoiceId = table.Column<int>(type: "int", nullable: false),
                    DeliveryOrderId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DispatchOrders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DispatchOrders_DeliveryOrders_DeliveryOrderId",
                        column: x => x.DeliveryOrderId,
                        principalTable: "DeliveryOrders",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DispatchOrders_Invoices_InvoiceId",
                        column: x => x.InvoiceId,
                        principalTable: "Invoices",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DispatchOrders_SalesOrders_SalesOrderId",
                        column: x => x.SalesOrderId,
                        principalTable: "SalesOrders",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "BillOfMaterialItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BillOfMaterialsId = table.Column<int>(type: "int", nullable: false),
                    MaterialName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Quantity = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    UnitCost = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BillOfMaterialItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BillOfMaterialItems_BillOfMaterials_BillOfMaterialsId",
                        column: x => x.BillOfMaterialsId,
                        principalTable: "BillOfMaterials",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductionStockItem",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    QualityStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Production = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    QuantityInProduced = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    QuantityInStock = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    StockType = table.Column<int>(type: "int", nullable: false),
                    UnitId = table.Column<int>(type: "int", nullable: false),
                    ProductionStockId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductionStockItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductionStockItem_ProductionStock_ProductionStockId",
                        column: x => x.ProductionStockId,
                        principalTable: "ProductionStock",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductionStockItem_Unit_UnitId",
                        column: x => x.UnitId,
                        principalTable: "Unit",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductionPlannings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlannedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PlannedProductionQuantity = table.Column<int>(type: "int", nullable: false),
                    StockLevelId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductionPlannings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductionPlannings_StockLevels_StockLevelId",
                        column: x => x.StockLevelId,
                        principalTable: "StockLevels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DispatchItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    VehicalNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VehicalEmptyWeight = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    VehicalLoadWeight = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    OrderItemId = table.Column<int>(type: "int", nullable: false),
                    StatusId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    DispatchQuantity = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IsPartiallyApproved = table.Column<bool>(type: "bit", nullable: false),
                    IsFullyApproved = table.Column<bool>(type: "bit", nullable: false),
                    DispatchOrderId = table.Column<int>(type: "int", nullable: false),
                    DispatchAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DispatchItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DispatchItems_DispatchOrders_DispatchOrderId",
                        column: x => x.DispatchOrderId,
                        principalTable: "DispatchOrders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DispatchItems_OrderItems_OrderItemId",
                        column: x => x.OrderItemId,
                        principalTable: "OrderItems",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DispatchItems_Status_StatusId",
                        column: x => x.StatusId,
                        principalTable: "Status",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MaterialsRequirements",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaterialName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RequiredQuantity = table.Column<int>(type: "int", nullable: false),
                    ProductionPlanningId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaterialsRequirements", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MaterialsRequirements_ProductionPlannings_ProductionPlanningId",
                        column: x => x.ProductionPlanningId,
                        principalTable: "ProductionPlannings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AccountTypes",
                columns: new[] { "Id", "Description", "TypeName" },
                values: new object[,]
                {
                    { 1, "Accounts representing company assets", "Asset" },
                    { 2, "Accounts representing company liabilities", "Liability" },
                    { 3, "Accounts representing owner's equity", "Equity" },
                    { 4, "Accounts representing company revenues", "Revenue" },
                    { 5, "Accounts representing company expenses", "Expense" }
                });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Plate" },
                    { 2, "Brass" }
                });

            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "Id", "AnnualRevenue", "CompanyAddress", "CompanyEmail", "CompanyPhone", "Country", "CreatedDate", "ExpiryDate", "FullName", "IncorporationDate", "IndustryType", "InvoiceAddress", "IsDeleted", "IsMultipleWareHouse", "IsPrimary", "IsPubliclyListed", "Name", "RegistrationNumber", "TaxIdentifier", "VATAreaCode", "VATCode", "WebPageAddress" },
                values: new object[,]
                {
                    { 1, 1000000.00m, "123 Sample St", "company@example.com", "123-456-7890", "Sample Country", new DateTime(2019, 11, 20, 12, 47, 4, 413, DateTimeKind.Local).AddTicks(7876), new DateTime(2029, 11, 20, 12, 47, 4, 413, DateTimeKind.Local).AddTicks(7879), "Full Name", new DateTime(2019, 11, 20, 12, 47, 4, 413, DateTimeKind.Local).AddTicks(7849), "Sample Industry", "456 Invoice St", false, true, true, false, "Company B", "123456789", "TAX123", "Area-123", "VAT-123", "www.company.com" },
                    { 2, 1000000.00m, "123 Sample St", "company@example.com", "123-456-7890", "Sample Country", new DateTime(2019, 11, 20, 12, 47, 4, 413, DateTimeKind.Local).AddTicks(7895), new DateTime(2029, 11, 20, 12, 47, 4, 413, DateTimeKind.Local).AddTicks(7896), "Full Name", new DateTime(2019, 11, 20, 12, 47, 4, 413, DateTimeKind.Local).AddTicks(7891), "Sample Industry", "456 Invoice St", false, true, true, false, "Company A", "123488796", "TAX123", "Area-123", "VAT-123", "www.company.com" }
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Address", "Balance", "CreatedDate", "Description", "MobileNo", "Name" },
                values: new object[,]
                {
                    { 1, "Dhaka", 200.00m, new DateTime(2024, 11, 20, 12, 47, 4, 380, DateTimeKind.Local).AddTicks(8839), "This is Plate Customer", "01887969696", "Alam" },
                    { 2, "Dhaka", 1000.00m, new DateTime(2024, 11, 20, 12, 47, 4, 380, DateTimeKind.Local).AddTicks(8863), "This is Brass Customer", "01887969696", "Shamim Enterprise" },
                    { 3, "Chittagong", 500.00m, new DateTime(2024, 11, 20, 12, 47, 4, 380, DateTimeKind.Local).AddTicks(8867), "This is Plate Customer", "01887969696", "Shahab Uddin" },
                    { 4, "Dhaka", 500.00m, new DateTime(2024, 11, 20, 12, 47, 4, 380, DateTimeKind.Local).AddTicks(8871), "This is Abdul Matin's Customer", "01887969696", "Abdul Matin" },
                    { 5, "Dhaka", 4100.00m, new DateTime(2024, 11, 20, 12, 47, 4, 380, DateTimeKind.Local).AddTicks(8874), "This is Abdur Rahman's Customer", "01887969696", "Abdur Rahman" },
                    { 6, "Dhaka", 400.00m, new DateTime(2024, 11, 20, 12, 47, 4, 380, DateTimeKind.Local).AddTicks(8877), "This is Abdus Salam's Customer", "01887969696", "Abdus Salam" },
                    { 7, "Dhaka", 3300.00m, new DateTime(2024, 11, 20, 12, 47, 4, 380, DateTimeKind.Local).AddTicks(8880), "This is Abul Bashar's Customer", "01887969696", "Abul Bashar" },
                    { 8, "Dhaka", 2200.00m, new DateTime(2024, 11, 20, 12, 47, 4, 380, DateTimeKind.Local).AddTicks(8882), "This is Abul Kashem's Customer", "01887969696", "Abul Kashem" },
                    { 9, "Dhaka", 1100.00m, new DateTime(2024, 11, 20, 12, 47, 4, 380, DateTimeKind.Local).AddTicks(8885), "This is Abutaher's Customer", "01887969696", "Abutaher" },
                    { 10, "Dhaka", 4500.00m, new DateTime(2024, 11, 20, 12, 47, 4, 380, DateTimeKind.Local).AddTicks(8888), "This is Agrabad Office's Customer", "01887969696", "Agrabad Office" },
                    { 11, "Dhaka", 600.00m, new DateTime(2024, 11, 20, 12, 47, 4, 380, DateTimeKind.Local).AddTicks(8891), "This is Akkas's Customer", "01887969696", "Akkas" },
                    { 12, "Dhaka", 2000.00m, new DateTime(2024, 11, 20, 12, 47, 4, 380, DateTimeKind.Local).AddTicks(8894), "This is Al Madina's Customer", "01887969696", "Al Madina" },
                    { 13, "Dhaka", 200.00m, new DateTime(2024, 11, 20, 12, 47, 4, 380, DateTimeKind.Local).AddTicks(8897), "This is Alamgir's Customer", "01887969696", "Alamgir" },
                    { 14, "Dhaka", 800.00m, new DateTime(2024, 11, 20, 12, 47, 4, 380, DateTimeKind.Local).AddTicks(8900), "This is AR Enterprise's Customer", "01887969696", "AR Enterprise" },
                    { 15, "Dhaka", 4500.00m, new DateTime(2024, 11, 20, 12, 47, 4, 380, DateTimeKind.Local).AddTicks(8903), "This is Ayub Khan's Customer", "01887969696", "Ayub Khan" },
                    { 16, "Dhaka", 600.00m, new DateTime(2024, 11, 20, 12, 47, 4, 380, DateTimeKind.Local).AddTicks(8906), "This is AZ Brothers' Customer", "01887969696", "AZ Brothers" },
                    { 17, "Dhaka", 200.00m, new DateTime(2024, 11, 20, 12, 47, 4, 380, DateTimeKind.Local).AddTicks(8908), "This is Bablu's Customer", "01887969696", "Bablu" },
                    { 18, "Dhaka", 14000.00m, new DateTime(2024, 11, 20, 12, 47, 4, 380, DateTimeKind.Local).AddTicks(8911), "This is Bacha Meah's Customer", "01887969696", "Bacha Meah" },
                    { 19, "Dhaka", 2200.00m, new DateTime(2024, 11, 20, 12, 47, 4, 380, DateTimeKind.Local).AddTicks(8914), "This is Bismillah's Customer", "01887969696", "Bismillah" },
                    { 20, "Dhaka", 100.00m, new DateTime(2024, 11, 20, 12, 47, 4, 380, DateTimeKind.Local).AddTicks(8917), "This is Dalehsar Iron's Customer", "01887969696", "Dalehsar Iron" }
                });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "IT" },
                    { 2, "HR" }
                });

            migrationBuilder.InsertData(
                table: "LeaveType",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Annual Leave" },
                    { 2, "Sick Leave" },
                    { 3, "Casual Leave" },
                    { 4, "Leave Without Pay" },
                    { 5, "Maternity Leave" },
                    { 6, "Paternity Leave" },
                    { 7, "Bereavement Leave" },
                    { 8, "Public Holiday" },
                    { 9, "Absent" },
                    { 10, "Other" }
                });

            migrationBuilder.InsertData(
                table: "ProductionPriority",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Low" },
                    { 2, "Medium" },
                    { 3, "High" },
                    { 4, "Critical" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "CreatedDate", "ModifiedDate", "RoleDescription", "RoleName" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 11, 20, 6, 47, 4, 401, DateTimeKind.Utc).AddTicks(5489), new DateTime(2024, 11, 20, 6, 47, 4, 401, DateTimeKind.Utc).AddTicks(5492), "Administrator with full access to system", "Admin" },
                    { 2, new DateTime(2024, 11, 20, 6, 47, 4, 401, DateTimeKind.Utc).AddTicks(5496), new DateTime(2024, 11, 20, 6, 47, 4, 401, DateTimeKind.Utc).AddTicks(5497), "Manager with access to oversee operations", "Manager" },
                    { 3, new DateTime(2024, 11, 20, 6, 47, 4, 401, DateTimeKind.Utc).AddTicks(5500), new DateTime(2024, 11, 20, 6, 47, 4, 401, DateTimeKind.Utc).AddTicks(5500), "Regular user with limited access", "User" },
                    { 4, new DateTime(2024, 11, 20, 6, 47, 4, 401, DateTimeKind.Utc).AddTicks(5502), new DateTime(2024, 11, 20, 6, 47, 4, 401, DateTimeKind.Utc).AddTicks(5503), "Guest user with read-only access", "Guest" }
                });

            migrationBuilder.InsertData(
                table: "SalesOrderStatuses",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "CreateSalesOrder" },
                    { 2, "PendingApprovalOrder" },
                    { 3, "ApprovedSalesOrder" },
                    { 4, "CreateInvoice" },
                    { 5, "ApprovedInvoice" },
                    { 6, "CreateDO" },
                    { 7, "ApprovedDO" },
                    { 8, "CreateDispatcheAndDone" },
                    { 9, "Reject" }
                });

            migrationBuilder.InsertData(
                table: "Status",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Pending" },
                    { 2, "Approved" },
                    { 3, "Rejected" }
                });

            migrationBuilder.InsertData(
                table: "TalentAcquisitions",
                columns: new[] { "Id", "ApplicationDate", "CandidateName", "Department", "InterviewDate", "Position", "Status" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 9, 20, 12, 47, 4, 397, DateTimeKind.Local).AddTicks(403), "John Doe", "IT", new DateTime(2024, 10, 20, 12, 47, 4, 397, DateTimeKind.Local).AddTicks(437), "Software Engineer", "Hired" },
                    { 2, new DateTime(2024, 8, 20, 12, 47, 4, 397, DateTimeKind.Local).AddTicks(447), "Jane Smith", "Operations", new DateTime(2024, 9, 20, 12, 47, 4, 397, DateTimeKind.Local).AddTicks(448), "Project Manager", "Offered" }
                });

            migrationBuilder.InsertData(
                table: "Unit",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "KG" },
                    { 2, "Lot" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Password", "PasswordHash", "PasswordSalt", "RefreshToken", "TokenCreated", "TokenExpires", "Username" },
                values: new object[] { 1, "1234", new byte[0], new byte[0], "sample_refresh_token", new DateTime(2024, 11, 20, 6, 47, 4, 401, DateTimeKind.Utc).AddTicks(2909), new DateTime(2024, 11, 27, 6, 47, 4, 401, DateTimeKind.Utc).AddTicks(2913), "admin" });

            migrationBuilder.InsertData(
                table: "Vendors",
                columns: new[] { "Id", "Address", "ContactNumber", "Name" },
                values: new object[,]
                {
                    { 1, "123 Main St", "1234567890", "Vendor1" },
                    { 2, "456 Second St", "0987654321", "Vendor2" }
                });

            migrationBuilder.InsertData(
                table: "Warehouses",
                columns: new[] { "Id", "CompanyId", "Location", "WarehouseName" },
                values: new object[,]
                {
                    { 1, null, "Location A", "Warehouse A" },
                    { 2, null, "Location B", "Warehouse B" },
                    { 3, null, "Location C", "Warehouse C" },
                    { 4, null, "Location D", "Warehouse D" },
                    { 5, null, "Location E", "Warehouse E" },
                    { 6, null, "Location F", "Warehouse F" },
                    { 7, null, "Location G", "Warehouse G" },
                    { 8, null, "Location H", "Warehouse H" },
                    { 9, null, "Location I", "Warehouse I" },
                    { 10, null, "Location J", "Warehouse J" }
                });

            migrationBuilder.InsertData(
                table: "Branches",
                columns: new[] { "BranchId", "BranchAddress", "BranchEmail", "BranchName", "BranchPhone", "City", "CompanyId", "CreatedDate", "IsActive", "OpeningDate", "PostalCode", "ProductionOrderId", "State" },
                values: new object[] { 1, "456 Central Road, Dhaka, Bangladesh", "dhaka.branch@aenenterprise.com", "Dhaka Branch", "+880987654321", "Dhaka", 1, new DateTime(2024, 11, 20, 12, 47, 4, 403, DateTimeKind.Local).AddTicks(5490), true, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "1205", 0, "Dhaka Division" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "CompanyId", "CostPrice", "DefaultVatPercent", "Description", "FixedAsset", "InventoryType", "IsConsumable", "IsInventoryRequired", "IsPurchaseable", "IsQuantityMeasureable", "IsSaleable", "MRP", "Name", "PurchasePrice", "RawMaterials", "TradePrice", "UnitId", "WarehouseId", "WholesalePrice" },
                values: new object[,]
                {
                    { 1, 1, 1, 90.00m, "15%", "Description of Shop angle Garder", false, "Type1", false, true, true, true, true, 120.00m, "Shop angle Garder", 100.00m, true, 105.00m, 1, 1, 110.00m },
                    { 2, 1, 1, 45.00m, "18%", "Description of SS Wire", false, "Type2", false, true, true, true, true, 60.00m, "SS Wire", 50.00m, true, 52.00m, 1, 1, 55.00m },
                    { 3, 1, 1, 22.00m, "12%", "Description of Gateball Butterfly", false, "Type3", false, true, true, true, true, 30.00m, "Gateball Butterfly", 25.00m, true, 27.00m, 1, 1, 28.00m },
                    { 4, 1, 1, 180.00m, "10%", "Description of Bate Ball+Butter fly", false, "Type4", false, true, true, true, true, 230.00m, "Bate Ball+Butter fly", 200.00m, true, 205.00m, 1, 1, 210.00m },
                    { 5, 1, 1, 135.00m, "8%", "Description of Gate bulb and Butterfly", false, "Type5", false, true, true, true, true, 175.00m, "Gate bulb and Butterfly", 150.00m, true, 155.00m, 1, 1, 160.00m },
                    { 6, 1, 1, 75.00m, "18%", "Description of Cold Store", false, "Type6", false, true, true, true, true, 90.00m, "Cold Store", 80.00m, true, 82.00m, 1, 1, 85.00m },
                    { 7, 1, 1, 110.00m, "15%", "Description of SS Coil Pipe", false, "Type7", false, true, true, true, true, 135.00m, "SS Coil Pipe", 120.00m, true, 122.00m, 1, 1, 125.00m },
                    { 8, 1, 1, 230.00m, "10%", "Description of SS Coil Nojel Pipe", false, "Type8", false, true, true, true, true, 275.00m, "SS Coil Nojel Pipe", 250.00m, true, 255.00m, 1, 1, 260.00m },
                    { 9, 1, 1, 115.00m, "12%", "Description of SS Pipe", false, "Type9", false, true, true, true, true, 150.00m, "SS Pipe", 130.00m, true, 135.00m, 1, 1, 140.00m },
                    { 10, 1, 1, 275.00m, "10%", "Description of Varieties Scrap", false, "Type10", false, true, true, true, true, 320.00m, "Varieties Scrap", 300.00m, true, 305.00m, 1, 1, 310.00m },
                    { 11, 1, 1, 160.00m, "10%", "Description of Joint Scrap", false, "Type11", false, true, true, true, true, 200.00m, "Joint Scrap", 180.00m, true, 185.00m, 1, 1, 190.00m },
                    { 12, 1, 1, 380.00m, "18%", "Description of MS Net", false, "Type12", false, true, true, true, true, 420.00m, "MS Net", 400.00m, true, 405.00m, 1, 1, 410.00m },
                    { 13, 1, 1, 480.00m, "18%", "Description of Kitchen Room", false, "Type13", false, true, true, true, true, 525.00m, "Kitchen Room", 500.00m, true, 505.00m, 1, 1, 510.00m },
                    { 14, 1, 1, 575.00m, "12%", "Description of Hidrolik Pump (Alumonium Body)", false, "Type14", false, true, true, true, true, 630.00m, "Hidrolik Pump (Alumonium Body)", 600.00m, true, 610.00m, 1, 1, 615.00m },
                    { 15, 1, 1, 45.00m, "15%", "Description of Bit Garder", false, "Type15", false, true, true, true, true, 60.00m, "Bit Garder", 50.00m, false, 52.00m, 1, 1, 55.00m },
                    { 16, 1, 1, 140.00m, "10%", "Description of Relling", false, "Type16", false, true, true, true, true, 170.00m, "Relling", 150.00m, false, 155.00m, 1, 1, 160.00m },
                    { 17, 1, 1, 85.00m, "8%", "Description of Roller", false, "Type17", false, true, true, true, true, 100.00m, "Roller", 90.00m, false, 92.00m, 1, 1, 95.00m },
                    { 18, 1, 1, 165.00m, "8%", "Description of Roller Garda", false, "Type18", false, true, true, true, true, 200.00m, "Roller Garda", 180.00m, false, 185.00m, 1, 1, 190.00m },
                    { 19, 1, 1, 45.00m, "5%", "Description of Star pump", false, "Type19", false, true, true, true, true, 60.00m, "Star pump", 50.00m, false, 52.00m, 1, 1, 55.00m },
                    { 20, 1, 1, 180.00m, "7%", "Description of Mach Iron", false, "Type20", false, true, true, true, true, 220.00m, "Mach Iron", 200.00m, false, 205.00m, 1, 1, 210.00m },
                    { 21, 1, 1, 230.00m, "8%", "Description of Aluminium Stair", false, "Type21", false, true, true, true, true, 270.00m, "Aluminium Stair", 250.00m, false, 255.00m, 1, 1, 260.00m },
                    { 22, 1, 1, 110.00m, "6%", "Description of Brass Cornecer Radioter", false, "Type22", false, true, true, true, true, 130.00m, "Brass Cornecer Radioter", 120.00m, false, 122.00m, 1, 1, 125.00m },
                    { 23, 1, 1, 45.00m, "15%", "Description of Cast Iron", false, "Type23", false, true, true, true, true, 60.00m, "Cast Iron", 50.00m, false, 52.00m, 1, 1, 55.00m },
                    { 24, 1, 1, 140.00m, "10%", "Description of Navi Item", false, "Type24", false, true, true, true, true, 170.00m, "Navi Item", 150.00m, false, 155.00m, 1, 1, 160.00m },
                    { 25, 1, 1, 170.00m, "5%", "Description of Furniture", false, "Type25", false, true, true, true, true, 200.00m, "Furniture", 180.00m, false, 185.00m, 1, 1, 190.00m },
                    { 26, 1, 1, 90.00m, "18%", "Description of General Store", false, "Type26", false, true, true, true, true, 120.00m, "General Store", 100.00m, false, 105.00m, 1, 1, 110.00m },
                    { 27, 1, 1, 275.00m, "12%", "Description of MS Konakata", false, "Type27", false, true, true, true, true, 320.00m, "MS Konakata", 300.00m, false, 305.00m, 1, 1, 310.00m },
                    { 28, 1, 1, 375.00m, "10%", "Description of MS Plance", false, "Type28", false, true, true, true, true, 420.00m, "MS Plance", 400.00m, false, 405.00m, 1, 1, 410.00m },
                    { 29, 1, 1, 90.00m, "15%", "Description of Shop angle Garder", false, "Type1", false, true, true, true, true, 120.00m, "Shop angle Garder", 100.00m, true, 105.00m, 1, 1, 110.00m },
                    { 30, 1, 1, 45.00m, "18%", "Description of SS Wire", false, "Type2", false, true, true, true, true, 60.00m, "SS Wire", 50.00m, true, 52.00m, 1, 1, 55.00m },
                    { 31, 1, 1, 22.00m, "12%", "Description of Socket", false, "Type3", false, true, true, true, true, 30.00m, "Socket", 25.00m, false, 27.00m, 1, 1, 28.00m },
                    { 32, 1, 1, 180.00m, "10%", "Description of 5.8 Shop plate", false, "Type4", false, true, true, true, true, 230.00m, "5.8 Shop plate", 200.00m, false, 205.00m, 1, 1, 210.00m },
                    { 33, 1, 1, 135.00m, "8%", "Description of Shop bit garder", false, "Type5", false, true, true, true, true, 175.00m, "Shop bit garder", 150.00m, false, 155.00m, 1, 1, 160.00m },
                    { 34, 1, 1, 75.00m, "18%", "Description of Cable", false, "Type6", false, true, true, true, true, 90.00m, "Cable", 80.00m, false, 82.00m, 1, 1, 85.00m },
                    { 35, 1, 1, 110.00m, "15%", "Description of Shopping bit. Garder", false, "Type7", false, true, true, true, true, 135.00m, "Shopping bit. Garder", 120.00m, false, 122.00m, 1, 1, 125.00m },
                    { 36, 1, 1, 230.00m, "10%", "Description of 3.8 Plate Shop", false, "Type8", false, true, true, true, true, 275.00m, "3.8 Plate Shop", 250.00m, false, 255.00m, 1, 1, 260.00m },
                    { 37, 1, 1, 115.00m, "12%", "Description of Blour", false, "Type9", false, true, true, true, true, 150.00m, "Blour", 130.00m, false, 135.00m, 1, 1, 140.00m },
                    { 38, 1, 1, 275.00m, "10%", "Description of 1.2 Shop Plate", false, "Type10", false, true, true, true, true, 320.00m, "1.2 Shop Plate", 300.00m, false, 305.00m, 1, 1, 310.00m },
                    { 39, 1, 1, 160.00m, "10%", "Description of Ang+bit Gard", false, "Type11", false, true, true, true, true, 200.00m, "Ang+bit Gard", 180.00m, false, 185.00m, 1, 1, 190.00m },
                    { 40, 1, 1, 380.00m, "18%", "Description of Electronics Item", false, "Type12", false, true, true, true, true, 420.00m, "Electronics Item", 400.00m, false, 405.00m, 1, 1, 410.00m },
                    { 41, 1, 1, 480.00m, "18%", "Description of Motor", false, "Type13", false, true, true, true, true, 525.00m, "Motor", 500.00m, false, 505.00m, 1, 1, 510.00m },
                    { 42, 1, 1, 575.00m, "12%", "Description of CanonPCD 320 ofset paper", false, "Type14", false, true, true, true, true, 630.00m, "CanonPCD 320 ofset paper", 600.00m, false, 610.00m, 1, 1, 615.00m },
                    { 43, 1, 1, 45.00m, "15%", "Description of Gateball Butterfly", false, "Type15", false, true, true, true, true, 60.00m, "Gateball Butterfly", 50.00m, false, 52.00m, 1, 1, 55.00m }
                });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { 1, 1 });

            migrationBuilder.InsertData(
                table: "AccountGroups",
                columns: new[] { "AccountGroupId", "AccountCode", "AccountName", "AccountNumber", "AccountTypeId", "Balance", "BranchId", "CompanyId" },
                values: new object[,]
                {
                    { 1, "CASH", "Cash in Hand", "1001", 1, 10000.00m, 1, 1 },
                    { 2, "INV", "Inventory", "2001", 2, 50000.00m, 1, 1 }
                });

            migrationBuilder.InsertData(
                table: "DemandPlannings",
                columns: new[] { "Id", "ForecastDate", "ForecastedDemand", "ProductId" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 11, 20, 6, 47, 4, 381, DateTimeKind.Utc).AddTicks(3412), 1000, 1 },
                    { 2, new DateTime(2024, 11, 20, 6, 47, 4, 381, DateTimeKind.Utc).AddTicks(3416), 500, 2 }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "ActualSalary", "Address", "AppointmentType", "BranchId", "CompanyId", "DepartmentId", "Designation", "HireDate", "HireStatus", "JobLocation", "Name", "PaymentType", "Status", "TalentAcquisitionId", "WorkingType" },
                values: new object[,]
                {
                    { 1, 60000m, "Chittagong", "Parmanent", 1, 1, 1, "Driver", new DateTime(2022, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Confirm", "Chittagong", "Azam", "Monthly", "Active", null, "Full Time" },
                    { 2, 60000m, "Chittagong", "Parmanent", 1, 1, 1, "Commarcial manager", new DateTime(2022, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Confirm", "Chittagong", "Hanif", "Monthly", "Active", null, "Full Time" }
                });

            migrationBuilder.InsertData(
                table: "JournalEntries",
                columns: new[] { "JournalEntryId", "BranchId", "CompanyId", "CreatedDate", "Description", "EntryDate", "JournalEntryNo", "JournalName", "Partner", "ReferenceNumber", "TotalCredit", "TotalDebit" },
                values: new object[,]
                {
                    { 1, 1, 1, new DateTime(2024, 11, 20, 12, 47, 4, 386, DateTimeKind.Local).AddTicks(7939), "Opening balance for the company", new DateTime(2023, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "JE20231101", "Opening Balance", 0, "REF123", 0m, 0m },
                    { 2, 1, 1, new DateTime(2024, 11, 20, 12, 47, 4, 386, DateTimeKind.Local).AddTicks(8010), "Purchase of raw materials", new DateTime(2023, 11, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "JE20231102", "Purchase Entry", 0, "REF124", 0m, 0m }
                });

            migrationBuilder.InsertData(
                table: "JournalEntryLines",
                columns: new[] { "JournalEntryLineId", "AccountGroupId", "CreatedDate", "CreditAmount", "DebitAmount", "Description", "JournalEntryId" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2024, 11, 20, 0, 0, 0, 0, DateTimeKind.Local), 0.00m, 1000.00m, "Initial Journal Entry", 1 },
                    { 2, 2, new DateTime(2024, 11, 20, 0, 0, 0, 0, DateTimeKind.Local), 500.00m, 0.00m, "Second Journal Entry", 1 }
                });

            migrationBuilder.InsertData(
                table: "LedgerPostings",
                columns: new[] { "LedgerPostingId", "AccountGroupId", "Amount", "Description", "IsDebit", "PostingDate" },
                values: new object[,]
                {
                    { 1, 1, 5000m, "Ledger posting 1", true, new DateTime(2024, 11, 20, 12, 47, 4, 387, DateTimeKind.Local).AddTicks(8098) },
                    { 2, 2, 3000m, "Ledger posting 2", false, new DateTime(2024, 11, 20, 12, 47, 4, 387, DateTimeKind.Local).AddTicks(8118) }
                });

            migrationBuilder.InsertData(
                table: "PerformanceReviews",
                columns: new[] { "Id", "EmployeeId", "Feedback", "ReviewDate", "Score" },
                values: new object[] { 1, 1, "Excellent", new DateTime(2024, 11, 20, 12, 47, 4, 389, DateTimeKind.Local).AddTicks(3365), 5 });

            migrationBuilder.InsertData(
                table: "PortalAccesses",
                columns: new[] { "PortalAccessID", "AccessLevel", "EmployeeID", "LastLoginDate", "Password", "Username" },
                values: new object[] { 1, "Employee", 1, new DateTime(2024, 11, 20, 12, 47, 4, 389, DateTimeKind.Local).AddTicks(4440), "password123", "john.doe" });

            migrationBuilder.InsertData(
                table: "ProductionOrders",
                columns: new[] { "Id", "AssignedToId", "BranchId", "CreatedDate", "DirectLaborCost", "InitialProductCost", "InitiatorId", "LastDateOfUpdate", "OrderPriorityId", "OtherInitialCosts", "ProductionEndDate", "ProductionOrderNo", "ProductionStartDate", "PurchaseCost", "Remarks", "ResourceId" },
                values: new object[] { 1, 2, 1, new DateTime(2024, 11, 20, 0, 0, 0, 0, DateTimeKind.Local), 0m, 1000m, 1, new DateTime(2024, 11, 20, 0, 0, 0, 0, DateTimeKind.Local), 1, 0m, new DateTime(2024, 11, 25, 0, 0, 0, 0, DateTimeKind.Local), "PO-001", new DateTime(2024, 11, 20, 0, 0, 0, 0, DateTimeKind.Local), 0m, "Initial Production Order", 1 });

            migrationBuilder.InsertData(
                table: "TimeTrackings",
                columns: new[] { "Id", "CheckInTime", "CheckOutTime", "EmployeeId", "TimeOff", "WorkHours" },
                values: new object[] { 1, new DateTime(2024, 11, 20, 4, 47, 4, 397, DateTimeKind.Local).AddTicks(2033), new DateTime(2024, 11, 20, 12, 47, 4, 397, DateTimeKind.Local).AddTicks(2048), 1, false, new TimeSpan(0, 8, 0, 0, 0) });

            migrationBuilder.InsertData(
                table: "Trainings",
                columns: new[] { "Id", "Certificate", "CompletionDate", "CourseName", "EmployeeId", "TrainingStartDate" },
                values: new object[] { 1, "Certified", new DateTime(2024, 12, 20, 12, 47, 4, 397, DateTimeKind.Local).AddTicks(3451), "Leadership", 1, new DateTime(2024, 11, 20, 12, 47, 4, 397, DateTimeKind.Local).AddTicks(3445) });

            migrationBuilder.CreateIndex(
                name: "IX_AccountGroups_AccountTypeId",
                table: "AccountGroups",
                column: "AccountTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_AccountGroups_BranchId",
                table: "AccountGroups",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_AccountGroups_CompanyId",
                table: "AccountGroups",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_AdvancePayments_EmployeeId",
                table: "AdvancePayments",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_AdvancePayments_PayrollId",
                table: "AdvancePayments",
                column: "PayrollId");

            migrationBuilder.CreateIndex(
                name: "IX_Allowances_EmployeeId",
                table: "Allowances",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Attendances_EmployeeId",
                table: "Attendances",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Attendances_LeaveTypeId",
                table: "Attendances",
                column: "LeaveTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Attendances_PayrollId",
                table: "Attendances",
                column: "PayrollId");

            migrationBuilder.CreateIndex(
                name: "IX_Benefits_EmployeeId",
                table: "Benefits",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_BillOfMaterialItems_BillOfMaterialsId",
                table: "BillOfMaterialItems",
                column: "BillOfMaterialsId");

            migrationBuilder.CreateIndex(
                name: "IX_BillOfMaterials_CreatedById",
                table: "BillOfMaterials",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_BillOfMaterials_ProductionOrderId",
                table: "BillOfMaterials",
                column: "ProductionOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Branches_CompanyId",
                table: "Branches",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_PostId",
                table: "Comments",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_CostTransactions_ProductionOrderId",
                table: "CostTransactions",
                column: "ProductionOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_CreditMemos_CustomerId",
                table: "CreditMemos",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_CreditMemos_InvoiceId",
                table: "CreditMemos",
                column: "InvoiceId");

            migrationBuilder.CreateIndex(
                name: "IX_DeliveryOrderItem_DeliveryOrderId",
                table: "DeliveryOrderItem",
                column: "DeliveryOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_DeliveryOrderItem_OrderItemId",
                table: "DeliveryOrderItem",
                column: "OrderItemId");

            migrationBuilder.CreateIndex(
                name: "IX_DeliveryOrderItem_StatusId",
                table: "DeliveryOrderItem",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_DeliveryOrders_InvoiceId",
                table: "DeliveryOrders",
                column: "InvoiceId");

            migrationBuilder.CreateIndex(
                name: "IX_DeliveryOrders_SalesOrderId",
                table: "DeliveryOrders",
                column: "SalesOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_DemandPlannings_ProductId",
                table: "DemandPlannings",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_DispatchItems_DispatchOrderId",
                table: "DispatchItems",
                column: "DispatchOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_DispatchItems_OrderItemId",
                table: "DispatchItems",
                column: "OrderItemId");

            migrationBuilder.CreateIndex(
                name: "IX_DispatchItems_StatusId",
                table: "DispatchItems",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_DispatchOrders_DeliveryOrderId",
                table: "DispatchOrders",
                column: "DeliveryOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_DispatchOrders_InvoiceId",
                table: "DispatchOrders",
                column: "InvoiceId");

            migrationBuilder.CreateIndex(
                name: "IX_DispatchOrders_SalesOrderId",
                table: "DispatchOrders",
                column: "SalesOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_BranchId",
                table: "Employees",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_CompanyId",
                table: "Employees",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_DepartmentId",
                table: "Employees",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_TalentAcquisitionId",
                table: "Employees",
                column: "TalentAcquisitionId");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceItem_InvoiceId",
                table: "InvoiceItem",
                column: "InvoiceId");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceItem_OrderItemId",
                table: "InvoiceItem",
                column: "OrderItemId");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceItem_StatusId",
                table: "InvoiceItem",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_SalesOrderId",
                table: "Invoices",
                column: "SalesOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_JournalEntries_BranchId",
                table: "JournalEntries",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_JournalEntries_CompanyId",
                table: "JournalEntries",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_JournalEntryLines_AccountGroupId",
                table: "JournalEntryLines",
                column: "AccountGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_JournalEntryLines_JournalEntryId",
                table: "JournalEntryLines",
                column: "JournalEntryId");

            migrationBuilder.CreateIndex(
                name: "IX_Leaves_EmployeeId",
                table: "Leaves",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Leaves_LeaveTypeId",
                table: "Leaves",
                column: "LeaveTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_LedgerPostings_AccountGroupId",
                table: "LedgerPostings",
                column: "AccountGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_MaterialsRequirements_ProductionPlanningId",
                table: "MaterialsRequirements",
                column: "ProductionPlanningId");

            migrationBuilder.CreateIndex(
                name: "IX_Onboardings_EmployeeId",
                table: "Onboardings",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_ProductId",
                table: "OrderItems",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_SalesOrderId",
                table: "OrderItems",
                column: "SalesOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_StatusId",
                table: "OrderItems",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_UnitId",
                table: "OrderItems",
                column: "UnitId");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentReceipts_CustomerId",
                table: "PaymentReceipts",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentReceipts_InvoiceId",
                table: "PaymentReceipts",
                column: "InvoiceId");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_ReconciliationId",
                table: "Payments",
                column: "ReconciliationId");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_VendorInvoiceId",
                table: "Payments",
                column: "VendorInvoiceId");

            migrationBuilder.CreateIndex(
                name: "IX_Payrolls_EmployeeId",
                table: "Payrolls",
                column: "EmployeeId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PerformanceReviews_EmployeeId",
                table: "PerformanceReviews",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_PortalAccesses_EmployeeID",
                table: "PortalAccesses",
                column: "EmployeeID");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_CategoryId",
                table: "Posts",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductionCosts_ProductionOrderId",
                table: "ProductionCosts",
                column: "ProductionOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductionOrderItems_ApprovalStatusId",
                table: "ProductionOrderItems",
                column: "ApprovalStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductionOrderItems_ProductId",
                table: "ProductionOrderItems",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductionOrderItems_ProductionOrderId",
                table: "ProductionOrderItems",
                column: "ProductionOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductionOrderItems_UnitId",
                table: "ProductionOrderItems",
                column: "UnitId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductionOrders_AssignedToId",
                table: "ProductionOrders",
                column: "AssignedToId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductionOrders_BranchId",
                table: "ProductionOrders",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductionOrders_InitiatorId",
                table: "ProductionOrders",
                column: "InitiatorId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductionOrders_OrderPriorityId",
                table: "ProductionOrders",
                column: "OrderPriorityId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductionPlannings_StockLevelId",
                table: "ProductionPlannings",
                column: "StockLevelId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductionStock_ProductionOrderId",
                table: "ProductionStock",
                column: "ProductionOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductionStockItem_ProductionStockId",
                table: "ProductionStockItem",
                column: "ProductionStockId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductionStockItem_UnitId",
                table: "ProductionStockItem",
                column: "UnitId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CompanyId",
                table: "Products",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_WarehouseId",
                table: "Products",
                column: "WarehouseId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseItems_ProductId",
                table: "PurchaseItems",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseItems_PurchaseOrderId",
                table: "PurchaseItems",
                column: "PurchaseOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseItems_UnitId",
                table: "PurchaseItems",
                column: "UnitId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseOrders_VendorId",
                table: "PurchaseOrders",
                column: "VendorId");

            migrationBuilder.CreateIndex(
                name: "IX_Resignation_EmployeeId",
                table: "Resignation",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesOrders_CustomerId",
                table: "SalesOrders",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesOrders_SalesOrderStatusId",
                table: "SalesOrders",
                column: "SalesOrderStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_StockLevels_DemandPlanningId",
                table: "StockLevels",
                column: "DemandPlanningId");

            migrationBuilder.CreateIndex(
                name: "IX_StockLevels_ProductId",
                table: "StockLevels",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_TimeTrackings_EmployeeId",
                table: "TimeTrackings",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Trainings_EmployeeId",
                table: "Trainings",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_TrainingSession_OnboardingId",
                table: "TrainingSession",
                column: "OnboardingId");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_BankAccountId",
                table: "Transactions",
                column: "BankAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_TrialBalanceLines_TrialBalanceAsOfDate",
                table: "TrialBalanceLines",
                column: "TrialBalanceAsOfDate");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_RoleId",
                table: "UserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_VendorInvoices_PurchaseOrderId",
                table: "VendorInvoices",
                column: "PurchaseOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Warehouses_CompanyId",
                table: "Warehouses",
                column: "CompanyId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AdvancePayments");

            migrationBuilder.DropTable(
                name: "Allowances");

            migrationBuilder.DropTable(
                name: "Attendances");

            migrationBuilder.DropTable(
                name: "Benefits");

            migrationBuilder.DropTable(
                name: "BenefitsAdministrations");

            migrationBuilder.DropTable(
                name: "BillOfMaterialItems");

            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "CostTransactions");

            migrationBuilder.DropTable(
                name: "CostTypes");

            migrationBuilder.DropTable(
                name: "CreditMemos");

            migrationBuilder.DropTable(
                name: "DeliveryOrderItem");

            migrationBuilder.DropTable(
                name: "DispatchItems");

            migrationBuilder.DropTable(
                name: "InvoiceItem");

            migrationBuilder.DropTable(
                name: "JournalEntryLines");

            migrationBuilder.DropTable(
                name: "Leaves");

            migrationBuilder.DropTable(
                name: "LedgerPostings");

            migrationBuilder.DropTable(
                name: "MaterialsRequirements");

            migrationBuilder.DropTable(
                name: "OnlineUsers");

            migrationBuilder.DropTable(
                name: "PaymentReceipts");

            migrationBuilder.DropTable(
                name: "Payments");

            migrationBuilder.DropTable(
                name: "PerformanceReviews");

            migrationBuilder.DropTable(
                name: "PortalAccesses");

            migrationBuilder.DropTable(
                name: "ProductionCosts");

            migrationBuilder.DropTable(
                name: "ProductionOrderItems");

            migrationBuilder.DropTable(
                name: "ProductionStockItem");

            migrationBuilder.DropTable(
                name: "PurchaseItems");

            migrationBuilder.DropTable(
                name: "Resignation");

            migrationBuilder.DropTable(
                name: "TimeTrackings");

            migrationBuilder.DropTable(
                name: "Trainings");

            migrationBuilder.DropTable(
                name: "TrainingSession");

            migrationBuilder.DropTable(
                name: "Transactions");

            migrationBuilder.DropTable(
                name: "TrialBalanceLines");

            migrationBuilder.DropTable(
                name: "UserRoles");

            migrationBuilder.DropTable(
                name: "Payrolls");

            migrationBuilder.DropTable(
                name: "BillOfMaterials");

            migrationBuilder.DropTable(
                name: "Posts");

            migrationBuilder.DropTable(
                name: "DispatchOrders");

            migrationBuilder.DropTable(
                name: "OrderItems");

            migrationBuilder.DropTable(
                name: "JournalEntries");

            migrationBuilder.DropTable(
                name: "LeaveType");

            migrationBuilder.DropTable(
                name: "AccountGroups");

            migrationBuilder.DropTable(
                name: "ProductionPlannings");

            migrationBuilder.DropTable(
                name: "Reconciliations");

            migrationBuilder.DropTable(
                name: "VendorInvoices");

            migrationBuilder.DropTable(
                name: "ProductionStock");

            migrationBuilder.DropTable(
                name: "Onboardings");

            migrationBuilder.DropTable(
                name: "BankAccounts");

            migrationBuilder.DropTable(
                name: "TrialBalances");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "BlogCategories");

            migrationBuilder.DropTable(
                name: "DeliveryOrders");

            migrationBuilder.DropTable(
                name: "Status");

            migrationBuilder.DropTable(
                name: "Unit");

            migrationBuilder.DropTable(
                name: "AccountTypes");

            migrationBuilder.DropTable(
                name: "StockLevels");

            migrationBuilder.DropTable(
                name: "PurchaseOrders");

            migrationBuilder.DropTable(
                name: "ProductionOrders");

            migrationBuilder.DropTable(
                name: "Invoices");

            migrationBuilder.DropTable(
                name: "DemandPlannings");

            migrationBuilder.DropTable(
                name: "Vendors");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "ProductionPriority");

            migrationBuilder.DropTable(
                name: "SalesOrders");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Branches");

            migrationBuilder.DropTable(
                name: "Departments");

            migrationBuilder.DropTable(
                name: "TalentAcquisitions");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "SalesOrderStatuses");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "Warehouses");

            migrationBuilder.DropTable(
                name: "Companies");
        }
    }
}
