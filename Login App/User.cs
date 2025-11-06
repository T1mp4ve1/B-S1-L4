namespace Login_App
{
    public static class User
    {
        public static string Username { get; set; } = "Pavel";
        public static string Password { get; set; } = "qwe";
        public static DateTime LoginTime { get; set; }
        public static List<DateTime> ListLogin { get; set; } = new List<DateTime>();
        public static bool LoginStatus = false;

        private static string filePath = "logins.txt";
        static User()
        {
            LoadListLogin();
        }

        //LOGIN
        public static void Login()
        {
            if (LoginStatus)
            {
                Console.WriteLine("Sei gia loggato");
                Console.WriteLine("Premi un tasto per continuare...\n");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Inserisci il tuo Username:");
                string inputName = Console.ReadLine();
                Console.WriteLine("Inserisci la tua Password:");
                string inputPass = Console.ReadLine();
                Console.WriteLine("Ripeti la Password:");
                string inputPass2 = Console.ReadLine();
                Console.WriteLine("");

                if (inputName != Username || inputPass != Password)
                {
                    Console.WriteLine("Username o Password non trovati\n");
                    Console.WriteLine("Premi un tasto per continuare...\n");
                    Console.ReadKey();
                }
                else if (inputPass != inputPass2)
                {
                    Console.WriteLine("Password devono coincidere\n");
                    Console.WriteLine("Premi un tasto per continuare...\n");
                    Console.ReadKey();
                }
                else
                {
                    Console.WriteLine("Il login effettuato con successo\n");
                    Console.WriteLine("Premi un tasto per continuare...\n");
                    Console.ReadKey();
                    LoginTime = DateTime.Now;
                    ListLogin.Add(LoginTime);
                    SaveListLogin(LoginTime);
                    LoginStatus = true;
                }
            }

        }

        //LOGOUT
        public static void Logout()
        {
            if (!LoginStatus)
            {
                Console.WriteLine("Devi prima fare il login\n");
                Console.WriteLine("Premi un tasto per continuare...\n");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Logout eseguito con successo\n");
                Console.WriteLine("Premi un tasto per continuare...\n");
                Console.ReadKey();
                LoginStatus = false;
            }
        }

        //DATE
        public static void InoutDate()
        {
            if (!LoginStatus)
            {
                Console.WriteLine("Devi prima fare il login\n");
                Console.WriteLine("Premi un tasto per continuare...\n");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine($"L'ultimo login eseguito: {LoginTime}\n");
                Console.WriteLine("Premi un tasto per continuare...\n");
                Console.ReadKey();
            }
        }

        //List DATE
        public static void ListDate()
        {
            if (!LoginStatus)
            {
                Console.WriteLine("Devi prima fare il login\n");
                Console.WriteLine("Premi un tasto per continuare...\n");
                Console.ReadKey();
            }
            else
            {
                foreach (DateTime data in ListLogin)
                {
                    Console.WriteLine($"{data}");

                }
                Console.WriteLine("Premi un tasto per continuare...\n");
                Console.ReadKey();
            }
        }

        private static void SaveListLogin(DateTime date)
        {
            try
            {
                File.AppendAllText(filePath, date.ToString() + Environment.NewLine);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Errore nel salvataggio {ex.Message}");
            }
        }

        private static void LoadListLogin()
        {
            try
            {
                string[] lines = File.ReadAllLines(filePath);
                foreach (string line in lines)
                {
                    if (DateTime.TryParse(line, out DateTime parsed))
                    {
                        ListLogin.Add(parsed);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Errore nella lettura {ex.Message}");
            }
        }
    }

}