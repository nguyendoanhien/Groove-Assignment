import { Injectable } from '@angular/core';
import { HttpRequest, HttpHandler, HttpEvent, HttpInterceptor } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable()
export class httpInterceptor implements HttpInterceptor {
    intercept(request: HttpRequest<any>, newRequest: HttpHandler): Observable<HttpEvent<any>> {
       
        // add authorization header to request

        //Get Token data from local storage
        let tokenInfo = localStorage.getItem('token');


        request = request.clone({
            setHeaders: {                 
                 Authorization: `Bearer ${tokenInfo}`,
                 'Content-Type': 'application/json;charset=utf-8'
               
            }
        });

        // if (tokenInfo && tokenInfo.token) {
        //     request = request.clone({
        //         setHeaders: {
        //             'Accept': 'text/html, application/xhtml+xml, */*',
        //             Authorization: `Bearer ${tokenInfo.token}`,
        //             'Content-Type': 'application/x-www-form-urlencoded;charset=utf-8'
        //         },
        //         responseType: "text" as 'json'
        //     });
        // }

        return newRequest.handle(request);
    }
}