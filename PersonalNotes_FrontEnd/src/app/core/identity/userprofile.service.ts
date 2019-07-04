import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
// import { UserProfileState } from '../../states/userprofile.state';
import { JwtHelperService } from '@auth0/angular-jwt';
import { Subject } from 'rxjs';
import { map } from 'rxjs/operators';
import { UserProfileModel } from 'src/app/account/user-profile/user-profile.model';
import { environment } from '../../../environments/environment';
import { LoginModel } from '../../account/login/login.model';
import { AuthService } from '../auth/auth.service';

const authUrl = environment.authUrl;

@Injectable()
export class UserProfileService {

  private userProfile: UserProfileModel;

  constructor(private router: Router,
    private authService: AuthService,
    private http: HttpClient) {
    this.userProfile = new UserProfileModel();
  }

  public displayNameSub$: Subject<UserProfileModel> = new Subject<UserProfileModel>();


  logIn(loginModel: LoginModel) {

    const userName = loginModel.userName;
    const password = loginModel.password;
    if (userName !== '' && password !== '') {
      const body = {
        Username: userName,
        Password: password
      };
      const httpOptions = {
        headers: new HttpHeaders({
          'Accept': 'text/html, application/xhtml+xml, */*',
          'Content-Type': 'application/json'
        }),
        responseType: 'text' as 'json'
      };

      return this.http.post<string>(authUrl, body, httpOptions)
        .pipe(
          map((token: string) => { this.parseJwtToken(token); localStorage.setItem('token', token) })
        )
        .subscribe(

        );
    }
  }

  logOut(): Promise<boolean> {
    this.authService.clearToken(); // Hien them

    this.displayNameSub$.next(null); // Xoa

    return this.router.navigate(['account', 'login']);
  }

  public CurrentUserName(): string {
    this.displayNameSub$.subscribe((userprofileModel: UserProfileModel) => {

      this.userProfile = userprofileModel;
    });
    return this.userProfile.Email;
  }
  public parseJwtToken(token: string) {
    debugger;
    const jwt = token;
    const jwtHelper = new JwtHelperService();
    const decodedJwt = jwtHelper.decodeToken(jwt);
    this.authService.setToken(jwt);
    const userProfileModel = new UserProfileModel();
    userProfileModel.UserName = decodedJwt.UserName;
    userProfileModel.DisplayName = decodedJwt.DisplayName;
    userProfileModel.Email = decodedJwt.email;
    userProfileModel.SecurityAccessToken = jwt;
    this.userProfile = userProfileModel;
    this.displayNameSub$.next(this.userProfile/* .DisplayName */);
  }

  loadStoredUserProfile() {
    const token = this.authService.getToken();
    if (token.length > 0) {
      this.parseJwtToken(token);
    }
  }
}
