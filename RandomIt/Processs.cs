using OfficeOpenXml;

namespace RandomIt
{
    public class Processs
    {
        static List<Vocabulary> jpWords = new();

        public static void GetDataFromExcel()
        {
            try
            {
                ExcelPackage xlPackage = new ExcelPackage(new FileInfo(@"D:\Documents\日本語\Mimikara.xlsx"));

                var myWorksheet = xlPackage.Workbook.Worksheets.ElementAt(0); //select sheet here
                var totalRows = myWorksheet.Dimension.End.Row;
                var totalColumns = myWorksheet.Dimension.End.Column;

                for (int rowNum = 2; rowNum <= totalRows; rowNum++) //select starting row here
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

        public static void GetAll()
        {
            if (jpWords.Count == 0) Console.WriteLine("No data found!");
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
                case 1://Hiragana_to_Kanji
                    jpWords.ForEach(w =>
                    {
                        Console.WriteLine("Hiragana: {0}", w.ExtraExplanation);
                        Thread.Sleep(10000);
                        Console.WriteLine("Kanji: {0}", w.Term);
                        Thread.Sleep(1000);
                    });
                    break;
                case 2://Definition_to_Kanji
                    jpWords.ForEach(w =>
                    {
                        Console.WriteLine("Definition: {0}", w.Definition);
                        Thread.Sleep(10000);
                        Console.WriteLine("Kanji: {0}", w.Term);
                        Thread.Sleep(1000);
                    });
                    break;
                case 3://Kanji_to_Hiragana_and_Definition
                    jpWords.ForEach(w =>
                    {
                        Console.WriteLine("Kanji: {0}", w.Term);
                        Thread.Sleep(8000);
                        Console.WriteLine("Hiragana: {0}, Definition: {1}", w.ExtraExplanation, w.Definition);
                        Thread.Sleep(1000);
                    });
                    break;
                default:
                    Console.WriteLine("Unsupported options");
                    break;

            }
        }
    }
}

