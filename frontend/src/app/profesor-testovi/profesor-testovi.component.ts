import {Component, OnInit} from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {MojConfig} from "../moj-config";
import {Razred} from "../profesor-page/get-razredi-profesor";
import {Test} from "./get-testovi-profesor";
import {CommonModule, DatePipe, NgForOf} from "@angular/common";
import {FormsModule, ReactiveFormsModule} from "@angular/forms";
declare function init_plugin():any;
@Component({
  selector: 'app-profesor-testovi',
  standalone: true,
  imports: [
    NgForOf,
    DatePipe,
    CommonModule,
    ReactiveFormsModule,
    FormsModule
  ],
  templateUrl: './profesor-testovi.component.html',
  styleUrl: './profesor-testovi.component.css'
})
export class ProfesorTestoviComponent implements OnInit{
  public predmeti: any;
  private id: number | undefined;
  public razredi: any | null;
  constructor(private http:HttpClient) {
  }
  ngOnInit(): void {
    this.id=parseInt(localStorage.getItem("id")!);
    init_plugin();
    this.getTestovi();
    this.UcitajPredmete();
    this.UcitajRazrede();
  }
  otvoriDijalog:boolean=false;
  test:any;
  predmetid: number |undefined ;
  razredid: number|undefined;
  nazivtesta: string | undefined;
  trajanje: number|undefined;
  aktivanDo: string | undefined;
  DodajPitanjeDijalog: boolean|undefined;
  public oblasti: any;
  getTestovi(){
    var url = MojConfig.adresa_servera+'/Testovi';
    return this.http.get<Test>(url).subscribe(x=>{
      this.test=x;
    });
  }


  private UcitajPredmete() {
      this.http.get(`https://localhost:7020/GetPredmetiByProfesor?profesorId=${this.id}`,{observe:'response'}).subscribe((data)=>{
        this.predmeti=data.body;
      })
    }

  private UcitajRazrede() {
    this.http.get(`https://localhost:7020/Razredi/byProfesor?id=${this.id}`, {observe:'response'}).subscribe((data)=>{
      if(data.status==200)
      {
        this.razredi=data.body

      }
    })
  }

  KreirajTest() {
    let obj = {
      naziv: this.nazivtesta,
      trajanje: this.trajanje,
      aktivanDo: this.aktivanDo,
      razredId: this.razredid,
      predmetId: this.predmetid,
      profesorId: this.id
    }

    this.http.post(`https://localhost:7020/Testovi`,obj,{observe:'response'}).subscribe((data)=>{
      if(data.status==200)
      {
        alert("Uspjesno dodano");
        this.getTestovi();
      }
    })
  }

  ObrisiTest(id:number) {
    this.http.delete(`https://localhost:7020/Testovi?id=${id}`,{observe:'response'}).subscribe((data)=>{
      if(data.status==200)
      {
        alert("Uspjesno obrisana")
        this.getTestovi();
      }
    })
  }

  DodajPitanja(id:number) {

    this.UcitajOblasti(id);
    this.DodajPitanjeDijalog=true;

  }

  protected UcitajOblasti(id: number) {
    this.http.get(`https://localhost:7020/Oblast?PredmetId=${id}`,{observe:'response'}).subscribe((data)=>{
      if(data.status==200)
      {
        this.oblasti=data.body;
      }
    })
  }
}



