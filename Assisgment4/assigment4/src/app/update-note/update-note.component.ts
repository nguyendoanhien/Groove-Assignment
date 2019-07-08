import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { AuthenticationService } from '../Services/authentication.service';
import { Router, ActivatedRoute } from '@angular/router';
import {Notes} from '../note-list/Notes'
import { Title } from '@angular/platform-browser';
import { UpperCasePipe } from '@angular/common';
@Component({
  selector: 'app-update-note',
  templateUrl: './update-note.component.html',
  styleUrls: ['./update-note.component.css']
})
export class UpdateNoteComponent implements OnInit {
  noteForm: FormGroup;
  submitClick = false;
  submitted = false;
  returnUrl: string;
  error = '';
 public Note :Notes;

 
  

  constructor( private formbulider: FormBuilder,
    private authentication: AuthenticationService,
    private route: ActivatedRoute,
    private router: Router) { 

    
        
     
    }

  ngOnInit() {
    this.noteForm = this.formbulider.group({
      title: ['',[Validators.required]],
      description: ['',[Validators.required]],
      idbook:['',[Validators.required]],
    })
this.Note= new Notes()
    this.route.paramMap.subscribe(params=>{
      const id=+params.get('id');
    this.authentication.getById(id).subscribe(
      val=>{
        
      this.Note = val;
      // console.log(this.Note);
      this.noteForm = this.formbulider.group({
        title: [this.Note.title,[Validators.required]],
        description: [this.Note.description,[Validators.required]],
        idbook:[this.Note.notebookId,[Validators.required]],
      })
      }, error=>console.log(error));
   

    

    })
  }
// getNotes(id:number){
// this.authentication.getById(id).subscribe(
//   (note:Notes)=>this.EditNotes(note),
//   err=>console.log(err)
// );
// }
// EditNotes(note:Notes){
// this.noteForm.patchValue({
//   title:note.title,
//   description: note.description,
//   idbook:note.notebookId

// })
// }


  get formData() { return this.noteForm.controls; }
  Update() {
    this.submitted=true;
    if(this.noteForm.invalid){
      return ;
    }
    this.submitClick=true;
    this.route.paramMap.subscribe(param=>{
      const id = +this.route.snapshot.paramMap.get('id');
  this.Note=new Notes();
   this.Note.id=id;
 this.Note.title=this.formData.title.value,
this.Note.description=this.formData.description.value,
this.Note.notebookId=this.formData.idbook.value;
console.log(this.Note);
 console.log(id);
 console.log(this.formData.title.value);
      this.authentication.update(this.Note).subscribe(
        
        val=>{
          console.log(val)
        },

       

        errr=>console.log(errr)
      );
    })
    
 
 
  }
}

