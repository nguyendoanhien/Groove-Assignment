import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Note } from 'src/app/models/note';
import { NoteService } from 'src/app/services/note.service';
import { UserService } from 'src/app/services/user.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-add-note',
  templateUrl: './add-note.component.html',
  styleUrls: ['./add-note.component.css']
})
export class AddNoteComponent implements OnInit {
  notebookId: number = 1;
  addnoteForm: FormGroup;
  constructor(
    private formBuilder: FormBuilder,
    private noteService: NoteService,
    private userService: UserService,
    private router: Router
  ) { }

  ngOnInit() {
    this.addnoteForm = this.formBuilder.group({
      tittle: ['', Validators.required],
      description: ['', Validators.required],
      notebookid: ['', Validators.required],
    });
  }
  get f() { return this.addnoteForm.controls; }

  onSubmit() {
    this.addNote();
  }

  addNote() {
    debugger
    const _tittle: string = this.f.tittle.value;
    const _description: string = this.f.description.value;
    let _username: string;
    this.userService.displayNameSub$.subscribe((name: string) => {
      _username = name;
    });
    const newNote: Note = {
      title: _tittle,
      description: _description,
      notebookId: this.notebookId,
      id: 0,
      isdone: false,
      createdBy: _username,
      createdOn: null,
      updatedOn: null,
      updatedBy: null,
      deleted: false,
      timestamp: null
    };
    this.noteService.addNote(newNote).subscribe(val => {
      console.log(val);
      window.alert('Added Successfully');
      this.router.navigate(['/note/list']);
    }, err => console.log(err));
  }

  selectedOption(id: number) {
    console.log(id);
    this.notebookId = id;
  }
}
