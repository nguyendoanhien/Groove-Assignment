import { UserProfileService } from './identity/userprofile.service';
import { Injectable } from '@angular/core';

import { CanActivate, Router, ActivatedRouteSnapshot, RouterStateSnapshot, CanActivateChild, CanDeactivate } from '@angular/router';
import { AuthService } from './auth/auth.service';
import { NoteCreateComponent } from '../note/note-create/note-create.component';

@Injectable()
export class AuthGuardService implements CanActivate, CanActivateChild, CanDeactivate<NoteCreateComponent> {
  canDeactivate(component: NoteCreateComponent): boolean {
    if (component.createForm.dirty) {
      return confirm('Are you sure you want to discard your changes ?');
    }
    return true;
  }
  canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot) {
    console.log('check parent');
    debugger;
    var isAuthenticated = this.authService.isAuthenticated();
    if (isAuthenticated) {
      return true;
    }
    else {
      this.router.navigate(['/account/login']);
      return false;
    }
  }

  canActivateChild(next: ActivatedRouteSnapshot, state: RouterStateSnapshot) {
    debugger;
    console.log('check child');
    return this.canActivate(next, state);
  }

  constructor(
    private router: Router,
    private authService: AuthService) {

  }

}
