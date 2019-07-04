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

  loginForm: FormGroup;
  loading = false;
  submitted = false;
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
        this.authService.setToken(val);
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
      this.router.navigate(['/dashboard']);
    }
  }
}
