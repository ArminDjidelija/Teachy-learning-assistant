import {Component, OnInit} from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {DialogService} from "../services/dialog-service";
import {MojConfig} from "../moj-config";
import {StudentTestResp} from "./get-zavrseni-testovi";
import {DatePipe, NgForOf, NgIf} from "@angular/common";

@Component({
  selector: 'app-student-zavrseni-testovi',
  standalone: true,
  imports: [
    NgForOf,
    DatePipe,
    NgIf
  ],
  templateUrl: './student-zavrseni-testovi.component.html',
  styleUrl: './student-zavrseni-testovi.component.css'
})
export class StudentZavrseniTestoviComponent implements OnInit{

  constructor(private httpClient:HttpClient, private dialogService:DialogService) {
  }

  ngOnInit(): void {
    this.dohvatiZavrsene();
  }

  zavrseniTestovi:StudentTestResp[]=[];
  dohvatiZavrsene(){
    let url=MojConfig.adresa_servera+`/Testovi/getzavrseni?studentID=${localStorage.getItem('id')}`;
    this.httpClient.get<StudentTestResp[]>(url).subscribe(x=>{
      this.zavrseniTestovi=x;
    })
  }

}
