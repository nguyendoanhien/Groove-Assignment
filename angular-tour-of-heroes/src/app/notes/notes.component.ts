import { Component, OnInit } from '@angular/core';
import { Note } from '../note';
import { NoteService } from '../note.service';
@Component({
  selector: 'app-notes',
  templateUrl: './notes.component.html',
  styleUrls: ['./notes.component.css']
})
export class NotesComponent implements OnInit {
  // public notes:Array<Note> = Array<Note>();
  public notes:Note[];
  constructor(private _noteService: NoteService) {


  }

  ngOnInit() {
    this._noteService.getNotes().subscribe(noteData => {
      this.notes = noteData;
    });

  }

}
