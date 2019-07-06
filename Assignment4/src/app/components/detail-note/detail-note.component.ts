import { Component, OnInit } from '@angular/core';
import { getOrCreateNodeInjector } from '@angular/core/src/render3/di';
import { Note, INote } from 'src/app/models/note';
import { Router, ActivatedRoute, ActivatedRouteSnapshot } from '@angular/router';
import { NoteService } from '../../services/note.service';
import { AuthService } from 'src/app/services/auth.service';
@Component({
  selector: 'app-detail-note',
  templateUrl: './detail-note.component.html',
  styleUrls: ['./detail-note.component.css']
})
export class DetailNoteComponent implements OnInit {
  public note: Note;
  constructor(
    private router: ActivatedRoute,
    private noteService: NoteService,
    private authService: AuthService
  ) { }

  ngOnInit() {
    const id = +this.router.snapshot.paramMap.get('id');
    this.noteService.getNote(id).subscribe(val => {
      console.log(val);
      this.note = val;
    },
      err => console.log(err));
  }
  checkAuth(): boolean {
    const isAuth = this.authService.getIsAuth();
    if (isAuth === 'true') {
      return true;
    } else { return false; }
  }
}
