import { Component } from '@angular/core';
import { UserService } from '../services/user.service';
import { User } from '../models/user.model';
import { Router } from '@angular/router';

@Component({
  selector: 'app-user-add',
  templateUrl: './user-add.component.html',
  styleUrls: ['./user-add.component.scss']
})
export class UserAddComponent {
  newUser: User = {
    name: '',
    email: '',
    phoneNumber: ''
  };

  constructor(private userService: UserService, private router: Router) { }

  addUser() {
    if (!this.isFormValid()) {
      return; // Don't proceed if the form is not valid
    }

    this.userService.addUser(this.newUser).subscribe(
      () => {
        // Clear the form fields after adding the user
        this.newUser = {
          name: '',
          email: '',
          phoneNumber: ''
        };
        this.router.navigate(['/users']);
      },
      (error) => {
        // Handle any error from the API (e.g., display a message)
        console.error('Error adding user:', error);
      }
    );
  }

  private isFormValid(): boolean {
    // Check if the form is valid by checking the ngModel control statuses
    return (
      this.newUser.name !== '' &&
      this.newUser.email !== '' &&
      this.newUser.phoneNumber !== ''
    );
  }
}
