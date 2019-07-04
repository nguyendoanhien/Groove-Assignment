import { Injectable } from '@angular/core';
import { INote } from '../models/note';
import { Http, Response } from '@angular/http';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
@Injectable({
  providedIn: 'root'
})
export class NoteService {

  constructor(private _http: HttpClient) { }

  getNotes(): Observable<INote[]> {
    return this._http.get<INote[]>('https://localhost:44316/api/note');
  }

  getNote(id: number): Observable<INote> {
    return this._http.get<INote>(`https://localhost:44316/api/note/${id}`);
  }

  deleteNote(id: number): Observable<INote> {
    return this._http.delete<INote>(`https://localhost:44316/api/note/${id}`);
  }

  editNote(id: number, note: INote): Observable<INote> {
    return this._http.put<INote>(`https://localhost:44316/api/note/${id}`, note);
  }

}
