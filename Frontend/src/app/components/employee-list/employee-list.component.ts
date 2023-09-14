import { Component, OnInit } from '@angular/core';
import { MatTableDataSource } from '@angular/material/table';
import { HttpClient } from '@angular/common/http';
import { MatDialog } from '@angular/material/dialog';
import { EditProfileComponentComponent } from '../edit-profile-component/edit-profile-component.component';
import { DatePipe } from '@angular/common';

export interface Employee {
  usersID: number;
  firstName: string;
  lastName: string;
  username: string;
  email: string;
  birthDate: string;
}

@Component({
  selector: 'app-employee-list',
  templateUrl: './employee-list.component.html',
  styleUrls: ['./employee-list.component.css'],
})
export class EmployeeListComponent implements OnInit {
  displayedColumns: string[] = [
    'firstName',
    'lastName',
    'username',
    'email',
    'birthdate',
    'info',
  ];

  employees: Employee[] = [];
  dataSource = new MatTableDataSource<Employee>(this.employees);

  constructor(private http: HttpClient, private dialog: MatDialog) {}

  ngOnInit() {
    this.http.get<Employee[]>('https://localhost:7272/api/Users').subscribe((data) => {
      this.employees = data;
      this.dataSource.data = this.employees;
    });
  }

  openEditProfile(userId: number) {
    const dialogRef = this.dialog.open(EditProfileComponentComponent, {
      width: '400px',
      data: { userId: userId },
    });

    dialogRef.afterClosed().subscribe((result) => {
      
       this.ngOnInit();
      
    });
  }

  formatBirthdate(birthdate: Date | null): string {
    if (birthdate) {
      const formattedDate = new DatePipe('en-US').transform(
        birthdate,
        'dd.MM.yyyy'
      );
      return formattedDate || '';
    }
    return '';
  }
}
