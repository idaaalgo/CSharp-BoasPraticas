using Alura.Adopet.Console.Servicos;

namespace Alura.Adopet.Tests
{
    public class HttpClientPetTest
    {
        [Fact]
        public async Task ListPetsAsync_DeveRetornarListaNaoVazia()
        {
            // Arrange
            var clientPet = new HttpClientPet();

            // Act
            var list = await clientPet.ListPetsAsync();

            // Assert
            Assert.NotNull(list);
            Assert.NotEmpty(list);
        }

        [Fact]
        public async Task QuandoApiEstiverFora_DeveRetornarExcecao()
        {
            //Arrange
            var clientPet = new HttpClientPet(uri: "http://localhost:1111");

            //Act + Assert
            await Assert.ThrowsAnyAsync<Exception>(() => clientPet.ListPetsAsync());
        }
    }
}