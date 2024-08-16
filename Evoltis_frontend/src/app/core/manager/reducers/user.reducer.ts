import { createReducer, on } from "@ngrx/store";
import { User } from "../../../features/user/models/user";
import { Failure } from "../../failures/failure";
import { 
  setUserDataError, 

  getUserById, 
  getUserByIdSuccess, 
  loadUsers, 
  loadedUsers, 
  createUser,
  createUserSuccess
} from "../actions/user.actions"

export interface UserState {
  users: User[];
  selectedUser: User | null;
  error: Failure | null;
  successMessage: string | null;
  loading: boolean;
}

export const initialState: UserState = {
  users: [],
  selectedUser: null,
  error: null,
  successMessage: null,
  loading: false,
};

export const userReducer = createReducer(
  initialState,

  on(loadUsers, state => ({
    ...state,
    loading: true
  })),

  on(loadedUsers, (state, { categories }) => ({
    ...state,
    users: categories,
    loading: false
  })),

  on(getUserById, state => ({
    ...state,
    loading: true
  })),

  on(getUserByIdSuccess, (state, { user }) => ({
    ...state,
    selectedUser: user,
    loading: false
  })),

  on(setUserDataError, (state, { error }) => ({
    ...state,
    error: error,
    loading: false
  })),

  on(createUser, (state) => ({
    ...state,
    error: null,
    loading: false
  })),

  on(createUserSuccess, (state, { user }) => ({
    ...state,
    users: [...state.users, user],
    error: null
  })),
);
