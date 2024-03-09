import {Component, OnInit} from '@angular/core';
import {Router, RouterLink, RouterOutlet} from "@angular/router";
import {MojConfig} from "../moj-config";
import {HttpClient} from "@angular/common/http";
import {DialogService} from "../services/dialog-service";
import {LogoutRequest} from "./logout-request";
declare function init_plugin():any;
@Component({
  selector: 'app-student-page',
  standalone: true,
  imports: [
    RouterOutlet,
    RouterLink
  ],
  templateUrl: './student-page.component.html',
  styleUrl: './student-page.component.css'
})
export class StudentPageComponent implements OnInit{

  constructor(private httpClient:HttpClient, private dialogService:DialogService,
              private router:Router) {
  }

  ngOnInit(): void {
    init_plugin();
  }


  logoutReq!:LogoutRequest;
  odjaviSe() {
    let idStudenta=localStorage.getItem('id');
    let ulogaStudenta=localStorage.getItem('uloga');
    this.logoutReq={
      // @ts-ignore
      uloga:ulogaStudenta,
      // @ts-ignore
      id:idStudenta

    }
    let url=MojConfig.adresa_servera+`/Logout`;
    this.httpClient.post(url, this.logoutReq).subscribe(x=>{
      this.dialogService.openOkDialog("Odjava uspješna!").afterClosed().subscribe((x=>{
        this.router.navigate(['/pocetna'])
      }))
    })
  }
}
