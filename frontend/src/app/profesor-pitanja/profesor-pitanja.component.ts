import { Component } from '@angular/core';
import {ActivatedRoute, Router, RouterOutlet} from "@angular/router";
import {HttpClient} from "@angular/common/http";
import {NgForOf, NgIf} from "@angular/common";

@Component({
  selector: 'app-profesor-pitanja',
  standalone: true,
  imports: [
    RouterOutlet,
    NgForOf,
    NgIf
  ],
  templateUrl: './profesor-pitanja.component.html',
  styleUrl: './profesor-pitanja.component.css'
})
export class ProfesorPitanjaComponent {

  public pitanja: any;
  public odabranoPitanje:any;
  odgovoriModal: boolean=false;
  odgovori:any;
  constructor(private client:HttpClient, private route: ActivatedRoute, private router:Router) {
  }


  ngOnInit(): void {
    this.UcitajPitanja();


  }

  private UcitajPitanja() {
    this.client.get(`https://localhost:7020/PitanjaByPredmet`,{observe:'response'}).subscribe((data)=>{
      if(data.status==200)
      {
        this.pitanja=data.body;
      }
    })
  }

  OtvoriModalOdgovori(pit: any) {
    this.odabranoPitanje=pit;
    this.UcitajOdgovore(pit.id);
    this.odgovoriModal=true;


  }

  private UcitajOdgovore(num:number) {
    this.client.get(`https://localhost:7020/api/GetOdgovoriByPitanje?pitanjeId=${num}`, {observe:'response'}).subscribe((data)=>{
      if(data.status==200)
      {
        this.odgovori=data.body;
      }
    })
  }
}
