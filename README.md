# 🧠 MissionManagementAPI

MissionManagementAPI is a .NET Core Web API built to handle mission reservation requests within an organization, with a clean approval workflow and role-based authorization.

---

## 📦 Tech Stack

- ASP.NET Core 6 Web API  
- Entity Framework Core (Oracle 21c XE)  
- JWT Authentication  
- BCrypt password hashing  
- Layered architecture: API, Application, Domain, Infrastructure

---

## 🏗️ Architecture

- `MissionManagementAPI.Api` – Web API controllers, routing, JWT middleware
- `MissionManagementAPI.Application` – Business logic, services, DTOs, interfaces
- `MissionManagementAPI.Domain` – Core entities and enums
- `MissionManagementAPI.Infrastructure` – Database context, EF repositories

---

## 👤 Authentication

- Users log in with **email + password**
- JWT issued with claims: Email, Role, Department, CodeAgent
- No public registration — users are created manually via Admin endpoints

---

## 📁 Reservations

- Users submit reservation requests
- Workflow:
  1. **Submit**
  2. **Approve N+1** (manager)
  3. **Approve DAAJ**
  4. **Finalize by Parc**
  5. **Reject** (by manager, DAAJ or admin)

- Role/identity-based access enforced for all workflow steps

---

## 🚗 Passengers

- Multiple passengers (transported persons) can be linked to a reservation
- Includes: Full name, Function, Organization

---

## 🔐 Admin Management

- Admins can:
  - Create users
  - Delete users
  - List all users

- User model includes:
  - Email, Password (hashed), Role, Department, Full Name

---

## 🔔 Notifications

- No DB persistence
- Live notifications are sent (console or SignalR-ready)
- Example: “Nouvelle demande de mission soumise par X le Y. Objet: Z.”

---

## 📡 API Endpoints Summary

### Auth
- `POST /api/auth/login`

### Admin (Admin-only)
- `GET /api/admin/users`
- `POST /api/admin/users`
- `DELETE /api/admin/users/{codeAgent}`

### Reservations
- `GET /api/reservations`
- `GET /api/reservations/{id}`
- `POST /api/reservations`
- `PUT /api/reservations/{id}`
- `DELETE /api/reservations/{id}`
- `POST /api/reservations/{id}/submit`
- `POST /api/reservations/{id}/approve-n1`
- `POST /api/reservations/{id}/approve-daaj`
- `POST /api/reservations/{id}/finalise`
- `POST /api/reservations/{id}/reject`

### Passengers
- `GET /api/reservations/{id}/passengers`
- `POST /api/reservations/{id}/passengers`
- `DELETE /api/passengers/{id}`

---

## 🧩 Frontend Integration Notes

- Authenticate via `/auth/login` and store the JWT token
- Include token in Authorization headers for all protected routes
- Role from JWT determines what UI actions are available
- Notification system will eventually use SignalR (currently mocked via console)
- Dates should be handled in ISO format or displayed prettily

---

## 🧪 Testing & Deployment

Testing will be handled once logic is fully implemented. All features are being built first before bug fixing.

