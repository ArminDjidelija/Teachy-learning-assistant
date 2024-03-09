import {Component, OnInit} from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {TestoviStudent, TestoviStudentResponse} from "./get-testovi-student";
import {MojConfig} from "../moj-config";
import {NgForOf} from "@angular/common";
import {RouterLink} from "@angular/router";
import {virtualManagerService} from "../services/virtualManager-service";

@Component({
  selector: 'app-testovi-student',
  standalone: true,
  imports: [
    NgForOf,
    RouterLink
  ],
  templateUrl: './testovi-student.component.html',
  styleUrl: './testovi-student.component.css'
})
export class TestoviStudentComponent implements OnInit{

  constructor(private httpClient:HttpClient) {
  }

  ngOnInit(): void {
    this.dohvatiTestoveZaStudenta();
  }

  testovi:TestoviStudentResponse[]=[];
  dohvatiTestoveZaStudenta(){
    let url=MojConfig.adresa_servera+`/TestoviStudent`;
    this.httpClient.get<TestoviStudent>(url).subscribe((x=>{
      this.testovi=x;
    }))
  }


  protected readonly virtualManagerService = virtualManagerService;
}
