


var builder = WebApplication.CreateBuilder();
var app =  builder.Build();
var timeReq = DateTime.Now.ToShortTimeString();

app.MapWhen(context => context.Request.Path == "/time",
    async appBuilder => appBuilder.Run(async context =>
    {
        var time = DateTime.Now.ToShortDateString();
        Console.WriteLine($"time now: {timeReq}");
    })
    );

app.UseWhen(context => context.Request.Path == "/date",
    async appBuilder => appBuilder.Run(async context =>
    {
        var time = DateTime.Now.ToShortTimeString();
        var date = DateTime.Now.ToShortDateString();
        await context.Response.WriteAsync($"date: {date} : {time}" );
    })
    );
app.Run(async context =>
{
    await context.Response.WriteAsync("Default");
});

app.Run();