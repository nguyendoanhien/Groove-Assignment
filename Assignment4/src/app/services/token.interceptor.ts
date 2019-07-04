import { environment } from '../../environments/environment';
import { Injectable } from '@angular/core';
import {
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpInterceptor,
  HttpErrorResponse
} from '@angular/common/http';
import { AuthService } from './auth.service';
import { User } from '../models/user';
import { Observable } from 'rxjs';
import { tap } from 'rxjs/operators';
import { Router } from '@angular/router';
const authUrl = 'https://localhost:44316/api/account';

@Injectable()
export class TokenInterceptor implements HttpInterceptor {

  constructor(
    private authService: AuthService,
    private router: Router) {
  }
  intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    var securityToken = this.authService.getToken();
    console.log(securityToken);
    if (request.url === authUrl) {
      request.headers.set('Content-Type', 'application/json; charset=UTF-8');
      return next.handle(request);
    } else if (securityToken.length > 0) {
      request = request.clone({
        setHeaders: {
          'Content-Type': 'application/json; charset=UTF-8',
          Authorization: `Bearer ${securityToken}`
        }
      });
      return next.handle(request)
      .pipe(
        tap(event => { }, err => {
          if (err instanceof HttpErrorResponse) {
            this.router.navigate(['/login']);
            window.alert('Vui lòng đăng nhập lại');
          }
        })
      );
    }
  }
}
