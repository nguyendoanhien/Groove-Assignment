import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule, HTTP_INTERCEPTORS } from "@angular/common/http";

import {UserService} from './shared/user.service';
import { ReactiveFormsModule, FormsModule } from "@angular/forms";
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HomeComponent } from './home/home.component';
import { UserComponent } from './user/user.component';
import { LoginComponent } from './user/login/login.component';
import { NoteService } from './shared/note.service';
import { AuthInterceptor } from './auth/auth.interceptor';
import { NoteListComponent } from './home/note-list/note-list.component';
import { NoteDetailComponent } from './home/note-detail/note-detail.component';
import { NotebookService } from './shared/notebook.service';
import { ToastrModule } from 'ngx-toastr';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { RegisterComponent } from './user/register/register.component';
import { ConfirmMailComponent } from './user/confirm-mail/confirm-mail.component';
@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    UserComponent,
    LoginComponent,
    NoteListComponent,
    NoteDetailComponent,
    RegisterComponent,
    ConfirmMailComponent
  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    AppRoutingModule,
    HttpClientModule,
    ReactiveFormsModule,
    FormsModule,
    ToastrModule.forRoot()
  ],
  providers: [UserService,NoteService,NotebookService,{provide:HTTP_INTERCEPTORS,useClass:AuthInterceptor,multi:true}],
  bootstrap: [AppComponent]
})
export class AppModule { }
