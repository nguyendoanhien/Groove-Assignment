import { Injectable } from '@angular/core';
import { INote } from '../models/note';
import { Http, Response } from '@angular/http';
import 'rxjs/add/operator/map';
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
}
