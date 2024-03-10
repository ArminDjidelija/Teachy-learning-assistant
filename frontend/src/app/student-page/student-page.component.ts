import {Component, OnInit} from '@angular/core';
import {RouterOutlet} from "@angular/router";
declare function init_plugin():any;
@Component({
  selector: 'app-student-page',
  standalone: true,
  imports: [
    RouterOutlet
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
