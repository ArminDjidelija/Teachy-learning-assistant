import {Component} from '@angular/core';
import {FormsModule, ReactiveFormsModule} from "@angular/forms";
import {DialogService} from "../services/dialog-service";
import {Router} from "@angular/router";
import {LoginRequest} from "./login-request";
import {MojConfig} from "../moj-config";
import {HttpClient} from "@angular/common/http";
import {diagnose} from "@angular-devkit/build-angular/src/tools/esbuild/angular/compilation/parallel-worker";

@Component({
  selector: 'app-prijava',
  standalone: true,
  imports: [
    FormsModule,
    ReactiveFormsModule
  ],
  templateUrl: './prijava.component.html',
  styleUrl: './prijava.component.css'
})
export class PrijavaComponent {

  constructor(private dialogService: DialogService, private router: Router,
              private httpClient:HttpClient) {
  }

  public loginRequest:LoginRequest={
    lozinka:"",
    email:"",
  }

  logirajSe() {
    let url=MojConfig.adresa_servera+`/Login`;

    this.httpClient.post<LoginRequest>(url,this.loginRequest).subscribe((x=>{
      this.dialogService.openOkDialog("Uspješna prijava!").afterClosed().subscribe(x=>{
        if(x==true){
          this.router.navigate(['/'])
        }
      })
    }), error => {
      this.dialogService.openOkDialog("Pogrešan username/password!")
    });
  }
}
