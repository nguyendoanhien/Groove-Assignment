import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { DashboardComponent } from '../components/dashboard/dashboard.component';
import { LoginComponent } from '../components/login/login.component';
import { NoteListComponent } from '../components/note-list/note-list.component';
import { EditNoteComponent } from '../components/edit-note/edit-note.component';
import { DetailNoteComponent } from '../components/detail-note/detail-note.component';
import { AddNoteComponent } from '../components/add-note/add-note.component';
const routes: Routes = [
  { path: 'dashboard', component: DashboardComponent },
  { path: 'login', component: LoginComponent },
  { path: 'note/list', component: NoteListComponent },
  { path: 'note/edit/:id', component: EditNoteComponent },
  { path: 'note/detail/:id', component: DetailNoteComponent },
  { path: 'note/add', component: AddNoteComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
