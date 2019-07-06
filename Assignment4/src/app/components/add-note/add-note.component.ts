import { Component, OnInit, ViewChild } from '@angular/core';
import { FormGroup, FormBuilder, Validators, MaxLengthValidator, NgForm } from '@angular/forms';
import { Note } from 'src/app/models/note';
import { NoteService } from 'src/app/services/note.service';
import { UserService } from 'src/app/services/user.service';
import { Router } from '@angular/router';
import { AuthService } from 'src/app/services/auth.service';
import { Location } from '@angular/common';
@Component({
  selector: 'app-add-note',
  templateUrl: './add-note.component.html',
  styleUrls: ['./add-note.component.css']
})
export class AddNoteComponent implements OnInit {
  notebookId = 1;
  addnoteForm: FormGroup;
  submitted = false;
  constructor(
    private formBuilder: FormBuilder,
    private noteService: NoteService,
    private userService: UserService,
    private router: Router,
    private location: Location,
    private authService: AuthService
  ) { }

  ngOnInit() {
    this.addnoteForm = this.formBuilder.group({
      title: ['', [Validators.required, Validators.maxLength(50)]],
      description: ['', Validators.required]
    });
  }
  get f() { return this.addnoteForm.controls; }

  onSubmit() {
    this.submitted = true;
    if (this.addnoteForm.invalid) { return }
    else { this.addNote(); };
  }

  addNote() {
    const _title: string = this.f.title.value;
    const _description: string = this.f.description.value;
    let _username: string;
    this.userService.displayNameSub$.subscribe((name: string) => {
      _username = name;
    });
    const newNote: Note = {
      title: _title,
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
      window.alert('Note Added Successfully');
      this.router.navigate(['/note/list']);
    }, err => console.log(err));
  }

  selectedOption(id: number) {
    console.log(id);
    this.notebookId = id;
  }
  checkAuth(): boolean {
    const isAuth = this.authService.getIsAuth();
    if (isAuth === 'true') {
      return true;
    } else { return false; }
  }
  goBack() {
    if (window.confirm('Are you sure you want to leave this page?'))
      this.location.back();
  }
}
