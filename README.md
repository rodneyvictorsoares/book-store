
# 📚 BOOKSTORE

![ASP.NET Core](https://img.shields.io/badge/ASP.NET%20Core-6.0-blue)
![Entity Framework Core](https://img.shields.io/badge/Entity%20Framework%20Core-6.0-green)
![SQL Server](https://img.shields.io/badge/SQL%20Server-2019-red)
![Dependency Injection](https://img.shields.io/badge/Dependency%20Injection-✔️-orange)


## 📖 Sobre o Projeto

BOOKSTORE é uma aplicação web desenvolvida para gerenciar uma livraria online, permitindo a gestão de livros, autores e clientes. Esta solução foi construída utilizando ASP.NET Core MVC e segue uma arquitetura em camadas (DDD - **Domain Driven Design**) para promover a separação de preocupações e a reutilização de código.

## 🚀 Tecnologias Utilizadas

- **ASP.NET Core MVC**: Framework para construção de aplicações web robustas e escaláveis.
- **Entity Framework Core**: ORM para acesso a dados.
- **Dependency Injection**: Gerenciamento de dependências para promover o desacoplamento.
- **SQL Server**: Banco de dados relacional.

## 📂 Estrutura do Projeto

```plaintext
BOOKSTORE
├── BOOKSTORE.sln                   # Arquivo de solução do Visual Studio
├── BOOKSTORE.APPLICATION           # Camada de aplicação
│   ├── BOOKSTORE.APPLICATION.csproj
│   └── DI
│       └── Initializer.cs
├── BOOKSTORE.DOMAIN                # Camada de domínio
│   └── BOOKSTORE.DOMAIN.csproj
├── BOOKSTORE.IOC                   # Configurações de IoC
│   └── BOOKSTORE.IOC.csproj
├── BOOKSTORE.WEB                   # Camada web (ASP.NET Core MVC)
│   ├── BOOKSTORE.WEB.csproj
│   └── Properties
│       └── launchSettings.json
└── README.md                       # Arquivo README do projeto
```

## 🛠️ Funcionalidades

- **Gestão de Livros**: Cadastro, atualização e exclusão de livros.
- **Gestão de Autores**: Cadastro e gerenciamento de informações dos autores.
- **Gestão de Clientes**: Cadastro e gerenciamento de clientes da livraria.
- **Busca e Filtro**: Busca de livros por título, autor ou categoria.
- **Interface Amigável**: Interface web responsiva e de fácil utilização.

## 📦 Configuração do Ambiente

Para configurar o ambiente de desenvolvimento, siga os passos abaixo:

1. **Clone o repositório**:
    ```
    git clone https://github.com/rodneyvictorsoares/book-store.git
    cd bookstore
    ```

2. **Configure o banco de dados**:
    - Configure a string de conexão no arquivo \`appsettings.json\`.

3. **Restaure os pacotes NuGet**:
    ```
    dotnet restore
    ```

4. **Execute as migrações do Entity Framework**:
    ```
    dotnet ef database update
    ```

5. **Execute a aplicação**:
    ```
    dotnet run --project BOOKSTORE.WEB
    ```

## 🧪 Testes

Para executar os testes, utilize o comando:

```
dotnet test
```

## 📄 Licença

Este projeto está licenciado sob a Licença MIT. Veja o arquivo [LICENSE](LICENSE) para mais detalhes.

## 👥 Contribuidores

- Rodney Victor (https://github.com/rodneyvictorsoares) - Desenvolvedor

## 📞 Contato

Para dúvidas ou sugestões, entre em contato através do email: ordabelem@hotmail.com

---

Feito por Rodney Victor(https://github.com/rodneyvictorsoares)
