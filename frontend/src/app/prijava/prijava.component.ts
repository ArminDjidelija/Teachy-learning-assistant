import { Component } from '@angular/core';
import {FormsModule, ReactiveFormsModule} from "@angular/forms";
import {DialogService} from "../services/dialog-service";

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

  constructor(private dialogService:DialogService) {
  }

  korisnickoIme: string='';
  lozinka: string='';

  logirajSe() {
    if(this.korisnickoIme=='profesor' && this.lozinka==='profesor'){
      this.dialogService.openOkDialog("Prijava uspješna!").afterClosed().subscribe(res=>{
        if(res==true){
          //navigiraj na profu
        }
      });
    }
    else if(this.korisnickoIme==='ucenik' && this.lozinka==='ucenik'){
      this.dialogService.openOkDialog("Prijava uspješna!").afterClosed().subscribe(res=>{
        if(res==true){
          //navigiraj na studenta
        }
      });
    }
    else if(this.korisnickoIme=="" || this.lozinka==""){
      this.dialogService.openOkDialog("Pogrešno korisničko ime/lozinka!");
    }
  }
}
