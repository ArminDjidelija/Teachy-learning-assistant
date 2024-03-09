import {Component, Inject} from '@angular/core';
import {MatIcon} from "@angular/material/icon";
import {MatButton} from "@angular/material/button";
import {MAT_DIALOG_DATA, MatDialogClose, MatDialogRef} from "@angular/material/dialog";
import {OkDialogComponent} from "../ok-dialog/ok-dialog.component";

@Component({
  selector: 'app-confirm-dialog',
  standalone: true,
  imports: [
    MatIcon,
    MatButton,
    MatDialogClose
  ],
  templateUrl: './confirm-dialog.component.html',
  styleUrl: './confirm-dialog.component.css'
})
export class ConfirmDialogComponent {

  // @ts-ignore
  constructor(@Inject(MAT_DIALOG_DATA) public data,
              public dialogRef:MatDialogRef<ConfirmDialogComponent>) {
  }
  closeDialog() {
    this.dialogRef.close(false);
  }
}
