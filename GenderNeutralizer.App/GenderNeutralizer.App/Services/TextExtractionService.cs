using GenderNeutralizer.App.Models;
using PdfDocument = UglyToad.PdfPig.PdfDocument;

namespace GenderNeutralizer.App.Services
{
    public class TextExtractionService : ITextExtractionService
    {
        public string ExtractTextFromFile(FileCV file)
        {
            // ToDo: implement parameters to extract file from given file path
            // LZ, 2023-10-02 right now is simple test to read file
            string extractedText = txtExtraction();
            return extractedText;
        }

        private string txtExtraction()
        {
            string pdfPath = @"C:\VirtualServer\GenderNeutralizer\CV_LukaszZ_ENG_07042024.pdf";
            string outputFolder = @"C:\VirtualServer\GenderNeutralizer\output";
            string extractedText = string.Empty;
            string neutralizedText = string.Empty;

            // convert pdf to jpg
            //string jpgPath = ConvertPdfToJpg(pdfPath, outputFolder);
            extractedText = ExtractTextFromPdf(pdfPath, outputFolder);

            // saving extracted text to file
            string fullOutputPath1 = Path.Combine(outputFolder, "extractedText.txt");
            bool isSucces = SaveText(extractedText, fullOutputPath1);

            // adding newvline sign when . at the end of the sentence
            string formatText = addNewlines(extractedText);
            string fullOutputPath2 = Path.Combine(outputFolder, "extractedText_newlines.txt");
            isSucces = SaveText(formatText, fullOutputPath2);

            return neutralizedText;
        }


        private string ExtractTextFromPdf(string pdfPath, string outputFolder)
        {
            using var document = PdfDocument.Open(pdfPath);
            var allText = new System.Text.StringBuilder();

            foreach (var page in document.GetPages())
            {
                allText.AppendLine(page.Text);
            }

            return allText.ToString();
        }

        private bool SaveText(string txt, string outputPath)
        {
            try
            {
                File.WriteAllText(outputPath, txt);
                return true;
            }
            catch (Exception ex)
            {
                // Handle exceptions (e.g., log the error)
                return false;
            }
        }

        // Add new line to text when .
        private string addNewlines(string text)
        {
            // Replace every ". " (period followed by space) with ".\n" (period + newline)
            // This splits sentences into new lines
            string result = text.Replace(". ", "." + Environment.NewLine);

            // Optional: Also handle if period is at the very end with no space after
            // (so no extra newline added, or if you want, add it too)
            if (result.EndsWith("."))
                result += Environment.NewLine;

            return result;
        }


    }
}
