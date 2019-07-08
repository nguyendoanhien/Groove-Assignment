import { Component, OnInit } from '@angular/core';
declare var FB: any;
import { NgForm, FormBuilder } from '@angular/forms';
import { Router } from '@angular/router';
import { UserService } from './../../shared/user.service';
@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {


  errLogin: string = null
  constructor(private service: UserService, private router: Router) { }
  formModel = {
    UserName: 'PhuongNam',
    Password: '123456'
  }
  ngOnInit() {

    this.initFB();

    if (localStorage.getItem('token') != null)
      this.router.navigateByUrl('/note/list');
  }

  initFB() {
    (window as any).fbAsyncInit = function () {
      FB.init({
        appId: '422020174947532',
        cookie: true,
        xfbml: true,
        version: 'v3.1'
      });
      FB.AppEvents.logPageView();
    };

    (function (d, s, id) {
      var js, fjs = d.getElementsByTagName(s)[0];
      if (d.getElementById(id)) { return; }
      js = d.createElement(s); js.id = id;
      js.src = "https://connect.facebook.net/en_US/sdk.js";
      fjs.parentNode.insertBefore(js, fjs);
    }(document, 'script', 'facebook-jssdk'));
  }

  submitLogin() {
    FB.login( (response) => {
      this.service.loginFB({ "AccessToken": response.authResponse.accessToken }).subscribe(
        (res: any) => {
          localStorage.setItem('token', res.token);
          localStorage.setItem('username', res.userName);
          this.router.navigateByUrl('/note/list');
          window.location.reload();
        },
        err => {
          this.errLogin = err.error.message;
        }
      )
    });
  }

  getInfoFB() {
    FB.api('/me?fields=id,name,email', function (res) {
      console.log(res);
    });
  }

  onSubmit(form: NgForm) {
    this.service.login(form.value).subscribe(
      (res: any) => {
        localStorage.setItem('token', res.token);
        localStorage.setItem('username', res.userName);
        this.router.navigateByUrl('/note/list');
      },
      err => {
        this.errLogin = err.error.message;
      }
    )
  }




}
