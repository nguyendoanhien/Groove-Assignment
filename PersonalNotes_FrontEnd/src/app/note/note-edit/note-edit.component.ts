import { Component, OnInit, Input } from '@angular/core';
import { Note } from 'src/app/note.model';
import { FormGroup, FormControl } from '@angular/forms';
import { NoteService } from 'src/app/note.service';
import { Router, ActivatedRoute } from '@angular/router';
import { UserProfileService } from 'src/app/core/identity/userprofile.service';
import { Location } from '@angular/common';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-note-edit',
  templateUrl: './note-edit.component.html',
  styleUrls: ['./note-edit.component.css']
})
export class NoteEditComponent implements OnInit {
  public note: Note;
  test: number = 123;
  noteForm: FormGroup;
  constructor(private location: Location, private route: ActivatedRoute, private _noteService: NoteService, private _router: Router, private userProfileService: UserProfileService) { }

  ngOnInit() {
    const id = +this.route.snapshot.paramMap.get('id');
    console.log(id);
    this.getNote();
  }
  editNote() {
    debugger;
    this._noteService.editNote(this.note.id, this.note).subscribe((note: Note) => {
      console.log(note);
      this._router.navigate(['note', 'list']);
    }, (error: any) => console.log(error));

  }



  getNote(): void {
    debugger;
    const id = +this.route.snapshot.paramMap.get('id');
    this._noteService.getNote(id)
      .subscribe(note => {
        debugger;
        this.note = note
      });
  }

  goBack(): void {
    this.location.back;
  }
}
