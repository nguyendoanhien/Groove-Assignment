import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import {FormGroup,Validators, FormBuilder} from '@angular/forms';
import { CookieService } from 'ngx-cookie-service';
import {Router} from '@angular/router'
import {AuthService,LoginInfo} from '../../services/auth.service';
@Component({
  selector: 'app-dashboard',
  templateUrl: 'login.component.html'
})
export class LoginComponent implements OnInit { 
  constructor(private router:Router,private http: HttpClient, private authservice:AuthService, private fb :FormBuilder,private cookieService: CookieService){

  }
  LoginForm : FormGroup;
  data:LoginInfo = {} as LoginInfo;
  Isloginfail=false;
  loading =false;
  ngOnInit() {
    this.LoginForm = this.fb.group({
      username:[this.data.Username,Validators.compose([Validators.required])],
      password:[this.data.Password,Validators.compose([Validators.required])]
    })
  }
  onLoginFormSubmit(){
    this.loading = true;
    console.log(this.data);
    this.authservice.login(this.data).subscribe(res=>{
      this.loading= false;
      this.Isloginfail=false;
      // Save to cookies
      this.cookieService.set(btoa('userInfo'),btoa(JSON.stringify(res)));
      // Set loggedIn status
      this.authservice.setLoggedIn(true);
      // Ridirect to home page
      this.router.navigate(['/dashboard']);
    }, err=>{console.log(err),this.Isloginfail=true,this.loading=false})
  }
}
