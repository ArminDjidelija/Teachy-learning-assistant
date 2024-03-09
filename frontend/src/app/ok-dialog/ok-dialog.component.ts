import {Component, Inject} from '@angular/core';
import {MatButton} from "@angular/material/button";
import {MAT_DIALOG_DATA, MatDialogClose, MatDialogRef} from "@angular/material/dialog";
import {MatIcon} from "@angular/material/icon";

@Component({
  selector: 'app-ok-dialog',
  standalone: true,
  imports: [
    MatButton,
    MatDialogClose,
    MatIcon
  ],
  templateUrl: './ok-dialog.component.html',
  styleUrl: './ok-dialog.component.css'
})
export class OkDialogComponent {

  // @ts-ignore
  constructor(@Inject(MAT_DIALOG_DATA) public data,
              public dialogRef:MatDialogRef<OkDialogComponent>) {
  }
  closeDialog() {
    this.dialogRef.close(false);
  }
}
