using Supabase.Gotrue;
using System.Threading.Tasks;

namespace SupabaseBlazor.Services
{
    public interface IAuthenticationService
    {
        User User { get; }
        Task Login(string email, string password);
        Task Logout();
    }
}
