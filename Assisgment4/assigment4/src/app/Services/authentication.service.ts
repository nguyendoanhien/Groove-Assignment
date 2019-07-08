import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Notes} from '../note-list/Notes'
import { Router } from '@angular/router';

import { AuthService } from '../auth/auth.service';
import { environment } from '../../environments/environment';

import { LoginModel } from '../login/login.model';
import { UserProfileState } from '../states/userprofile.state'
import { JwtHelperService } from '@auth0/angular-jwt';
import { Subject } from 'rxjs';
import { catchError, retry, map } from 'rxjs/operators';
import { UserProfileModel } from '../user-profile/user-profile.model';

@Injectable()
export class AuthenticationService {
    public Note:Notes;
    private userProfile: UserProfileModel;
    
    constructor(private http: HttpClient,
        private router: Router,
        private authService: AuthService,
       
        ) {  this.userProfile = new UserProfileModel(); }
        public displayNameSub$: Subject<string> = new Subject<string>();
    login(username:string,password:string) : Observable<any> {
        return this.http.post<any>('https://localhost:44393/Indentity/ClientAccount/login', { username, password });         
    }
    public parseJwtToken(token: string) {
        const jwt = token;
        const jwtHelper = new JwtHelperService();
        const decodedJwt = jwtHelper.decodeToken(jwt);
        this.authService.setToken(jwt);
        const userProfileModel = new UserProfileModel();
        userProfileModel.UserName = decodedJwt.UserName;
        userProfileModel.DisplayName = decodedJwt.DisplayName;
        userProfileModel.SecurityAccessToken = jwt;
        this.userProfile = userProfileModel;
        this.displayNameSub$.next(this.userProfile.DisplayName);
    }

  
 get():Observable<Notes[]>{
    return this.http.get<Notes[]>('https://localhost:44393/api/Notes');     
 }
 delete(id:number):Observable<Notes>{
     return this.http.delete<Notes>(`https://localhost:44393/api/Notes/${id}`)
 }
 create(title:string ,description:string,Idbook:number):Observable<Notes>{
    return this.http.post<any>('https://localhost:44393/api/Notes',{title,description,Idbook});    
 }
 getById(id:number):Observable<Notes>{
     
    return this.http.get<Notes>(`https://localhost:44393/api/Notes/${id}`); 

 } 
 update(note:Notes) :Observable<Notes>{
     return this.http.put<Notes>(`https://localhost:44393/api/Notes/${note.id}`,note
     ,{ headers : new HttpHeaders({

        'Content-Type': 'application/json;charset=utf-8'
     })
    })
  
     
    }
     
   
     
    logout() {
        // remove user from local storage to log user out
        localStorage.removeItem('TokenInfo');
    }
}