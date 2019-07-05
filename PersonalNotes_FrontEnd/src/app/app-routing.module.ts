import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { PageNotFoundComponent } from './page-not-found/page-not-found.component';
import { AuthGuardService } from './core/authguard.service';

const routes: Routes = [
  { path: '', redirectTo: 'account', pathMatch: 'full' },
  {
    path: 'account',
    loadChildren: () => import('./account/account.module').then(mod => mod.AccountModule),
  },
  {
    path: 'note',
    loadChildren: () => import('./note/note.module').then(mod => mod.NoteModule)
  },
  { path: '**', component: PageNotFoundComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
