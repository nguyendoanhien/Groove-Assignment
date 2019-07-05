import { Component, OnInit } from '@angular/core';
import { LoginModel } from './login.model';
import { UserProfileService } from 'src/app/core/identity/userprofile.service';
import { Router } from '@angular/router';
import { AuthService } from 'src/app/core/auth/auth.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  login = new LoginModel("toilati123vn@gmail.com", "qQ@123");

  constructor(private userProfileService: UserProfileService, private _router: Router, private _authService: AuthService) { }

  ngOnInit() {
    // if (localStorage.getItem('token')) {
    //   this._router.navigate(['']);

    // }
    if (this._authService.isAuthenticated()) {
      this._router.navigate(['note']);
    }
  }

  onSubmit() {

    this.userProfileService.logIn(this.login).subscribe(() => this._router.navigate(['note']));

  }

}
