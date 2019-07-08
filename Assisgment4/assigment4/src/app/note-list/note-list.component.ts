import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms'
import { first } from 'rxjs/operators';
import { AuthenticationService } from '../Services/authentication.service';
import { Router, ActivatedRoute } from '@angular/router';
import {Notes} from './Notes'
import { from } from 'rxjs';
@Component({
  selector: 'app-note-list',
  templateUrl: './note-list.component.html',
  styleUrls: ['./note-list.component.css']
})
export class NoteListComponent implements OnInit {
 public notelist :Notes[];
 public tempemp: Notes
  constructor(

    private authentication: AuthenticationService
  ) {
     
    
   }

  ngOnInit() {
   this.Loaddata();
  
  }
    Loaddata(){
      this.authentication.get().subscribe(val => {
        this.notelist=val;
      console.log(val) ;
        // console.log(val)
      }, err => console.log(err));
      
    }
    Delete(id :number){
      this.tempemp=new Notes();
      this.tempemp.id=id;
      this.authentication.delete(this.tempemp.id).subscribe(val => {
     
      console.log(this.tempemp.id) ;
      this.Loaddata();
        // console.log(val)
      }, err => console.log(err));
    }
    
    }
  




