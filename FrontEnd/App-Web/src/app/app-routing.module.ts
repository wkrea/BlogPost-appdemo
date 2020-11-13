import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { HomeComponent } from './Components/Menu/home/home.component';
import { UsersComponent } from './Components/Users/users/users.component';

const routes: Routes = [
  { path: '',  component: HomeComponent},

  { path: 'users',  component: UsersComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
