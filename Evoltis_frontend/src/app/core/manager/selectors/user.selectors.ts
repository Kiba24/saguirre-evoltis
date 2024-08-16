import { createSelector } from '@ngrx/store';
import { UserState } from '../reducers/user.reducer';


export const selectUserState = (state: any) => state.user; 

export const selectAllUsers = createSelector(
  selectUserState,
  (state: UserState) => state.users
);
