import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';

import { UploadComponent } from './upload/upload.component';
import { UploadsComponent } from './uploads/uploads.component';
import { EmployeesComponent } from './employees/employees.component';
import { EmployeeEditComponent } from './employees/employee-edit.component';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    UploadComponent,
    UploadsComponent,
    EmployeesComponent,
    EmployeeEditComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'employees', component: EmployeesComponent }, // List
      { path: 'employee/:id', component: EmployeeEditComponent }, //Edit
      { path: 'employee', component: EmployeeEditComponent } //Add new
    ])
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
