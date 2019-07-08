import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { LoginComponent } from './login/login.component';



import { AddNoteComponent } from './add-note/add-note.component';
import { UpdateNoteComponent } from './update-note/update-note.component';
import { NoteListComponent} from './note-list/note-list.component'

const routes: Routes = [ {path: 'login', component: LoginComponent},
  {path:'addnote',component:AddNoteComponent,
// loadChildren:()=>import('./add-note/add-note-routing.module').then(add=>add.AddNoteRoutingModule),
},
  {path:'editnote/:id',component:UpdateNoteComponent},
  {path: 'note' ,component:NoteListComponent,
//  loadChildren: () => import('./note-list/note-list-routing.module').then(a=> a.NoteListRoutingModule),

},
 {
  path: 'home',
  loadChildren: () => import('./home/home-routing.module').then(mod => mod.HomeRoutingModule),
},
 
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
