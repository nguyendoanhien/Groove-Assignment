import { Component, OnInit } from '@angular/core';
import { UserService } from 'src/app/shared/user.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {

  constructor(private service: UserService, private router: Router) { }

  ngOnInit() {
  }

  onSubmit() {
    this.service.register().subscribe(
      res => {
        this.router.navigateByUrl('/note/list');
      },
      err => console.log(err)
    );
  }

}
