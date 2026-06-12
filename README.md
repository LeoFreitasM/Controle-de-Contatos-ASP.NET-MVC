<div align="center">

<h1>📞 Controle de Contatos</h1>
<p><strong>Aplicação Web para Gerenciamento de Contatos com ASP.NET MVC</strong></p>

![C#](https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=csharp&logoColor=white)
![ASP.NET](https://img.shields.io/badge/ASP.NET_MVC-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)
![Entity Framework](https://img.shields.io/badge/Entity_Framework-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)
![SQL Server](https://img.shields.io/badge/SQL_Server-CC2927?style=for-the-badge&logo=microsoftsqlserver&logoColor=white)

</div>

---

## 📋 Sobre o projeto

Aplicação web desenvolvida em **C# com ASP.NET Core MVC** para gerenciamento completo de contatos. O sistema segue a arquitetura **MVC** com separação clara de responsabilidades, autenticação de usuários e acesso a dados via **Entity Framework Core**.

---

## ✨ Funcionalidades

- ✅ Cadastro de contatos
- ✅ Edição e exclusão de contatos
- ✅ Visualização e listagem de contatos
- ✅ Autenticação e login de usuários
- ✅ Controle de acesso com Filters
- ✅ Banco de dados gerenciado com Migrations (EF Core)

---

## 🛠️ Tecnologias

| Tecnologia | Uso |
|---|---|
| **C#** | Linguagem principal |
| **ASP.NET Core MVC** | Framework web |
| **Entity Framework Core** | ORM e Migrations |
| **Razor Pages** | Renderização de views |
| **SQL Server** | Banco de dados relacional |

---

## 🏗️ Estrutura do projeto

```
ControleDeContatos/
├── Controllers/      # Lógica dos controladores MVC
├── Models/           # Modelos da aplicação (classes de domínio)
├── Views/            # Interfaces de usuário (Razor)
├── Data/             # Contexto do banco de dados
├── Migrations/       # Migrations do Entity Framework
├── Repositorio/      # Lógica de acesso a dados
├── Enums/            # Enumerações do projeto
├── Filters/          # Autenticação e autorização
├── Helper/           # Classes auxiliares
└── ViewComponents/   # Componentes de visualização reutilizáveis
```

---

## 🚀 Como rodar localmente

### Pré-requisitos
- .NET 6+ instalado
- SQL Server rodando localmente
- Visual Studio ou VS Code

### Passos

```bash
# Clone o repositório
git clone https://github.com/LeoFreitasM/Controle-de-Contatos-ASP.NET-MVC.git

# Acesse a pasta do projeto
cd Controle-de-Contatos-ASP.NET-MVC/ControleDeContatos
```

Configure a string de conexão em `appsettings.json`:

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=localhost;Database=ControleContatos;Trusted_Connection=True;"
}
```

```bash
# Aplique as migrations
dotnet ef database update

# Execute a aplicação
dotnet run
```

> A aplicação iniciará em: `https://localhost:7000` (ou porta configurada)

---

<div align="center">

Desenvolvido por **Leonardo Freitas** · [LinkedIn](https://linkedin.com/in/leonardofreitasdev) · [GitHub](https://github.com/LeoFreitasM)

</div>
