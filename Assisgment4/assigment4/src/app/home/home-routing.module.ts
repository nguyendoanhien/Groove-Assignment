import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from './home.component'
import { authGuard } from '../auth/auth.guard';

const routes: Routes = [
  {
    path: '', component: HomeComponent,
    canActivate: [authGuard],
    canActivateChild: [authGuard]
  }
];
@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
  declarations:[
    HomeComponent
  ],
  providers:[
   authGuard
  ]
})
export class HomeRoutingModule { }
