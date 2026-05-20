namespace Taller6_ArchivosPlanos
{
    public class UserService
    {
        private readonly string _usersPath = "Users.txt";
        private string _loggedUser = "";

        public string LoggedUser => _loggedUser;

        // Intenta hacer login. Retorna true si fue exitoso.
        public bool Login()
        {
            Console.Clear();
            Console.WriteLine("========================================");
            Console.WriteLine("           INICIAR SESIÓN");
            Console.WriteLine("========================================");

            int attempts = 0;

            while (attempts < 3)
            {
                Console.Write("Usuario: ");
                string username = Console.ReadLine()?.Trim() ?? "";

                Console.Write("Contraseña: ");
                string password = ReadPassword(); // oculta la contraseña

                var users = ReadUsers();
                var user = users.FirstOrDefault(u =>
                    u.username == username && u.password == password);

                if (user.username != null)
                {
                    if (!user.active)
                    {
                        Console.WriteLine("\nUsuario BLOQUEADO. Contacte al administrador.");
                        return false;
                    }
                    _loggedUser = username;
                    Console.WriteLine($"\nBienvenido, {username}!");
                    return true;
                }

                attempts++;
                int remaining = 3 - attempts;
                Console.WriteLine($"\nDatos incorrectos. Intentos restantes: {remaining}");

                if (remaining == 0)
                {
                    BlockUser(username);
                    Console.WriteLine("Usuario BLOQUEADO por exceder intentos.");
                }
            }

            return false;
        }

        // Lee todos los usuarios del archivo
        private List<(string username, string password, bool active)> ReadUsers()
        {
            var list = new List<(string, string, bool)>();
            if (!File.Exists(_usersPath)) return list;

            foreach (var line in File.ReadAllLines(_usersPath))
            {
                var parts = line.Split(',');
                if (parts.Length == 3)
                    list.Add((parts[0], parts[1], bool.Parse(parts[2])));
            }
            return list;
        }

        // Bloquea un usuario cambiando su campo active a false
        private void BlockUser(string username)
        {
            if (!File.Exists(_usersPath)) return;

            var lines = File.ReadAllLines(_usersPath).ToList();
            for (int i = 0; i < lines.Count; i++)
            {
                var parts = lines[i].Split(',');
                if (parts[0] == username)
                {
                    lines[i] = $"{parts[0]},{parts[1]},false";
                    break;
                }
            }
            File.WriteAllLines(_usersPath, lines);
        }

        // Lee la contraseña sin mostrarla en pantalla
        private string ReadPassword()
        {
            string pass = "";
            ConsoleKeyInfo key;
            do
            {
                key = Console.ReadKey(intercept: true);
                if (key.Key != ConsoleKey.Enter && key.Key != ConsoleKey.Backspace)
                {
                    pass += key.KeyChar;
                    Console.Write("*");
                }
                else if (key.Key == ConsoleKey.Backspace && pass.Length > 0)
                {
                    pass = pass[..^1];
                    Console.Write("\b \b");
                }
            } while (key.Key != ConsoleKey.Enter);
            Console.WriteLine();
            return pass;
        }
    }
}