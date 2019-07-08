import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import {  NoteListComponent } from './note-list.component'
import { authGuard } from '../auth/auth.guard';

const routes: Routes = [
  {
    path: '', component: NoteListComponent,
    canActivate: [authGuard],
    canActivateChild: [authGuard]
  }
];
@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
  declarations:[
    NoteListComponent
  ],
  providers:[
   authGuard
  ]
})
export class NoteListRoutingModule { }
