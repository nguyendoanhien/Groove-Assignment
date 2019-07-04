import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { TopMenuComponent } from './layout/top-menu/top-menu.component';
import { UserProfileService } from './core/identity/userprofile.service';
import { AuthService } from './core/auth/auth.service';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { MaterialModule } from './core/material-module.module';
import { AuthGuardService } from './core/authguard.service';
import { PageNotFoundComponent } from './page-not-found/page-not-found.component';
import { TokenInterceptor } from './core/auth/token.interceptor';
import { NoteRoutingModule } from './note/note-routing.module';
import { NoteListComponent } from './note/note-list/note-list.component';
import { NoteCreateComponent } from './note/note-create/note-create.component';
import { NoteEditComponent } from './note/note-edit/note-edit.component';
import { DisplayNoteComponent } from './note/display-note.component';
import { FormsModule } from '@angular/forms';

@NgModule({
  declarations: [
    AppComponent,
    TopMenuComponent,
    PageNotFoundComponent,
    // NoteListComponent,
    // NoteCreateComponent,
    // NoteEditComponent,
    // DisplayNoteComponent
  ],
  imports: [
    BrowserModule,
    // NoteRoutingModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    HttpClientModule,
    MaterialModule,
    FormsModule

  ],
  exports: [
  ],
  providers: [
    {
      provide: HTTP_INTERCEPTORS,
      useClass: TokenInterceptor,
      multi: true
    },
    UserProfileService,
    AuthService,
    AuthGuardService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
