import { Component } from '@angular/core';
import { FormsModule } from "@angular/forms";
import { UserService } from '../../services/user.service';
import { User } from '../../interfaces/User.interface';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  imports: [FormsModule],
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})
export class LoginComponent {
  constructor(private userService: UserService, private active: Router) { }
  email: string = ""
  passwordHash: string = ""
  triedToRegister: boolean = false

  user: User = {
    userId: 0,
    lastName: "",
    email: "",
    passwordHash: "",
    firstName: "",
    recipes: []
  }
  login() {
    this.userService.GetUser(this.email, this.passwordHash).subscribe(
      (data) => {
        //הכנסת המשתמש למחלקה מהסרוויס
        this.user = data;
        //בדיקה האם המשתמש לא קיים במערכת
        if (this.user == null) {
          //בדיקה האם ניסה להתחבר ונכשל
          if (this.triedToRegister == false) {
            //איפוס המשתנים
            this.passwordHash = ""
            this.email = ""
            alert("אימייל או סיסמה שגויים, אנא נסה שוב.");
            this.triedToRegister = true;
          }
          else {
            alert("אימייל או סיסמה שגויים, אנא הרשם.")
            this.triedToRegister = false;
            //ניתוב יזום להרשמה
            this.active.navigate(["/registration"]);
          }
        }
        else {
          //עדכון קוד משתמש בסרוויס
          this.userService.UserId = this.user.userId;
          //עדכון שם משתמש בסרוויס
          this.userService.UserName = this.user.firstName;
          //ניתוב יזום לדף הבית
          this.active.navigate(["/home page"]);
        }
      },
      err => {
        console.log(err);
      });
  }
}
