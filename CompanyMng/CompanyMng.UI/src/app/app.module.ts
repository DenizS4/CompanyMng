import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ProductsComponent } from './products/products.component';
import { CompaniesComponent } from './companies/companies.component';
import { LoginComponent } from './login/login.component';
import {FormsModule, ReactiveFormsModule} from "@angular/forms";
import { SignupComponent } from './signup/signup.component';
import { DashboardComponent } from './dashboard/dashboard.component';
import {Client} from "./shared/Api";
import {HttpClientModule} from "@angular/common/http";
import { UsersComponent } from './users/users.component';
import { TopwidgetsComponent } from './dashboard/topwidgets/topwidgets.component';
import { CompaniesbycountryComponent } from './dashboard/companiesbycountry/companiesbycountry.component';
import { ProductsByCompanyComponent } from './dashboard/products-by-company/products-by-company.component';
import { ProductsByCategoryComponent } from './dashboard/products-by-category/products-by-category.component';
import { TopThreeProductsComponent } from './dashboard/top-three-products/top-three-products.component';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';

@NgModule({
  declarations: [
    AppComponent,
    ProductsComponent,
    CompaniesComponent,
    LoginComponent,
    SignupComponent,
    DashboardComponent,
    UsersComponent,
    TopwidgetsComponent,
    CompaniesbycountryComponent,
    ProductsByCompanyComponent,
    ProductsByCategoryComponent,
    TopThreeProductsComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    ReactiveFormsModule,
    FormsModule,
    FontAwesomeModule
  ],
  providers: [Client],
  bootstrap: [AppComponent]
})
export class AppModule { }
