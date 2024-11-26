using AenEnterprise.DataAccess.Repository;
using AenEnterprise.DataAccess.RepositoryInterface;
using AenEnterprise.DataAccess;
using AenEnterprise.ServiceImplementations.Implementation;
using AenEnterprise.ServiceImplementations.Interface;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.AspNetCore.Builder;
using AenEnterprise.FrontEndMvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication.Cookies;
using AenEnterprise.DomainModel.CookieStorage;

using AenEnterprise.ServiceImplementations.ViewModel;
using AenEnterprise.ServiceImplementations;

using AenEnterprise.FrontEndMvc.Models;
using AenEnterprise.FrontEndMvc.Middleware;
using System.Net;
using Microsoft.AspNetCore.Diagnostics;

using AenEnterprise.ServiceImplementations.Implementation.Inventories;
using AenEnterprise.ServiceImplementations.Mapping.Automappers;
using StackExchange.Redis;
using AenEnterprise.DataAccess.RepositoryInterface.Blogs;
using AenEnterprise.DataAccess.Repository.BlogsRepository;
using AenEnterprise.DomainModel.BlogsDomain;
using AenEnterprise.ServiceImplementations.Implementation.JwtTwoFactorAuth;
using Serilog;
using AenEnterprise.ServiceImplementations.Implementation.AccountsService;
using AenEnterprise.DataAccess.RepositoryInterface.AccountRepositoriesInterface;
using AenEnterprise.DataAccess.Repository.AccountRepositories;
using AenEnterprise.ServiceImplementations.Mapping.Automappers.MappingProfile;
using AenEnterprise.ServiceImplementations.Implementation.InventoryManagement;
using AenEnterprise.DataAccess.Repository.InventoryRepository;
using AenEnterprise.DataAccess.RepositoryInterface.InventoryRepositoryInterface;
using AenEnterprise.DomainModel.HumanResources.HumanResourceInterface;
using AenEnterprise.DomainModel.HumanResources;
using AenEnterprise.DomainModel.HumanResources.Benefits;
using AenEnterprise.ServiceImplementations.Implementation.HumanResourceImplementation;
using AenEnterprise.DataAccess.Repository.HumanResourceRepositories;
using AenEnterprise.DataAccess.RepositoryInterface.HumanResourceRepositoriesInterace;
using AenEnterprise.ServiceImplementations.Mapping.Automappers.HumanResource;
using AenEnterprise.DataAccess.RepositoryInterface.SupplyAndChainRepositoryInterface;
using AenEnterprise.DataAccess.Repository.SupplyAndChainRepositories;
using AenEnterprise.ServiceImplementations.Mapping.Automappers.GeneralLedger;
using AenEnterprise.DomainModel.AccountsAndFinance.GeneralLedger.GeneralLedgerInterface;
using AenEnterprise.DomainModel.AccountsAndFinance.GeneralLedger;
using AenEnterprise.DomainModel.InventoryManagement;
using AenEnterprise.ServiceImplementations.FeatureRabbitMQ;

var builder = WebApplication.CreateBuilder(args);

// Configure Serilog
Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Debug() // Set minimum log level
    .MinimumLevel.Override("Microsoft", Serilog.Events.LogEventLevel.Warning) // Adjust Microsoft log level
    .WriteTo.Console() // Log to console
    .WriteTo.File("Logs/log-.txt", rollingInterval: RollingInterval.Day) // Log to file (optional)
    .CreateLogger();

builder.Host.UseSerilog(); // Use Serilog for logging

Log.Information("Starting up the application...");

// Add services to the container.
builder.Host.UseSerilog(); // Use Serilog for logging
// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddSingleton<RabbitMQPublisher>();
builder.Services.AddHostedService<RabbitMQConsumer>();
builder.Services.AddSignalR();
builder.Services.AddSingleton<SalesOrderApprovalConsumer>(); // Add RabbitMQ Consumer
//BlogEngine Service
builder.Services.AddTransient<IBlogEngineService, BlogEngineService>();
builder.Services.AddTransient<IBlogCategoryRepository, BlogCategoryRepository>();
builder.Services.AddTransient<IPostRepository, PostRepository>();
builder.Services.AddTransient<ICommentRepository, CommentRepository>();

