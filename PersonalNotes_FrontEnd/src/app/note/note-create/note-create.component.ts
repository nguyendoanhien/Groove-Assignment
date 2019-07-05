import { Component, OnInit } from '@angular/core';
import { NgForm, FormGroup, FormControl } from '@angular/forms';
import { NoteService } from 'src/app/note.service';
import { Router } from '@angular/router';
import { Note } from 'src/app/note.model';
import { UserProfileService } from 'src/app/core/identity/userprofile.service';

@Component({
  selector: 'app-note-create',
  templateUrl: './note-create.component.html',
  styleUrls: ['./note-create.component.css']
})
export class NoteCreateComponent implements OnInit {

  noteForm: FormGroup;
  constructor(private _noteService: NoteService, private _router: Router, private userProfileService: UserProfileService) { }

  ngOnInit() {
    this.noteForm = new FormGroup({
      title: new FormControl(),
      description: new FormControl()
    });
  }
  createNote() {
    var note: Note = {
      title: this.noteForm.controls.title.value,
      description: this.noteForm.controls.description.value, createdOn: new Date(),
      createdBy: this.userProfileService.CurrentUserName()
    };

    this._noteService.createNote(note).subscribe((note: Note) => {
      console.log(note);
      this._router.navigate(['note','list']);
    }, (error: any) => console.log(error));


  }
}
