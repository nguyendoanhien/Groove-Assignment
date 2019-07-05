import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { first } from 'rxjs/operators';
import { NgForm } from '@angular/forms';
import { UserService } from '../../services/user.service';
import { User } from '../../models/user';
import * as JWT from 'jwt-decode';
import { AuthService } from 'src/app/services/auth.service';
@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  userName: string;
  loginForm: FormGroup;
  userLoginSuccess: User;
  returnUrl: string;
  constructor(
    private formBuilder: FormBuilder,
    private route: ActivatedRoute,
    private router: Router,
    private userService: UserService,
    private authService: AuthService
  ) { }

  ngOnInit() {
    this.loginForm = this.formBuilder.group({
      username: ['user2@gmail.com', Validators.required],
      password: ['B8Z!Z8kdNrERfrF', Validators.required]
    });
  }
  get f() { return this.loginForm.controls; }
  onSubmit() {
    const a: User = { username: this.f.username.value, password: this.f.password.value };
    this.userService.Login(a)
      .subscribe(val => {
        console.log(val);
        this.userLoginSuccess = val;
        this.authService.setToken(val);

        this.SetUserName(a);
        this.SetIsAuth();
        this.IsLogin();
      }, err => {
        console.log(err);
      });

  }

  IsLogin() {
    if (this.authService.getToken() === 'null') {
      window.alert('Đăng nhập thất bại');
      this.authService.removeToken();
      this.router.navigate(['/login']);
    } else if (this.authService.getToken() !== 'null') {
      window.alert('Đăng nhập thành công');
      this.router.navigate(['/dashboard']);
    }
  }

  SetUserName(user: User) {
    if (this.authService.isAuthenticated()) {
      this.authService.setUserName(user.username);
    }
  }
  SetIsAuth() {
    if (this.authService.isAuthenticated()) {
      this.authService.setIsAuth('true');
    } else { this.authService.setIsAuth('false'); }
  }

  checkAuth(): boolean {
    const isAuth = this.authService.getIsAuth();
    if (isAuth === 'true') {
      return true;
    } else { return false; }
  }

  // AuthExists(): boolean {
  //   debugger
  //   if (this.authService.getIsAuth() === null) {
  //     return false;
  //   } else { return true; }
  // }
  // RedirectURL() {
  //   debugger
  //   this.router.navigate(['note/list']);
  //   }
}
