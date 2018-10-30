import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { CounterComponent } from './counter/counter.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';
import { CompanyCreateComponent } from './company/company-create/company-create.component';
import { CompanyListComponent } from './company/company-list/company-list.component';
import { EmployeeListComponent } from './employee/employee-list/employee-list.component';
import { EmployeeCreateComponent } from './employee/employee-create/employee-create.component';
import { CompanyService } from './company/company.service';
import { CompanyComponent } from './company/company-list/company/company.component';
import { CompanyOptionsComponent } from './company/company-options/company-options.component';
import { CompanyEditComponent } from './company/company-edit/company-edit.component';
import { EmployeeService } from './employee/employee.service';
import { EmployeeComponent } from './employee/employee-list/employee/employee.component';
import { EmployeeEditComponent } from './employee/employee-edit/employee-edit.component';
import { LoaderComponent } from './loader/loader.component';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    CounterComponent,
    FetchDataComponent,
    CompanyCreateComponent,
    CompanyListComponent,
    EmployeeListComponent,
    EmployeeCreateComponent,
    CompanyComponent,
    CompanyOptionsComponent,
    CompanyEditComponent,
    EmployeeComponent,
    EmployeeEditComponent,
    LoaderComponent,
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', component: CompanyListComponent, pathMatch: 'full' },
      { path: 'counter', component: CounterComponent },
      { path: 'fetch-data', component: FetchDataComponent },
      { path: 'create', component: CompanyCreateComponent },
      { path: 'company-list', component: CompanyListComponent },
      { path: 'company-option/:id', component: CompanyOptionsComponent },
      { path: 'company-edit/:id', component: CompanyEditComponent },
      { path: 'company/:id/employee-create', component: EmployeeCreateComponent },
      { path: 'company/:id/employee-list', component: EmployeeListComponent },
      { path: "company/:compId/employee-edit/:empId", component: EmployeeEditComponent }
    ])
  ],
  providers: [CompanyService, EmployeeService],
  bootstrap: [AppComponent]
})
export class AppModule { }
