import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class ApiService {
  constructor() { }
  baseUrl = "https://localhost:44330/api/";
  auth = {
    login : this.baseUrl + 'auth/login',
    user:this.baseUrl + 'users',
    note: this.baseUrl + 'note',
    notebook:this.baseUrl+'notebook'
  };
  getApiUrl(name:string){
    return this.baseUrl + name;
  }
}
