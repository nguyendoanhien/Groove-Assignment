import { Injectable } from '@angular/core';
import { CanDeactivate, ActivatedRouteSnapshot, RouterStateSnapshot } from '@angular/router';
import { Observable } from 'rxjs';
import { AddNoteComponent } from '../components/add-note/add-note.component';

@Injectable()
export class AddNoteGuard implements CanDeactivate<AddNoteComponent> {
  canDeactivate(component: AddNoteComponent): boolean {
    if (component.addNoteForm.dirty) {
      debugger
      return confirm('Are your sure you want to discard your changes?');
    }
    return true;
  }
}


