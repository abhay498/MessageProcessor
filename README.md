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

# Application Flow

