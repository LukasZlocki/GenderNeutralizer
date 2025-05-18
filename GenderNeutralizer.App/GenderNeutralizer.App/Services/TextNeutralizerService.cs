using OpenAI.Chat;

namespace GenderNeutralizer.App.Services
{
    public class TextNeutralizerService : ITextNeutralizerService
    {

        public string NeutralizeAndSummarizeCvText(string text)
        {
            var test = Testchat(text);

            return test;
        }


        private string Testchat(string textToSummarize)
        {
            string apiKey = "CONNECTIO_OPENAI_API_KEY";
            string testString = string.Empty;
            try
            {
                ChatClient client = new(model: "gpt-4o", apiKey);

                ChatCompletion completion = client.CompleteChat("Podsumuj mi to CV piszac osobno adres, osobno edukacje i osobno doswiadczenie: "+ textToSummarize);

                Console.WriteLine($"[ASSISTANT]: {completion.Content[0].Text}");
                testString = completion.Content[0].Text;
                return testString;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return testString = ex.Message;
            }
        }

    }
}
