import { Routes } from '@angular/router';
import {LandingPageComponent} from "./landing-page/landing-page.component";
import {PrijavaComponent} from "./prijava/prijava.component";
import {StudentPageComponent} from "./student-page/student-page.component";
import {TestoviStudentComponent} from "./testovi-student/testovi-student.component";
import {ProfesorPageComponent} from "./profesor-page/profesor-page.component";
import {ProfesorPitanjaComponent} from "./profesor-pitanja/profesor-pitanja.component";
import {ProfesorTestoviComponent} from "./profesor-testovi/profesor-testovi.component";
import {ProfesorMaterijaliComponent} from "./profesor-materijali/profesor-materijali.component";
import {ProfesorPocetnaComponent} from "./profesor-pocetna/profesor-pocetna.component";
import {MaterijaliStudentComponent} from "./materijali-student/materijali-student.component";
import {StudentPocetnaComponent} from "./student-pocetna/student-pocetna.component";
import {StudentZavrseniTestoviComponent} from "./student-zavrseni-testovi/student-zavrseni-testovi.component";

export const routes: Routes = [
  {path:'', component:LandingPageComponent, pathMatch:'full'},
  {path:'login', component:PrijavaComponent},
  {path:'student', component:StudentPageComponent, children:[
      {path:'testovi', component:TestoviStudentComponent},
      {path:'materijali', component:MaterijaliStudentComponent},
      {path:'pocetna', component:StudentPocetnaComponent},
      {path:'zavrseni', component:StudentZavrseniTestoviComponent},

    ]},
  {path:'profesor', component:ProfesorPageComponent,children:[
      {path:'pitanjaprofesor',component:ProfesorPitanjaComponent},
      {path:'testoviprofesor',component:ProfesorTestoviComponent},
      {path:'materijali', component:ProfesorMaterijaliComponent},
      {path:'pocetna',component: ProfesorPocetnaComponent}


    ]},
  {path:'pocetna', component:LandingPageComponent, pathMatch:'full'},


];
