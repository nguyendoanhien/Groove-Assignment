import { Component, OnInit } from '@angular/core';
import { AuthService } from './services/auth.service';
// import { HttpClient } from '@angular/http';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
import { UserService } from './services/user.service';
import { stringify } from '@angular/core/src/util';
@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {

  title = 'Assignment4';
  public displayName: string;
  public isLogin: string;
  constructor(
    private authService: AuthService,
    public router: Router,
    public userservice: UserService
  ) {
    this.authService.SetAuth();
  }
  // public IsAuthenticated: boolean = this.authService.isAuthenticated();
  ngOnInit(): void {
    this.userservice.displayNameSub$.subscribe((name: string) => {
      this.displayName = name;
    });
    console.log('dislay name: ' + this.displayName);
    this.userservice.displayNameSub$.subscribe((auth: string) => {
      this.isLogin = auth;
    });
    console.log('isauth name: ' + this.isLogin);
  }

  logout() {
    this.authService.removeToken();
    this.router.navigate(['/login']);
  }
  checkAuth(): boolean {
    return this.isLogin === 'true' ? true : false;
  }

}
