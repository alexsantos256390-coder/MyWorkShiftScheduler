# 🚀 WorkShift Scheduler API

API backend para gerenciamento de escalas de funcionários, desenvolvida utilizando **.NET** com foco em **DDD (Domain-Driven Design)**.

---

## 📌 Funcionalidades

* ✅ Criar escala com **mínimo de 5 e máximo de 10 funcionários**
* ✅ Geração automática de turnos:

  * 🕙 10:00 às 18:00
  * 🕒 15:00 às 23:00
* ✅ Listar escalas com funcionários e turnos
* ✅ Buscar escala por ID
* ✅ Deletar Escala Junto Com Funcionarios

---

## 🧠 Regras de Negócio

* Cada escala deve ter entre **5 e 10 funcionários**
* Turnos são **fixos e validados no domínio**
* Funcionários recebem turnos automaticamente
* Regras centralizadas nas **entities (DDD)**

---

## 🛠️ Tecnologias

* .NET
* ASP.NET Core
* Entity Framework Core
* SQL Server
* FluentValidation

---

## 📂 Estrutura do Projeto

* `Domain` → Entidades e regras de negócio
* `Application` → UseCases
* `Infrastructure` → Banco de dados
* `API` → Controllers

---

## ▶️ Como rodar o projeto

### 1. Clonar repositório

```bash
git clone https://github.com/seu-usuario/workshift-scheduler-api.git
```

---

### 2. Configurar banco

No `appsettings.json`:

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=.;Database=WorkShiftDB;Trusted_Connection=True;TrustServerCertificate=True"
}
```

---

### 3. Rodar migrations

```bash
Add-Migration InitialCreate
Update-Database
```

---

### 4. Rodar API

```bash
dotnet run
```

---

### 5. Acessar Swagger

```
https://localhost:xxxx/swagger
```

---

## 📌 Exemplo de requisição

{
  "dataInicio": "2026-03-19T00:00:00Z",
  "dataFim": "2026-03-19T00:00:00Z",
  "nomesFuncionarios": [
    "João",
    "Maria",
    "Carlos",
    "Ana",
    "pedro"
  ]
}

## 📈 Melhorias futuras
* 🔹 Autenticação (JWT)
* 🔹 Frontend

---

## 👨‍💻 Autor

Desenvolvido por Alex 🚀
