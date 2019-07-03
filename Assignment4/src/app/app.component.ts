import { Component } from '@angular/core';
import { AuthService } from './services/auth.service';
// import { HttpClient } from '@angular/http';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
import { User } from './models/user';
@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'Assignment4';
  public username: string;
  constructor(
    private authService: AuthService,
    public router: Router
  ) {
    this.username = 'truc';
  }
  logout() {
    this.authService.removeToken();
    this.router.navigate(['/login']);
  }

  getName() {
    this.authService.getToken();
  }

  public IsAuthenticated: boolean = this.authService.isAuthenticated();

}
