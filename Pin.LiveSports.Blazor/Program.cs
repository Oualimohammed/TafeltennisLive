using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.EntityFrameworkCore;
using Pin.LiveSports.Blazor.Data;
using Pin.LiveSports.Blazor.Repositories;
using Pin.LiveSports.Blazor.Services.Implementations;
using Pin.LiveSports.Blazor.Services.Interfaces;
using Pin.LiveSports.Blazor.Hubs;


namespace Pin.LiveSports.Blazor
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorPages();
            builder.Services.AddServerSideBlazor();

            // registratie van de DbContext
            //builder.Services.AddDbContext<SportDbContext>(options =>
            //    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            builder.Services.AddDbContextFactory<SportDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            // Registatie voor de services
            /*      builder.Services.AddScoped<ITournamentService, TournamentService>();
                  builder.Services.AddScoped<IPlayerService, PlayerService>();

                  builder.Services.AddScoped<IMatchService, MatchService>();*/

            builder.Services.AddSingleton<InMemoryEventRepository>();


            builder.Services.AddTransient<ITournamentService, TournamentService>();
            builder.Services.AddTransient<IPlayerService, PlayerService>();
            builder.Services.AddTransient<IMatchService, MatchService>();

            builder.Services.AddTransient<IEventService, EventService>();

            //builder.Services.AddSignalR();
            // SignalR configuratie
            builder.Services.AddSignalR(options => {
                options.EnableDetailedErrors = true;
                options.MaximumReceiveMessageSize = 1024 * 1024; // 1MB
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseRouting();

            app.MapHub<LiveMatchHub>("/liveMatchHub");

            app.MapBlazorHub();
            app.MapFallbackToPage("/_Host");

            app.Run();
        }
    }
}