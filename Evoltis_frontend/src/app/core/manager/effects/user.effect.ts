import { Injectable } from '@angular/core';
import { Actions, createEffect, ofType } from '@ngrx/effects';
import { of } from 'rxjs';
import { catchError, map, switchMap } from 'rxjs/operators';


import { UserService } from '../../../features/user/services/user.service';
import { createUser, createUserSuccess, getUserById, getUserByIdSuccess, loadedUsers, loadUsers, setUserDataError } from '../actions/user.actions';

@Injectable()
export class UserEffects {

  constructor(
    private actions$: Actions,
    private userService: UserService
  ) {}

  loadUsers$ = createEffect(() => this.actions$.pipe(
    ofType(loadUsers),
    switchMap(() => this.userService.getUsers()
      .pipe(
        map(users => loadedUsers({ categories: users })),
        catchError(error => of(setUserDataError({ error })))
      )
    )
  ));

  getUserById$ = createEffect(() => this.actions$.pipe(
    ofType(getUserById),
    switchMap(action => this.userService.getUserById(action.userId)
      .pipe(
        map(user => getUserByIdSuccess({ user })),
        catchError(error => of(setUserDataError({ error })))
      )
    )
  ));

  createUser$ = createEffect(() => this.actions$.pipe(
    ofType(createUser),
    switchMap(action => this.userService.createUser(action.user).pipe(
      map(user => createUserSuccess({ user })),
      catchError(error => of(setUserDataError({ error })))
    ))
  ));
  

}
