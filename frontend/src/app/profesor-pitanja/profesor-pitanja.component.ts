import {Component, OnInit} from '@angular/core';
import {ActivatedRoute, Router, RouterOutlet} from "@angular/router";
import {HttpClient} from "@angular/common/http";
import {NgForOf, NgIf} from "@angular/common";
import {FormsModule} from "@angular/forms";
import {Chart} from "chart.js";
import {DialogService} from "../services/dialog-service";

@Component({
  selector: 'app-profesor-pitanja',
  standalone: true,
  imports: [
    RouterOutlet,
    NgForOf,
    NgIf,
    FormsModule
  ],
  templateUrl: './profesor-pitanja.component.html',
  styleUrl: './profesor-pitanja.component.css'
})
export class ProfesorPitanjaComponent implements OnInit {

  public pitanja: any;
  public odabranoPitanje:any;
  odgovoriModal: boolean=false;
  odgovori:any;
  oblasti:any;
  // @ts-ignore
  public odabranitip: number;
  tipovipitanja:any;
  pitanjeModal: boolean=false;
  public id: number | undefined;
  predmeti:any;
  odabraniPredmet: any;
  // @ts-ignore
  public predmetid: number;
  odabranaoblast: number|undefined;
  tekstOdgovora: string |undefined;
  bodovi: number |undefined;
  tekstOdgovoraPravi: number|undefined;
  tacanodgovor: boolean=false;
  esejsko: string|undefined;

  constructor(private client:HttpClient, private route: ActivatedRoute, private router:Router,
              private dialogService:DialogService) {
  }


  ngOnInit(): void {
    this.id=parseInt(localStorage.getItem("id")!);
    this.UcitajPitanja();
    this.UcitajTipove();
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
    this.UcitajOblasti(pit.id);
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

  protected UcitajOblasti(id: number) {
    this.client.get(`https://localhost:7020/Oblast?PredmetId=${id}`,{observe:'response'}).subscribe((data)=>{
      if(data.status==200)
      {
        this.oblasti=data.body;
      }
    })
  }

  private UcitajTipove() {
    this.client.get(`https://localhost:7020/TipPitanja`,{observe:'response'}).subscribe((data)=>{
      if(data.status==200)
      {
        this.tipovipitanja=data.body;
      }
    })
  }

  OtvoriPitanjeModal() {
    this.UcitajPredmete();
    this.pitanjeModal=true;
  }

  private UcitajPredmete() {
    this.client.get(`https://localhost:7020/GetPredmetiByProfesor?profesorId=${this.id}`,{observe:'response'}).subscribe((data)=>{
      this.predmeti=data.body;
    })
  }

  PromjenaPredmeta() {
    let id = parseInt((document.getElementById("selectpredmet") as HTMLSelectElement).value);
    this.client.get(`https://localhost:7020/Oblast?PredmetId=${this.predmetid}`, {observe:'response'}).subscribe((data)=>{
      if(data.status==200)
      {
        this.oblasti=data.body;
      }
    })
  }

  SpasiPitanje() {
    let obj = {
      tekst: this.tekstOdgovora,
      brojBodova: this.bodovi,
      oblastId: this.odabranaoblast,
      tipPitanjaId: this.odabranitip,
      profesorId: this.id
    }

    this.client.post(`https://localhost:7020/Pitanje`,obj,{observe:'response'}).subscribe((data)=>{
      if(data.status==200)
      {
        this.dialogService.openOkDialog("Uspješno dodavanje!");
      }
    })
  }

  Klik() {
    this.tacanodgovor=!this.tacanodgovor;
  }

  SpremiOdgovor() {
    let obj = {
      tekst: this.tekstOdgovoraPravi,
      tacan: this.tacanodgovor,
      esejsko: this.esejsko,
      pitanjeId: this.odabranoPitanje.id
    };
    this.client.post(`https://localhost:7020/Odgovori`,obj,{observe:'response'}).subscribe((data)=>{
      if(data.status==200)
      {
        this.dialogService.openOkDialog("Uspješno dodan odgovor!");
        this.UcitajOdgovore(this.odabranoPitanje.id);
      }
    })
  }

  ObrisiOdgovor(id:number) {
    this.client.delete(`https://localhost:7020/Odgovori?id=${id}`,{observe:'response'}).subscribe((data)=>{
      if(data.status==200)
      {
        this.dialogService.openOkDialog("Uspješno obrisano!");
        this.UcitajOdgovore(this.odabranoPitanje.id);
      }
    })
  }

  ObrisiPitanje(id:number) {
    this.client.delete(`https://localhost:7020/Pitanje?id=${id}`,{observe:'response'}).subscribe((data)=>{
      if(data.status==200)
      {
        this.dialogService.openOkDialog("Uspješno obrisano!");
        this.UcitajPitanja();
      }
    })
  }
}
