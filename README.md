
# Register Cards

Realizando teste o mais simples e objetivo possível. Levando em conta somente o que foi pedido e sem inserir muitas perfumarias.
Usar o mínimo de pacotes possiveis para explicitar meu próprio código e deixar tudo mais leve e sem dependências. Sem usar pacotes de mapeamento, notificações, mediatr ou messagebrocker. 

usei minimalApi por ser muito mais exuto e para esse projeto pequeno seria um cenário ideal para usa-la

Banco de dados em memoria com EFCore



## Documentação da API

#### Cadastro de client

```http
  POST /api/v1/client
```

| Parâmetro   | Tipo       | Descrição                           |
| :---------- | :--------- | :---------------------------------- |
| `name` | `string` | Obrigatório. |
| `cpf` | `string` | Obrigatório. Necessário ser cpf válido |

#### Retorna um client

```http
  GET /api/v1/client/${id}
```

| Parâmetro   | Tipo       | Descrição                                   |
| :---------- | :--------- | :------------------------------------------ |
| `id`      | `string` | Obrigatório. O ID do item que você quer |

#### Retorna todos client (sem paginação)

```http
 GET /api/v1/client
```

#### Cadastro de cartão de crédito e geração do token

```http
  POST /api/v1/{clientId}/credit-card
```

| Parâmetro   | Tipo       | Descrição                           |
| :---------- | :--------- | :---------------------------------- |
| `number` | `string` | Obrigatório. numero do cartão |
| `securityCode` | `short` | Obrigatório. codigo de 4 dígitos |

Dado um CVV impar, o token será gerado usando o MD5.

Dado um CVV par, o token será gerado usando a rotação  circular dos 4 últimos digitos do cartão.


## Rodando os testes

Para rodar os testes, rode o seguinte comando

```bash
  dotnet test
```

## Execução

Use o arquivo de coleção do postmand disponibilizado na raiz do projeto para execução da API e devidos novos testes
RegisterCard_collection.json
