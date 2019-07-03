import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { map } from 'rxjs/operators';
import { User } from '../models/user';
import { Observable, Subject } from 'rxjs';
import { AuthService } from './auth.service';
import { Router } from '@angular/router';
@Injectable({
  providedIn: 'root'
})
export class UserService {
   private user: User;
  constructor(
    private http: HttpClient,
    private authService: AuthService,
    private router: Router
    ) {
      this.user = new User();
    }

    public displayNameSub$: Subject<string> = new Subject<string>();

  Login(userLogin: User): Observable<any> {
    const httpOptions = {
      headers: new HttpHeaders({
        'Accept': 'text/html, application/xhtml+xml, */*',
        'Content-Type': 'application/json'
      }),
      responseType: 'text' as 'json'
    };
     this.user.username = userLogin.username;
    return this.http.post(`https://localhost:44316/api/account`, userLogin, httpOptions);
  }

  // GetName(){
  //   this.displayNameSub$.next(this..DisplayName);
  // }
  // Logout() {
  //   this.authService.removeToken();
  // }
}
