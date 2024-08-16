import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { UserComponent } from './features/user/components/list-user/user.component';
import { CreateUserComponent } from './features/user/components/create-user/create-user.component';

const routes: Routes = [
  { path: 'users', component: UserComponent },
  { path: '', redirectTo: '/users', pathMatch: 'full' }, 
  { path: 'users/new', component: CreateUserComponent },

  { path: '**', redirectTo: '/users' } 
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
