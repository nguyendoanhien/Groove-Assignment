import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LoginComponent } from './login/login.component';

import { httpInterceptor } from './Interceptor/httpInterceptor';
 
import { AuthorizationCheck } from './Services/authorizationCheck'
import { AuthenticationService } from './Services/authentication.service';
import { TokenInterceptor } from './Services/token.interceptor';
 import { NoteListComponent } from './note-list/note-list.component';
import {AuthService} from './auth/auth.service'
import { from } from 'rxjs';

import { AddNoteComponent } from './add-note/add-note.component';
import { UpdateNoteComponent } from './update-note/update-note.component';
import { UserProfileComponent } from './user-profile/user-profile.component';
import { UserProfileService } from './Services/user.service'

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
   NoteListComponent,  
  
   AddNoteComponent,
    UpdateNoteComponent,
    UserProfileComponent
   
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    RouterModule
  ],
  providers: [
    { provide: HTTP_INTERCEPTORS, useClass: TokenInterceptor, multi: true },
    // { provide: HTTP_INTERCEPTORS, useClass: ErrorInterceptor, multi: true },
   AuthenticationService, AuthorizationCheck,AuthService, UserProfileService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
