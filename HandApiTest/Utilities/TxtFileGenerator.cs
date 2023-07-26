using System;
using System.IO;
using System.Text.RegularExpressions;

namespace HandApiTest.Utilities
{
    public static class TxtFileGenerator
    {
        public static string GenerateTxtFile(string text, string labCode)
        {
            string outputPath = "C:\\Users\\vince.chiu\\Documents\\VinceChiu\\API_ARM\\_txt";
            string timestamp = DateTime.Now.ToString("yyyy-MM-dd'T'HH:mm:ss");
            string numericTimestamp = Regex.Replace(timestamp, @"\D", "");
            string fileName = labCode + "CDR" + numericTimestamp + GenerateRandomNumericChar();
            string filePath = Path.Combine(outputPath, fileName + ".txt");
            int fileNumber = 1;
            
            while (File.Exists(filePath))
            {
                filePath = Path.Combine(outputPath, fileName + "_" + fileNumber + ".txt");
                fileNumber++;
            }

            using (StreamWriter writer = new StreamWriter(filePath))
            {
                writer.Write(text);
            }

            return Path.GetFileName(filePath);
        }

        private static string GenerateRandomNumericChar()
        {
            Random random = new Random();
            int randomNumber = random.Next(0, 100000000); // Generate a random number between 0 and 99999999
            
            return randomNumber.ToString("D8"); // Format the number as an 8-digit string with leading zeros if necessary
        }
    }
}