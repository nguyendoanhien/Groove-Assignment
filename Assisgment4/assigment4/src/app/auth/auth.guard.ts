import { Injectable } from '@angular/core';
import { CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot, CanActivateChild, Router } from '@angular/router';
import { AuthService} from './auth.service'

@Injectable()
export class authGuard implements CanActivate, CanActivateChild {

    canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot) {
        var isAuthenticated = this.authService.isAuthenticated();
        if (isAuthenticated) {
            return true;
        }
        else {
            this.router.navigate(['/login']);
            return false;
        }
    }

    canActivateChild(next: ActivatedRouteSnapshot, state: RouterStateSnapshot) {
        return this.canActivate(next, state);
    }

    constructor(
        private router: Router,
        private authService: AuthService ) {

    }

}

