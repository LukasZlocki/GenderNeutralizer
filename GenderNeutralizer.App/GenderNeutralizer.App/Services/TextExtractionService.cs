using GenderNeutralizer.App.Models;
using System.Runtime.Serialization;
using PdfDocument = UglyToad.PdfPig.PdfDocument;

namespace GenderNeutralizer.App.Services
{
    public class TextExtractionService : ITextExtractionService
    {
        private readonly ITextNeutralizerService _textNeutralizerService;
        private readonly ICandidateService _candidateService;

        public TextExtractionService(ITextNeutralizerService textNeutralizerService, ICandidateService candidateService)
        {
            _textNeutralizerService = textNeutralizerService;
            _candidateService = candidateService;
        }


        public async Task<bool> NeutralizeCandidateCv(string filePath, int candidateId)
        {
            // ToDo: implement parameters to extract file from given file path
            // LZ, 2023-10-02 right now is simple test to read file
            string extractedText = txtExtraction(filePath);

            // update camdidate in db with extracted raw text
            bool isCandidateUpdated = await _candidateService.UpdateCandidateRawTxtCv(extractedText, candidateId);

            // ToDo : neutralize text by AI agents
            string neutralizedText = txtAiNeutralization(extractedText);

            // save neutralized text to db
            bool isCandidateNeutralized = await _candidateService.UpdateCandidateNeutralizedTxt(neutralizedText, candidateId);

            if (!isCandidateUpdated && !isCandidateNeutralized)
            {
                // ToDo : Handle error
                //throw new Exception("Failed to update candidate with neutralized text.");
                return false;
            }

            return true;
        }

        private string txtExtraction(string filePath)
        {
            //string pdfPath = @"C:\VirtualServer\GenderNeutralizer\textToExtract.pdf";
            string outputFolder = @"C:\VirtualServer\GenderNeutralizer\output";
            string extractedText = string.Empty;
            string neutralizedText = string.Empty;

            // Step 1: Extracting text from cv in pdf format 
            extractedText = ExtractTextFromPdf(filePath, outputFolder);

            return extractedText;

            /*
            // Step 2: Saving extracted raw text to file
            // saving extracted text to file
            string fullOutputPath1 = Path.Combine(outputFolder, "extractedText.txt");
            bool isSucces = SaveText(extractedText, fullOutputPath1);

            // Step 3: Add new lines to extracted and save text.
            // adding newvline sign when . at the end of the sentence
            string formatText = addNewlines(extractedText);
            string fullOutputPath2 = Path.Combine(outputFolder, "extractedText_newlines.txt");
            isSucces = SaveText(formatText, fullOutputPath2);

            // Step 4: Connect to AI API and neutralize the text
            // ToDo : Code cnnection to AI API
            // ToDo : Code sending data to API and getting it back
            string neutralizedTxt = _textNeutralizerService.NeutralizeAndSummarizeCvText(formatText);
            // ToDo : save neutralized text here
            string fullOutputPath3 = Path.Combine(outputFolder, "extractedText_AI.txt");
            isSucces = SaveText(neutralizedTxt, fullOutputPath3);

            return neutralizedText;
            */
        }

        private string txtAiNeutralization(string txtToBeNeutralized)
        {
            // Step 4: Connect to AI API and neutralize the text
            string neutralizedTxt = _textNeutralizerService.NeutralizeAndSummarizeCvText(txtToBeNeutralized);
            /*
            // ToDo : save neutralized text here
            string fullOutputPath3 = Path.Combine(outputFolder, "extractedText_AI.txt");
            isSucces = SaveText(neutralizedTxt, fullOutputPath3);
            */
            return neutralizedTxt;
        }


        /// <summary>
        /// Extracts text from a PDF file using PdfPig library.
        /// </summary>
        /// <param name="pdfPath"></param>
        /// <param name="outputFolder"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Saves the extracted text to a file.
        /// </summary>
        /// <param name="txt"></param>
        /// <param name="outputPath"></param>
        /// <returns></returns>
        private bool SaveText(string txt, string outputPath)
        {
            try
            {
                File.WriteAllText(outputPath, txt);
                return true;
            }
            catch (Exception ex)
            {
                // ToDo : Handle exceptions (e.g., log the error)
                return false;
            }
        }


        /// <summary>
        /// Adds new lines to the text based on certain conditions.
        /// </summary>
        /// <param name="text">Text to be new lines added</param>
        /// <returns>string with text with new lines after certain condition</returns>
        private string addNewlines(string text)
        {
            // Replace every ". " (period followed by space) with ".\n" (period + newline)
            // This splits sentences into new lines
            string result = text.Replace(". ", "." + Environment.NewLine);

            // Replace ": " with ":\n" to split clauses after colons
            result = result.Replace(": ", ":" + Environment.NewLine);

            // Optional: Also handle if period is at the very end with no space after
            // (so no extra newline added, or if you want, add it too)
            if (result.EndsWith("."))
                result += Environment.NewLine;

            // Optional: Handle colons at the end of the text
            if (result.EndsWith(":"))
                result += Environment.NewLine;

            return result;
        }

 
    }
}
