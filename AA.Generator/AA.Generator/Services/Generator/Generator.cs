using AA.Generator.Services.Render;
using AA.Generator.Utilities;
using System.Text;

namespace AA.Generator.Services.Generator
{
    public class Generator : IGenerator
    {
        private readonly IRender _render;
        private Random random = new Random();
        public int RowWidth { get; set; } = 80;
        public Generator(IRender render)
        {
            _render = render;
        }
        private string GetRandomData(IEnumerable<string> data)
        {
            if (data.Count() == 0)
                return "Aleksandr";
            var rndPos = random.Next(0, data.Count());
            return data.ElementAt(rndPos);
        }
        private string GetRandomName()
        {
            string filePath = Path.Combine("CSV", "Names.csv");
            var data = CSVUtilities.GetData(filePath);
            return GetRandomData(data).ToUpperInvariant();
        }
        private string GetRandomSurname()
        {
            string filePath = Path.Combine("CSV", "Surnames.csv");
            var data = CSVUtilities.GetData(filePath);
            return GetRandomData(data).ToUpperInvariant();
        }

        public void Generate()
        {
            var sb = new StringBuilder();
            sb.AppendLine("Report".AlignByCenter(RowWidth));
            sb.AppendLine();
            sb.AppendLine($"{GetRandomName()} {GetRandomSurname()}".AlignByCenter(RowWidth));

            var words = LoremNET.Lorem.Words(250);
            sb.AppendLine();
            int i = 0;
            for (i = 0; i < words.Length / RowWidth; i++)
            {
                sb.AppendLine(words.Substring(i * RowWidth, RowWidth));
            }
            sb.AppendLine(words.Substring(i * RowWidth));
            sb.AppendLine();
            sb.AppendLine();
            sb.AppendLine();
            sb.AppendLine(String.Format(new String("{0," + RowWidth + "}"), DateTime.UtcNow.ToString()));
            _render.Render(sb.ToString());
        }
    }
}
