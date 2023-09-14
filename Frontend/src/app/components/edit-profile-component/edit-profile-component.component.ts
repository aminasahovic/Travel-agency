
import { Component, Inject, OnInit } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { HttpClient } from '@angular/common/http';

export interface EditProfileData {
  userId: number;
}

export interface UserProfile {
  firsName: string;
  usersID: number;
  firstName: string;
  lastName: string;
  birthDate: string;
  isAdmin: boolean;
  email: string;
  username: string;
  password: string;
  token: string;
  role: string;
  isEmailAccepted: boolean;
  resetPasswordToken: string;
  resetPasswordExpiry: string;
  isDeleted: boolean;
  profileImageBase64: string;
  profileImage: string;
}

@Component({
  selector: 'app-edit-profile-component',
  templateUrl: './edit-profile-component.component.html',
  styleUrls: ['./edit-profile-component.component.css']
})
export class EditProfileComponentComponent implements OnInit {
  userProfile!: UserProfile;
  firstName!: string;
  lastName!: string;
  email!: string;
  username!: string;
  birthdate!: string;

  constructor(
    public dialogRef: MatDialogRef<EditProfileComponentComponent>,
    @Inject(MAT_DIALOG_DATA) public data: EditProfileData,
    private http: HttpClient
  ) {}

  ngOnInit() {
    this.getUserProfile();
  }

  getUserProfile() {
    const apiUrl = `https://localhost:7272/api/Users/GetProfileById?id=${this.data.userId}`;
    this.http.get<UserProfile>(apiUrl).subscribe((data) => {
      this.userProfile = data;
      this.firstName = data.firsName;
      this.lastName = data.lastName;
      this.email = data.email;
      this.username = data.username;
      this.birthdate = data.birthDate;
    });
  }

  cancel() {
    this.dialogRef.close();
  }

  save() {
    const requestBody = {
      id: this.data.userId,
      firstName: this.firstName,
      lastName: this.lastName,
      email: this.email,
      username: this.username,
      birthDate: this.birthdate,
    };
  
    this.http
      .put('https://localhost:7272/api/Users/EditUserProfile', requestBody)
      .subscribe((response) => {
        this.dialogRef.close(response);
      });
  }
  
}


