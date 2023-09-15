using OpenAI_API;
using ScreenSound.Modelos;

namespace ScreenSound.Menus;

internal class MenuRegistrarBanda : Menu
{
    public override void Executar(Dictionary<string, Banda> bandasRegistradas)
    {
        base.Executar(bandasRegistradas);
        ExibirTituloDaOpcao("Registro das bandas");
        
        Console.Write("Digite o nome da banda que deseja registrar: ");
        string nomeDaBanda = Console.ReadLine()!;
        Banda banda = new Banda(nomeDaBanda);

        OpenAIAPI OpenAIClient = new OpenAIAPI("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");

        var chat = OpenAIClient.Chat.CreateConversation();

        chat.AppendSystemMessage($"Resuma a banda {nomeDaBanda} em um parágrafo. Adote um estilo informal.\n");

        string resposta = chat.GetResponseFromChatbotAsync().GetAwaiter().GetResult();
        banda.resumo = resposta;

        bandasRegistradas.Add(nomeDaBanda, banda);
        
        Console.WriteLine($"A banda {nomeDaBanda} foi registrada com sucesso!");
        Console.WriteLine("\nDigite uma tecla para votar ao menu principal");
        Console.ReadKey();
        Console.Clear();

    }
}
