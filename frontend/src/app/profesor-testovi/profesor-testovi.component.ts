import { Component } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {MojConfig} from "../moj-config";
import {Razred} from "../profesor-page/get-razredi-profesor";
import {Test} from "./get-testovi-profesor";
import {DatePipe, NgForOf} from "@angular/common";
declare function init_plugin():any;
@Component({
  selector: 'app-profesor-testovi',
  standalone: true,
  imports: [
    NgForOf,
    DatePipe
  ],
  templateUrl: './profesor-testovi.component.html',
  styleUrl: './profesor-testovi.component.css'
})
export class ProfesorTestoviComponent {
  constructor(private http:HttpClient) {
  }
  ngOnInit(): void {
    init_plugin();
    this.getTestovi();
  }
  test:any;
  getTestovi(){
    var url = MojConfig.adresa_servera+'/Testovi';
    return this.http.get<Test>(url).subscribe(x=>{
      this.test=x;
    });
  }

}
