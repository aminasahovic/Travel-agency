import { Component } from '@angular/core';
import { AuthService } from 'src/app/Services/auth.service';
import { UserStoreService } from 'src/app/Services/user-store.service';

@Component({
  selector: 'app-basic-user-dashboard',
  templateUrl: './basic-user-dashboard.component.html',
  styleUrls: ['./basic-user-dashboard.component.css'],
})
export class BasicUserDashboardComponent {
  public fullName: string = '';
  public role: string = '';
  public id: string = '';
  public profileImg: string = '';
  constructor(private userStore: UserStoreService, private auth: AuthService) {}
  korisniciGet: any = {};
  test: any;
  onTest() {
    this.test = true;
  }
  

  ngOnInit() {
    this.userStore.getNameFromStore().subscribe((val) => {
      const fullNameFromToken = this.auth.getFullNameFromToken();
      this.fullName = fullNameFromToken || val;
    });
    this.userStore.getRoleFromStore().subscribe((val) => {
      const roleFromToken = this.auth.getRoleFromToken();
      this.role = roleFromToken || val;
    });
    this.userStore.getIdFromStore().subscribe((val) => {
      const idFromToken = this.auth.getIdFromToken();
      this.id = idFromToken || val;
    });
    this.korisniciGet[7] = {};
    // this.getAll();
    this.getProfileImg();
  }

  getAll() {
    return fetch('https://localhost:7272/api/Users')
      .then((response) => response.json())
      .then((json) => {
        this.korisniciGet = json;
      });
  }
  getProfileImg() {
    fetch('https://localhost:7272/api/Users/GetProfileImgById?id='+this.id)
      .then(response => {
        if (!response.ok) {
          throw new Error('Network response was not ok');
        }
        return response.text();
      })
      .then(data => {
        this.profileImg =  data;
      })
      .catch(error => {
        console.error('Error:', error);
      });
  }
  
  getImg(base64img: string) {
    const url = `data:image/jpg;base64,${base64img}`;
    return url;
  }
  addMETAdata(img: any) {
    return 'data:image/jpg;base64,' + img;
  }

  logOut() {
    this.auth.singOut();
  }
}
