import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { UserService } from 'src/app/shared/user.service';

@Component({
  selector: 'app-confirm-mail',
  templateUrl: './confirm-mail.component.html',
  styleUrls: ['./confirm-mail.component.css']
})
export class ConfirmMailComponent implements OnInit {

  userId:string;
  token:string;
  constructor(private route: ActivatedRoute,private service: UserService) { }

  async ngOnInit() {
    await this.getParams();
    await this.confirmEmail();
  }

  getParams() {
    this.route.queryParams.subscribe(
      params => {
      this.userId = params.userId;
      this.token = params.token;
      console.log(this.token)
    }); 
  }

  confirmEmail() {
    this.service.confirmEmail({"userId":this.userId,"token":this.token}).subscribe(
      res => console.log(res),
      err => console.log(err)
    );
  }

}
