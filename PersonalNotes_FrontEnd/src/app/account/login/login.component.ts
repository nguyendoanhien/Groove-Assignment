import { Component, OnInit } from '@angular/core';
import { LoginModel } from './login.model';
import { UserProfileService } from 'src/app/core/identity/userprofile.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  login = new LoginModel("toilati123vn@gmail.com", "qQ@123");

  constructor(private userProfileService: UserProfileService, private _router: Router) { }

  ngOnInit() {
    // if (localStorage.getItem('token')) {
    //   this._router.navigate(['']);

    // }
  }

  onSubmit() {

    this.userProfileService.logIn(this.login);
    this._router.navigate(['']);
  }

}
