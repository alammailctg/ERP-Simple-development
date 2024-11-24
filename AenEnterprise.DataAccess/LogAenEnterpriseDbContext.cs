using AenEnterprise.DataAccess.ModelEntityConfigurations;
using AenEnterprise.DataAccess.ModelEntityConfigurations.Blogs;
using AenEnterprise.DomainModel;
using AenEnterprise.DomainModel.AccountsAndFinance.AccountPayable;
using AenEnterprise.DomainModel.AccountsAndFinance.AccountReceivable;
using AenEnterprise.DomainModel.AccountsAndFinance.AccountReceivable.Configuration;
using AenEnterprise.DomainModel.AccountsAndFinance.AccountReceivable.SalesManagement;
using AenEnterprise.DomainModel.AccountsAndFinance.GeneralLedger;
using AenEnterprise.DomainModel.BlogsDomain;
using AenEnterprise.DomainModel.HRDomain;
using AenEnterprise.DomainModel.HumanResources;
using AenEnterprise.DomainModel.SupplyAndChainManagement;
using AenEnterprise.DomainModel.SupplyAndChainManagement.Configuration;
using AenEnterprise.DomainModel.UserDomain;
using Castle.Core.Logging;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace AenEnterprise.DataAccess
{
    public class LogAenEnterpriseDbContext:AenEnterpriseDbContext
    {
        private readonly ILogger<AenEnterpriseDbContext> _logger;

        public LogAenEnterpriseDbContext()
        {

        }
        public LogAenEnterpriseDbContext(DbContextOptions<AenEnterpriseDbContext> options) : base(options) { }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            if (!options.IsConfigured)
            {
                options.UseSqlServer("Data Source=.\\SQLEXPRESS;Initial Catalog=AenDbEnterprise;User ID=sa;Password=1234;TrustServerCertificate=True;")
                .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking)
                .EnableSensitiveDataLogging()
                .LogTo(LogQueryExecutionTime, LogLevel.Information);
            }
        }

        private void LogQueryExecutionTime(string log)
        {
            // Log SQL query
            _logger.LogInformation(log);

            // Log specific message for executed commands
            if (log.Contains("Executed DbCommand"))
            {
                _logger.LogInformation("Database query execution time logged");
            }
        }
        //General Ledger

        //BlogPost
        public DbSet<BlogCategory> BlogCategories { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }


        //Authentication
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<OnlineUser> OnlineUsers { get; set; }

        //Sales management system
        public DbSet<Account> Accounts { get; set; }
        public DbSet<AccountGroup> AccountGroups { get; set; }
        public DbSet<AccountType> AccountTypes { get; set; }
        public DbSet<BenefitsAdministration> BenefitsAdministrations { get; set; }
        public DbSet<CreditMemo> CreditMemos { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<DemandPlanning> DemandPlannings { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Inventory> Inventories { get; set; }
        public DbSet<JournalEntry> JournalEntries { get; set; }
        public DbSet<JournalEntryLine> JournalEntryLines { get; set; }
        public DbSet<LedgerPosting> LedgerPostings { get; set; }
        public DbSet<MaterialsRequirement> MaterialsRequirements { get; set; }
        public DbSet<Onboarding> Onboardings { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<PaymentReceipt> PaymentReceipts { get; set; }
        public DbSet<Payroll> Payrolls { get; set; }
        public DbSet<PerformanceReview> PerformanceReviews { get; set; }
        public DbSet<PortalAccess> PortalAccesses { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductionPlanning> ProductionPlannings { get; set; }
        public DbSet<PurchaseItem> PurchaseItems { get; set; }
        public DbSet<PurchaseOrder> PurchaseOrders { get; set; }
        public DbSet<Reconciliation> Reconciliations { get; set; }
        public DbSet<TalentAcquisition> TalentAcquisitions { get; set; }
        public DbSet<TimeTracking> TimeTrackings { get; set; }
        public DbSet<Training> Trainings { get; set; }
        public DbSet<Vendor> Vendors { get; set; }
        public DbSet<VendorInvoice> VendorInvoices { get; set; }
        public DbSet<Warehouse> Warehouses { get; set; }
        public DbSet<StockLevel> StockLevels { get; set; } // Include your StockLevel entity here
        public DbSet<SalesOrder> SalesOrders { get; set; }
        public DbSet<DeliveryOrder> DeliveryOrders { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<DispatcheOrder> DispatchOrders { get; set; }
        public DbSet<DispatchItem> DispatchItems { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }


        //Account Payable
        public DbSet<SalesOrderStatus> SalesOrderStatuses { get; set; }
        public DbSet<BankAccount> BankAccounts { get; set; }
        public DbSet<Transaction> Transactions { get; set; }



        //HR Management
        public DbSet<Attendance> Attendances { get; set; }
        public DbSet<Leave> Leaves { get; set; }
        public DbSet<Salary> Salary { get; set; }
        public DbSet<Increament> Increaments { get; set; }
        public DbSet<Department> Departments { get; set; }

        //Company Info
        public DbSet<Company> Companies { get; set; }
        public DbSet<Branch> Branches { get; set; }




        //Purchase Management
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AccountConfiguration());
            modelBuilder.ApplyConfiguration(new AccountGroupConfiguration());
            modelBuilder.ApplyConfiguration(new AccountTypeConfiguration());
            modelBuilder.ApplyConfiguration(new BenefitsAdministrationConfiguration());
            modelBuilder.ApplyConfiguration(new CustomerConfiguration());
            modelBuilder.ApplyConfiguration(new DemandPlanningConfiguration());
            modelBuilder.ApplyConfiguration(new EmployeeConfiguration());
            modelBuilder.ApplyConfiguration(new InventoryConfiguration());
            modelBuilder.ApplyConfiguration(new JournalEntryConfiguration());
            modelBuilder.ApplyConfiguration(new JournalEntryLineConfiguration());
            modelBuilder.ApplyConfiguration(new LedgerPostingConfiguration());
            modelBuilder.ApplyConfiguration(new MaterialsRequirementConfiguration());
            modelBuilder.ApplyConfiguration(new OnboardingConfiguration());
            modelBuilder.ApplyConfiguration(new PaymentConfiguration());
            modelBuilder.ApplyConfiguration(new PayrollConfiguration());
            modelBuilder.ApplyConfiguration(new PerformanceReviewConfiguration());
            modelBuilder.ApplyConfiguration(new PortalAccessConfiguration());
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new ProductionPlanningConfiguration());
            modelBuilder.ApplyConfiguration(new PurchaseItemConfiguration());
            modelBuilder.ApplyConfiguration(new PurchaseOrderConfiguration());
            modelBuilder.ApplyConfiguration(new ReconciliationConfiguration());
            modelBuilder.ApplyConfiguration(new StockLevelConfiguration());
            modelBuilder.ApplyConfiguration(new TalentAcquisitionConfiguration());
            modelBuilder.ApplyConfiguration(new TimeTrackingConfiguration());
            modelBuilder.ApplyConfiguration(new TrainingConfiguration());
            modelBuilder.ApplyConfiguration(new VendorConfiguration());
            modelBuilder.ApplyConfiguration(new VendorInvoiceConfiguration());
            modelBuilder.ApplyConfiguration(new CreditMemoConfiguration());
            modelBuilder.ApplyConfiguration(new PaymentReceiptConfiguration());
            modelBuilder.ApplyConfiguration(new WarehouseConfiguration());
            modelBuilder.ApplyConfiguration(new UserRoleConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new RoleConfiguration());
            modelBuilder.ApplyConfiguration(new OnlineUserConfiguration());
            modelBuilder.ApplyConfiguration(new InvoiceConfiguration());
            modelBuilder.ApplyConfiguration(new InvoiceItemConfiguration());

            //Blog 
            modelBuilder.ApplyConfiguration(new BlogCategoryConfiguration());
            modelBuilder.ApplyConfiguration(new PostConfiguration());
            modelBuilder.ApplyConfiguration(new CommentConfiguration());


            modelBuilder.Entity<Leave>(entity =>
            {
                entity.HasKey(x => x.Id);
                //map relation One SalesOrder with many Invoice

            });

            modelBuilder.Entity<Increament>(entity =>
            {
                entity.HasKey(x => x.Id);
                entity.Property(emp => emp.Amount).HasColumnType("decimal(18,2)");
                //map relation One SalesOrder with many Invoice

            });
            modelBuilder.Entity<Salary>(entity =>
            {
                entity.HasKey(x => x.Id);
                entity.Property(emp => emp.BasicSalary).HasColumnType("decimal(18,2)");
                entity.Property(emp => emp.SalaryPerDay).HasColumnType("decimal(18,2)");
                entity.Property(emp => emp.Allowances).HasColumnType("decimal(18,2)");
                entity.Property(emp => emp.Deductions).HasColumnType("decimal(18,2)");
                entity.Property(emp => emp.GrossSalary).HasColumnType("decimal(18,2)");
                entity.Property(emp => emp.NetSalary).HasColumnType("decimal(18,2)");


            });
            modelBuilder.Entity<Attendance>(entity =>
            {
                entity.HasKey(x => x.Id);

                //map relation One SalesOrder with many Invoice

            });
            modelBuilder.Entity<BankAccount>(entity =>
            {
                entity.HasKey(x => x.Id);
                entity.Property(so => so.Balance).HasColumnType("decimal(18,2)");
                entity.HasMany(b => b.Transactions).WithOne(t => t.BankAccount).HasForeignKey(t => t.BankAccountId);
            });
            modelBuilder.Entity<Transaction>(entity =>
            {
                entity.HasKey(x => x.Id);
                entity.Property(so => so.Amount).HasColumnType("decimal(18,2)");
                entity.Property(so => so.BalanceBefore).HasColumnType("decimal(18,2)");
                entity.Property(so => so.BalanceAfter).HasColumnType("decimal(18,2)");
                //map relation One Bank Account with many Transaction

                entity.HasOne(t => t.BankAccount).WithMany(b => b.Transactions).HasForeignKey(t => t.BankAccountId).OnDelete(DeleteBehavior.NoAction);


            });


            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasKey(x => x.Id);
                entity.Property(p => p.Name).IsRequired();
                entity.HasData(new Product { Id = 1, Name = "Plate" },
                    new Product { Id = 2, Name = "Brass" });
            });
            modelBuilder.Entity<Company>(entity =>
            {
                entity.HasKey(c => c.Id); // Set the primary key
                entity.Property(c => c.Name).HasColumnName("Name").HasColumnType("nvarchar(max)").IsRequired();
                entity.Property(c => c.RegistrationNumber).HasColumnName("RegistrationNumber").HasColumnType("nvarchar(max)").IsRequired();
                entity.Property(c => c.TaxIdentifier).HasColumnName("TaxIdentifier").HasColumnType("nvarchar(max)").IsRequired();
                entity.Property(c => c.IndustryType).HasColumnName("IndustryType").HasColumnType("nvarchar(max)").IsRequired();
                entity.Property(c => c.CompanyAddress).HasColumnName("CompanyAddress").HasColumnType("nvarchar(max)").IsRequired();
                entity.Property(c => c.Country).HasColumnName("Country").HasColumnType("nvarchar(max)").IsRequired();
                entity.Property(c => c.CompanyEmail).HasColumnName("CompanyEmail").HasColumnType("nvarchar(max)").IsRequired();
                entity.Property(c => c.CompanyPhone).HasColumnName("CompanyPhone").HasColumnType("nvarchar(max)").IsRequired();
                entity.Property(c => c.IncorporationDate).HasColumnName("IncorporationDate").HasColumnType("datetime2").IsRequired();
                entity.Property(c => c.FullName).HasColumnName("FullName").HasColumnType("nvarchar(max)").IsRequired();
                entity.Property(c => c.InvoiceAddress).HasColumnName("InvoiceAddress").HasColumnType("nvarchar(max)").IsRequired();
                entity.Property(c => c.WebPageAddress).HasColumnName("WebPageAddress").HasColumnType("nvarchar(max)").IsRequired();
                entity.Property(c => c.VATCode).HasColumnName("VATCode").HasColumnType("nvarchar(max)").IsRequired();
                entity.Property(c => c.VATAreaCode).HasColumnName("VATAreaCode").HasColumnType("nvarchar(max)").IsRequired();
                entity.Property(c => c.IsPrimary).HasColumnName("IsPrimary").HasColumnType("bit").IsRequired();
                entity.Property(c => c.CreatedDate).HasColumnName("CreatedDate").HasColumnType("datetime2").IsRequired();
                entity.Property(c => c.ExpiryDate).HasColumnName("ExpiryDate").HasColumnType("datetime2").IsRequired();
                entity.Property(c => c.IsDeleted).HasColumnName("IsDeleted").HasColumnType("bit").IsRequired();
                entity.Property(c => c.AnnualRevenue).HasColumnName("AnnualRevenue").HasColumnType("decimal").IsRequired();
                entity.Property(c => c.IsPubliclyListed).HasColumnName("IsPubliclyListed").HasColumnType("bit").IsRequired();
                entity.Property(c => c.IsMultipleWareHouse).HasColumnName("IsMultipleWareHouse").HasColumnType("bit").IsRequired();

                // Sample data for Company entity
                entity.HasData(
                    new Company
                    {
                        Id = 1,
                        Name = "Company B",
                        RegistrationNumber = "123456789",
                        TaxIdentifier = "TAX123",
                        IndustryType = "Sample Industry",
                        CompanyAddress = "123 Sample St",
                        Country = "Sample Country",
                        CompanyEmail = "company@example.com",
                        CompanyPhone = "123-456-7890",
                        IncorporationDate = DateTime.Now.AddYears(-5),
                        FullName = "Full Name",
                        InvoiceAddress = "456 Invoice St",
                        WebPageAddress = "www.company.com",
                        VATCode = "VAT-123",
                        VATAreaCode = "Area-123",
                        IsPrimary = true,
                        CreatedDate = DateTime.Now.AddYears(-5),
                        ExpiryDate = DateTime.Now.AddYears(5),
                        IsDeleted = false,
                        AnnualRevenue = 1000000.00m,
                        IsPubliclyListed = false,
                        IsMultipleWareHouse = true
                    },
                    new Company
                    {
                        Id = 2,
                        Name = "Company A",
                        RegistrationNumber = "123488796",
                        TaxIdentifier = "TAX123",
                        IndustryType = "Sample Industry",
                        CompanyAddress = "123 Sample St",
                        Country = "Sample Country",
                        CompanyEmail = "company@example.com",
                        CompanyPhone = "123-456-7890",
                        IncorporationDate = DateTime.Now.AddYears(-5),
                        FullName = "Full Name",
                        InvoiceAddress = "456 Invoice St",
                        WebPageAddress = "www.company.com",
                        VATCode = "VAT-123",
                        VATAreaCode = "Area-123",
                        IsPrimary = true,
                        CreatedDate = DateTime.Now.AddYears(-5),
                        ExpiryDate = DateTime.Now.AddYears(5),
                        IsDeleted = false,
                        AnnualRevenue = 1000000.00m,
                        IsPubliclyListed = false,
                        IsMultipleWareHouse = true
                    });

            });





            // Purchase Mapping
            modelBuilder.Entity<PurchaseOrder>((Action<Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<PurchaseOrder>>)(entity =>
            {
                entity.HasKey(x => x.Id);

            }));

            modelBuilder.Entity<PurchaseItem>(entity =>
            {
                entity.HasKey(x => x.Id);
                entity.Property(so => so.Price).HasColumnType("decimal(18,2)");
                entity.Property(so => so.Quantity).HasColumnType("decimal(18,2)");
                entity.Property(so => so.Amount).HasColumnType("decimal(18,2)");
                entity.HasOne(oi => oi.PurchaseOrder).WithMany(sp => sp.PurchaseItems).HasForeignKey(po => po.PurchaseOrderId).OnDelete(DeleteBehavior.NoAction);
                entity.HasOne(oi => oi.Unit).WithMany(sp => sp.PurchaseItems).HasForeignKey(po => po.UnitId).OnDelete(DeleteBehavior.NoAction);
            });


            modelBuilder.Entity<Status>(entity =>
            {
                entity.HasKey(x => x.Id);
                entity.Property(p => p.Name).IsRequired();
                entity.HasData(new Product { Id = 1, Name = "Pending" },
                    new Product { Id = 2, Name = "Approved" }, new Product { Id = 3, Name = "Rejected" });
            });


            modelBuilder.Entity<SalesOrderStatus>(entity =>
            {
                entity.HasKey(x => x.Id);
                entity.Property(c => c.Name).IsRequired();
                entity.HasData(
                    new SalesOrderStatus { Id = 1, Name = "CreateSalesOrder" },
                    new SalesOrderStatus { Id = 2, Name = "PendingApprovalOrder" },
                    new SalesOrderStatus { Id = 3, Name = "ApprovedSalesOrder" },
                    new SalesOrderStatus { Id = 4, Name = "CreateInvoice" },
                    new SalesOrderStatus { Id = 5, Name = "ApprovedInvoice" },
                    new SalesOrderStatus { Id = 6, Name = "CreateDO" },
                    new SalesOrderStatus { Id = 7, Name = "ApprovedDO" },
                    new SalesOrderStatus { Id = 8, Name = "CreateDispatcheAndDone" },
                    new SalesOrderStatus { Id = 9, Name = "Reject" }
                 );

                //map relation One role with many User
            });

            modelBuilder.Entity<Unit>(entity =>
            {
                entity.HasKey(x => x.Id);
                entity.Property(c => c.Name).IsRequired();
                entity.HasData(new Unit { Id = 1, Name = "KG" },
                    new Unit { Id = 2, Name = "Lot" });
            });



            modelBuilder.Entity<SalesOrder>(entity =>
            {
                entity.HasKey(x => x.Id);

                entity.HasOne(so => so.Customer).WithMany(cust => cust.SalesOrders).HasForeignKey(cust => cust.CustomerId).OnDelete(DeleteBehavior.NoAction);
                //entity.HasMany(so => so.OrderItems).WithOne(t => t.SalesOrder).HasForeignKey(t => t.SalesOrderId).OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<OrderItem>(entity =>
            {
                entity.HasKey(x => x.Id);
                entity.Property(oi => oi.Price).HasColumnType("decimal(18,2)");
                entity.Property(oi => oi.Quantity).HasColumnType("decimal(18,2)");
                entity.Property(oi => oi.BalanceQuantity).HasColumnType("decimal(18,2)");
                entity.Property(oi => oi.InvoicedQuantity).HasColumnType("decimal(18,2)");
                entity.Property(oi => oi.Amount).HasColumnType("decimal(18,2)");
                entity.Property(oi => oi.DiscountPercent).HasColumnType("decimal(18,2)");
                entity.Property(oi => oi.NetAmount).HasColumnType("decimal(18,2)");
                entity.Property(oi => oi.ProductId).HasColumnType("int");
                entity.Property(oi => oi.InvoicedAmount).HasColumnType("decimal(18,2)");
                //map relation One SalesOrder with many Invoice
                entity.HasOne(oi => oi.SalesOrder).WithMany(so => so.OrderItems).HasForeignKey(oi => oi.SalesOrderId).OnDelete(DeleteBehavior.Cascade);
                entity.HasOne(oi => oi.Product).WithMany(p => p.OrderItems).HasForeignKey(oi => oi.ProductId).OnDelete(DeleteBehavior.NoAction);
                entity.HasOne(oi => oi.Unit).WithMany(un => un.OrderItems).HasForeignKey(oi => oi.UnitId).OnDelete(DeleteBehavior.NoAction);
                entity.HasOne(oi => oi.Status).WithMany(p => p.OrderItems).HasForeignKey(oi => oi.StatusId).OnDelete(DeleteBehavior.NoAction);

            });


            modelBuilder.Entity<DeliveryOrder>(entity =>
            {
                entity.HasKey(x => x.Id);
                entity.Property(dord => dord.Id).IsRequired();
                entity.HasOne(dord => dord.SalesOrder).WithMany(so => so.DeliveryOrders).HasForeignKey(dord => dord.SalesOrderId).OnDelete(DeleteBehavior.NoAction);
                entity.HasOne(dord => dord.Invoice).WithMany(inv => inv.DeliveryOrders).HasForeignKey(dord => dord.InvoiceId).OnDelete(DeleteBehavior.NoAction);
            });

            modelBuilder.Entity<DeliveryOrderItem>(entity =>
            {
                entity.HasKey(x => x.Id);
                entity.Property(dord => dord.Id).IsRequired();
                entity.Property(dord => dord.DeliveryQuantity).HasColumnType("decimal(18,2)");
                entity.Property(dord => dord.DeliveryAmount).HasColumnType("decimal(18,2)");
                entity.Property(dord => dord.DispatchQuantity).HasColumnType("decimal(18,2)");
                entity.Property(dord => dord.DispatchAmount).HasColumnType("decimal(18,2)");
                entity.Property(dord => dord.BalanceQuantity).HasColumnType("decimal(18,2)");
                entity.Property(dord => dord.BalanceAmount).HasColumnType("decimal(18,2)");

                entity.HasOne(oi => oi.Status).WithMany(p => p.DeliveryOrderItems).HasForeignKey(oi => oi.StatusId).OnDelete(DeleteBehavior.NoAction);

                entity.HasOne(oi => oi.OrderItem).WithMany(p => p.DeliveryOrderItems).HasForeignKey(oi => oi.OrderItemId).OnDelete(DeleteBehavior.NoAction);
            });
            modelBuilder.Entity<DispatcheOrder>(entity =>
            {
                entity.HasKey(x => x.Id);
                entity.HasOne(disp => disp.SalesOrder).WithMany(so => so.DispatcheOrders).HasForeignKey(disp => disp.SalesOrderId).OnDelete(DeleteBehavior.NoAction);
                entity.HasOne(disp => disp.Invoice).WithMany(inv => inv.DispatcheOrders).HasForeignKey(disp => disp.InvoiceId).OnDelete(DeleteBehavior.NoAction);
                entity.HasOne(disp => disp.DeliveryOrder).WithMany(dord => dord.DispatcheOrders).HasForeignKey(disp => disp.DeliveryOrderId).OnDelete(DeleteBehavior.NoAction);
            });

            modelBuilder.Entity<DispatchItem>(entity =>
            {
                entity.HasKey(x => x.Id);
                entity.Property(disp => disp.Id).IsRequired();
                entity.Property(dord => dord.VehicalEmptyWeight).HasColumnType("decimal(18,2)");
                entity.Property(dord => dord.VehicalLoadWeight).HasColumnType("decimal(18,2)");
                entity.Property(dord => dord.DispatchQuantity).HasColumnType("decimal(18,2)");
                entity.Property(dord => dord.DispatchAmount).HasColumnType("decimal(18,2)");
                entity.HasOne(di => di.OrderItem).WithMany(di => di.DispatchItems).HasForeignKey(di => di.OrderItemId).OnDelete(DeleteBehavior.NoAction);
            });
        }
    }
}
