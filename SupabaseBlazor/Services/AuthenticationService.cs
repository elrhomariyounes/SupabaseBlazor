using Microsoft.AspNetCore.Components;
using Supabase.Gotrue;
using System;
using System.Threading.Tasks;
namespace SupabaseBlazor.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly Supabase.Client _supabaseClient;
        private readonly NavigationManager _navigationManager;
        public AuthenticationService(NavigationManager navigationManager)
        {
            _navigationManager = navigationManager;

            _supabaseClient = Supabase.Client.Initialize(
                Environment.GetEnvironmentVariable("supabaseUrl"),
                Environment.GetEnvironmentVariable("supabaseKey"));
        }

        public User User { get; private set; }

        public async Task Login(string email, string password)
        {
            var user = await _supabaseClient.Auth.SignUp(email, password);
            User = user.User;
        }

        public async Task Logout()
        {
            User = null;
            await _supabaseClient.Auth.SignOut();
            _navigationManager.NavigateTo("/");
        }
    }
}
