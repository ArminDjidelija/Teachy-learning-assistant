import { Component } from '@angular/core';
import {RouterLink, RouterOutlet} from "@angular/router";
import {HttpClient} from "@angular/common/http";
import {MojConfig} from "../moj-config";
import {Razred, RazredLista} from "./get-razredi-profesor";
import {CommonModule} from "@angular/common";
declare function init_plugin():any;
@Component({
  selector: 'app-profesor-page',
  standalone: true,
  imports: [
    RouterOutlet,
    RouterLink,
    CommonModule
  ],
  templateUrl: './profesor-page.component.html',
  styleUrl: './profesor-page.component.css'
})
export class ProfesorPageComponent {
  constructor(private http:HttpClient) {
  }
  ngOnInit(): void {
    init_plugin();
    this.getRazred();
  }
  razred:any;
  getRazred(){
    var url = MojConfig.adresa_servera+'/Razredi';
    return this.http.get<Razred>(url).subscribe(x=>{
      this.razred=x;
    });
  }
}
