# Gift of the Givers – Disaster Relief Web Application (Part 1)

![Gift of the Givers Logo](wwwroot/images/logo.png)

A prototype web application built for the **Gift of the Givers Foundation** to streamline disaster relief operations, manage volunteers, and facilitate donations.

This project was developed as part of the **APPR6312 – Applied Programming** module.

---

## 📋 Table of Contents

- [Project Overview](#-project-overview)
- [Features](#-features)
- [Technologies Used](#-technologies-used)
- [Getting Started](#-getting-started)
  - [Prerequisites](#prerequisites)
  - [Installation](#installation)
  - [Running Locally](#running-locally)
- [Project Structure](#-project-structure)
- [Database Schema](#-database-schema)
- [Azure Deployment](#-azure-deployment)
- [Screenshots](#-screenshots)
- [Contributors](#-contributors)
- [Future Work (Part 2)](#-future-work-part-2)

---

## 📖 Project Overview

The Gift of the Givers Foundation is Africa's largest disaster relief organisation. This prototype aims to provide a centralised platform for:

- Managing relief projects and updates.
- Coordinating volunteer registrations.
- Processing donations (one-time and recurring) with automatic tax certificate generation.
- Allowing employees to view volunteer sign-ups and post project updates.

The solution follows Agile principles and was planned using **Azure Boards**, designed with a relational database schema, and built using **ASP.NET Core 8 MVC**.

---

## ✨ Features

- **Branding & Responsive Design** – Custom logo, green/gold theme, Bootstrap 5, mobile-friendly navigation.
- **Authentication & Roles** – ASP.NET Core Identity with two roles: `Employee` and `Donor`.
- **Donation Module** – One-time/recurring donations, multi-currency (ZAR default), anonymous giving, and a placeholder tax certificate.
- **Volunteer Registration** – Simple form to capture name, email, phone, skills, and availability.
- **Employee Dashboard** – Secure area for employees to view recent donations, volunteer sign-ups, and post project updates.
- **Animations** – Typewriter effect, counter animations, hover effects, and smooth scrolling.

---

## 🛠 Technologies Used

| Layer | Technology |
|-------|------------|
| Frontend | HTML5, CSS3, Bootstrap 5, JavaScript |
| Backend | ASP.NET Core 8 MVC |
| Database | SQLite (local development) / Azure SQL (planned) |
| ORM | Entity Framework Core 8 |
| Authentication | ASP.NET Core Identity |
| Cloud Hosting | Azure App Services |
| Project Planning | Azure Boards (Epics, User Stories, Tasks, Sprints) |
| Version Control | Git & Azure Repos |

---

## 🚀 Getting Started

### Prerequisites

- [.NET 8.0 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [Visual Studio 2022](https://visualstudio.microsoft.com/) with **ASP.NET and web development** workload
- SQLite (included with EF Core provider)
- An Azure account (for deployment)

### Installation

1. **Clone the repository**

   ```bash
   git clone https://dev.azure.com/YOUR-ORG/YOUR-PROJECT/_git/YOUR-REPO
   cd GiftOfTheGivers.Web
   ```

2. **Restore NuGet packages**

   ```bash
   dotnet restore
   ```

3. **Apply database migrations**

   ```bash
   dotnet ef database update
   ```

   This will create the SQLite database `GiftOfTheGivers.db` in the project root.

### Running Locally

Run the application:

```bash
dotnet run
```

Or press **F5** in Visual Studio.

**Default login credentials** (seeded automatically):

- Email: `employee@giftofgivers.org`
- Password: `Employee@123`
- Role: `Employee`

---

## 📁 Project Structure

```
GiftOfTheGivers.Web/
│
├── Controllers/
│   ├── HomeController.cs
│   ├── DonationsController.cs
│   ├── VolunteerInterestsController.cs
│   └── EmployeeController.cs
│
├── Models/
│   ├── ApplicationUser.cs
│   ├── Donation.cs
│   ├── VolunteerInterest.cs
│   ├── ReliefProject.cs
│   └── DonationViewModel.cs
│
├── Data/
│   ├── ApplicationDbContext.cs
│   └── DbInitializer.cs
│
├── Views/
│   ├── Home/
│   ├── Donations/
│   ├── VolunteerInterests/
│   ├── Employee/
│   └── Shared/
│
├── wwwroot/
│   ├── css/site.css
│   ├── js/site.js
│   └── images/
│
├── Migrations/
├── appsettings.json
└── Program.cs
```

---

## 🗄 Database Schema

The database was designed to support the core entities of the foundation. The ERD includes:

- **Users** – Identity users with roles (Employee, Donor).
- **Volunteers** – Volunteer interest registrations.
- **Donations** – Donation records with amount, currency, recurrence, and optional project link.
- **Relief Projects** – Projects that donations can be allocated to.

> **Note:** For the prototype, SQLite is used for local development. The schema is compatible with Azure SQL for production deployment.

For the full ERD, refer to the `docs/ERD.png` file (or the team's design document).

---

## ☁️ Azure Deployment

The prototype is deployed to Azure App Services.

- **Live URL:** https://giftofgivers-demo-2026.azurewebsites.net *(replace with your actual URL)*
- **Deployment method:** Published directly from Visual Studio using the Azure App Service publish profile.
- **Database:** SQLite file stored in the `App_Data` folder (for prototype). In Part 2, this will be migrated to Azure SQL.

---

## 📸 Screenshots

| Page | Preview |
|------|---------|
| Home Page | `docs/screenshots/home.png` |
| Donation Form | `docs/screenshots/donate.png` |
| Tax Certificate | `docs/screenshots/certificate.png` |
| Volunteer Form | `docs/screenshots/volunteer.png` |
| Employee Dashboard | `docs/screenshots/dashboard.png` |
| Login Page | `docs/screenshots/login.png` |

*(Place your own screenshots in the `docs/screenshots` folder and update the paths.)*

---

## 👥 Contributors

| Name | Role | Responsibilities |
|------|------|-------------------|
| [Student 1] | Project Lead | Azure Boards setup, sprint planning, coordination |
| [Student 2] | Database Designer | ERD, schema design, database optimisation |
| [Your Name] | Developer (Prototype) | ASP.NET Core web app, donation module, volunteer form, employee dashboard, Azure deployment |
| [Student 4] | Quality Reviewer | Testing, bug fixes, documentation |
| [Student 5] | UI/UX & Integration | Branding, styling, animations, integration |

---

## 🔮 Future Work (Part 2)

- Add Azure Functions for tax certificate generation and logging.
- Integrate Azure Repos Git for version control and branching.
- Set up Azure Pipelines for CI/CD.
- Publish a NuGet helper library to Azure Artifacts.
- Migrate from SQLite to Azure SQL Database.
- Implement full donation workflows and reporting.

---

## 📄 License

This project is developed for academic purposes as part of the APPR6312 module. All rights reserved by the contributors.

> *"A beacon of hope in times of crisis." – Gift of the Givers Foundation*
