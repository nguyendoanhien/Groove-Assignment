import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { NoteListComponent } from './note-list/note-list.component';
import { AuthGuardService } from '../core/authguard.service';
import { NoteEditComponent } from './note-edit/note-edit.component';
import { NoteCreateComponent } from './note-create/note-create.component';

const routes: Routes = [
  {
    path: '', canActivate: [AuthGuardService], children: [
      { path: '', redirectTo: 'list', pathMatch: 'full' },
      { path: 'list', component: NoteListComponent },
      { path: 'create', component: NoteCreateComponent },
      { path: 'edit/:id', component: NoteEditComponent }
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class NoteRoutingModule { }
