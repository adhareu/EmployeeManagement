import { Routes } from '@angular/router';
import { LoginComponent } from './Users/login/login.component';

import { authGuard } from './guards/auth.guard';
import { DepartmentListComponent } from './departments/department-list/department-list.component';
import { DepartmentAddeditComponent } from './departments/department-addedit/department-addedit.component';
import { DesignationListComponent } from './designations/designation-list/designation-list.component';
import { DesignationAddeditComponent } from './designations/designation-addedit/designation-addedit.component';
import { EmployeeListComponent } from './employees/employee-list/employee-list.component';
import { EmployeeAddeditComponent } from './employees/employee-addedit/employee-addedit.component';
import { HomeComponent } from './home/home.component';
export const routes: Routes = [
{path:'login',component:LoginComponent},
{path:'home',component:HomeComponent,canActivate:[authGuard]},
{path:'department',component:DepartmentListComponent,canActivate:[authGuard]},
{path:'department/add',component:DepartmentAddeditComponent,canActivate:[authGuard]},
{path:'department/edit/:id',component:DepartmentAddeditComponent,canActivate:[authGuard]},
{path:'designation',component:DesignationListComponent,canActivate:[authGuard]},
{path:'designation/add',component:DesignationAddeditComponent,canActivate:[authGuard]},
{path:'designation/edit/:id',component:DesignationAddeditComponent,canActivate:[authGuard]},
{path:'employee',component:EmployeeListComponent,canActivate:[authGuard]},
{path:'employee/add',component:EmployeeAddeditComponent,canActivate:[authGuard]},
{path:'employee/edit/:id',component:EmployeeAddeditComponent,canActivate:[authGuard]},
{path:'**',redirectTo:'login'}

];
