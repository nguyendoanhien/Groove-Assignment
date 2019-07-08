import { Component, OnInit } from '@angular/core';
import {Notes} from '../note-list/Notes'
import { FormBuilder, FormGroup, Validators } from '@angular/forms'
import { first } from 'rxjs/operators';
import { AuthenticationService } from '../Services/authentication.service';
import { Router, ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-add-note',
  templateUrl: './add-note.component.html',
  styleUrls: ['./add-note.component.css']
})
export class AddNoteComponent implements OnInit {
  noteForm: FormGroup;
  submitClick = false;
  submitted = false;
  returnUrl: string;
  error = '';


  constructor( private formbulider: FormBuilder,
     private authentication: AuthenticationService,
     private route: ActivatedRoute,
     private router: Router
   
    )  { 
    
    
  }

  ngOnInit() {
    this.noteForm=this.formbulider.group({
      title:['',[Validators.required]],
      description:['',[Validators.required]],
      idbook:['',[Validators.required]],
     })
  }

  get formData() { return this.noteForm.controls; }
  onnote() {
    this.submitted=true;
    if(this.noteForm.invalid){
      return ;
    }
    this.submitClick=true;
    this.authentication.create(this.formData.title.value,this.formData.description.value,this.formData.idbook.value).subscribe(
      val=>{
        console.log(val);
      }, error=>error.log(this.error));
  }
  }