import { Component, OnInit } from '@angular/core';
import {Notes} from '../note-list/Notes';
import { AuthenticationService } from '../Services/authentication.service';
import { UserProfileService } from '../Services/user.service'
import {AuthService} from '../auth/auth.service'
@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
 
  public displayName: string;

  constructor(
    authservice:AuthService,
    ) {
  
      
      
    }

  ngOnInit() {
    debugger
    this.displayName=localStorage.getItem('username');
    

  }

}
