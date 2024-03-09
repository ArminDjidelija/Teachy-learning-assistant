import {Component, OnInit} from '@angular/core';
import {ActivatedRoute} from "@angular/router";
import {HttpClient} from "@angular/common/http";
import {NgForOf, NgIf} from "@angular/common";
import {FormsModule} from "@angular/forms";

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
  constructor(private route:ActivatedRoute, private client:HttpClient) {
  }

  ngOnInit(): void {

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

  Next() {
    if(this.trenutnoPitanje<this.pitanjaOdgovori.length-1)
    {
      this.trenutnoPitanje++;
      console.log(this.pitanjaOdgovori[this.trenutnoPitanje].tekst);
    }
    else
    {
    }
  }

  Previous() {
    if(this.trenutnoPitanje>0)
    {
      this.trenutnoPitanje--;
    }
  }
}
