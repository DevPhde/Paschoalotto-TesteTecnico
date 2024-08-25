import { Component, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { User } from 'src/app/interfaces/User.interface';

@Component({
  selector: 'app-detail-user-modal',
  templateUrl: './detail-user-modal.component.html',
  styleUrls: ['./detail-user-modal.component.css']
})
export class DetailUserModalComponent {


  constructor(
    public dialogRef: MatDialogRef<DetailUserModalComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any
  ) { }


  onClose(): void {
    this.dialogRef.close();
  }
}
