import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { AppRoutingModule } from './app-routing/app-routing.module';
import { AppComponent } from './app.component';
import { DashboardComponent } from './components/dashboard/dashboard.component';
import { LoginComponent } from './components/login/login.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { AuthService } from './services/auth.service';
import { UserService } from './services/user.service';
import { TokenInterceptor } from './services/token.interceptor';
import { NoteListComponent } from './components/note-list/note-list.component';
import { EditNoteComponent } from './components/edit-note/edit-note.component';
import { DetailNoteComponent } from './components/detail-note/detail-note.component';
import { AddNoteComponent } from './components/add-note/add-note.component';
import { AddNoteGuard } from './services/route-guard.service';
import { PageNotFoundComponent } from './components/page-not-found/page-not-found.component';
import { RouteGuardCanActivate } from './services/RouteGuardCanActivate';
@NgModule({
  declarations: [
    AppComponent,
    DashboardComponent,
    LoginComponent,
    NoteListComponent,
    EditNoteComponent,
    DetailNoteComponent,
    AddNoteComponent,
    PageNotFoundComponent
    ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    HttpClientModule,
    ReactiveFormsModule
  ],
  providers: [{
    provide: HTTP_INTERCEPTORS,
    useClass: TokenInterceptor,
    multi: true
  },
    AuthService,
    UserService,
    AddNoteGuard,
    RouteGuardCanActivate
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
