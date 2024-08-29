# AuthService

**AuthService** is an ASP.NET Core Web API designed for managing user authentication and authorization. This service offers endpoints for user registration, login, token refresh, password reset, and email confirmation using JWT and Refresh Tokens. Email functionalities are seamlessly integrated via SendGrid.

## Features

- **User Registration**: Automatic role assignment during user registration.
- **JWT-based Authentication**: Supports token refresh capability.
- **Email Confirmation & Password Reset**: Integrated with SendGrid.
- **Secure Role-based Access Control**: Ensures that only authorized users have access to specific resources.

## Endpoints

### 1. Register a New User

- **Endpoint**: `POST /api/auth/register`
- **Description**: Registers a new user with email, password, and phone number. Assigns the "Admin" role to the user.
- **Request**:
  ```json
  {
    "email": "user@example.com",
    "password": "Password123!",
    "phoneNumber": "1234567890"
  }

  
### 2. User Login (Sign In)
- **Endpoint**: `POST /api/auth/signIn`
- **Description**: Authenticates a user and returns a JWT access token and a refresh token.
- **Request**:
  ```json
  {
    "email": "user@example.com",
    "password": "Password123!"
  }

  
### 3. Refresh JWT Token

- **Endpoint**: `POST /api/auth/refresh`
- **Description**: Refreshes a JWT access token using a valid refresh token.
- **Request**:
  ```json
  {
    "accessToken": "existingAccessToken",
    "refreshToken": "validRefreshToken"
  }

  
### 4. Confirm Email
- **Endpoint**: `POST /api/auth/confirm-email`
- **Description**: Confirms a user's email address using a confirmation token.
- **Request**:
  ```json
  {
    "email": "user@example.com",
    "token": "confirmationToken"
  }

  
### 5. Send Confirmation Email
- **Endpoint**: `POST /api/auth/send-confirmation-email`
- **Description**: Sends an email confirmation link to the specified user's email address.
- **Request**:
  ```json
  {
    "email": "user@example.com"
  }


### 6. Send Confirmation Change Email
- **Endpoint**: `POST /api/auth/send-confirmation-change-email`
- **Description**: Sends a confirmation email to change the user's email address.
- **Authorization**:  Required (Roles: Admin)
- **Request**:
  ```json
  {
    "newEmail": "newuser@example.com"
  }

  
### 7. Confirm Changed Email
- **Endpoint**: `POST /api/auth/confirm-changed-email`
- **Description**: Confirms a new user's email address using a confirmation token.
- **Authorization**:  Required (Roles: Admin)
- **Request**:
  ```json
  {
    "newEmail": "newuser@example.com"
    "token": "confirmationToken"
  }

  
### 8. Change Password
- **Endpoint**: `POST /api/auth/change-password`
- **Description**: Changes the user's password.
- **Authorization**:  Required (Roles: Admin)
- **Request**:
  ```json
  {
    "currentPassword": "CurrentPassword123!",
    "newPassword": "NewPassword123!"
  }


### 9. Send Reset Password Token
- **Endpoint**: `POST /api/auth/send-reset-password-token`
- **Description**: Sends an email with a token confirming password reset.
- **Request**:
  ```json
  {
    "email": "user@example.com",
    "newPassword": "NewPassword123!"
  }

    
### 10. Reset Password
- **Endpoint**: `POST /api/auth/reset-password`
- **Description**: Resets the user's password using a password reset token.
- **Request**:
  ```json
  {
    "email": "user@example.com",
    "token": "resetToken",
    "newPassword": "NewPassword123!"
  }
  
## Getting Started

### Prerequisites

- Docker and Docker Compose should be installed on your machine.
- .NET SDK for local development.

### Installation

#### 1. Clone the repository:
  ```console
   git clone https://github.com/zml18x/AuthService
   cd AuthService
  ```

#### 2. Run the Docker containers:
  ```console
   docker-compose up -d
  ```

#### 3. Update the appsettings.json file in your project to include the connection string for PostgreSQL:
  ```json
   "ConnectionStrings": {
     "DefaultConnection": "Host=localhost;Port=5432;Database=AuthServiceDb;Username=[userNameFromDockerComposeFile];Password=[passwordFromDockerComposeFile]"
   }
 ```

#### 4. Add the required secrets for SendGrid:

Set these values in your local secrets manager:
   ```console
   dotnet user-secrets set "SENDGRID_API_KEY" "YOUR_SENDGRID_API_KEY"
   dotnet user-secrets set "SENDGRID_SENDER_EMAIL" "YOUR_SENDGRID_SENDER_EMAIL"
   ```

#### 5. Run the application:
  ```bash
   dotnet run
```

#### 6. Access the application via
   `http://localhost:7099`

### Using pgAdmin

#### 1. Visit http://localhost:8080 in your browser.
#### 2. Login with the credentials you provided (admin@example.com / adminpassword).
#### 3. Add a new server with the following details:
   - Host name/address: db
   - Port: 5432
   - Username: admin
   - Password: adminpassword

   This will allow you to manage your PostgreSQL database via pgAdmin.
