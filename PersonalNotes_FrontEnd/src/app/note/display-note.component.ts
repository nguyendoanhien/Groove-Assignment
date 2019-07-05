import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { Note } from '../note.model';
import { NoteService } from '../note.service';
import { Router } from '@angular/router';
import { NoteListComponent } from './note-list/note-list.component';

@Component({
  // selector: 'app-display-note',
  selector: '[my-tr]',
  templateUrl: './display-note.component.html',
  styleUrls: ['./display-note.component.css']
})
export class DisplayNoteComponent implements OnInit {
  @Input() note: Note;
  @Output() notify = new EventEmitter<string>();
  callParent() {
    this.deleteNote();


  }
  constructor(private _noteService: NoteService, private _router: Router/* , private listComponent: NoteListComponent */) { }

  ngOnInit() {
  }
  editNote(/* id: number */) {
    this._router.navigate(['/note/edit', this.note.id]);

  }
  detailNote(/* id: number */) {
    // this._noteService.deleteNote(this.note.id).subscribe(
    //   () => alert(`Note with id${this.note.id} deleted`)
    // );

  }
  deleteNote(/* id: number */) {
    if (confirm("Are you sure to delete " + this.note.id)) {

      this._noteService.deleteNote(this.note.id).subscribe(
        () => { console.log(`note with id =${this.note.id} deleted`); this._router.navigate(['note', 'list']); this.notify.emit();/* ; this.listComponent.getNotes(); */ },
        (err) => alert("You are not permitted !")
        // noteData =>
        // this.notes = noteData
      );

    }

  }
}
