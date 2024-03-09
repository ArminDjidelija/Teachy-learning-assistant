import { Routes } from '@angular/router';
import {LandingPageComponent} from "./landing-page/landing-page.component";
import {PrijavaComponent} from "./prijava/prijava.component";
import {StudentPageComponent} from "./student-page/student-page.component";
import {TestoviStudentComponent} from "./testovi-student/testovi-student.component";

export const routes: Routes = [
  {path:'', component:LandingPageComponent, pathMatch:'full'},
  {path:'login', component:PrijavaComponent},
  {path:'student', component:StudentPageComponent, children:[
      {path:'testovi', component:TestoviStudentComponent},
    ]},
];
