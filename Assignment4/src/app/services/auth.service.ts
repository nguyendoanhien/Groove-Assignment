import { Injectable } from '@angular/core';
import { Subject } from 'rxjs';
@Injectable()
export class AuthService {
  private rs: string;
  public isAuth$: Subject<string> = new Subject<string>();
  constructor() {

  }
  public getToken(): string {
    return localStorage.getItem('token') === null ? '' : localStorage.getItem('token');
  }

  public setToken(token: string) {
    localStorage.setItem('token', token);
  }


  public removeToken() {
    localStorage.removeItem('token');
    localStorage.removeItem('username');
    localStorage.removeItem('isAuth');
  }

  public isAuthenticated(): boolean {
    const token = this.getToken();
    if (token === null || token.length === 0 || token === 'null') {
      return false;
    } else {
      return true;
    }
  }
  public SetAuth() {
    this.rs = this.isAuthenticated() === true ? 'true' : 'false';
    this.isAuth$.next(this.rs);
    console.log(this.rs);
  }

  public setUserName(username: string) {
    localStorage.setItem('username', username);
  }
  public getUserName(): string {
    return localStorage.getItem('username') === null ? '' : localStorage.getItem('username');
  }
  public setIsAuth(val: string) {
    localStorage.setItem('isAuth', val);
  }
  public getIsAuth(): string {
    return localStorage.getItem('isAuth') === null ? '' : localStorage.getItem('isAuth');
  }
}
