import { Injectable } from '@angular/core';
import { CanDeactivate, ActivatedRouteSnapshot, RouterStateSnapshot } from '@angular/router';
import { Observable } from 'rxjs';
import { EditNoteComponent } from '../components/edit-note/edit-note.component';

@Injectable()
export class AddNoteGuard implements CanDeactivate<EditNoteComponent> {
  canDeactivate(component: EditNoteComponent): boolean {
    if (component.editNoteForm.dirty) {
      debugger
      return confirm('Are your sure you want to discard your changes?');
    }
    return true;
  }
}


