import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Note } from 'src/app/models/note';
import { NoteService } from 'src/app/services/note.service';
import { validateConfig } from '@angular/router/src/config';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';

@Component({
  selector: 'app-edit-note',
  templateUrl: './edit-note.component.html',
  styleUrls: ['./edit-note.component.css']
})
export class EditNoteComponent implements OnInit {
  editnoteForm: FormGroup;
  public note: Note;
  constructor(
    private router: ActivatedRoute,
    private noteService: NoteService,
    private formBuilder: FormBuilder,
    private route: Router
  ) { }

  ngOnInit() {
    const id = +this.router.snapshot.paramMap.get('id');
    this.getOldNote(id);
    
  }
  getOldNote(id: number): Note {
    debugger
    this.noteService.getNote(id).subscribe(val => {
      console.log(val);
      this.note = val;
    }, err => console.log(err));
    return this.note;
  }

  onSumit(){
    const id = +this.router.snapshot.paramMap.get('id');
    this.noteService.editNote(id,this.note).subscribe(val=>{
      console.log(val);
      this.route.navigate(['note/list']);
      window.alert('Successful Edited')
    },err=>console.log(err));
  }
}
