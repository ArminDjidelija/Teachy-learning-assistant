import {Component, OnInit} from '@angular/core';
import {ActivatedRoute, Router} from "@angular/router";
import {HttpClient} from "@angular/common/http";
import {NgForOf, NgIf} from "@angular/common";
import {FormsModule} from "@angular/forms";
import {ListaKorisnika, ListaKorisnikaResponse} from "./studenttest-classes";

@Component({
  selector: 'app-student-test',
  standalone: true,
  imports: [
    NgForOf,
    NgIf,
    FormsModule
  ],
  templateUrl: './student-test.component.html',
  styleUrl: './student-test.component.css'
})
export class StudentTestComponent implements OnInit{
  public testID: number = 0;
  pitanjaOdgovori:any[] = [];
  trenutnoPitanje: number = 0;
  korisnickiUnos:any[] = [];
  studentitestoviodgovori:ListaKorisnika[]=[];
  private studentid: number  = 0;
  esejsko: string="";
  constructor(private route:ActivatedRoute, private client:HttpClient, private router:Router) {
  }

  ngOnInit(): void {
    this.studentid=parseInt(localStorage.getItem("id")!);
    this.testID = Number(this.route.snapshot.paramMap.get('id'));
    this.GetPitanjaIOdgovori();
  }

  private GetPitanjaIOdgovori() {
    let url = `https://localhost:7020/GetTestByID?Id=${this.testID}`;
    this.client.get(url).subscribe((data:any)=>
    {
      this.pitanjaOdgovori = data;
    })
  }

  Next(id:number) {
    let odgID:number | null=this.studentitestoviodgovori[this.trenutnoPitanje]?.odgovorID;
    if(this.trenutnoPitanje<this.pitanjaOdgovori.length-1)
    {
      this.studentitestoviodgovori[this.trenutnoPitanje]={
        studentID:this.studentid,
        esejsko:this.esejsko,
        testID:this.testID,
        odgovorID:id
      };
      this.esejsko="";
      this.trenutnoPitanje++;
      console.log(this.pitanjaOdgovori[this.trenutnoPitanje].tekst);
    }
    else
    {
    }
  }

  Previous(id:number) {

    if(this.trenutnoPitanje>0)
    {
      this.studentitestoviodgovori[this.trenutnoPitanje]={
        studentID:this.studentid,
        esejsko:this.esejsko,
        testID:this.testID,
        odgovorID:id
      };
      this.esejsko="";
      this.trenutnoPitanje--;
    }
  }

  OznaciOdgovor(odgovor: any) {
    this.studentitestoviodgovori[this.trenutnoPitanje] = {
      odgovorID:odgovor.id,
      testID:this.testID,
      studentID:this.studentid,
      esejsko:this.esejsko
    }
  }

  Zavrsi(id:number) {
    let odgID:number | null=this.studentitestoviodgovori[this.trenutnoPitanje]?.odgovorID;    this.studentitestoviodgovori[this.trenutnoPitanje]={
      studentID:this.studentid,
      esejsko:this.esejsko,
      testID:this.testID,
      odgovorID:id}
    let obj:ListaKorisnikaResponse={
      listaKorisnika:this.studentitestoviodgovori
    }
    this.client.post(`https://localhost:7020/api/StudentPitanje`,obj,{observe:'response'}).subscribe((data)=>{
      if(data.status==200)
      {
        alert("Ispit zavrsen");
        this.router.navigate(["/student/testovi"]);
      }
    })
  }
}
