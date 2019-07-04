import { Component, OnInit } from '@angular/core';
import { FormGroup,FormBuilder, Validator } from '@angular/forms';

@Component({
  selector: 'app-add-note',
  templateUrl: './add-note.component.html',
  styleUrls: ['./add-note.component.css']
})
export class AddNoteComponent implements OnInit {

  addNoteForm: FormGroup;
  constructor(
    private formGroup: FormGroup,
    private formBuilder: FormBuilder
  ) { }

  ngOnInit( )
  {
    this.addNoteForm = this.formBuilder.group({
      username: ['user2@gmail.com'],
      password: ['B8Z!Z8kdNrERfrF']
    });
  }
  onSubmit() {
    // const a: User = { username: this.f.username.value, password: this.f.password.value };
    // this.userService.Login(a)
    //   .subscribe(val => {
    //     console.log(val);
    //     this.authService.setToken(val);
    //     this.IsLogin();
    //   }, err => {
    //     console.log(err);
    //   });

  }
}
