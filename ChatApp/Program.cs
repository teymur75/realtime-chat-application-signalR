using ChatApp.Hubs;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(option =>
{
    option.AddDefaultPolicy(policy =>
    {
        policy.AllowAnyHeader()
        .AllowAnyMethod()
        .AllowCredentials   ()
        .SetIsOriginAllowed(origin => true);
    });
});

builder.Services.AddSignalR();



var app = builder.Build();
app.MapHub<ChatHub>("/chathub");
app.UseCors(); 

app.Run();
