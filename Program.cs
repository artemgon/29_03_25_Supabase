using ConsoleAppSupabase.Data.Source.Remote.SupabaseDB;
using ConsoleAppSupabase.Screens.Home;
using System.Runtime.CompilerServices;
using System.Text;

namespace ConsoleAppSupabase
{
    class Program
    {
        static async Task Main()
        {
            Console.InputEncoding = Encoding.Unicode;
            Console.OutputEncoding = Encoding.Unicode;
            SupabaseService supabaseService = new();
            try
            {
                do
                {
                    await supabaseService.InitService();
                    Console.WriteLine("[1] - Login");
                    Console.WriteLine("[2] - Register");
                    Console.Write("Select an option: ");
                    var option = Console.ReadLine();
                    string email, password;
                    Console.Write("Email: ");
                    email = Console.ReadLine() ?? string.Empty;
                    Console.Write("Password: ");
                    password = Console.ReadLine() ?? string.Empty;
                    if (email.Length == 0 || password.Length == 0)
                    {
                        Console.WriteLine("Email and password cannot be empty.");
                        continue;
                    }
                    switch (option)
                    {
                        case "1":
                            await supabaseService.Login(email, password);
                            break;
                        case "2":
                            await supabaseService.Register(email, password);
                            Console.WriteLine("Registration is successful! Confirm your email to login.");
                            continue;
                        default:
                            continue;
                    } 
                    supabaseService.SetAuthUser();
                    if (supabaseService.IsLoggedIn)
                    {
                        Console.WriteLine("Login successful!");
                        Console.Clear();
                        HomeScreen.View(supabaseService);
                    }
                    else
                    {
                        Console.WriteLine("Login failed.");
                    }
                }
                while (true);
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(ex.Message);
            }
            Console.ReadKey();
        }
    }
}
