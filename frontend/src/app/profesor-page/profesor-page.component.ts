import { Component } from '@angular/core';
import {RouterOutlet} from "@angular/router";
declare function init_plugin():any;
@Component({
  selector: 'app-profesor-page',
  standalone: true,
    imports: [
        RouterOutlet
    ],
  templateUrl: './profesor-page.component.html',
  styleUrl: './profesor-page.component.css'
})
export class ProfesorPageComponent {
  constructor() {
  }
  ngOnInit(): void {
    init_plugin();
  }
}
