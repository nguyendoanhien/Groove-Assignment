import { Injectable } from '@angular/core';
import { Note } from './note';
import { INoteTemp } from './notetemp';
// import { HttpClient, HttpResponse } from '@angular/common/http';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { map } from 'rxjs/operators';
import { environment } from 'src/environments/environment';


@Injectable({
  providedIn: 'root'
})
export class NoteService {

  constructor(private _httpClient: HttpClient) { }

  getNotes(): Observable<Note[]> {
     return this._httpClient.get<Note[]>(environment.apiUrl); //ok

    // return this._httpClient.get(environment.apiUrl).pipe(
    //   map((response: any) => { response }));



    // debugger;
    // var bar = this._httpClient.get('https://localhost:44364/api/notes');
    // return bar.pipe(map(response=>response));
    // return [{ Id: 1, Title: 'Book 1', CreatedBy: 'Hien', CreatedOn: new Date(), Deleted: false, Description: 'None', UpdatedBy: null, UpdatedOn: null, Timestamp: 'none' },

    // { Id: 2, Title: 'Book 2', CreatedBy: 'Hien2', CreatedOn: new Date(), Deleted: false, Description: 'None', UpdatedBy: null, UpdatedOn: null, Timestamp: 'none' }]


  }
}
