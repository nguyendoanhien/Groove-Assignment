import { Component, OnInit } from '@angular/core';
import { getOrCreateNodeInjector } from '@angular/core/src/render3/di';
import { Note, INote } from 'src/app/models/note';
import { Router, ActivatedRoute } from '@angular/router';
import { NoteService } from '../../services/note.service';
@Component({
  selector: 'app-detail-note',
  templateUrl: './detail-note.component.html',
  styleUrls: ['./detail-note.component.css']
})
export class DetailNoteComponent implements OnInit {

  public note: INote;
  constructor(
    private router: ActivatedRoute,
    private noteService: NoteService
  ) { }

  ngOnInit() {
    const id = +this.router.snapshot.paramMap.get('id');
    this.noteService.getNote(id).subscribe(val => {
      console.log(val);
      this.note = val;
    },
      err => console.log(err));
  }

}
