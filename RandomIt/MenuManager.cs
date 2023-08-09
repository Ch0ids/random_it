using System.Text;

namespace RandomIt
{
    public class MenuManager
    {
        //option decription
        static string[] fileOptions =
            {
                "Excel",
                "Word",
                "CSV"
            };

        static string[] CheckOptions = 
            {
                "Hiragana_to_Kanji",
                "Definition_to_Kanji",
                "Kanji_to_Hiragana_and_Definition",
                "Back"
            };

        static string[] operationOptions =
            {
                "Add_from_file",
                "Show_all",
                "Check_it",
                "Exit"
            };
        public static void Create()
        {
            //get choices
            int userChoice;
            do
            {
                //create menu
                var menu = new StringBuilder();
                menu.AppendLine("***********Choose an options below for best practice: ***********");
                for (int i = 1; i <= operationOptions.Length; i++)
                {
                    menu.AppendFormat("{0}. {1}", i, operationOptions[i - 1]);
                    menu.AppendLine();
                }
                Console.WriteLine(menu.ToString());
                Console.Write("Your choice? ");
                userChoice = int.Parse(Console.ReadLine());
                switch (userChoice)
                {
                    case 1:
                        Processs.GetDataFromExcel();
                        break;
                    case 2:
                        Processs.GetAll();
                        break;
                    case 3:
                        int subUserChoice;
                        //create submenu (List in List to store the submenu of each choice and access the list of submenus by the choice number)
                        var submenu = new StringBuilder();
                        submenu.AppendLine("\n3. Check_it?");
                        for (int i = 1; i <= operationOptions.Length; i++)
                        {
                            submenu.AppendFormat("   {0}. {1}", i, CheckOptions[i - 1]);
                            submenu.AppendLine();
                        }
                        Console.WriteLine(submenu.ToString());
                        subUserChoice = int.Parse(Console.ReadLine());
                        Processs.CheckIt(subUserChoice);
                        break;
                }
                Console.WriteLine();
            }
            while (userChoice > 0 && userChoice < 4);

            Console.WriteLine("Have a nice day!");//quotes
        }
    }
}
