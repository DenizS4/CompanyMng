import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import {CompaniesComponent} from "./companies/companies.component";
import {ProductsComponent} from "./products/products.component";
import {LoginComponent} from "./login/login.component";
import {SignupComponent} from "./signup/signup.component";
import {DashboardComponent} from "./dashboard/dashboard.component";
import {UsersComponent} from "./users/users.component";
import {authGuard} from "./shared/auth.guard";
import {roleGuard} from "./shared/role.guard";
import {notAuthGuard} from "./shared/not-auth.guard";

const routes: Routes = [
  {path:"Companies", component:CompaniesComponent, canActivate: [authGuard]},
  {path:"Products", component:ProductsComponent, canActivate: [authGuard]},
  {path:"", component:LoginComponent, canActivate: [notAuthGuard]},
  {path:"login", component:LoginComponent, canActivate: [notAuthGuard]},
  {path:"SignUp", component:SignupComponent, canActivate: [notAuthGuard]},
  {path:"Users", component:UsersComponent, canActivate: [roleGuard]},
  {path:"**", component:DashboardComponent, pathMatch:'full', canActivate: [authGuard]}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
