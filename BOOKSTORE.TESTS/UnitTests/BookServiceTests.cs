using System;
using Moq;
using Xunit;
using BOOKSTORE.DOMAIN.Models;
using BOOKSTORE.DOMAIN.Interfaces;

namespace BOOKSTORE.TEST
{
    public class BookServiceTests
    {
        [Fact]
        public void Create_NewBook_ShouldCallSave()
        {
            // Arrange: Configura o mock para o repositório que retorna null (livro não existe)
            var mockRepository = new Mock<IRepository<Book>>();
            mockRepository.Setup(r => r.GetById(It.IsAny<int>())).Returns(() => null);

            // Cria uma instância do serviço com o repositório mockado
            var service = new BookService(mockRepository.Object);

            // Act: Chama o método Create, simulando a criação de um novo livro
            service.Create(1, "Titulo Novo", "Genero Novo", "Autor Novo", 2023);

            // Assert: Verifica se o método Save foi chamado exatamente uma vez e com os parâmetros corretos
            mockRepository.Verify(r => r.Save(It.Is<Book>(b =>
                b.Titulo == "Titulo Novo" &&
                b.Genero == "Genero Novo" &&
                b.Autor == "Autor Novo" &&
                b.AnoPublicacao == 2023
            )), Times.Once);
        }

        [Fact]
        public void Create_ExistingBook_ShouldNotCallSave()
        {
            // Arrange: Cria um livro existente
            var existingBook = new Book("Titulo Antigo", "Genero Antigo", "Autor Antigo", 2020);
            // Configura o mock para retornar o livro já existente
            var mockRepository = new Mock<IRepository<Book>>();
            mockRepository.Setup(r => r.GetById(It.IsAny<int>())).Returns(existingBook);

            // Cria a instância do serviço com o repositório mockado
            var service = new BookService(mockRepository.Object);

            // Act: Chama o método Create para atualizar o livro existente
            service.Create(1, "Titulo Atualizado", "Genero Atualizado", "Autor Atualizado", 2023);

            // Assert: Verifica que o método Save não foi chamado uma vez que o livro já existe
            mockRepository.Verify(r => r.Save(It.IsAny<Book>()), Times.Never);

        }
    }
}
