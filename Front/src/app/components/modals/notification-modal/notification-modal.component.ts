import { Component, Inject } from '@angular/core';
import { RemoveModalComponent } from '../remove-modal/remove-modal.component';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';

@Component({
  selector: 'app-notification-modal',
  templateUrl: './notification-modal.component.html',
  styleUrls: ['./notification-modal.component.css']
})
export class NotificationModalComponent {
  constructor(
    public dialogRef: MatDialogRef<NotificationModalComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any
  ) { }

  Close(): void {
    this.dialogRef.close();
  }
}
