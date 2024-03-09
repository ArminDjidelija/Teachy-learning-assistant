import {Component, OnInit} from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {MojConfig} from "../moj-config";
import {Razred} from "../profesor-page/get-razredi-profesor";
import {Test} from "./get-testovi-profesor";
import {CommonModule, DatePipe, NgForOf} from "@angular/common";
import {FormsModule, ReactiveFormsModule} from "@angular/forms";
import {DialogService} from "../services/dialog-service";
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
  private testid: number|undefined;
  constructor(private http:HttpClient, private dialogService:DialogService) {
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
  public pitanja:any;
  oblastid: number|undefined;
  pitanjadodana: any;
  otvoriTestoviModal: boolean=false;
  studentitestovi:any;

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
        this.dialogService.openOkDialog("Uspješno dodano!");
        this.getTestovi();
      }
    })
  }

  ObrisiTest(id:number) {
    this.http.delete(`https://localhost:7020/Testovi?id=${id}`,{observe:'response'}).subscribe((data)=>{
      if(data.status==200)
      {
        this.dialogService.openOkDialog("Uspješno obrisana!");
        this.getTestovi();
      }
    })
  }

  DodajPitanja(id:number) {

    this.UcitajOblasti(id);
    this.testid=id;
    this.UcitajDodana();
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

  UcitajPitanja() {
   this.http.get(`https://localhost:7020/Pitanje/${this.oblastid}`,{observe:'response'}).subscribe((data)=>{
     if(data.status==200)
     {
       this.pitanja=data.body;
     }
   })
  }

  SpasiPitanje(id:number) {
    let obj = {
      pitanjeId: id,
      testId: this.testid
    }

    this.http.post(`https://localhost:7020/PitanjaTestovi`,obj,{observe:'response'}).subscribe((data)=>{
      if(data.status==200)
      {
        this.dialogService.openOkDialog("Uspješno dodano!");
        this.UcitajDodana();
      }
    })
  }

  private UcitajDodana() {
    this.http.get(`https://localhost:7020/PitanjaTestovi?id=${this.testid}`,{observe:'response'}).subscribe((data)=>{
      if(data.status==200)
      {
        this.pitanjadodana=data.body;
      }
    })
  }

  ObrisiPitanje(id:number) {
    this.http.delete(`https://localhost:7020/PitanjaTestovi?id=${id}`,{observe:'response'}).subscribe((data)=>{
      if(data.status==200)
      {
        this.dialogService.openOkDialog("Uspješno obrisano!");
        this.UcitajDodana();
      }
    })
  }

  OtvoriTestove(id:number) {
    this.otvoriTestoviModal=true;
    this.UcitajTestoveStudente(id);
  }

  private UcitajTestoveStudente(id: number) {
    this.http.get(`https://localhost:7020/TestoviStudent/GetByStudTest?testid=${id}`,{observe:'response'}).subscribe((data)=>{
      if(data.status==200)
      {
        this.studentitestovi=data.body;
      }
    })
  }

  Ocijeni(id:number) {
    this.http.put(`https://localhost:7020/api/TestoviStudentOdgovori?teststudentid=${id}`,1,{observe:'response'}).subscribe((data)=>{

    })
  }
}



