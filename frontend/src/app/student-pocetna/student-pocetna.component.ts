import {Component, OnInit} from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {Predmeti, PredmetiGet} from "./dohvati-predmete";
import {MojConfig} from "../moj-config";
import {NgForOf} from "@angular/common";

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

  predmeti:PredmetiGet[]=[];
  dohvatiPredmete(){
    let url=MojConfig.adresa_servera+`/Predmeti`;
    this.httpClient.get<Predmeti>(url).subscribe((x=>{
      this.predmeti=x;
    }))
  }


}
