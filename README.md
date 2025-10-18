# EF Core Multi-Provider

A .NET 9.0 web API project demonstrating multi-database provider support with Entity Framework Core, currently configured for SQL Server and PostgreSQL.

## ✅ Approaches to Support Multiple Database Providers in EF Core

When designing an application that should work with different databases
(e.g., SQL Server, PostgreSQL), EF Core offers **two main strategies**.
Each strategy affects how you structure your DbContext and where you store your migrations.

---

### ✅ 1️⃣ Single `DbContext` + Multiple **Migrations Projects** ✅

- You define **one shared `DbContext`** that represents your domain model.
- You create **a separate migrations project (or folder) for each provider**.
  - Example: `Migrations.SqlServer`, `Migrations.PostgreSQL`
- Each project contains its provider-specific migrations.
- At runtime, you load the correct migrations assembly based on the active provider.

**✔ Advantages**
- Clean and maintainable structure  
- No duplication of domain logic  
- Works perfectly with Clean Architecture  
- Each provider has its own history table and SQL


🔗 **Example project (Single DbContext + Multi Migrations Projects):**  
`👉 https://github.com/your-repo-url-here`
---

### ✅ 2️⃣ Multiple `DbContext` Types + Single **Migrations Project**

- You create a different `DbContext` **for each provider**  
  - Example: `SqlServerDbContext` and `PostgreSqlDbContext`
- All migrations are stored in **one shared project**
- Each context generates its own migration history inside the same project

**✔ Advantages**
- Easier to set up initially


🔗 **Example project (Multi DbContext + Single Migrations Project):**  
`👉 https://github.com/your-repo-url-here`


