import {Component, OnInit} from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {ActivatedRoute, Router} from "@angular/router";
import {NgForOf, NgIf} from "@angular/common";
import Chart from 'chart.js/auto';

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
  otvorenModal:boolean=false;

  constructor(private client:HttpClient, private route: ActivatedRoute, private router:Router) {
  }


  ngOnInit(): void {
    this.id=parseInt(localStorage!.getItem("id")!);

    this.UcitajRazrede();
    this.createChart();

  }

  createChart() {
    var myChart = new Chart('vrijeme', {
      type: 'bar',
      data: {
        labels: [123,321,11],
        datasets: [
          {
            label: 'Minutes',
            data: [11,22,33],
            type: 'bar', // Ovo postavlja tip na bar za glavni set podataka
            borderWidth: 2,
            order: 2, // Redosled crtanja za barove
            backgroundColor: 'rgba(75, 192, 192, 0.2)', // Boja ispune barova
            borderColor: 'rgba(75, 192, 192, 1)', // Boja linija oko barova
          },
          {
            type: 'line', // Ovo postavlja tip na line za dodatni set podataka
            label: 'Minutes line',
            data: [123,32,1], // Podaci za dodatni set (može biti drugačiji niz podataka ako je potrebno)
            fill: false, // Da li popuniti prostor ispod linije
            order: 1, // Redosled crtanja za liniju
            borderColor: 'rgba(255, 99, 132, 1)', // Boja linije
            tension: 0.1, // Tenzija linije (0.0 - 1.0)

          },
        ],
      },
      options: {
        plugins:{
          title:{
            display:true,
            text:'Sitting time per day'
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
  private UcitajRazrede() {
    this.client.get(`https://localhost:7020/Razredi/byProfesor?id=${this.id}`, {observe:'response'}).subscribe((data)=>{
      if(data.status==200)
      {
        this.razred=data.body
      }
    })
  }

  otvoriModal() {
    this.otvorenModal=true;
  }

  zatvoriModal() {
    this.otvorenModal=false;
  }
}
