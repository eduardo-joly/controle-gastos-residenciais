# 🏠 Controle de Gastos Residenciais

[![Dotnet Version](https://img.shields.io/badge/.NET-8.0-blueviolet?style=for-the-badge&logo=dotnet)](https://dotnet.microsoft.com/)
[![React Version](https://img.shields.io/badge/React-18-blue?style=for-the-badge&logo=react)](https://react.dev/)
[![TypeScript](https://img.shields.io/badge/TypeScript-5-blue?style=for-the-badge&logo=typescript)](https://www.typescriptlang.org/)
[![SQLite](https://img.shields.io/badge/SQLite-3-lightgrey?style=for-the-badge&logo=sqlite)](https://www.sqlite.org/)
[![Deploy Vercel](https://img.shields.io/badge/Deploy-Vercel-success?style=for-the-badge&logo=vercel)](https://controle-gastos-residenciais-ruddy.vercel.app)
[![API Railway](https://img.shields.io/badge/API-Railway-blue?style=for-the-badge&logo=railway)](https://controle-gastos-residenciais-production.up.railway.app/swagger/index.html)

Um sistema completo de controle financeiro residencial projetado para simplificar a gestão de receitas e despesas familiares. O projeto foi desenvolvido com uma arquitetura moderna dividida em uma API robusta no backend e uma aplicação rica e interativa no frontend.

---

## 🚀 Funcionalidades

### 👥 Gestão de Pessoas
- **Cadastro Completo:** Registro de novos membros da residência (nome e idade).
- **Visualização Dinâmica:** Listagem em tempo real de todas as pessoas cadastradas.
- **Exclusão de Registros:** Remoção rápida de pessoas do banco de dados.

### 💰 Controle de Transações
- **Receitas & Despesas:** Lançamento detalhado de entradas e saídas de valores.
- **Associação Inteligente:** Cada transação é obrigatoriamente vinculada a uma pessoa cadastrada.
- **Histórico Completo:** Listagem tabular com detalhes de descrição, valor, tipo e responsável.

### 📊 Dashboard e Métricas
- **Resumo Financeiro:** Cartões informativos com o total acumulado de Receitas, Despesas e o Saldo Geral atualizado dinamicamente no frontend.

---

## 🛠️ Tecnologias Utilizadas

### **Backend**
*   **Linguagem & Plataforma:** C# com .NET 8.
*   **Framework Web:** ASP.NET Core Web API.
*   **Persistência de Dados:** Entity Framework Core (EF Core) com SQLite.
*   **Documentação da API:** Swagger (OpenAPI).

### **Frontend**
*   **Biblioteca Principal:** React.js com TypeScript para tipagem estática e segurança de código.
*   **Gerenciador de Build:** Vite (rápido e leve).
*   **Comunicação HTTP:** Axios para chamadas à API.
*   **Estilização:** CSS customizado (sem frameworks externos para maior fidelidade de layout).

---

## 📂 Estrutura do Projeto

```text
controle-gastos-residenciais
├── MinhaApi/                       # API Backend (.NET 8)
│   ├── Controllers/                # Controllers da API (Endpoints)
│   ├── Data/                       # Contexto do Banco de Dados (EF Core)
│   ├── Migrations/                 # Migrações geradas pelo EF Core
│   ├── Models/                     # Classes de modelo (Pessoa, Transacao)
│   ├── Program.cs                  # Configuração de inicialização e middlewares
│   └── MinhaApi.csproj             # Arquivo de projeto do C#
│
└── MinhaApp/                       # Frontend SPA (React + TypeScript)
    ├── src/
    │   ├── api/                    # Configurações do Axios
    │   ├── App.css                 # Estilos específicos da aplicação
    │   ├── App.tsx                 # Componente principal e lógica da aplicação
    │   ├── index.css               # Estilos globais e reset
    │   └── main.tsx                # Ponto de entrada do React
    ├── package.json                # Dependências e scripts do Node.js
    └── vite.config.ts              # Configuração do Vite
```

---

## 🔌 API Endpoints

Abaixo estão descritos os principais endpoints expostos pela API backend:

### **Pessoas** (`/api/Pessoas`)
| Método | Endpoint | Descrição | Exemplo de Payload |
| :--- | :--- | :--- | :--- |
| **GET** | `/api/Pessoas` | Retorna a lista de todas as pessoas | - |
| **POST** | `/api/Pessoas` | Cadastra uma nova pessoa | `{"nome": "Eduardo", "idade": 30}` |
| **DELETE** | `/api/Pessoas/{id}` | Exclui uma pessoa pelo ID | - |

### **Transações** (`/api/Transacoes`)
| Método | Endpoint | Descrição | Exemplo de Payload |
| :--- | :--- | :--- | :--- |
| **GET** | `/api/Transacoes` | Retorna a lista de transações com os nomes das pessoas | - |
| **POST** | `/api/Transacoes` | Cria uma nova transação (Receita/Despesa) | `{"descricao": "Mercado", "valor": 150.00, "tipo": "Despesa", "pessoaId": 1}` |
| **PUT** | `/api/Transacoes/{id}` | Atualiza dados de uma transação existente | `{"descricao": "Mercado", "valor": 160.00, "tipo": "Despesa", "pessoaId": 1}` |
| **DELETE** | `/api/Transacoes/{id}` | Remove uma transação pelo ID | - |

### **Totais por Pessoa** (`/api/Totais`)
| Método | Endpoint | Descrição | Exemplo de Retorno |
| :--- | :--- | :--- | :--- |
| **GET** | `/api/Totais` | Retorna o resumo de gastos e receitas por pessoa | `[{"pessoa": "Eduardo", "totalReceitas": 2500, "totalDespesas": 150, "saldo": 2350}]` |

---

## ⚙️ Como Executar o Projeto

### Pré-requisitos
*   [.NET 8 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/8.0) instalado.
*   [Node.js](https://nodejs.org/) (versão LTS recomendada).

---

### **1. Executando o Backend**

1. Navegue até a pasta do backend:
   ```bash
   cd MinhaApi
   ```
2. Execute a aplicação (as migrações do SQLite serão aplicadas e o banco criado caso não exista):
   ```bash
   dotnet run
   ```
3. A API estará ativa em: `http://localhost:5142`
4. Você pode acessar a interface interativa do Swagger em: `http://localhost:5142/swagger`

---

### **2. Executando o Frontend**

1. Navegue até a pasta do frontend:
   ```bash
   cd MinhaApp
   ```
2. Instale as dependências necessárias:
   ```bash
   npm install
   ```
3. Inicie o servidor de desenvolvimento do Vite:
   ```bash
   npm run dev
   ```
4. Abra o navegador no endereço indicado (geralmente `http://localhost:5173`).

---

## 🤝 Autor

Desenvolvido com dedicação por:
* **Eduardo Joly Castellini da Silva**
* **GitHub:** [@eduardo-joly](https://github.com/eduardo-joly)