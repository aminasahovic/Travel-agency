using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Repository.TuristickaAgenija.Repositories;
using Service.TuristickaAgencija.Service;
using System.Text;
using TuristickaAgenija.Repository;
using Web.TuristickaAgencija.HubConfig;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddSignalR();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<TuristickaAgencijaDbContext>(opcije => opcije.UseSqlServer(builder.Configuration.GetConnectionString("TuristickaAgencija")));
builder.Services.AddTransient<IKorisnikService, KorisnikService>();

builder.Services.AddTransient<ICountryService, CountryService>();
builder.Services.AddTransient<ICityService, CityService>();
builder.Services.AddTransient<IUsersService, UsersService>();
builder.Services.AddTransient(typeof(IAccommodationService), typeof(AccommodationService));
builder.Services.AddTransient(typeof(IDestinationService), typeof(DestinationService));
builder.Services.AddTransient(typeof(ITransportationService), typeof(TransportationService));
builder.Services.AddTransient(typeof(ITravelArrangementService), typeof(TravelArrangementService));
builder.Services.AddTransient(typeof(ILandmarkService), typeof(LandmarkService));
builder.Services.AddTransient(typeof(ICounterService), typeof(CounterService));
builder.Services.AddTransient(typeof(IDepartmentService), typeof(DepartmentService));
builder.Services.AddTransient(typeof(IOfficeService), typeof(OfficeService));
builder.Services.AddTransient(typeof(IClientService), typeof(ClientService));
builder.Services.AddTransient(typeof(IMotelService), typeof(MotelService));
builder.Services.AddTransient(typeof(IDestinationImageService), typeof(DestinationImageService));
builder.Services.AddTransient(typeof(IAccommodationImage), typeof(AccommodationImageService));



builder.Services.AddScoped(typeof(IEmailService), typeof(EmailService));






builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddTransient(typeof(ICountryRepository), typeof(CountryRepository));
builder.Services.AddTransient(typeof(ICityRepository), typeof(CityRepository));
builder.Services.AddTransient(typeof(IUsersRepository), typeof(UsersRepository));
builder.Services.AddTransient(typeof(IAccommodationRepositroy), typeof(AccommodationRepository));
builder.Services.AddTransient(typeof(IDestinationRepository), typeof(DestinationRepository));
builder.Services.AddTransient(typeof(ITransportationRepository), typeof(TransportationRepository));
builder.Services.AddTransient(typeof(ITravelArrangmentRepository), typeof(TravelArrangementRepository));
builder.Services.AddTransient(typeof(ILandmarkRepository), typeof(LandmarkRepository));
builder.Services.AddTransient(typeof(ICounterRepository), typeof(CounterRepository));
builder.Services.AddTransient(typeof(IDepartmentRepository), typeof(DepartmentRepository));
builder.Services.AddTransient(typeof(IOfficeRepostory), typeof(OfficeRepository));
builder.Services.AddTransient(typeof(IClientRepository), typeof(ClientRepository));
builder.Services.AddTransient(typeof(IMotelRepository), typeof(MotelRepository));


builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(x =>
{
    x.RequireHttpsMetadata = false;
    x.SaveToken = true;
    x.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("veryverysecret.....")),
        ValidateAudience = false,
        ValidateIssuer = false
    };
});



var app = builder.Build();

app.UseRouting();
app.UseHttpsRedirection();
app.UseCors(
               options => options
               .SetIsOriginAllowed(x => _ = true)
               .AllowAnyMethod()
               .AllowAnyHeader()
               .AllowCredentials()
           ); //This needs to set everything allowed

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthentication();
app.UseAuthorization();
//app.UseEndpoints(endpoints => {
//    endpoints.MapControllers();
//    endpoints.MapHub<MyHub>("/offers");
//});
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
    endpoints.MapHub<MyHub>("/poruke-hub-putanja");
});
//app.MapControllers();

app.Run();
