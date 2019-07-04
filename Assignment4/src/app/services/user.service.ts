import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { map } from 'rxjs/operators';
import { User } from '../models/user';
import { Observable, Subject, BehaviorSubject } from 'rxjs';
import { AuthService } from './auth.service';
import { Router } from '@angular/router';
@Injectable({
  providedIn: 'root'
})
export class UserService {
  private user: User;
  private userName: string;
  constructor(
    private http: HttpClient,
    private authService: AuthService,
    private router: Router
  ) {
    this.user = new User();
  }

  public displayNameSub$: Subject<string> = new Subject<string>();
  // public displayNameSub$ = new BehaviorSubject<string>();

  Login(userLogin: User): Observable<any> {
    const httpOptions = {
      headers: new HttpHeaders({
        'Accept': 'text/html, application/xhtml+xml, */*',
        'Content-Type': 'application/json'
      }),
      responseType: 'text' as 'json'
    };
    // this.displayUserName(userLogin.username);
    this.user =  userLogin;
    this.user.username = userLogin.username;
    this.displayNameSub$.next(this.user.username);
    return this.http.post(`https://localhost:44316/api/account`, userLogin, httpOptions);
  }

  // displayUserName(name: string): string  {
  // //  return this.displayNameSub$.next(name);
  // }
  // getName(): string {
  //   return this.userName;
  // }
}

