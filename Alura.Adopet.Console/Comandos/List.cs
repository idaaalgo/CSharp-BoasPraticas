using Alura.Adopet.Console.Modelos;
using Alura.Adopet.Console.Servicos;
using System.Net.Http.Headers;
using System.Net.Http.Json;

namespace Alura.Adopet.Console.Comandos
{
    [DocComando(instrucao: "list", documentacao: "adopet list comando que exibe no terminal o conteúdo cadastrado na base de dados da AdoPet.")]
    public class List : IComando
    {
        public async Task ExecutarAsync(string[] args)
        {
            await ListaDadosDaAPIAsync();
        }

        private async Task ListaDadosDaAPIAsync()
        {
            var httpListPet = new HttpClientPet();
            IEnumerable<Pet>? pets = await httpListPet.ListPetsAsync();
            System.Console.WriteLine("----- Lista de Pets importados no sistema -----");
            foreach (var pet in pets)
            {
                System.Console.WriteLine(pet);
            }
        }
    }
}
