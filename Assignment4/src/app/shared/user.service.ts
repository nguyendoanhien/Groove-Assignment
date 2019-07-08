import { Injectable } from '@angular/core';
import { FormBuilder, Validators, FormGroup } from '@angular/forms';
import { HttpClient, HttpHeaders } from "@angular/common/http";
import { async } from '@angular/core/testing';


@Injectable({
    providedIn: 'root'
  })
export class UserService {
    readonly BaseURI = 'https://localhost:44386/api';

    constructor(private http: HttpClient,private fb: FormBuilder) { }

    formModel = this.fb.group({
        UserName: ['namnph59@gmail.com', Validators.email],
        Password: ['123456', Validators.required],
    })

    login(formData) {
        return this.http.post(this.BaseURI + '/User/Login', formData);
    }

    loginFB(AccessToken:any) {
        return this.http.post(this.BaseURI + '/User/LoginFacebook',AccessToken);
    }

    register() {
        return this.http.post(this.BaseURI + '/User/Register',this.formModel.value);
    }

    confirmEmail(form:any) {
        return this.http.post(this.BaseURI + '/User/ConfirmEmail',form);
    }

}