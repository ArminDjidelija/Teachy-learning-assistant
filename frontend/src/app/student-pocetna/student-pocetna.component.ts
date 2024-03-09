import {Component, OnInit} from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {MojConfig} from "../moj-config";
import {NgForOf} from "@angular/common";
import {PredmResponse} from "./dohvati-predmete";

@Component({
  selector: 'app-student-pocetna',
  standalone: true,
  imports: [
    NgForOf
  ],
  templateUrl: './student-pocetna.component.html',
  styleUrl: './student-pocetna.component.css'
})
export class StudentPocetnaComponent implements OnInit{

  constructor(private httpClient:HttpClient) {
  }

  ngOnInit(): void {
    this.dohvatiPredmete();
  }

  predmeti:PredmResponse[]=[];
  dohvatiPredmete(){
    let id=localStorage.getItem('id');
    console.log(id)
    let url=MojConfig.adresa_servera+`/Predmeti?studentId=${id}`;
    this.httpClient.get<PredmResponse[]>(url).subscribe((x=>{
      this.predmeti=x;
    }))
  }


}
