import { UserProfileService } from './identity/userprofile.service';
import { Injectable } from '@angular/core';
import { CanActivate, Router, ActivatedRouteSnapshot, RouterStateSnapshot, CanActivateChild, ActivatedRoute } from '@angular/router';
import { AuthService } from './auth/auth.service';
import { Observable } from 'rxjs';
import { NoteService } from '../note.service';
import { map } from 'rxjs/operators';

@Injectable()
export class EditGuardService implements CanActivate, CanActivateChild {


  canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): Observable<boolean> {
    const id = +route.paramMap.get('id');
    debugger;
    return this._noteService.getNote(id).pipe(
      map(res => {
        debugger;
        if (res) {
          return true;
        }

        this.router.navigate(['note', 'list']);
      }
    )
  )
}


  canActivateChild(next: ActivatedRouteSnapshot, state: RouterStateSnapshot) {
    debugger;
    return this.canActivate(next, state);
  }

  constructor(
    private router: Router,
    private authService: AuthService, private route: ActivatedRoute, private _noteService: NoteService) {

  }

}
