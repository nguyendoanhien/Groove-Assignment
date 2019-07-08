import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';


@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  username:string
  constructor(private router: Router) { 
    
  }

  ngOnInit() {
    this.username =  localStorage.getItem('username');
  }

  onLogout() {
    localStorage.removeItem('token');
    localStorage.removeItem('username');
    this.router.navigateByUrl('/user/login');
  }

}
