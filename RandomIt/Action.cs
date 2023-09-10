using OfficeOpenXml;

namespace RandomIt
{
    public class Action
    {
        static List<Vocabulary> jpWords = new();

        public static void GetDataFromExcel(int startWord, int endWord)
        {
            try
            {
                ExcelPackage xlPackage = new ExcelPackage(new FileInfo(@"D:\Documents\日本語\Mimikara.xlsx"));

                var myWorksheet = xlPackage.Workbook.Worksheets.ElementAt(0); //select sheet here
                var totalColumns = myWorksheet.Dimension.End.Column;

                for (int rowNum = startWord; rowNum <= endWord; rowNum++) //select starting row here
                {
                    var row = myWorksheet.Cells[rowNum, 2, rowNum, totalColumns].Select(c => c.Value == null ? string.Empty : c.Value.ToString()).ToList();
                    jpWords.Add(new Vocabulary
                    {
                        Term = row.ElementAt(0),
                        ExtraExplanation = row.ElementAt(1),
                        Definition = row.ElementAt(2)
                    });
                }
                Console.WriteLine("Loading successfully! You can now practice.");
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static void ShowAll()
        {
            if (jpWords.Count == 0) Console.WriteLine("（⁉）No data found");
            else
            {
                jpWords.ForEach(w => Console.WriteLine("Kanji: {0}, Hiragana: {1}, Definition: {2}", w.Term, w.ExtraExplanation, w.Definition));
            }
        }

        public static void CheckIt(int choice)
        {
            //Shuffle List
            Random random = new();
            for (int i = jpWords.Count - 1; i >= 0; i--)
            {
                int k = random.Next(i + 1);
                Vocabulary v = jpWords[k];
                jpWords[k] = jpWords[i];
                jpWords[i] = v;
            }

            //Print by required choice

            switch (choice)
            {
                case 3://Hiragana_to_Kanji
                    jpWords.ForEach(w =>
                    {
                        Console.Write("Hiragana: {0}", w.ExtraExplanation);
                        Thread.Sleep(8000);
                        
                        Console.WriteLine("=> Kanji: {0} \n", w.Term);
                        Thread.Sleep(1000);
                    });
                    break;
                case 1://Definition_to_Kanji_and_Hira
                    jpWords.ForEach(w =>
                    {
                        Console.Write("Definition: {0}", w.Definition);
                        Thread.Sleep(5000);

                        Console.Write("=> Hira: {0}", w.ExtraExplanation);
                        Thread.Sleep(3000);

                        Console.WriteLine("=> Kanji: {0} \n", w.Term);
                        Thread.Sleep(1000);
                    });
                    break;
                case 2://Kanji_to_Hirag_and_Definition
                    jpWords.ForEach(w =>
                    {
                        Console.Write("Kanji: {0}", w.Term);
                        Thread.Sleep(8000);

                        Console.WriteLine("=> Hiragana: {0}, Definition: {1} \n", w.ExtraExplanation, w.Definition);
                        Thread.Sleep(1000);
                    });
                    break;
                case 4:
                    break;
                default:
                    Console.WriteLine("Unsupported options");
                    break;

            }
        }
    }
}

