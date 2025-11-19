using System.Net.Http.Headers;
using System.Net.Http.Json;
using Alura.Adopet.Console;

// na linha abaixo cria-se uma instância de HttpClient para consumir API Adopet.
Console.ForegroundColor = ConsoleColor.Green;
try
{
    string comando = args[0].Trim();
    string caminhoDoArquivoDeImportacao = args[1];
    switch (comando)
    {
        case "import":
            var import = new Import();
            await import.ImportacaoArquivoPetAsync(caminhoDoArquivoDeImportacao: args[1]);
            break;
        case "help":
            // se não passou mais nenhum argumento mostra help de todos os comandos
            var help = new Help();
            help.ExibeDocumentacao(args);
            break;
        case "show":
            string caminhoDoArquivoASerExibido = args[1];
            var show = new Show();
            show.ExibeConteudoArquivo(caminhoDoArquivoASerExibido);
            break;
        case "list":
            var list = new List();
            await list.ListaDadosDaAPIAsync();
            break;
        default:
            // exibe mensagem de comando inválido
            Console.WriteLine("Comando inválido!");
            break;
    }
}
catch (Exception ex)
{
    // mostra a exceção em vermelho
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine($"Aconteceu um exceção: {ex.Message}");
}
finally
{
    Console.ForegroundColor = ConsoleColor.White;
}