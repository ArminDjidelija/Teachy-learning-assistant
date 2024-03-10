import { Routes } from '@angular/router';
import {LandingPageComponent} from "./landing-page/landing-page.component";
import {PrijavaComponent} from "./prijava/prijava.component";

export const routes: Routes = [
  {path:'', component:LandingPageComponent, pathMatch:'full'},
  {path:'login', component:PrijavaComponent}
];
