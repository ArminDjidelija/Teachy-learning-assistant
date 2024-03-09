import {Component, OnInit} from '@angular/core';
import {FormsModule} from "@angular/forms";
import {RouterLink} from "@angular/router";
import {PrijavaComponent} from "../prijava/prijava.component";
import {virtualManagerService} from "../services/virtualManager-service";

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
export class LandingPageComponent implements OnInit{

  protected readonly PrijavaComponent = PrijavaComponent;

  ngOnInit(): void {
    virtualManagerService.showVirtualManager = false;
  }
}
