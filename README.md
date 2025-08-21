#  Estoque API - Manual de Testes via cURL

Este projeto é uma API para gerenciamento de produtos em estoque. Abaixo estão os comandos cURL para testar os principais endpoints.

---

## Iniciar o servidor

Certifique-se de estar na raiz do projeto e execute:

```bash
dotnet run
```

---

##  Listar todos os produtos

```bash
curl http://localhost:5185/api/produto
```

---

##  Buscar produto por ID

```bash
curl http://localhost:5185/api/produto/1
```

---

## Adicionar novo produto

```bash
curl -X POST http://localhost:5185/api/produto \
     -H "Content-Type: application/json" \
     -d '{"nome":"Produto A", "quantidade":100, "preco":99.99}'
```

---

## Baixar (remover do estoque) unidades de um produto

```bash
curl -X PUT "http://localhost:5185/api/produto/1/baixar?quantidade=3"
```

---

##  Verificar novamente o produto

```bash
curl http://localhost:5185/api/produto/1
```

---

##  Notas

- A API precisa estar em execução para os comandos funcionarem ().
- A porta usada é `5185`, altere se necessário.
- Verifique o ID retornado após criar um produto, pois ele pode variar.

---

## Exemplo completo (teste rápido)

```bash
curl -X POST http://localhost:5185/api/produto \
     -H "Content-Type: application/json" \
     -d '{"nome":"Camiseta", "quantidade":30, "preco":59.90}'

curl http://localhost:5185/api/produto

curl -X PUT "http://localhost:5185/api/produto/1/baixar?quantidade=5"

curl http://localhost:5185/api/produto/1
```

