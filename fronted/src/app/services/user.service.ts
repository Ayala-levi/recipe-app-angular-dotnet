import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { User } from '../interfaces/User.interface';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
//מקביל לקונטרולר של משתמשים
export class UserService {
  Url: string = "https://localhost:7062/api/Users"
  ListUser: Array<User> = []
  UserId: number = 0
  UserName:string="לא מחובר"
  constructor(private httpc: HttpClient) { }
  //שליפת כל המשתמשים
  Get(): Observable<User[]> {
    return this.httpc.get<User[]>(this.Url);
  }
  //שליפת משתמש לפי מייל וסיסמה
  GetUser(email: string, password: string): Observable<User> {
    return this.httpc.get<User>(`${this.Url}/${email},${password}`);
  }
  //הוספת משתמש
  AddUser(user: User): Observable<User> {
    return this.httpc.post<User>(this.Url, user);
  }
  IsConnect() {
    if (this.UserId == 0) {
      return false;
    }
    return true;
  }
}
