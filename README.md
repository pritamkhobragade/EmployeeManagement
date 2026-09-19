# Employee Management System

A web-based Employee Management System developed using ASP.NET MVC, C#, Entity Framework, and SQL Server.

The application provides employee management, department management, authentication, dashboard statistics, and role-based access.

---

## 🚀 Features

### 🔐 Authentication
- User Login
- Logout
- Session-based authentication
- Protected Dashboard
- Invalid login error message
- Password validation

### 📊 Dashboard
- Total Employees
- Active Employees
- Inactive Employees
- Total Salary
- Active Employee Percentage
- Inactive Employee Percentage
- Department Count
- Quick Actions

### 👨‍💼 Employee Management
- Add Employee
- Edit Employee
- Delete Employee
- View Employee
- Search Employee
- Employee Status
- Employee Salary
- Employee Department

### 🏢 Department Management
- Add Department
- Edit Department
- Delete Department
- View Department

---

## 🛠️ Technologies Used

- C#
- ASP.NET MVC
- Entity Framework
- SQL Server
- HTML5
- CSS3
- JavaScript
- jQuery
- AJAX
- Bootstrap
- LINQ

---

## 📁 Project Structure

```text
EmployeeManagementSystem
│
├── Controllers
│   ├── AccountController.cs
│   ├── DashboardController.cs
│   ├── EmployeeController.cs
│   └── DepartmentController.cs
│
├── Models
│   ├── User.cs
│   ├── Role.cs
│   ├── Employee.cs
│   └── Department.cs
│
├── Views
│   ├── Account
│   │   └── Login.cshtml
│   │
│   ├── Dashboard
│   │   └── Index.cshtml
│   │
│   ├── Employee
│   │   ├── Index.cshtml
│   │   ├── Create.cshtml
│   │   └── Edit.cshtml
│   │
│   └── Department
│       ├── Index.cshtml
│       ├── Create.cshtml
│       └── Edit.cshtml
│
├── Content
├── Scripts
├── App_Start
├── Web.config
└── EmployeeManagementSystem.sln
