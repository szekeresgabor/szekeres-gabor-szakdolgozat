using identity_api.Extensions;

var builder = WebApplication.CreateBuilder(args);
var app = builder.BuildApi();

//var connString = builder.Configuration.GetConnectionString("DefaultConnection");

app.Run();
