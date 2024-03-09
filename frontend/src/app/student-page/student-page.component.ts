import {Component, OnInit} from '@angular/core';
import {RouterLink, RouterOutlet} from "@angular/router";
declare function init_plugin():any;
@Component({
  selector: 'app-student-page',
  standalone: true,
  imports: [
    RouterOutlet,
    RouterLink
  ],
  templateUrl: './student-page.component.html',
  styleUrl: './student-page.component.css'
})
export class StudentPageComponent implements OnInit{

  constructor() {
  }

  ngOnInit(): void {
    init_plugin();
  }


}
