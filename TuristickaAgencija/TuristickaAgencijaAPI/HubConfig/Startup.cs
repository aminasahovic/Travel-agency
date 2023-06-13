namespace Web.TuristickaAgencija.HubConfig
{
    public class Startup
    {
        public void Configure(IApplicationBuilder app)
        {
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapHub<MyHub>("/chathub"); // Promenite "ChatHub" sa imenom vašeg SignalR Hub-a
                                                       // Dodajte ostale rutiranje endpointe prema potrebama vaše aplikacije
            });
        }

    }
}
