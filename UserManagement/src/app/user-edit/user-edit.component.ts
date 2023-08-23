import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { UserService } from '../services/user.service';
import { User } from '../models/user.model';

@Component({
  selector: 'app-user-edit',
  templateUrl: './user-edit.component.html',
  styleUrls: ['./user-edit.component.scss']
})
export class UserEditComponent implements OnInit {
  user: User = {name: '', email: '', phoneNumber: ''};
  userId: string = '';

  constructor(
    private userService: UserService,
    private route: ActivatedRoute,
    private router: Router
  ) { }

  ngOnInit() {
    this.route.params.subscribe(params => {
      this.userId = params['id'];
      this.userService.getUserById(this.userId).subscribe(user => {
        this.user = user;
      });
    });
  }

  updateUser() {
    this.userService.updateUser(this.userId, this.user).subscribe(() => {
      // After updating, navigate back to user details
      this.router.navigate(['/users', this.userId]);
    });
  }
}
