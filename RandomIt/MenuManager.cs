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
                "Definition_to_Kanji_and_Hira",
                "Kanji_to_Hirag_and_Definition",
                "Hiragana_to_Kanji",
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
                Console.Write("(❓) Your choice: ");
                userChoice = int.Parse(Console.ReadLine());
                switch (userChoice)
                {
                    case 1:
                        Console.Write("Please insert the two limitations of the list (format:[value1] [value2]): ");
                        string? input = Console.ReadLine();

                        string[] values =
                            input == null ? Array.Empty<string>() : input.Split(' ');
                        Array.Sort(values);

                        int startRow, endRow;

                        if (int.TryParse(values[0], out startRow) & int.TryParse(values[1], out endRow))
                        {
                            Action.GetDataFromExcel(startRow + 1, endRow + 1);
                        }
                        else
                        {
                            Console.WriteLine("(⁉) Invalid input");
                        }

                        
                        break;
                    case 2:
                        Action.ShowAll();
                        break;
                    case 3:
                        int subUserChoice;
                        //create submenu (List in List to store the submenu of each choice and access the list of submenus by the choice number)
                        var submenu = new StringBuilder();
                        submenu.AppendLine("\n（❓）3. Check_it");
                        for (int i = 1; i <= operationOptions.Length; i++)
                        {
                            submenu.AppendFormat("   {0}. {1}", i, CheckOptions[i - 1]);
                            submenu.AppendLine();
                        }
                        Console.WriteLine(submenu.ToString());
                        subUserChoice = int.Parse(Console.ReadLine());
                        Action.CheckIt(subUserChoice);
                        break;
                }
                Console.WriteLine();
            }
            while (userChoice > 0 && userChoice < 4);

            Console.WriteLine("Have a nice day!");//quotes
        }
    }
}
