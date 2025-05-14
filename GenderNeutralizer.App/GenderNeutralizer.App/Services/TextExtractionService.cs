using GenderNeutralizer.App.Models;
using PdfiumViewer;
using System;
using System.Drawing;
using System.Text;
using Tesseract;
using System.Drawing.Imaging;



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
            string pdfPath = @"C:\VirtualServer\GenderNeutralizer\textToExtract.pdf";
            string tessDataPath = @"./tessdata"; // Should contain 'eng.traineddata', etc.
            StringBuilder extractedText = new StringBuilder();

            var test = PdfDocument.Load(pdfPath);


            using (var pdfDoc = PdfDocument.Load(pdfPath))
            using (var ocrEngine = new TesseractEngine(tessDataPath, "eng", Tesseract.EngineMode.Default))
            {
                for (int i = 0; i < pdfDoc.PageCount; i++)
                {
                    using (var image = pdfDoc.Render(i, 300, 300, true))
                    using (var pix = PixConverter.ToPix((Bitmap)image))
                    using (var page = ocrEngine.Process(pix))
                    {
                        extractedText.AppendLine(page.GetText());
                    }
                }
            }

            string ocrResult = extractedText.ToString();
            Console.WriteLine("Extracted Text:\n" + ocrResult);

            return ocrResult;
        }


        public static class PixConverter
        {
            public static Pix ToPix(Bitmap bitmap)
            {
                using (var stream = new MemoryStream())
                {
                    bitmap.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
                    stream.Position = 0;
                    return Pix.LoadFromMemory(stream.ToArray());
                }
            }
        }

    }
}
