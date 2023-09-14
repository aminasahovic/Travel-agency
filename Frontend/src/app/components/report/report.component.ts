import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { MatExpansionModule } from '@angular/material/expansion';
import { MatTableDataSource } from '@angular/material/table';
import { AuthService } from 'src/app/Services/auth.service';

export interface Users {
  usersID: number;
  firstName: string;
  lastName: string;
  email: string;
  role: string;
}
@Component({
  selector: 'app-report',
  templateUrl: './report.component.html',
  styleUrls: ['./report.component.css'],
})
export class ReportComponent implements OnInit {
  users: Users[] = [];
  displayedColumns: string[] = ['firstName', 'lastName', 'email', 'usersID']; // dataSource = ELEMENT_DATA;
  dataSource = new MatTableDataSource<Users>(this.users);

  constructor(private http: HttpClient, private auth: AuthService) {}

  ngOnInit() {
    this.http
      .get<Users[]>('https://localhost:7272/api/Users')
      .subscribe((data) => {
        this.users = data;
        this.dataSource.data = this.users.filter((e) => e.role == '');
      });
  }
  DownloadPdf(userId: number) {
    this.auth.generateUserPdf(userId).subscribe((res) => {
      let blob: Blob = res.body as Blob;
      let url= window.URL.createObjectURL(blob);
      window.open(url);
    });
  }
}
