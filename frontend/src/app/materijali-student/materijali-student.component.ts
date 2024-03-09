import {Component} from '@angular/core';
import {FormsModule} from "@angular/forms";
import {NgForOf, NgIf} from "@angular/common";
import {PredmetiGetAll, PredmetiGetAllResponse} from "../profesor-materijali/get-all-predmeti";
import {MojConfig} from "../moj-config";
import {HttpClient} from "@angular/common/http";
import {OblastResponse} from "../profesor-materijali/get-oblasti-by-predmet";

@Component({
  selector: 'app-materijali-student',
  standalone: true,
  imports: [
    FormsModule,
    NgForOf,
    NgIf
  ],
  templateUrl: './materijali-student.component.html',
  styleUrl: './materijali-student.component.css'
})
export class MaterijaliStudentComponent {

  constructor(private httpClient:HttpClient) {
    this.dohvatiPredmete();
  }

  predmeti: PredmetiGetAllResponse[] = [];
  odabraniPredmet: number=1;

  dohvatiPredmete() {
    let url = MojConfig.adresa_servera + `/Predmeti`;
    this.httpClient.get<PredmetiGetAll>(url).subscribe(x => {
      this.predmeti = x;
    })
  }

  oblasti: OblastResponse[] = [];
  ucitajOblast(odabraniPredmet: number) {
    let url = MojConfig.adresa_servera + `/Oblast?PredmetId=${odabraniPredmet}`;
    this.httpClient.get<OblastResponse[]>(url).subscribe(x => {
      this.oblasti = x;
      console.log(this.oblasti);
    })
  }
}
