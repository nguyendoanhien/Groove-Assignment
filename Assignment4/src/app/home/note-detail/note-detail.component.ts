import { Component, OnInit } from '@angular/core';
import { NoteService } from 'src/app/shared/note.service';
import { NgForm } from '@angular/forms';
import { NotebookService } from 'src/app/shared/notebook.service';
import { ToastrService } from 'ngx-toastr';
import { ActivatedRoute, Router } from "@angular/router";


@Component({
  selector: 'app-note-detail',
  templateUrl: './note-detail.component.html',
  styleUrls: ['./note-detail.component.css']
})
export class NoteDetailComponent implements OnInit {

  idNote:number
  constructor(private noteService: NoteService,private notebookService: NotebookService,private toastr: ToastrService,private route: ActivatedRoute,private router: Router) { }

  async ngOnInit() {
    this.initNote();
    this.notebookService.getAllNotebook();
    await this.getParams();
    if(this.idNote != undefined)
    {
      await this.getNote();

    }
    //await this.getNote();
  }

  getParams() {
    this.route.paramMap.subscribe(params => {
      if(params.get('id')) {
        this.idNote = parseInt(params.get('id'));
      }
    })
  }



  initNote(form?:NgForm) {
    if (form != null)
      form.form.reset();
    this.noteService.formData = {
      id: 0,
      title: '',
      description: '',
      notebookId:0,
      finished: false
    };
  }

  resetForm() {
    this.initNote();
  }

  onSubmit(form: NgForm) {
    if(this.noteService.formData.id == 0)
    {
      this.addNote(form);
    }
    else
      this.putNote(form);
  }

  getNote() {
    this.noteService.getNote(this.idNote);
  }

  addNote(form: NgForm) {
    this.noteService.addNote().subscribe(
      res => {
        this.initNote(form);
        this.toastr.success('Add Note Success');
        this.router.navigateByUrl('/note/list');
      },
      err => console.log(err)
    )
  }

  putNote(form:NgForm) {
    this.noteService.putNote().subscribe(
      res => {
        this.initNote(form);
        this.toastr.success('Update Note Success');
        this.router.navigateByUrl('/note/list');
      },
      err => console.log(err)
    )
  }

}
