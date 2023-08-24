![User Management Diagram](./UserCRUD.png)
# User Management Application

The User Management Application is a web-based system that allows you to manage user data. It consists of two main components: an Angular frontend and a .NET Core API backend, both integrated with a MongoDB database for data storage.
## Features

- Add, edit, and delete user records.
- View a list of users in a grid format.
- Form validation to ensure data integrity.
- Integration with the .NET Core API for data storage and retrieval.


## Prerequisites

Before you begin, ensure you have met the following requirements:

- Node.js and npm installed for the Angular frontend.
- .NET Core SDK and runtime installed for the API.
- Docker and Docker Compose for containerization (optional).
- MongoDB database (you can use a local or cloud-hosted instance).
## Installation

Follow these steps to set up and run the User Management Application:

1. **Clone the Repository:**

   ```bash
   git clone https://github.com/Ronnel-Matthew-Robles/user-management
   ```

2. **Start the MongoDB Database:**

Ensure your MongoDB instance is running and properly configured. Update the connection string in the API's `appsettings.json` file if necessary.

3. **Frontend Setup:**

- Navigate to the `frontend` directory.
- Install frontend dependencies:
```bash
cd UserManagement
npm install
```
- Start the frontend development server:
```bash
ng serve
```
The frontend will be available at `http://localhost:4200`.

**Note:** Make sure you also `npm install -g @angular/cli` if you haven't done so. Additionally, go to `src/app/services/user.service.ts` and change the `apiUrl` depending on the URL of the API in the next step. Usually it's at port 5057 but right now it's configured to be 5000.

4. **API Setup:**

- Navigate to the `UserManagementAPI` directory.

- Build and run the API:
```bash
dotnet restore
dotnet build
dotnet run
```

The API will be available at `http://localhost:5057` (or 5000).
## Docker Support

If you prefer to use Docker for containerization, a `docker-compose.yaml` file is provided to simplify the setup. Ensure you have Docker and Docker Compose installed and follow these steps:

1. Clone the repository (if not already done).

2. Navigate to the project root directory.

3. Build and run the containers:
```bash
docker pull mattwolfrob/user-mngmnt-frontend:latest
docker pull mattwolfrob/user-mngmnt-api:latest
docker-compose up
```
Access the application at the appropriate ports (frontend: http://localhost:4200, API: http://localhost:5000).
