import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AddNoteComponent } from './add-note.component'
import { authGuard } from '../auth/auth.guard';

const routes: Routes = [
  {
    path: '', component: AddNoteComponent,
    canActivate: [authGuard],
    canActivateChild: [authGuard]
  }
];
@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
  declarations:[
 AddNoteComponent
  ],
  providers:[
   authGuard
  ]
})
export class AddNoteRoutingModule { }
