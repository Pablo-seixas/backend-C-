
#  Ecommerce Platform - Microservices com .NET 8 e MySQL

Este projeto simula uma plataforma de e-commerce usando uma arquitetura de microsserviços. Ele é composto por três serviços principais:

-  `estoque/` — Gerencia produtos e seus estoques.
-  `vendas/` — Gerencia as vendas realizadas.
-  `api-gateway/` — Roteador central que direciona requisições para os microsserviços.
- 🔄`shared/` — Biblioteca compartilhada entre os serviços.

---

##  Serviços Já Implementados

###  Estoque
- Projeto criado com: `dotnet new webapi -n estoque`
- Conectado ao MySQL (`EcommerceEstoqueDb`) usando `Pomelo.EntityFrameworkCore.MySql`
- Migrations aplicadas com sucesso:
  ```bash
  dotnet ef migrations add InitialCreate
  dotnet ef database update
  ```
- `appsettings.json` configurado com a connection string para MySQL
- Models, Context e Startup prontos

###  Vendas
- Projeto criado com: `dotnet new webapi -n vendas`
- Conectado ao MySQL (`EcommerceVendasDb`) com `Pomelo.EntityFrameworkCore.MySql`
- Pacotes adicionais instalados:
  - `MassTransit` + `RabbitMQ` (ainda não configurados)
- Migrations aplicadas com sucesso:
  ```bash
  dotnet ef migrations add InitialCreate
  dotnet ef database update
  ```
- Models e Context configurados

###  API Gateway (em construção)
- Criado com: `dotnet new web -n api-gateway`
- YARP (Yet Another Reverse Proxy) adicionado para roteamento
- Exemplo de roteamento será configurado no `appsettings.json` e `Program.cs`

---

## Estrutura do Projeto

```
/ecommerce-platform
├── api-gateway/
│   └── ApiGateway.csproj
├── estoque/
│   └── EstoqueService.csproj
├── vendas/
│   └── VendasService.csproj
├── shared/
│   └── SharedLib.csproj
└── docker-compose.yml (ignorado por enquanto)
```

---

## 🔧 Requisitos

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- MySQL 8+
- RabbitMQ (opcional)
- Visual Studio Code ou Rider (opcional)

---


---

## Autor

Desenvolvido por **Seixas** durante um desafio prático de arquitetura com .NET.

---

🚀 Projeto em constante evolução!
