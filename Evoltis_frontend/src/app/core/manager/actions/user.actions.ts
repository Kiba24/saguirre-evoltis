import { createAction, props } from "@ngrx/store";
import { User } from "../../../features/user/models/user";
import { Failure } from "../../failures/failure";
import { UserActionName } from "./user.action-name.enum";

export const updateUser = createAction(
  UserActionName.UPDATE_USER,
  props<{user:User}>()
);

export const createUser = createAction(
  UserActionName.CREATE_USER,
  props<{user:User}>()
);

export const setUserDataError = createAction(
  UserActionName.SET_USER_ERROR,
  props<{error: Failure}>()
);

export const getUserById = createAction(
  UserActionName.GET_USER_BY_ID,
  props<{userId: string}>()
);

export const getUserByIdSuccess = createAction(
  UserActionName.GET_USER_BY_ID_SUCCESS,
  props<{user: User}>()
);

export const loadUsers = createAction(
  UserActionName.LOAD_USERS
);

export const loadedUsers = createAction(
  UserActionName.LOADED_USERS,
  props<{categories: User[]}>()
);

export const createUserSuccess = createAction(
  UserActionName.CREATE_USER_SUCCESS,
  props<{ user: User }>()
);

