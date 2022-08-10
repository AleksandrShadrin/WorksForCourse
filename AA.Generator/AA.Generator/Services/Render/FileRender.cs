using System.Text.RegularExpressions;

namespace AA.Generator.Services.Render
{
    public class FileRender : IRender
    {
        public string ReportsPath { get; set; } = Path.Combine(".", "reports");
        private readonly Regex _regex;
        public FileRender()
        {
            _regex = new("^report-[0-9]+");
        }
        private int CreateFileNumber()
        {
            var fileNumbers = GetNumbersOfFiles();

            int newNumber = 0;
            if (fileNumbers.Count() > 0)
            {
                newNumber = fileNumbers.Max() + 1;
            }

            return newNumber;
        }
        private IEnumerable<int> GetNumbersOfFiles()
        {
            if (Directory.Exists(ReportsPath) == false)
                Directory.CreateDirectory(ReportsPath);

            var fileNumbers = Directory.GetFiles(ReportsPath)
                .Select(filePath => filePath.Split(Path.DirectorySeparatorChar).Last())
                .Where(file => _regex
                .IsMatch(file))
                .Select(file =>
                {
                    var fileNumber = Regex.Match(file.Split('-')[1], @"\d+").Value;

                    if (String.IsNullOrEmpty(fileNumber))
                    {
                        return 0;
                    }
                    else
                    {
                        return Convert.ToInt32(fileNumber);
                    }
                });
            return fileNumbers;
        }
        public void Render(string text)
        {
            var newNumber = CreateFileNumber();
            using (StreamWriter fs = File.CreateText($"{Path.Combine(ReportsPath, $"report-{newNumber}.txt")}"))
            {
                fs.Write(text);
            }
        }
    }
}
