// import { Injectable } from '@angular/core';
// import { HttpClientHHea } from '@angular/common/http';
// import { map } from 'rxjs/operators';

// const httpOptions = {
//   headers: new HttpHeaders({
//     'Content-Type': 'application/json',
//     'Authorization': 'my-auth-token'
//   })
// };

// @Injectable()
// export class AuthenticationService {
//     constructor(private http: HttpClient) { }
//     login(username: string, password: string) {
//         return this.http.post<any>(`https://localhost:44316/api/account`, { username: username, password: password })
//             .pipe(map(user => {
//                 // login successful if there's a jwt token in the response
//                 if (user && user.token) {
//                     // store user details and jwt token in local storage to keep user logged in between page refreshes
//                     localStorage.setItem('currentUser', JSON.stringify(user));
//                 }

//                 return user;
//             }));
//     }

//     logout() {
//         // remove user from local storage to log user out
//         localStorage.removeItem('currentUser');
//     }
// }
