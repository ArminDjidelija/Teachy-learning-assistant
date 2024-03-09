import { Component } from '@angular/core';
import {Router, RouterLink, RouterOutlet} from "@angular/router";
import {MojConfig} from "../moj-config";
import {LogoutRequest} from "../student-page/logout-request";
import {HttpClient} from "@angular/common/http";
import {Dialog} from "@angular/cdk/dialog";
import {DialogService} from "../services/dialog-service";
declare function init_plugin():any;
@Component({
  selector: 'app-profesor-page',
  standalone: true,
  imports: [
    RouterOutlet,
    RouterLink
  ],
  templateUrl: './profesor-page.component.html',
  styleUrl: './profesor-page.component.css'
})
export class ProfesorPageComponent {
  constructor(private httpClient:HttpClient, private dialogService:DialogService,
              private router:Router) {
  }
  ngOnInit(): void {
    init_plugin();
  }

  logoutReq!:LogoutRequest;
  odjaviSe() {
    let idProfesora=localStorage.getItem('id');
    let ulogaProf=localStorage.getItem('uloga');
    this.logoutReq={
      // @ts-ignore
      uloga:ulogaProf,
      // @ts-ignore
      id:idProfesora
    }
    let url=MojConfig.adresa_servera+`/Logout`;
    this.httpClient.post(url, this.logoutReq).subscribe(x=>{
      this.dialogService.openOkDialog("Odjava uspješna!").afterClosed().subscribe((x=>{
        this.router.navigate(['/pocetna'])
      }))
    })
  }
}
