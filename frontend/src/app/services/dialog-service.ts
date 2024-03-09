import {Injectable} from "@angular/core";
import {MatDialog} from "@angular/material/dialog";
import {OkDialogComponent} from "../ok-dialog/ok-dialog.component";
import {ConfirmDialogComponent} from "../confirm-dialog/confirm-dialog.component";

@Injectable({
  providedIn: 'root'
})

export class DialogService{
  constructor(private dialog:MatDialog) { }

  openConfirmDialog(msg:string){
    return this.dialog.open(ConfirmDialogComponent,{
      width:'390px',
      panelClass:'confirm-dialog-container',
      disableClose:true,
      position:{top:"10px"},
      data:{
        message:msg
      }
    });
  }
  openOkDialog(msg:string){
    return this.dialog.open(OkDialogComponent,{
      width:'390px',
      panelClass:'ok-dialog-container',
      disableClose:true,
      position:{top:"10px"},
      data:{
        message:msg
      }
    });
  }
}
