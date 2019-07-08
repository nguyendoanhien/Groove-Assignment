import { Injectable } from '@angular/core';
import { Note } from './note.model';
// import { HttpClient, HttpResponse } from '@angular/common/http';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Observable, throwError, of } from 'rxjs';
import { environment } from 'src/environments/environment';
import { catchError, map } from 'rxjs/operators';
import { Router } from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class NoteService {

  constructor(private _httpClient: HttpClient, private router: Router) { }

  getNote(id: number): Observable<Note> {
    return this._httpClient.get<Note>(`${environment.apiUrl}/${id}`).pipe(map(data => data),
      catchError(this.handleError<Note>('getHeroes', null))

    );
  }
  private handleError<T>(operation = 'operation', result?: T) {
    return (error: any): Observable<T> => {

      // TODO: send the error to remote logging infrastructure
      console.error(error); // log to console instead

      // TODO: better job of transforming error for user consumption
      console.log(`${operation} failed: ${error.message}`);

      // Let the app keep running by returning an empty result.
      return of(result as T);
    };
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
    debugger;
    return this._httpClient.put<Note>(`${environment.apiUrl}/${id}`, note);

  }
  createNote(note: Note): Observable<Note> {
    return this._httpClient.post<Note>(`${environment.apiUrl}`, note);

  }

  // private handleError(errorResponse: HttpErrorResponse) {
  //   if (errorResponse.error instanceof ErrorEvent) {
  //     console.log('Client Side Error', errorResponse.error.message);
  //   } else {
  //     console.log('Server Side Error', errorResponse.error.message);
  //   }
  //   return throwError('Uknown error !!!');
  // }
}
