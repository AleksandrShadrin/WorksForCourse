using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AA.Generator.Utilities
{
    internal static class CSVUtilities
    {
        public static IEnumerable<string> GetData(string filePath)
        {
            List<string> data = new List<string>();
            try
            {
                using (StreamReader sr = File.OpenText(filePath))
                {
                    string row;
                    while ((row = sr.ReadLine()) != null)
                    {
                        data.Add(row);
                    }
                }
                return data;
            }
            catch (IOException ex)
            {
                Console.WriteLine(ex.Message);
                return data;
            }

        }
    }
}
