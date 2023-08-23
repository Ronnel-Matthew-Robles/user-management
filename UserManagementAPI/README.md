

# .NET Core API for User Management

This is the .NET Core API backend for our User Management Application. It serves as the data storage and retrieval system for user records.

## Features

- RESTful API endpoints for CRUD operations on user data.
- MongoDB database integration for data storage.
- Integration with the Angular frontend for user interface.


## Run Locally

Clone the project

```bash
  git clone https://github.com/yourusername/user-management-api.git
```

Go to the project directory

```bash
  cd user-management-api
```

Install dependencies

```bash
  dotnet restore
```

Start the server

```bash
  dotnet run
```
The API will be available at http://localhost:5057.


## API Reference

#### Get all users

```http
  GET /api/User
```

#### Get specific user

```http
  GET /api/User/${id}
```

| Parameter | Type     | Description                       |
| :-------- | :------- | :-------------------------------- |
| `id`      | `string` | **Required**. Id of user to fetch |

#### Store user

```http
  POST /api/User
```

| Parameter | Type     | Description                       |
| :-------- | :------- | :-------------------------------- |
| `name`      | `string` | **Required** |
| `email`      | `string` | **Required** |
| `phoneNumber`      | `string` | **Required** |

#### Update user

```http
  PUT /api/User/${id}
```

| Parameter | Type     | Description                       |
| :-------- | :------- | :-------------------------------- |
| `id`      | `string` | **Required**. Id of user to update |

##### Body

| Property | Type     | Description                       |
| :-------- | :------- | :-------------------------------- |
| `name`      | `string` | **Required** |
| `email`      | `string` | **Required** |
| `phoneNumber`      | `string` | **Required** |

#### Delete user

```http
  DELETE /api/User/${id}
```

| Parameter | Type     | Description                       |
| :-------- | :------- | :-------------------------------- |
| `id`      | `string` | **Required**. Id of user to delete |

## Usage

- Use the API endpoints to perform CRUD operations on user data.
- Ensure the MongoDB database is properly configured and accessible.

