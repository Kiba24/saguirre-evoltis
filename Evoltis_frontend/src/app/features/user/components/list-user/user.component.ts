import { Component, ViewChild } from '@angular/core';
import { Store, select } from '@ngrx/store';
import { Observable } from 'rxjs';

import { Table } from 'primeng/table';
import { loadUsers } from '../../../../core/manager/actions/user.actions';
import { UserState } from '../../../../core/manager/reducers/user.reducer';
import { selectAllUsers } from '../../../../core/manager/selectors/user.selectors';
import { User } from '../../models/user';

@Component({
  selector: 'app-user',
  templateUrl: './user.component.html',
  styleUrl: './user.component.css'
})
export class UserComponent {
  @ViewChild('dt') dt: Table | undefined;
  users$: Observable<User[]>;

  constructor(private store: Store<UserState>) {
    this.users$ = this.store.pipe(select(selectAllUsers));
  }

  ngOnInit(): void {
    this.store.dispatch(loadUsers());
  }

  filter(event: Event, field: string): void {
    const input = event.target as HTMLInputElement;
    this.dt?.filter(input.value, field, 'contains');
  }

}
