import { Component, OnInit } from '@angular/core';
import { UserService } from '../services/user.service';
import { User } from '../models/user.model';

@Component({
  selector: 'app-user-list',
  templateUrl: './user-list.component.html',
  styleUrls: ['./user-list.component.scss']
})
export class UserListComponent {
  users: User[] = [];

  constructor(private userService: UserService) {}

  ngOnInit() {
    this.getUsers();
  }

  getUsers() {
    this.userService.getUsers().subscribe(users => {
      this.users = users;
    });
  }

  deleteUser(id: string) {
    this.userService.deleteUser(id).subscribe(() => {
      // Remove the deleted user from the local list
      this.users = this.users.filter(user => user.id !== id);
    });
  }
}
