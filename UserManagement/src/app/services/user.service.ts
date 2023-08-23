import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { User } from '../models/user.model';

@Injectable({
  providedIn: 'root'
})
export class UserService {
  private apiUrl = 'http://localhost:5057/api/User'; // Replace with your API URL

  constructor(private http: HttpClient) { }

  // Get a list of all users
  getUsers(): Observable<User[]> {
    return this.http.get<User[]>(this.apiUrl);
  }

  // Get a user by their ID
  getUserById(id: string): Observable<User> {
    const url = `${this.apiUrl}/${id}`;
    return this.http.get<User>(url);
  }

  // Add a new user
  addUser(user: User): Observable<User> {
    return this.http.post<User>(this.apiUrl, user);
  }

  // Update an existing user
  updateUser(id: string, updatedUser: User): Observable<any> {
    const url = `${this.apiUrl}/${id}`;
    return this.http.put(url, updatedUser);
  }

  // Delete a user by their ID
  deleteUser(id: string): Observable<any> {
    const url = `${this.apiUrl}/${id}`;
    return this.http.delete(url);
  }
}
