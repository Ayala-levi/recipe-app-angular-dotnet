# 🍴 Recipe App – Interactive Recipe Management System

An intuitive recipe management system that allows users to view, add, edit, and share recipes.  
The application was developed using modern technologies:

- 💻 **Frontend** – Angular  
- 🖥️ **Backend** – ASP.NET Core Web API (4-layer architecture)  
- 🗄️ **Database** – SQL Server

---

## ✨ Main Features

### 👨‍🍳 Users

- Login and registration  
- Display of the logged-in user's name in the Navbar  
- Role-based permissions – regular user vs. admin

### 📄 Home Page

- Card view for all recipes  
- Clicking a recipe card shows:  
  - Full recipe details  
  - Action buttons: **Download**, **Print**, **Share**, **Copy**

### 🧑‍💼 Admin Only – Add Recipe

- Full form for adding a new recipe, including:  
  - Recipe name  
  - Short description  
  - Image upload  
  - Preparation time  
  - Number of servings  
  - Difficulty level  
  - Add ingredients and quantities  
  - Preparation instructions

---

## 🛠️ Technologies

### 🔗 Backend – ASP.NET Core Web API

**4-layer architecture**:

- **API Layer** – Exposes the API to external clients, handles HTTP requests, dependency injection  
- **Service Layer** – Implements business logic according to defined interfaces  
- **Data Layer** – Database access using EF Core, repository implementations  
- **Core Layer** – Contracts: Entities, Interfaces, DTOs

### 🧑‍🎨 Frontend – Angular

Built using **Angular** as a modern Single Page Application (SPA), with use of HTTP Client, Routing, and Reactive Forms.

#### Key Technologies:

- Angular CLI  
- TypeScript  
- Bootstrap  
- Use of services and logic separation into components  
- Responsive and accessible UI

### 🗃️ Database – SQL Server

- `Users` – Users table  
- `Recipes` – Recipes table  
- `Ingredients` – Ingredients table  
- `RecipeIngredients` – Join table for many-to-many relationship between recipes and ingredients

---

### 🧪 Testing & Documentation

- API testing with **Postman** and **Swagger UI**  
- Use of **DTOs** for secure data transfer between layers
