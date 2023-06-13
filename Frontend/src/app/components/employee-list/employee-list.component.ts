import { Component, OnInit } from '@angular/core';
import { MatTableDataSource } from '@angular/material/table';
import { HttpClient } from '@angular/common/http';
import { SignalRService } from 'src/app/service/SignalRService';

export interface Employee {
  firstName: string;
  lastName: string;
  username: string;
  email: string;
  birthdate: string;
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

  constructor(private http: HttpClient,public s:SignalRService) {
    // this.s.openWebsocketChannel();

  }
 
  ngOnInit() {
    this.http.get<Employee[]>('https://localhost:7272/api/Users').subscribe(data => {
      this.employees = data;
      this.dataSource.data = this.employees;
    });

  }
}
