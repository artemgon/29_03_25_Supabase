using Supabase.Gotrue;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppSupabase.Data.Source.Remote.SupabaseDB
{
    public class SupabaseService
    {
        private const string SupabaseUrl = "https://gkjhohmhzqycnlnuevya.supabase.co";
        private const string SupabaseKey = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpc3MiOiJzdXBhYmFzZSIsInJlZiI6ImdramhvaG1oenF5Y25sbnVldnlhIiwicm9sZSI6ImFub24iLCJpYXQiOjE3NDY5Mzk2MjksImV4cCI6MjA2MjUxNTYyOX0.RvmVvNZ5xbacjJcy3lxD06Bo4W2R58-8AwacP5z_r_M";

        private readonly Supabase.Client _client;

        public User? SupabaseUser { get; set; } = null;

        public bool IsLoggedIn { get; set; } = false;

        public SupabaseService()
        {
            try
            {
                var options = new Supabase.SupabaseOptions
                {
                    AutoConnectRealtime = true,
                };
                _client = new Supabase.Client(SupabaseUrl, SupabaseKey, options);
            }
            catch (Exception ex)
            {
                throw new Exception($"SupabaseService raises exception: {ex}");
            }
        }

        public async Task InitService()
        {
            try
            {
                await _client.InitializeAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"InitService raises exception: {ex.Message}");
            }
        }

        public async Task<Session?> Login(string email, string password)
        {
            try
            {
                var session = await _client.Auth.SignIn(email, password);
                return session;
            }
            catch (Exception ex)
            {
                throw new Exception($"Login raises exception: {ex.Message}");
            }
        }

        public async Task<Session?> Register(string email, string password)
        {
            try
            {
                var session = await _client.Auth.SignUp(email, password);
                return session;
            }
            catch (Exception ex)
            {
                throw new Exception($"Register raises exception: {ex.Message}");
            }
        }

        public void SetAuthUser()
        { 
            if (_client.Auth.CurrentUser != null)
            {
                SupabaseUser = _client.Auth.CurrentUser;
                IsLoggedIn = true;
            }
        }
    }
}
