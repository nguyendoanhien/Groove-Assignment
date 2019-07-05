import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Note } from 'src/app/models/note';
import { NoteService } from 'src/app/services/note.service';
import { validateConfig } from '@angular/router/src/config';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { AuthService } from 'src/app/services/auth.service';
import { Location } from '@angular/common';
@Component({
  selector: 'app-edit-note',
  templateUrl: './edit-note.component.html',
  styleUrls: ['./edit-note.component.css']
})
export class EditNoteComponent implements OnInit {
  notebookid = 1;
  checkedIsdone: boolean;
  public note: Note;
  submitted = false;
  constructor(
    private router: ActivatedRoute,
    private noteService: NoteService,
    private formBuilder: FormBuilder,
    private route: Router,
    private authService: AuthService,
    private location: Location
  ) { }
  ngOnInit() {
    const id = +this.router.snapshot.paramMap.get('id');
    this.getOldNote(id);
  }
  getOldNote(id: number): Note {
    this.noteService.getNote(id).subscribe(val => {
      console.log(val);
      this.note = val;
    }, err => console.log(err));
    return this.note;
  }

  onSumit() {
    this.submitted = true;
    const id = +this.router.snapshot.paramMap.get('id');
    this.note.notebookId = this.notebookid;
      this.noteService.editNote(id, this.note).subscribe(val => {
        console.log(val);
        this.route.navigate(['note/list']);
        window.alert('Successful Edited');
      }, err => console.log(err));
  }

  selectedOption(id: number) {
    console.log(id);
    this.notebookid = id;
  }
  checkAuth(): boolean {
    const isAuth = this.authService.getIsAuth();
    if (isAuth === 'true') {
      return true;
    } else { return false; }
  }

  goBack() {
    if (confirm('Are your sure you want to discard your changes?')) {
      this.location.back();
    }
  }
}