//Start EF connectionstring
builder.Services.AddDbContext<AenEnterpriseDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("AenDbEnterpriseConnection")),ServiceLifetime.Scoped);
//End
builder.Services.AddRazorPages();
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

builder.Services.AddTransient<IPurchaseOrderRepository, PurchaseOrderRepository>();
builder.Services.AddTransient<IPurchaseItemRepository, PurchaseItemRepository>();
builder.Services.AddTransient<IPurchaseOrderService, PurchaseOrderService>();

//Authentication and Authorization Jwt
builder.Services.AddTransient<IJwtAuthService, JwtAuthService>();


builder.Services.AddTransient<IProductionOrderService, ProductionOrderService>();
builder.Services.AddTransient<IProductionOrderRepository, ProductionOrderRepository>();
builder.Services.AddTransient<IProductionOrderItemRepository, ProductionOrderItemRepository>();
builder.Services.AddTransient<ICostTransactionRepository, CostTransactionRepository>();


builder.Services.AddTransient<IOnlineUserRepository, OnlineUserRepository>();
builder.Services.AddTransient<IUserRepository, UserRepository>();
builder.Services.AddTransient<IRoleRepository, RoleRepository>();
builder.Services.AddTransient<IUserRoleRepository, UserRoleRepository>();

//AccountPayable
builder.Services.AddTransient<IPaymentRepository, PaymentRepository>();
builder.Services.AddTransient<IVendorRepository, VendorRepository>();
builder.Services.AddTransient<IVendorInvoiceRepository, VendorInvoiceRepository>();
builder.Services.AddTransient<IPaymentReceiptService, PaymentReceiptService>();
builder.Services.AddTransient<IPaymentReceiptRepository, PaymentReceiptRepository>();
builder.Services.AddTransient<IJournalEntryRepository, JournalEntryRepository>();
builder.Services.AddTransient<IJournalEntryLineRepository, JournalEntryLineRepository>();
builder.Services.AddTransient<IAccountPayableService, AccountPayableService>();

// General Ledger
builder.Services.AddTransient<IGeneralLedgerService, GeneralLedgerService>();
builder.Services.AddTransient<IAccountRepository, AccountRepository>();

//Human Resource
builder.Services.AddTransient<IAllowanceRepository, AllowanceRepository>();
builder.Services.AddTransient<IBenefitRepository, BenefitRepository>();
builder.Services.AddTransient<IAdvancePaymentRepository, AdvancePaymentRepository>();

builder.Services.AddTransient<IEmployeeService, EmployeeService>(); 
builder.Services.AddTransient<IAttendanceService, AttendanceService>();
builder.Services.AddTransient<IAttendanceRepository, AttendanceRepository>();
builder.Services.AddTransient<IAllowanceCalculator, AllowanceCalculator>();
builder.Services.AddTransient<IBenefitCalculator, BenefitCalculator>();
builder.Services.AddTransient<IPayrollService, PayrollService>();
builder.Services.AddTransient<IEmployeeRepository, EmployeeRepository>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddTransient<IInvoiceRepository, InvoiceRepository>();
builder.Services.AddTransient<IInvoiceItemRepository, InvoiceItemRepository>();
builder.Services.AddTransient<IBankAccountRepository, BankAccountRepository>();
builder.Services.AddTransient<IProductionOrderItemValidator, DuplicateProductionItemValidate>();

//builder.Services.AddTransient<ISalesOrderRepository, SalesOrderRepository>();

//builder.Services.AddTransient<ISalesOrderService, SalesOrderService>();

// DRY (Don't Repeat Yourself) desing principle
var repositories = new[] 
{ 
    typeof(ISalesOrderRepository), 
    typeof(ISalesOrderService) 
};

foreach (var repo in repositories)
{
    var implementation = repo.Assembly.GetTypes().First(t => repo.IsAssignableFrom(t) && !t.IsInterface);
    builder.Services.AddScoped(repo, implementation);
}



builder.Services.AddTransient<IInvoiceService, InvoiceService>();
builder.Services.AddTransient<IDOService, DOService>();
builder.Services.AddTransient<IAttendanceCalculator, AttendanceCalculator>();
builder.Services.AddTransient<IOverTimeCalculator, OverTimeCalculator>();
builder.Services.AddTransient<IPayrollRepository, PayrollRepository>();
builder.Services.AddTransient<ITrialBalanceService, TrialBalanceService>();
builder.Services.AddTransient<ITrialBalanceGenerator, TrialBalanceGenerator>();
builder.Services.AddTransient<IPayrollRepository, PayrollRepository>();

