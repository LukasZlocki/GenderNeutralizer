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
            string apiKey = "add open ai key here";
            string testString = string.Empty;
            try
            {
                ChatClient client = new(model: "gpt-4o", apiKey);

                ChatCompletion completion = client.CompleteChat
                    ("Podsumuj mi to CV wypisując tylko i wyłącznie osobno edukacje, osobno doswiadczenie zawodowe, osobno kursy i szkolenia, osobno umiejętności, osobno zainteresowania/hobby. Nic wiecej nie wypisuj. " +
                    "dodatkowo tekst zanonimizuj tak bym nie wiedział czy to kobieta czy mężczyzna. pracuj na tekście poniżej:"+ textToSummarize);

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
