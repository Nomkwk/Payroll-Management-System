# 💼 Payroll Management System

A **Payroll Management System** built with **C#, .NET, UWP, and XAML** as part of the PROG1224 Object-Oriented Software Development course.

The application demonstrates object-oriented programming, inheritance, polymorphism, interfaces, generics, collections, LINQ, event-driven programming, and XAML-based user interface development.

## 📌 Project Overview

The Payroll Management System allows users to maintain employee records and process payroll for different types of employees.

The system supports:

* 👤 Multiple employee types
* 💰 Payroll calculation
* 🎁 Employee bonuses
* 📉 Payroll deductions
* 🔎 Employee searching and filtering
* ✏️ Updating employee information
* ➕ Adding new employees
* 📊 Payroll summaries
* ⚠️ Custom business-rule alerts
* 📈 LINQ-based decision support
* 🖥️ UWP/XAML user interface

---

## 🏗️ Employee Hierarchy

The application uses an object-oriented employee hierarchy:

```text
                    Employee
                   /        \
              Hourly         Salary
                               |
                         SalesEmployee
```

### Employee

The base class contains common employee information such as:

* Social Insurance Number (SIN)
* First name
* Last name
* Hire date
* Date of birth
* Phone number
* Email
* Canadian address
* Active status

It also provides common payroll and deduction functionality.

### Hourly

Hourly employees are paid based on:

```text
Hours Worked × Hourly Rate
```

### Salary

Salary employees are paid based on:

```text
Annual Salary ÷ 26
```

Salary employees also receive a bonus based on their years of service.

### SalesEmployee

The custom employee type extends the salary employee and calculates additional compensation based on sales and commission.

```text
Base Pay + Sales Commission
```

---

## 🧩 Main Components

### EmployeeLibrary

The class library contains the application's business logic.

```text
EmployeeLibrary
│
├── Employee.cs
├── Hourly.cs
├── Salary.cs
├── SalesEmployee.cs
├── Address.cs
├── IDeduction.cs
├── Data.cs
└── PayRoll.cs
```

### PayRollClient

The UWP application provides the graphical user interface.

```text
PayRollClient
│
├── MainPage.xaml
├── MainPage.xaml.cs
├── DecisionPage.xaml
└── DecisionPage.xaml.cs
```

---

## 💰 Payroll Processing

The generic `PayRoll<T>` class processes employees for a specific pay period.

It calculates:

* Current pay
* Bonus
* Income tax
* Pension
* Union dues
* Insurance
* Net pay

Example:

```text
987654321 John Doe
Net: $4,800.00
Bonus: $1,200.00
Deductions: $1,000.00
```

Employees are organized by employee type when payroll information is displayed.

---

## 📊 Decision Support

The application includes a separate decision-support view using **LINQ**.

The dashboard provides:

* Total number of each employee type
* Total active employees
* Total inactive employees
* Most senior employee
* Least senior employee
* Highest-paid employee
* Employee type with the highest total payroll
* Average employee pay
* A custom business-related result

Example:

```text
Employee Statistics

Hourly Employees: 5
Salary Employees: 5
Sales Employees: 5

Active Employees: 13
Inactive Employees: 2

Most Senior Employee:
John Smith - Salary - $2,850.00

Highest Paid Employee:
Jane Doe - SalesEmployee - $4,200.00

Highest Paying Employee Type:
SalesEmployee - $18,500.00

Average Pay:
$2,745.50
```

---

## 🔎 Employee Search & Filtering

The application allows employees to be filtered using different criteria.

Users can filter by:

* Employee type
* Employee name
* SIN
* Hire date

The employee list is displayed alphabetically by default and updates when filters are changed or cleared.

---

## ✏️ Employee Management

Users can select an employee from the `ListView` and view their information.

Depending on the employee type, the appropriate fields are displayed.

For example:

### Hourly Employee

```text
First Name
Last Name
Phone
Hourly Rate
Hours Worked
```

### Salary Employee

```text
First Name
Last Name
Phone
Annual Salary
```

### Sales Employee

```text
First Name
Last Name
Phone
Annual Salary
Sales
Commission Rate
```

Users can:

* Update employee information
* Submit changes
* Add new employees
* View updated employee information immediately

---

## ⚠️ Custom Payroll Alert

The application uses a custom event and delegate to detect a business-rule condition.

For example, the application can alert the user when an employee's calculated pay exceeds a defined threshold.

```text
⚠️ Payroll Alert

John Smith's payroll exceeds the defined threshold.
Please review the employee's payroll information.
```

The event is triggered automatically when the business condition occurs.

---

## 🧠 Object-Oriented Concepts Demonstrated

This project demonstrates several object-oriented programming concepts:

### Encapsulation

Employee data is controlled through properties with validation.

### Inheritance

```text
Employee
   ↓
Salary
   ↓
SalesEmployee
```

### Polymorphism

Different employee types implement their own:

```csharp
CalculatePay()
Bonus()
ToString()
```

methods.

### Abstraction

`Employee` is an abstract base class that defines common employee behavior.

### Interface

The `IDeduction` interface defines:

```csharp
IncomeTax()
Pension()
UnionDues()
Insurance()
```

### Generics

Payroll processing is implemented using:

```csharp
PayRoll<T>
```

### LINQ

LINQ is used for employee filtering, grouping, sorting, statistics, and decision-support calculations.

### Events & Delegates

A custom event is used to notify the UI when a payroll business rule is triggered.

---

## 🛠️ Technologies

* **C#**
* **.NET**
* **UWP (Universal Windows Platform)**
* **XAML**
* **LINQ**
* **Generics**
* **Object-Oriented Programming**
* **Visual Studio**
* **Git & GitHub**

---

## 📂 Project Structure

```text
PROG1224
│
├── EmployeeLibrary
│   ├── Address.cs
│   ├── Employee.cs
│   ├── Hourly.cs
│   ├── Salary.cs
│   ├── SalesEmployee.cs
│   ├── IDeduction.cs
│   ├── Data.cs
│   └── PayRoll.cs
│
└── PayRollClient
    ├── MainPage.xaml
    ├── MainPage.xaml.cs
    ├── DecisionPage.xaml
    └── DecisionPage.xaml.cs
```

---

## 🚀 How to Run

### Requirements

* Visual Studio
* .NET development tools
* UWP development workload
* Windows operating system

### Steps

1. Clone the repository.

```bash
git clone YOUR_REPOSITORY_URL
```

2. Open the solution in Visual Studio.

3. Make sure `EmployeeLibrary` is referenced by `PayRollClient`.

4. Build the solution.

5. Run the `PayRollClient` UWP application.

6. Use the employee list to search, select, update, and add employees.

7. Process payroll and view the decision-support information.

---

## 🎯 Learning Goals

This project was developed to practice:

* Designing class hierarchies
* Applying inheritance and polymorphism
* Creating reusable business logic
* Working with collections
* Building generic classes
* Implementing interfaces
* Using LINQ for data analysis
* Creating custom events
* Building UWP interfaces with XAML
* Separating business logic from the user interface

---

## 📚 Academic Project

This project was created for **PROG1224 – Object-Oriented Software Development**.

It demonstrates the concepts and programming techniques covered throughout the course, including object-oriented design, UWP development, collections, LINQ, generics, and event-driven programming.

---

## 👩‍💻 Author

**Nomuun Ankhbayar**

Computer Programming & Analysis
Niagara College, Ontario, Canada

---

⭐ If you found this project interesting, feel free to explore the source code and see how the employee hierarchy, payroll processing, LINQ queries, and UWP interface work together.
