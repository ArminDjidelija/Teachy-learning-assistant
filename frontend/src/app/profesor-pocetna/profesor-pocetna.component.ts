import {Component, OnInit} from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {ActivatedRoute, Router} from "@angular/router";
import {NgForOf} from "@angular/common";

@Component({
  selector: 'app-profesor-pocetna',
  standalone: true,
  imports: [
    NgForOf
  ],
  templateUrl: './profesor-pocetna.component.html',
  styleUrl: './profesor-pocetna.component.css'
})
export class ProfesorPocetnaComponent implements OnInit {
  private id: number | undefined;
  public razred: any;

  constructor(private client:HttpClient, private route: ActivatedRoute, private router:Router) {
  }


  ngOnInit(): void {
    this.id=parseInt(localStorage!.getItem("id")!);

    this.UcitajRazrede();

  }

  private UcitajRazrede() {
    this.client.get(`https://localhost:7020/Razredi/byProfesor?id=${this.id}`, {observe:'response'}).subscribe((data)=>{
      if(data.status==200)
      {
        this.razred=data.body
      }
    })
  }
}
