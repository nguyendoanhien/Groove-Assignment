import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { UserService } from '../../services/user.service';
import { User } from '../../models/user';
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
  submitted = false;
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
    this.submitted = true;
    const a: User = { username: this.f.username.value, password: this.f.password.value };
    this.userService.Login(a)
      .subscribe(val => {
        console.log(val);
        this.userLoginSuccess = val;
        this.authService.setToken(val);
        this.SetUserName(a);
        this.SetIsAuth();
        if(this.f.username.value != '' && this.f.password.value != '') { this.IsLogin() } ;
      }, err => {
        console.log(err);
      });

  }

  IsLogin() {
    if (this.authService.getToken() === 'null') {
      window.alert('Your password is invalid. Please try again');
      this.authService.removeToken();
      this.router.navigate(['/login']);
    } else if (this.authService.getToken() !== 'null') {
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
