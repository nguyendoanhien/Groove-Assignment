import { Component, Injectable, OnInit } from '@angular/core';
import { Note } from '../../note.model';
import * as $ from 'jquery';
import { NoteService } from 'src/app/note.service';

@Injectable({
  providedIn: 'root'
})

@Component({
  selector: 'app-note-list',
  templateUrl: './note-list.component.html',
  styleUrls: ['./note-list.component.css']
})
export class NoteListComponent implements OnInit {
  public notes: Note[];
  constructor(private _noteService: NoteService) { }

  ngOnInit() {
    this.getNotes();
  }

  getNotes() {
    debugger;
    this._noteService.getNotes().subscribe(noteData =>
      this.notes = noteData);
  }
  getNotesChild(text:string) {
    this._noteService.getNotes().subscribe(noteData =>
      this.notes = noteData);
  }

}
