import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatTreeModule } from '@angular/material/tree';

import { NoteRoutingModule } from './note-routing.module';
import { NoteListComponent } from './note-list/note-list.component';
import { MatIconModule, MatProgressBarModule, MatButtonModule } from '@angular/material';
import { NoteCreateComponent } from './note-create/note-create.component';
import { NoteEditComponent } from './note-edit/note-edit.component';
import { DisplayNoteComponent } from './display-note.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import {BsDatepickerModule} from 'ngx-bootstrap/datepicker';
import { ActivatedRouteSnapshot } from '@angular/router';
@NgModule({
  declarations: [NoteListComponent, NoteCreateComponent, NoteEditComponent, DisplayNoteComponent],
  imports: [
    CommonModule,
    NoteRoutingModule,
    MatTreeModule,
    MatIconModule,
    MatProgressBarModule,
    MatButtonModule,
    FormsModule,
    ReactiveFormsModule
  ],
  providers: [
  ]
})
export class NoteModule { }
