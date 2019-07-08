import { Component, OnInit } from '@angular/core';
import { NoteService } from '../../shared/note.service';
import { Note } from 'src/app/shared/note.model';
import { ToastrService } from 'ngx-toastr';
import { Router } from '@angular/router';
@Component({
  selector: 'app-note-list',
  templateUrl: './note-list.component.html',
  styleUrls: ['./note-list.component.css']
})
export class NoteListComponent implements OnInit {

  constructor(private noteService: NoteService,private toastr: ToastrService,private router: Router) { }

  ngOnInit() {
    this.noteService.getAllNote();
  }
  
  // EditForm(note:Note) {
  //   this.noteService.formData = Object.assign({},note);
  // }

  deleteNote(id:number) {
    this.noteService.deleteNote(id).subscribe(
      res=> {
        this.noteService.getAllNote();
        this.toastr.success('Delete Success');
      },
      err => console.log(err)
    )
  }

  goEdit(id:number) {
  this.router.navigateByUrl(`/note/edit/${id}`);
  }

}
