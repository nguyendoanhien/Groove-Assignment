import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms'
import { first } from 'rxjs/operators';
import { AuthenticationService } from '../Services/authentication.service';
import { Router, ActivatedRoute } from '@angular/router';
import { Token } from '@angular/compiler';
import {AuthService} from '../auth/auth.service'
import { from } from 'rxjs';
import{LoginModel} from '../login/login.model'
@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  loginForm: FormGroup;
  submitClick = false;
  submitted = false;
  returnUrl: string;
  error = '';
  public ulogin:LoginModel;
  constructor(private formBuilder: FormBuilder,
    private route: ActivatedRoute,
    private router: Router,
    private authenticationService: AuthenticationService,
    private Auth:AuthService,
  ) { }

  ngOnInit() {
    this.loginForm = this.formBuilder.group({
      username: ['mo@gmail.com', Validators.required],
      password: ['Ho1234@hu.', Validators.required]
    });
    this.returnUrl = this.route.snapshot.queryParams['returnUrl'] || '/';
  }
  get formData() { return this.loginForm.controls; }
  onLogin() {
    this.submitted = true;
  

    // stop here if form is invalid
    if (this.loginForm.invalid) {
      return;
    }
    this.submitClick = true;
    
    // this.authenticationService.logIn(this.formData.username.value, this.formData.password.value);

      this.authenticationService.login(this.formData.username.value,this.formData.password.value).subscribe((res:any)=>{
      console.log(res.token);
      this.Auth.setToken(res.token);
      debugger
      this.Auth.setusername(this.formData.username.value);
      this.router.navigate(['/home']);
    },error=>console.log(this.error));

  }

  
  //     localStorage.setItem('token',res.token);
  //  console.log( localStorage.setItem('token',res.token));
  //   },
  //   err=>{
  //     console.log("error");
  //   }
//     // )
//   }
// }

}