import { Component, OnInit, ViewChild } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { User } from 'src/app/interfaces/User.interface';
import { InteractionService } from 'src/app/services/interaction/interaction.service';
import { UserService } from 'src/app/services/user/user.service';
import { RemoveModalComponent } from '../modals/remove-modal/remove-modal.component';
import { NotificationModalComponent } from '../modals/notification-modal/notification-modal.component';
import { DetailUserModalComponent } from '../modals/detail-user-modal/detail-user-modal.component';

@Component({
  selector: 'app-table',
  templateUrl: './table.component.html',
  styleUrls: ['./table.component.css']
})
export class TableComponent implements OnInit {
  dataSource: MatTableDataSource<User> = new MatTableDataSource();
  isLoading: boolean = true;
  displayColumns: string[] = ["id", "idName", "idValue", "fullName", "email", "loginUsername", "registeredDate", "acoes"]
  @ViewChild(MatPaginator) paginator!: MatPaginator;
  @ViewChild(MatSort) sort!: MatSort;

  constructor(private interactionService: InteractionService, public dialog: MatDialog, private userService: UserService) {

  }
  ngOnInit(): void {
    this.interactionService.users.subscribe((data: User[]) => {
      console.log(data)
      this.dataSource.data = data;
      this.dataSource.paginator = this.paginator;
      this.dataSource.sort = this.sort;
      this.isLoading = false;
    })
  }
  applyFilter(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value;
    this.dataSource.filter = filterValue.trim().toLowerCase();

    if (this.dataSource.paginator) {
      this.dataSource.paginator.firstPage();
    }
  }


removeUser(user: User) {
  const dialogRef = this.dialog.open(RemoveModalComponent, {
    data: {name: user.fullName}
  });

  dialogRef.afterClosed().subscribe({
    next: (result) => {
      if (result) {
        this.userService.removeUser(user.id).subscribe({
          next: (data) => {
            this.dialog.open(NotificationModalComponent, {
              data: { message: data.message }
            });
          },
          error: (error) => {
            this.dialog.open(NotificationModalComponent, {
              data: { message: error.error.message }
            });
          }
        });
      }
    },
    error: () => {
      this.dialog.open(NotificationModalComponent, {
        data: { message: "Erro interno na interface de usuário." }
      });
    }
  });
}
detailUser(user: User) {
  this.dialog.open(DetailUserModalComponent, {
    data: user
  })
}
}
