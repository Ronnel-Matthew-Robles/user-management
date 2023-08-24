# Use an official Node.js runtime as the base image
FROM node:18 AS build

# Set the working directory in the container
WORKDIR /app

# Copy package.json and package-lock.json to the working directory
COPY package*.json ./

# Install Angular CLI globally
RUN npm install -g @angular/cli

# Install project dependencies
RUN npm install

# Copy the entire application to the container
COPY . .

# Build the Angular application
RUN ng build

# Use a lightweight Node.js runtime for serving the application
FROM node:18-slim

# Set the working directory in the container
WORKDIR /app

# Copy the production-ready Angular build from the build stage
COPY --from=build /app/dist .

# Install a simple HTTP server to serve the Angular app
RUN npm install -g http-server

# Expose port 80
EXPOSE 80

# Start the HTTP server to serve the Angular app
CMD ["http-server", "-p", "80"]
