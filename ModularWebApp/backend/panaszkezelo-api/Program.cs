using panaszkezelo_api.Extensions;

var builder = WebApplication.CreateBuilder(args);
var app = await builder.BuildApi();

app.Run();