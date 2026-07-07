# Controle de Gastos Residenciais

Sistema desenvolvido para controle financeiro residencial, permitindo cadastro de pessoas e gerenciamento de receitas e despesas.

## Tecnologias utilizadas

### Backend
- C#
- .NET 8
- ASP.NET Core Web API
- Entity Framework Core
- SQLite
- Swagger

### Frontend
- React
- TypeScript
- Axios
- Vite
- CSS

---

## Funcionalidades

### Pessoas

- Cadastro de pessoas
- Listagem de pessoas
- Exclusão de pessoas

### Transações

- Cadastro de receitas
- Cadastro de despesas
- Associação de transações com pessoas
- Listagem de movimentações
- Exclusão de transações

### Dashboard

- Total de receitas
- Total de despesas
- Cálculo automático do saldo

---

## Estrutura do projeto

projeto_estagio

├── MinhaApi
│ ├── Controllers
│ ├── Models
│ ├── Data
│ └── Banco SQLite
│
└── MinhaApp
├── src
├── App.tsx
└── App.css


---

## Como executar o projeto

### Backend

Entrar na pasta:


cd MinhaApi


Executar:


dotnet run


A API ficará disponível em:


http://localhost:5142


Swagger:


http://localhost:5142/swagger


---

### Frontend

Entrar na pasta:


cd MinhaApp


Instalar dependências:


npm install


Executar:


npm run dev


Aplicação:


http://localhost:5173


---

## Exemplos

Cadastro de pessoa:

```json
{
 "nome":"Eduardo",
 "idade":30
}

Cadastro de transação:

{
 "descricao":"Mercado",
 "valor":150,
 "tipo":"Despesa",
 "pessoaId":1
}
Autor

Eduardo Joly Castellini da Silva