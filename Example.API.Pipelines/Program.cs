using Example.API.Application.Behaviours;
using Example.API.Web.Filters;
using FluentValidation;
using MediatR;
using Serilog;
using AppAssembly = Example.API.Application.IAssemblyMarker;

var builder = WebApplication.CreateBuilder(args);
builder.Host.UseSerilog((context, configuration) =>
{
    configuration.ReadFrom.Configuration(context.Configuration);
});

// registers actions filters
builder.Services.AddControllers(options =>
{
    options.Filters.Add<SampleActionFilter>();
    options.Filters.Add<AsyncActionFilter>();
});
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// MediatR https://github.com/jbogard/MediatR
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(AppAssembly).Assembly));
builder.Services.AddValidatorsFromAssemblyContaining<AppAssembly>(ServiceLifetime.Transient);

// registers command-specific mediator behaviors
builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(BeforeCommandBehaviour<,>));
builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(AfterCommandBehaviour<,>));

// registers cross-cutting concern behaviours
builder.Services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
builder.Services.AddScoped(typeof(IPipelineBehavior<,>), typeof(LoggingBehaviour<,>));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseSerilogRequestLogging();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

// registers middleware
app.Use(async (context, next) =>
{
    Console.WriteLine("ASP.NET Core middleware invoked!");
    await next();
});

app.Run();
