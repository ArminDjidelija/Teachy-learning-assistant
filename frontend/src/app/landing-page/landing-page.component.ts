import { Component } from '@angular/core';
import {FormsModule} from "@angular/forms";
import {RouterLink} from "@angular/router";
import {PrijavaComponent} from "../prijava/prijava.component";

@Component({
  selector: 'app-landing-page',
  standalone: true,
  imports: [
    FormsModule,
    RouterLink
  ],
  templateUrl: './landing-page.component.html',
  styleUrl: './landing-page.component.css'
})
export class LandingPageComponent {

  protected readonly PrijavaComponent = PrijavaComponent;
}
