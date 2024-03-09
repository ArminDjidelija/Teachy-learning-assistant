import {Component, OnInit} from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {ActivatedRoute, Router} from "@angular/router";
import {NgForOf, NgIf} from "@angular/common";
import Chart from 'chart.js/auto';
import {MojConfig} from "../moj-config";
import {GetPodaciByProffRespo} from "./podaci-by-profesor";

@Component({
  selector: 'app-profesor-pocetna',
  standalone: true,
  imports: [
    NgForOf,
    NgIf,
  ],
  templateUrl: './profesor-pocetna.component.html',
  styleUrl: './profesor-pocetna.component.css'
})
export class ProfesorPocetnaComponent implements OnInit {
  private id: number | undefined;
  public razred: any;
  otvorenModal: boolean = false;

  constructor(private client: HttpClient, private route: ActivatedRoute, private router: Router) {
  }


  ngOnInit(): void {
    this.id = parseInt(localStorage!.getItem("id")!);

    this.UcitajRazrede();
    //this.createChart(pod.prosjecnaProlaznost, pod.brojStudenata);

  }

  createChart(prosjecnaProlaznost: number, brojStudenata: number, ukupnoBodova: number) {
    console.log(prosjecnaProlaznost, brojStudenata, ukupnoBodova);
    var myChart = new Chart('prolaznost', {
      type: 'bar',
      data: {
        labels: [prosjecnaProlaznost],
        datasets: [
          {
            label: 'Izlaznost',
            data: brojStudenata,
            type: 'bar',
            borderWidth: 2,
            order: 2,
            backgroundColor: 'rgba(75, 192, 192, 0.2)',
            borderColor: 'rgba(75, 192, 192, 1)',
          },
          {
            type: 'line',
            label: 'Prolaznost',
            data: prosjecnaProlaznost,
            fill: false,
            order: 1,
            borderColor: 'rgba(255, 99, 132, 1)',
            tension: 0.1,

          },
        ],
      },
      options: {
        plugins: {
          title: {
            display: true,
            text: 'Sitting time per day'
          }
        },
        scales: {
          y: {
            beginAtZero: true,
          },
        },
      },
    });
  }

  podaci: GetPodaciByProffRespo[] = [];

  UcitajRazrede() {
    let url = MojConfig.adresa_servera + `/GrafPodaciProfesor?profesorId=${this.id}`;
    this.client.get<GetPodaciByProffRespo[]>(url).subscribe(x => {
      this.podaci = x;
    })
  }

  otvoriModal() {
    this.otvorenModal = true;
  }

  zatvoriModal() {
    this.otvorenModal = false;
  }
}
