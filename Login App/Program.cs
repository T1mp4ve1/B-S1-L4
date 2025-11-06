using Login_App;

public class Program
{
    static void Main()
    {
        int choice;
        do
        {
            Console.Clear();
            Console.WriteLine("===============OPERAZIONI==============\n");
            Console.WriteLine("Scegli l'operazione da effettuare:\n");
            Console.WriteLine("1.: Login\n");
            Console.WriteLine("2.: Logout\n");
            Console.WriteLine("3.: Verifica ora e data di login\n");
            Console.WriteLine("4.: Lista degli accessi\n");
            Console.WriteLine("5.: Esci\n");
            Console.WriteLine("========================================\n");
            choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    User.Login();
                    break;
                case 2:
                    User.Logout();
                    break;
                case 3:
                    User.InoutDate();
                    break;
                case 4:
                    User.ListDate();
                    break;
                case 5:
                    Console.WriteLine("Uscita dal programma...");
                    break;
                default:
                    Console.WriteLine("Scelta non valida");
                    break;
            }
        } while (choice != 5);
    }
}