import { Component } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { createUser } from '../../../../core/manager/actions/user.actions';
import { Store } from '@ngrx/store';
import { MessageService } from 'primeng/api';
import { User } from '../../models/user';
import { Router } from 'express';
import { RouterLink } from '@angular/router';

@Component({
  selector: 'app-create-user',
  templateUrl: './create-user.component.html',
  styleUrl: './create-user.component.css'
})
export class CreateUserComponent {
  userForm: FormGroup;

  constructor(private fb: FormBuilder,    private store: Store,
    private messageService: MessageService
  ) {
    this.userForm = this.fb.group({
      name: ['', Validators.required],
      last_name: ['', Validators.required],
      email: ['', [Validators.required, Validators.email]],
      location_id: [null, [Validators.required, Validators.pattern('^[0-9]*$')]]
    });
  }

  onSubmit() {
    if (this.userForm.valid) {
      const user: User = this.userForm.value;
      this.store.dispatch(createUser({ user }));
      this.messageService.add({
        severity: 'success',
        summary: 'Success',
        detail: 'User created successfully!'
      });

      this.userForm.reset();
    } else {
      this.messageService.add({ severity: 'error', summary: 'Error', detail: 'Please correct the errors in the form.' });
    }
  }
}
