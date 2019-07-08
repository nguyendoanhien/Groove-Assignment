import { Injectable } from '@angular/core';
import {Note} from './note.model';
import { HttpClient } from "@angular/common/http";
@Injectable({
  providedIn: 'root'
})
export class NoteService {
  formData:Note;
  readonly BaseURI = 'https://localhost:44386/api';
  listNote:Note[];
  constructor(private http: HttpClient) { }

  getAllNote() {
    this.http.get(this.BaseURI + '/Note').toPromise().then(res => this.listNote = res as Note[])
  }

  getNote(id:number) {
    this.http.get(this.BaseURI + `/Note/${id}`).toPromise().then(res => this.formData = res as Note);
  }

  addNote() {
    return this.http.post(this.BaseURI + '/Note', this.formData);
  }

  deleteNote(id:number) {
   return this.http.delete(this.BaseURI + `/Note/${id}`);
  }

  putNote() {
    return this.http.put(this.BaseURI + '/Note',this.formData);
  }
}
