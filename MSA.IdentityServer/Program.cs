using Duende.IdentityServer.Models;
using Duende.IdentityServer.Test;
using MSA.IdentityService.DummyData;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddIdentityServer(options => {
    options.Events.RaiseErrorEvents = true;
    options.Events.RaiseInformationEvents = true;
    options.Events.RaiseSuccessEvents = true;
    options.Events.RaiseFailureEvents = true;

   options.EmitStaticAudienceClaim = true;
}).AddTestUsers(TestUsers.Users) 
  .AddInMemoryClients(Config.Clients)
  .AddInMemoryApiResources(Config.ApiResources)
  .AddInMemoryApiScopes(Config.ApiScopes)
  .AddInMemoryIdentityResources(Config.IdentityResources);

builder.Services.AddRazorPages();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseIdentityServer();

app.UseAuthorization();

app.MapControllers();

app.MapRazorPages();

app.Run();
