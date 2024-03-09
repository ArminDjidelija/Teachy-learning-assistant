import { Routes } from '@angular/router';
import {LandingPageComponent} from "./landing-page/landing-page.component";
import {PrijavaComponent} from "./prijava/prijava.component";
import {StudentPageComponent} from "./student-page/student-page.component";
import {TestoviStudentComponent} from "./testovi-student/testovi-student.component";
import {ProfesorPageComponent} from "./profesor-page/profesor-page.component";
import {ProfesorPitanjaComponent} from "./profesor-pitanja/profesor-pitanja.component";
import {ProfesorMaterijaliComponent} from "./profesor-materijali/profesor-materijali.component";
import {StudentTestComponent} from "./student-test/student-test.component";

export const routes: Routes = [
  {path:'', component:LandingPageComponent, pathMatch:'full'},
  {path:'login', component:PrijavaComponent},
  {path:'student', component:StudentPageComponent, children:[
      {path:'testovi', component:TestoviStudentComponent},
      {path:'test/:id', component: StudentTestComponent}
    ]},
  {path:'profesor', component:ProfesorPageComponent,children:[
      {path:'pitanjaprofesor',component:ProfesorPitanjaComponent},
      {path:'materijali', component:ProfesorMaterijaliComponent},

    ]},
  {path:'pocetna', component:LandingPageComponent, pathMatch:'full'},


];
