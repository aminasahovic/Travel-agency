import { Component, Input, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { MatDialog } from '@angular/material/dialog';
import { EditProfileComponentComponent } from '../edit-profile-component/edit-profile-component.component';

@Component({
  selector: 'app-view-profile',
  templateUrl: './view-profile.component.html',
  styleUrls: ['./view-profile.component.css']
})
export class ViewProfileComponent implements OnInit {
  @Input() userId: number = 1023;

  profileImageBase64: string = '';
  firstName: string = '';
  lastName: string = '';
  email: string = '';
  username: string = '';

  constructor(private http: HttpClient, private dialog: MatDialog) { }

  ngOnInit(): void {
    this.fetchProfileDetails();
  }

  fetchProfileDetails(): void {
    const apiUrl = `https://localhost:7272/api/Users/GetProfileById?id=${this.userId}`;
    this.http.get<any>(apiUrl).subscribe(response => {
      this.profileImageBase64 =  response.profileImageBase64;
      this.firstName = response.firsName;
      this.lastName = response.lastName;
      this.email = response.email;
      this.username = response.username;
    });
  }

  editProfile(): void {
    const dialogRef = this.dialog.open(EditProfileComponentComponent, {
      width: '500px',
      data: { userId: this.userId }
    });

    dialogRef.afterClosed().subscribe(result => {
      // Perform any necessary actions after the dialog is closed
      // For example, refresh the profile details
      this.fetchProfileDetails();
    });
  }
}
