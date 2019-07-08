import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { UserComponent } from './user/user.component';
import { LoginComponent } from './user/login/login.component';
import { HomeComponent } from './home/home.component';
import { AuthGuard } from './auth/auth.guard';
import { NoteListComponent } from './home/note-list/note-list.component';
import { NoteDetailComponent } from './home/note-detail/note-detail.component';
import { RegisterComponent } from './user/register/register.component';
import { ConfirmMailComponent } from './user/confirm-mail/confirm-mail.component';

const routes: Routes = [
  { path: '', redirectTo: '/user/login', pathMatch: 'full' },
  {
    path: 'user', component: UserComponent,
    children: [
      { path: 'login', component: LoginComponent },
      { path: 'register', component: RegisterComponent },
      { path: 'confirm-mail', component: ConfirmMailComponent }


    ]
  },
  {
    path: 'note', component: HomeComponent,
    children: [
      { path: 'list', component: NoteListComponent },
      { path: 'create', component: NoteDetailComponent },
      { path: 'edit/:id', component: NoteDetailComponent }
    ], canActivate: [AuthGuard]
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
