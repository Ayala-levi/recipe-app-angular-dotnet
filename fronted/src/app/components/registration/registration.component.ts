import { Component } from '@angular/core';
import { User } from '../../interfaces/User.interface';
import { FormsModule } from "@angular/forms";
import { UserService } from '../../services/user.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-registration',
  imports: [FormsModule],
  templateUrl: './registration.component.html',
  styleUrl: './registration.component.css'
})
export class RegistrationComponent {
  constructor(private userService: UserService, private active: Router) { }
  user: User = {
    userId: 0,
    lastName: "",
    email: "",
    passwordHash: "",
    firstName: "",
    recipes: []
  }
  //הרשמה-הוספת משתמש
  toRegister() {
    this.userService.AddUser(this.user).subscribe(
      (data) => {
        this.user = data;
        if (this.user == null) {
          alert("ההרשמה נכשלה, נסה שוב!");
        }
        else {
          alert("נרשמת בהצלחה, ברוכים הבאים!");
          //עדכון קוד משתמש בסרוויס
          this.userService.UserId=this.user.userId;
          //עדכון שם משתמש בסרוויס
          this.userService.UserName = this.user.firstName;
          //ניתוב יזום לדף הבית
          this.active.navigate(["/home page"]);
        }
      },
      err => {
        console.log(err);
      }
    )
  }
}
