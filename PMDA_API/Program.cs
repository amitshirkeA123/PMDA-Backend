using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.Extensions.Http;
using PMDA_API;
using PMDA_API.Interface;
using PMDA_API.Services;
using StackExchange.Redis;
using System.IO.Compression;

var builder = WebApplication.CreateBuilder(args);

#region IMemory Catche
builder.Services.AddMemoryCache(); // Register In-Memory Cache
#endregion

#region it will add data from db onece 
// Register the cache service as Singleton
builder.Services.AddSingleton<MasterPMDACacheService>();

// Register the background service to load data at startup
builder.Services.AddHostedService<MasterPMDALoaderService>();
#endregion

#region it will work for multiple user will reqest at same time so it will handel
builder.Services.AddScoped<StreamResponseService>();
// ? Correct way to configure MaxConnectionsPerServer
builder.Services.AddHttpClient("DefaultClient")
    .ConfigurePrimaryHttpMessageHandler(() => new SocketsHttpHandler
    {
        MaxConnectionsPerServer = 1000 // ? Increase parallel request handling
    });

builder.WebHost.ConfigureKestrel(options =>
{
    options.Limits.MaxRequestBodySize = 10000000; // 50MB
});
#endregion


builder.Services.Configure<FormOptions>(options =>
{
    options.MultipartBodyLengthLimit = 308435452012; // 256MB
});

#region Corse Enbaled
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        policy => policy.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader());
});

#endregion

#region This is For Gzip 
builder.Services.AddResponseCompression(options =>
{
    options.EnableForHttps = true;
    options.Providers.Add<GzipCompressionProvider>();
});

builder.Services.Configure<GzipCompressionProviderOptions>(options =>
{
    options.Level = CompressionLevel.Fastest;
});
#endregion


var mySqlConnectionString = builder.Configuration["SqlConnectionString:MySqlDBConnectionString"];
builder.Services.AddSingleton(mySqlConnectionString);
// Add services to the container.
builder.Services.AddSingleton<IConnectionMultiplexer>(sp =>
{
    var configuration = builder.Configuration.GetValue<string>("Redis:ConnectionString");
    var options = ConfigurationOptions.Parse(configuration);

    // ? Increase both Sync and Async timeout limits
    options.SyncTimeout = 90000;  // Increase timeout to 20 seconds for sync calls
    options.AsyncTimeout = 90000; // Set Async timeout for async Redis calls

    // ? Increase buffer size for large payloads
    options.WriteBuffer = 10240; // Increase write buffer for large payloads
    options.ConnectRetry = 5;    // Retry up to 5 times if Redis fails
    options.AbortOnConnectFail = false; // Allow retries instead of failing on initial connection

    // Set timeout and any other desired options
    options.SyncTimeout = 90000; // Timeout for synchronous operations
    options.AbortOnConnectFail = false; // Allow retries on initial connection failure

    // Create and return a single Redis connection
    return ConnectionMultiplexer.Connect(options);
});


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSwaggerGen(c =>
{
    // Add support for uploading multiple files
    c.OperationFilter<SwaggerFileUploadFilter>();
});

builder.Services.AddScoped<IPMDA, PMDA_Service>(); // Change AddScoped if needed.

// Add logging
builder.Logging.ClearProviders();
builder.Logging.AddConsole();  // Log to console
builder.Logging.AddDebug();    // Log to debug output
builder.Logging.AddEventLog(); // Optional: Log to event log (Windows)

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
        c.EnableTryItOutByDefault(); // Optional
    });

    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("AllowAll");

app.UseAuthorization();

app.MapControllers();

app.Run();
