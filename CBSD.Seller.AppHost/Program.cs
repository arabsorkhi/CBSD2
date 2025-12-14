


var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.BlazorApp1>("blazorapp1");

builder.AddProject<Projects.WebApplication1>("webapplication1");

builder.Build().Run();
