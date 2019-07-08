import { Injectable } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import { Notebook } from './notebook.model';
@Injectable({
  providedIn: 'root'
})
export class NotebookService {
  listNotebook:Notebook[];
  readonly BaseURI = 'https://localhost:44386/api';
  constructor(private http: HttpClient) { }

  getAllNotebook() {
    this.http.get(this.BaseURI + '/Notebook').toPromise().then(res => this.listNotebook = res as Notebook[]);
  }

}
