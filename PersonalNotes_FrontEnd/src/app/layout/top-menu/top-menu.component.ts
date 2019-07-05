import { Component, OnInit } from '@angular/core';
import { environment } from '../../../environments/environment';
import { UserProfileService } from 'src/app/core/identity/userprofile.service';
import { UserProfileModel } from 'src/app/account/user-profile/user-profile.model';

@Component({
  selector: 'app-top-menu',
  templateUrl: './top-menu.component.html',
  styleUrls: ['./top-menu.component.css']
})


export class TopMenuComponent implements OnInit {
  public appTitle: string;
  public _userProfileModel: UserProfileModel;
  constructor(private _userProfileService: UserProfileService) {



  }

  ngOnInit() {

    this.appTitle = environment.appName;
    debugger;
    this._userProfileModel = this._userProfileService.CurrentUserProfileModel();
    let GetColor: string = this._userProfileService.color;
    this._userProfileService.displayNameSub$.subscribe((userprofileModel: UserProfileModel) => {

      this._userProfileModel = userprofileModel;
    });
  }

  private logOut() {
    this._userProfileService.logOut();

  }
}
