import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';


import {NoteListRoutingModule} from './note-list-routing.module'
import { NoteListComponent} from './note-list.component';
@NgModule({
  declarations: [NoteListComponent],
  imports: [
    CommonModule,
    NoteListRoutingModule,
   
  ],
  providers:[
      
   
  ]
})
export class NoteListModule { }
