import { Component, OnInit } from '@angular/core';
import { NoteService } from '../../services/note.service';
import { pipe, Observable } from 'rxjs';
import { Note, INote } from '../../models/note';
import { routerNgProbeToken } from '@angular/router/src/router_module';
import { Router } from '@angular/router';
@Component({
  selector: 'app-note-list',
  templateUrl: './note-list.component.html',
  styleUrls: ['./note-list.component.css']
})
export class NoteListComponent implements OnInit {
  public notes: INote[];
  constructor(
    private noteService: NoteService,
    private router: Router
  ) { }

  ngOnInit() {
    this.getNoteList();
  }

  getNoteList() {
    this.noteService.getNotes().subscribe(val => {
      console.log(val);
      this.notes = val;
    }, err => console.log(err)
    );
  }

  getNote(id: number) {
    this.noteService.getNote(id).subscribe(val => {
      console.log(val);
      this.router.navigate([`/note/detail/${id}`]);
      }, err => console.log(err));
  }

  deleteNote(id: number) {
    this.noteService.deleteNote(id).subscribe(val => {
      console.log(val);
      this.getNoteList();
    }, err => console.log(err));

  }
}
