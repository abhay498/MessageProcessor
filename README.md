# MessageProcessor

A simple full-stack application demonstrating communication between a **React frontend** and an **ASP.NET Core Web API backend** using a `POST` request.

The backend is structured using **Clean Architecture** and **Dependency Injection**.

---

## Table of Contents

- [Overview](#overview)
- [Application Flow](#application-flow)
- [Features](#features)
- [Technology Stack](#technology-stack)
- [Project Structure](#project-structure)
- [Clean Architecture](#clean-architecture)
- [Dependency Injection](#dependency-injection)
- [Backend](#backend)
- [Frontend](#frontend)
- [API Endpoint](#api-endpoint)
- [Swagger](#swagger)
- [Prerequisites](#prerequisites)
- [Running the Backend](#running-the-backend)
- [Running the Frontend](#running-the-frontend)
- [Running the Complete Application](#running-the-complete-application)
- [Testing the API with Postman](#testing-the-api-with-postman)
- [Testing the API with Swagger](#testing-the-api-with-swagger)
- [How React Communicates with the Backend](#how-react-communicates-with-the-backend)
- [Project Dependencies](#project-dependencies)
- [Git and GitHub](#git-and-github)
- [Future Improvements](#future-improvements)
- [Author](#author)

---

# Overview

MessageProcessor is a simple full-stack application built to demonstrate how a React frontend communicates with an ASP.NET Core Web API backend.

The user enters a message in the React application and clicks the **Process** button.

React sends a `POST` request to the ASP.NET Core API.

The backend processes the message and returns a JSON response.

Example:

```text
User enters:

hello abhay

        ↓

React Frontend

        ↓ POST

ASP.NET Core Web API

        ↓

MessageService

        ↓

HELLO ABHAY

        ↓

JSON Response

        ↓

React Frontend

        ↓

Backend processed: HELLO ABHAY
```

# Application Flow

```text
┌──────────────────────────┐
│      React Frontend      │
│                          │
│  Enter message           │
│  Click Process           │
└────────────┬─────────────┘
             │
             │ HTTP POST
             ▼
┌──────────────────────────┐
│    ASP.NET Core API      │
│                          │
│  MessageController       │
└────────────┬─────────────┘
             │
             ▼
┌──────────────────────────┐
│     Application Layer    │
│                          │
│  IMessageService         │
│  MessageService          │
└────────────┬─────────────┘
             │
             ▼
┌──────────────────────────┐
│       Domain Layer       │
│                          │
│     MessageResult        │
└────────────┬─────────────┘
             │
             ▼
        JSON Response
             │
             ▼
┌──────────────────────────┐
│      React Frontend      │
│                          │
│ Display result           │
└──────────────────────────┘

```
# Features

- React frontend
- ASP.NET Core Web API
- REST API
- HTTP POST endpoint
- Clean Architecture
- Dependency Injection
- Service Layer
- Domain Entity
- Swagger/OpenAPI
- CORS configuration
- Postman support
- Git/GitHub integration
- Separate frontend and backend folders

# Technology Stack

Frontend
- React
- JavaScript
- Vite
- npm
- ESLint
- CSS
  
Backend
- C#
- ASP.NET Core
- .NET 10
- ASP.NET Core Web API
- Swagger / Swashbuckle
- OpenAPI
  
Architecture
- Clean Architecture
- Dependency Injection
- Service Layer
- Interface-based programming

Development Tools
- Visual Studio 2026
- Visual Studio Terminal
- Postman
- Git
- GitHub

# Project Structure

```text
MessageProcessor/
│
├── Backend/
│   │
│   ├── MessageProcessor.API/
│   │   ├── Controllers/
│   │   │   └── MessageController.cs
│   │   ├── Program.cs
│   │   ├── MessageProcessor.API.csproj
│   │   └── MessageProcessor.API.slnx
│   │
│   ├── MessageProcessor.Application/
│   │   ├── Interfaces/
│   │   │   └── IMessageService.cs
│   │   ├── Services/
│   │   │   └── MessageService.cs
│   │   └── MessageProcessor.Application.csproj
│   │
│   ├── MessageProcessor.Domain/
│   │   ├── Entities/
│   │   │   └── MessageResult.cs
│   │   └── MessageProcessor.Domain.csproj
│   │
│   └── MessageProcessor.Infrastructure/
│       ├── DependencyInjection.cs
│       └── MessageProcessor.Infrastructure.csproj
│
├── Frontend/
│   ├── src/
│   │   ├── App.jsx
│   │   ├── App.css
│   │   ├── main.jsx
│   │   └── ...
│   ├── public/
│   ├── package.json
│   ├── package-lock.json
│   ├── vite.config.js
│   └── ...
│
└── README.md
```

# Clean Architecture

The backend follows a Clean Architecture style.

The main layers are:

```text
API
 ↓
Application
 ↓
Domain
```

Infrastructure provides implementation and dependency registration for external concerns.

1. API Layer
Project:

MessageProcessor.API

Responsibilities:
- HTTP requests
- HTTP responses
- Controllers
- Routing
- Swagger
- CORS
- Application startup

Main controller:

Controllers/MessageController.cs

The controller should not contain business logic.

2. Application Layer
Project:

MessageProcessor.Application

Responsibilities:
- Application/business operations
- Interfaces
- Services
- Use-case logic

Contains:
Interfaces/
    IMessageService.cs

Services/
    MessageService.cs

3. Domain Layer
Project:

MessageProcessor.Domain

The Domain layer contains the core business objects.

Current entity:

Entities/MessageResult.cs

The Domain layer should remain independent of frameworks and infrastructure.

4. Infrastructure Layer
Project:

MessageProcessor.Infrastructure

Currently this project contains dependency registration.

File:

DependencyInjection.cs

This layer can later contain things such as:
- Database access
- Entity Framework Core
- Repositories
- External APIs
- File storage
- Email services
- Other infrastructure implementations

# Dependency Injection

Dependency Injection is used to provide the IMessageService implementation to the controller.
The service is registered in:

MessageProcessor.Infrastructure

using:

services.AddScoped<IMessageService, MessageService>();

This means:

IMessageService
       ↓
MessageService

The controller receives the interface through constructor injection:

public MessageController(IMessageService messageService)
{
    _messageService = messageService;
}

The controller does not create the service itself.
ASP.NET Core's Dependency Injection container creates and provides the required implementation.

# Backend

The backend is an ASP.NET Core Web API.
Backend solution:

Backend/MessageProcessor.API/MessageProcessor.API.slnx

The API uses .NET 10.

API Endpoint

The application exposes the following endpoint:

POST /api/Message/process

When running locally:
https://localhost:7091/api/Message/process

Request
Request body:

{
  "message": "hello abhay"
}

Response

{
  "result": "Backend processed: HELLO ABHAY"
}

Swagger

Swagger is configured using:

Swashbuckle.AspNetCore

When the backend is running, open:

https://localhost:7091/swagger

Swagger provides an interactive interface for testing the API.

The endpoint appears as:
POST /api/Message/process

You can select:
Try it out

and execute the request directly from Swagger.

Prerequisites
Install the following before running the project.
Backend
- .NET 10 SDK
- Visual Studio 2026
Verify .NET:
dotnet --version

Example:

10.0.302

# Frontend

Install:
- Node.js
- npm
Verify:
node --version

and:
npm --version

Optional Tools
For API testing:
- Postman
For source control:
- Git

# Running the Backend

There are several ways to run the backend.
Option 1 - Visual Studio
Open:

Backend/MessageProcessor.API/MessageProcessor.API.slnx

in Visual Studio 2026.
Set:

MessageProcessor.API

as the startup project.
Run:

Ctrl + F5

or:

F5

The API will start.
Example:

https://localhost:7091

and:

http://localhost:5010

Option 2 - Command Line
Navigate to:

cd Backend/MessageProcessor.API

Run:
dotnet run

The console will display the URLs where the API is listening.

# Running the Frontend
Open a separate terminal.
Navigate to:
cd Frontend

Install dependencies:
npm install

Start the development server:
npm run dev

Vite will display something similar to:
Local: http://localhost:5173/

Open:
http://localhost:5173

# Running the Complete Application

Two processes need to run.

Terminal 1 - Backend

cd C:\Users\Abhay\source\repos\MessageProcessor\Backend\MessageProcessor.API
dotnet run

Example backend:

https://localhost:7091

Terminal 2 - Frontend

cd C:\Users\Abhay\source\repos\MessageProcessor\Frontend
npm install
npm run dev

Frontend:
http://localhost:5173

Open the application
Go to:
http://localhost:5173

Enter:
hello abhay

Click:
Process

Expected result:
Backend processed: HELLO ABHAY

# Testing the API with Postman

Create a new HTTP request.
Method:
POST

URL:
https://localhost:7091/api/Message/process

Select:
Body
→ raw
→ JSON

Request:

{
  "message": "hello abhay"
}

Click:
Send

Expected response:

{
  "result": "Backend processed: HELLO ABHAY"
}

Development HTTPS certificate
If Postman reports an SSL certificate verification error while using the local development certificate, SSL
certificate verification can be disabled in Postman for local development.
Do not disable SSL certificate verification for production environments.

# Testing the API with Swagger

Start the backend.
Open:
https://localhost:7091/swagger

Find:
POST /api/Message/process

Click:
Try it out

Use:
{
  "message": "hello abhay"
}

Click:
Execute

Expected:
200 OK

Response:

{
  "result": "Backend processed: HELLO ABHAY"
}

# How React Communicates with the Backend

The React application calls the ASP.NET Core endpoint using JavaScript fetch.
The request is made from:

Frontend/src/App.jsx

Example:

const response = await fetch(
    "https://localhost:7091/api/message/process",
    {
        method: "POST",
        headers: {
            "Content-Type": "application/json"
        },
        body: JSON.stringify({
            message: message
        })
    }
);

The backend receives:

{
  "message": "hello abhay"
}

The backend processes the message and returns:

{
  "result": "Backend processed: HELLO ABHAY"
}

React then displays the result.

CORS
The backend allows requests from the React development server:

http://localhost:5173

The CORS policy is configured in:
Backend/MessageProcessor.API/Program.cs

Example:

builder.Services.AddCors(options =>
{
    options.AddPolicy("ReactPolicy", policy =>
    {
        policy
            .WithOrigins("http://localhost:5173")
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

This allows the React development server to communicate with the ASP.NET Core API.

# Project Dependencies
The project references follow the Clean Architecture design.

MessageProcessor.API
    ↓
MessageProcessor.Application

MessageProcessor.API
    ↓
MessageProcessor.Infrastructure

MessageProcessor.Application
    ↓
MessageProcessor.Domain

MessageProcessor.Infrastructure
    ↓
MessageProcessor.Application

MessageProcessor.Infrastructure
    ↓
MessageProcessor.Domain

The Domain layer remains independent of the other application layers.

Request Processing Flow
When the user clicks Process:

1. User enters a message
       ↓
2. User clicks Process
       ↓
3. React sends HTTP POST
       ↓
4. MessageController receives request
       ↓
5. IMessageService is injected by ASP.NET Core
       ↓
6. MessageService processes the message
       ↓
7. MessageResult is created
       ↓
8. Controller returns HTTP 200
       ↓
9. React receives JSON
       ↓
10. React displays the result

Why Clean Architecture?
Clean Architecture helps separate responsibilities.
For example:

Controller
    ↓
Handles HTTP

Application Service
    ↓
Handles application/business logic

Domain
    ↓
Contains core business objects

Infrastructure
    ↓
Handles technical/external concerns

This makes the application easier to:
- Maintain
- Test
- Extend
- Refactor
- Scale

Why Dependency Injection?
Dependency Injection avoids tightly coupling the controller to a concrete implementation.
Instead of:

var service = new MessageService();

the controller depends on:

IMessageService

and ASP.NET Core provides:

MessageService

through its DI container.
This makes it easier to replace implementations and write unit tests.