//builder.Services.AddTransient<ISalesOrderService, SalesService>();
builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();
builder.Services.AddTransient<ICategoryService, CategoryService>();
builder.Services.AddTransient<ICategoryRepository, CategoryRepository>();

builder.Services.AddTransient<IProductRepository, ProductRepository>();
builder.Services.AddTransient<ISalesOrderStatusRepository, SalesOrderStatusRepository>();
builder.Services.AddTransient<IUnitRepository, UnitRepository>();
builder.Services.AddTransient<IOrderItemRepository, OrderItemRepository>();

builder.Services.AddTransient<IInventoryService, InventoryService>();
builder.Services.AddTransient<IDeliveryOrderRepository, DeliveryOrderRepository>();
builder.Services.AddTransient<IDeliveryOrderItemRepository, DeliveryOrderItemRepository>();
builder.Services.AddTransient<IDispatcheRepository, DispatcheOrderRepository>();
 

builder.Services.AddTransient<ICustomerRepository, CustomerRepository>();
builder.Services.AddTransient<ICustomerService, CustomerService>();
builder.Services.AddTransient<ICookieImplementation, CookieImplementation>();

builder.Services.AddHttpContextAccessor();
builder.Services.AddEndpointsApiExplorer();


//Domain Model DI
//builder.Services.AddScoped<IPayrollCalculator, PayrollCalculator>();

//If it is not set, Registration will not resolve
builder.Services.AddScoped<JwtAuthService>();

builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30); // Set session timeout
});


// Redis configuration without maxconnections
var redisConnectionString = "host.docker.internal:6379,allowAdmin=true,connectTimeout=5000,syncTimeout=5000,abortConnect=false";
builder.Services.AddSingleton(new RedisConnection(redisConnectionString)); // Register RedisConnection
// Add Redis connection configuration
var connectionMultiplexer = ConnectionMultiplexer.Connect(redisConnectionString);

// Register IConnectionMultiplexer
builder.Services.AddSingleton<IConnectionMultiplexer>(connectionMultiplexer);

// Register IDatabase (the database that is used for operations)
builder.Services.AddSingleton<IDatabase>(provider => connectionMultiplexer.GetDatabase());

// Add memory caching
builder.Services.AddMemoryCache();

//Automapper
builder.Services.AddAutoMapper(typeof(MappingConfig)); 
builder.Services.AddAutoMapper(typeof(SalesOrderProfile));
builder.Services.AddAutoMapper(typeof(InvoiceProfile));
builder.Services.AddAutoMapper(typeof(DeliveryOrderProfile));
builder.Services.AddAutoMapper(typeof(InventoryMappingProfile)); 
builder.Services.AddAutoMapper(typeof(HumanResourceProfile));
builder.Services.AddAutoMapper(typeof(GeneralLedgerPrfile));


//Jwt Authentication
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration.GetSection("AppSettings:Token").Value)),
            ValidateIssuer = false,
            ValidateAudience = false
        };
    });
 
builder.Services.AddRazorPages();  // Razor Pages

builder.Services.AddHttpContextAccessor();
// Enable CORS configuration
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin", policy =>
    {
        policy.WithOrigins("http://localhost:4200") // Specify the Angular app's origin
              .AllowAnyHeader()
              .AllowAnyMethod()
              .AllowCredentials(); // Required for sending cookies or auth headers
    });
});


var app = builder.Build();
 
//Report Environment configure
var env = app.Services.GetRequiredService<IWebHostEnvironment>();

//app.UseMiddleware<ExceptionMiddleware>();
app.UseSession();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

//app.UseMiddleware<RedirectActionMiddleware>();
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseCors("AllowSpecificOrigin"); // Apply CORS policy

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

 app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapHub<NotificationHub>("/notificationHub");
app.MapHub<SalesOrderHub>("/salesOrderHub");

var salesOrderConsumer = app.Services.GetRequiredService<SalesOrderApprovalConsumer>();
salesOrderConsumer.StartListening();
app.Run();
//configureMapster();



