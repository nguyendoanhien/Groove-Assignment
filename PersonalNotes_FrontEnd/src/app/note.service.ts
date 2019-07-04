import { Injectable } from '@angular/core';
import { Note } from './note.model';
// import { HttpClient, HttpResponse } from '@angular/common/http';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { catchError } from 'rxjs/operators';


@Injectable({
  providedIn: 'root'
})
export class NoteService {

  constructor(private _httpClient: HttpClient) { }

  getNote(id: number): Observable<Note> {
    return this._httpClient.get<Note>(`${environment.apiUrl}/${id}`);
  }
  getNotes(): Observable<Note[]> {

    //  return this._httpClient.get<Note[]>(environment.apiUrl); //ok
    return this._httpClient.get<Note[]>(environment.apiUrl);

    // return this._httpClient.get(environment.apiUrl).pipe(
    //   map((response: any) => { response }));



    // debugger;
    // var bar = this._httpClient.get('https://localhost:44364/api/notes');
    // return bar.pipe(map(response=>response));
    // return [{ Id: 1, Title: 'Book 1', CreatedBy: 'Hien', CreatedOn: new Date(), Deleted: false, Description: 'None', UpdatedBy: null, UpdatedOn: null, Timestamp: 'none' },

    // { Id: 2, Title: 'Book 2', CreatedBy: 'Hien2', CreatedOn: new Date(), Deleted: false, Description: 'None', UpdatedBy: null, UpdatedOn: null, Timestamp: 'none' }]


  }

  deleteNote(id: number): Observable<void> {

    //  return this._httpClient.get<Note[]>(environment.apiUrl); //ok
    return this._httpClient.delete<void>(`${environment.apiUrl}/${id}`);

    // return this._httpClient.get(environment.apiUrl).pipe(
    //   map((response: any) => { response }));



    // debugger;
    // var bar = this._httpClient.get('https://localhost:44364/api/notes');
    // return bar.pipe(map(response=>response));
    // return [{ Id: 1, Title: 'Book 1', CreatedBy: 'Hien', CreatedOn: new Date(), Deleted: false, Description: 'None', UpdatedBy: null, UpdatedOn: null, Timestamp: 'none' },

    // { Id: 2, Title: 'Book 2', CreatedBy: 'Hien2', CreatedOn: new Date(), Deleted: false, Description: 'None', UpdatedBy: null, UpdatedOn: null, Timestamp: 'none' }]


  }
  editNote(id: number, note: Note): Observable<Note> {
    return this._httpClient.put<Note>(`${environment.apiUrl}/${id}`, note);

  }
  createNote(note: Note): Observable<Note> {
    return this._httpClient.post<Note>(`${environment.apiUrl}`, note);

  }
}
