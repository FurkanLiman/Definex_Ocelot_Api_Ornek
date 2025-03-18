# Definex Ocelot API Gateway Frontend

This is the frontend for the Definex Ocelot API Gateway Demo. It's a React application that consumes the microservices through the Ocelot API Gateway.

## Setup

1. Make sure you have Node.js installed (version 14.x or higher recommended)
2. Install dependencies:
   ```
   npm install
   ```
3. Start the development server:
   ```
   npm start
   ```

## Features

- Browse Articles and Writers through the API Gateway
- Create, Read, Update, Delete operations for both resources
- Responsive UI built with React Bootstrap

## Configuration

The application is configured to proxy API requests to the API Gateway at https://localhost:5003 (configured in package.json).

## API Gateway Routes

The application uses the following routes through the API Gateway:

- Articles:
  - GET /gateway/articles - Get all articles
  - GET /gateway/articles/{id} - Get article by ID
  - POST /gateway/articles - Create article
  - PUT /gateway/articles/{id} - Update article
  - DELETE /gateway/articles/{id} - Delete article

- Writers:
  - GET /gateway/writers - Get all writers
  - GET /gateway/writers/{id} - Get writer by ID
  - POST /gateway/writers - Create writer
  - PUT /gateway/writers/{id} - Update writer
  - DELETE /gateway/writers/{id} - Delete writer 