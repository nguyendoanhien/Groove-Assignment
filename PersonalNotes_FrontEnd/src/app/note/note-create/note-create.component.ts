import { Component, OnInit, ViewChild } from '@angular/core';
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
  @ViewChild('createForm', null) public createForm: NgForm;
  note: Note;
  constructor(private _noteService: NoteService, private _router: Router, private userProfileService: UserProfileService) { }

  ngOnInit() {

    this.note = {
      title: null,
      description: null,
      createdBy: this.userProfileService.CurrentUserProfileModel().Email,
      createdOn: new Date()

    };
  }
  createNote() {
    this._noteService.createNote(this.note).subscribe((note: Note) => {
      console.log(note);
      this._router.navigate(['note', 'list']);
    }, (error: any) => console.log(error));


  }
}
