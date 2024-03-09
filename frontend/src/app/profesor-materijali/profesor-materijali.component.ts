import { Component } from '@angular/core';
import {HttpClient} from "@angular/common/http";

@Component({
  selector: 'app-profesor-materijali',
  standalone: true,
  imports: [],
  templateUrl: './profesor-materijali.component.html',
  styleUrl: './profesor-materijali.component.css'
})
export class ProfesorMaterijaliComponent {

  constructor(private httpClient:HttpClient) {

  }

}
