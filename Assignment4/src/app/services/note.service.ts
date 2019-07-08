import { Injectable } from '@angular/core';
import { INote, Note } from '../models/note';
import { Http, Response } from '@angular/http';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
@Injectable({
  providedIn: 'root'
})
export class NoteService {

  constructor(private _http: HttpClient) { }

  getNotes(): Observable<Note[]> {
    return this._http.get<Note[]>('https://localhost:44316/api/note');
  }

  getNote(id: number): Observable<Note> {
    return this._http.get<Note>(`https://localhost:44316/api/note/${id}`);
  }

  deleteNote(id: number): Observable<INote> {
    return this._http.delete<INote>(`https://localhost:44316/api/note/${id}`);
  }

  editNote(id: number, note: Note): Observable<Note> {
    return this._http.put<Note>(`https://localhost:44316/api/note/${id}`, note);
  }

  addNote(note: Note): Observable<Note>{
    return this._http.post<Note>('https://localhost:44316/api/note',note);
  }

}
