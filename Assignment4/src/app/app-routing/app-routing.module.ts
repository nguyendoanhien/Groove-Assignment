import { NgModule } from '@angular/core';
import { RouterModule, Routes, ActivatedRoute, ActivatedRouteSnapshot } from '@angular/router';
import { DashboardComponent } from '../components/dashboard/dashboard.component';
import { LoginComponent } from '../components/login/login.component';
import { NoteListComponent } from '../components/note-list/note-list.component';
import { EditNoteComponent } from '../components/edit-note/edit-note.component';
import { DetailNoteComponent } from '../components/detail-note/detail-note.component';
import { AddNoteComponent } from '../components/add-note/add-note.component';
import { AddNoteGuard } from '../services/route-guard.service';
import { PageNotFoundComponent} from '../components/page-not-found/page-not-found.component';
import { RouteGuardCanActivate } from '../services/RouteGuardCanActivate';
const routes: Routes = [
  { path: 'dashboard', component: DashboardComponent },
  { path: 'login', component: LoginComponent },
  { path: 'note/list', component: NoteListComponent },
  { path: 'note/edit/:id', component: EditNoteComponent,
  canActivate: [RouteGuardCanActivate] },
  {
    path: 'note/detail/:id',
    component: DetailNoteComponent,
    canActivate: [RouteGuardCanActivate]
  },
  {
    path: 'note/add',
    component: AddNoteComponent,
    canDeactivate: [AddNoteGuard]
  },
  {
    path: 'notfound',
    component: PageNotFoundComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
