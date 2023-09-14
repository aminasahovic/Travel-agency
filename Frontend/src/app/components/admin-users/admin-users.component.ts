import { HttpClient } from '@angular/common/http';
import { Component, NgModule } from '@angular/core';
import { MatTableDataSource } from '@angular/material/table';
import { DatePipe } from '@angular/common';
import { Router } from '@angular/router';
import { MatSnackBar } from '@angular/material/snack-bar';


export interface User {
  usersID: number;
  firsName: string;
  lastName: string;
  username: string;
  email: string;
  birthDate: Date;
  role: string;
}

@Component({
  selector: 'app-admin-users',
  templateUrl: './admin-users.component.html',
  styleUrls: ['./admin-users.component.css'],
})
export class AdminUsersComponent {
  displayedColumns: string[] = [
    'firstName',
    'lastName',
    'username',
    'email',
    'birthDate',
    'role',
    'emailIcon',
    'delete',
  ];
  role!: string;
  users: User[] = [];
  dataSource = new MatTableDataSource<User>(this.users);
  searchValue: string = '';
  sortField: string | undefined;


  constructor(private http: HttpClient, private router: Router, private snackBar: MatSnackBar) {}

  ngOnInit() {
    this.http
      .get<User[]>('https://localhost:7272/api/Users')
      .subscribe((data) => {
        this.users = data;
        this.dataSource.data = this.users;
      });
  }

  applyFilter() {
    this.dataSource.filter = this.searchValue.trim().toLowerCase();
    this.dataSource.filterPredicate = (data: User, filter: string) => {
      const searchTerms = filter.split(' ');
      return searchTerms.every((term) =>
        data.firsName.toLowerCase().includes(term) || data.lastName.toLowerCase().includes(term)
      );
    };
  }

  sort(sortField: string) {
    if (this.sortField === sortField) {
      this.users.reverse();
    } else {
      const collator = new Intl.Collator('hr', { sensitivity: 'base' });
      this.users.sort((a: User, b: User) => {
        const aValue = this.getFieldValue(a, sortField);
        const bValue = this.getFieldValue(b, sortField);
  
        return collator.compare(aValue, bValue);
      });
    }
  
    this.sortField = sortField;
    this.dataSource.data = this.users;
  }
  

  getFieldValue(user: User, field: string): string {
    switch (field) {
      case 'firstName':
        return user.firsName.toLowerCase();
      case 'lastName':
        return user.lastName.toLowerCase();
      case 'role':
        return user.role.toLowerCase();
      default:
        return '';
    }
  }

  getFormattedRole(role: string): string {
    if (role == '') {
      role = 'Basic user';
    }
    return role;
  }

  sendNotificationEmail(userEmail: string) {
    const apiUrl = `https://localhost:7272/api/Users/send_notification_mail/${userEmail}`;
  
    this.http.post(apiUrl, {}).subscribe(
      () => {
        this.snackBar.open('Mail je uspjesno poslan!', 'OK', {
          duration: 3000,
        });
      },
      (error) => {
        this.snackBar.open('Mail nije poslan, korisnik nije potvrdio mail. ', 'OK', {
          duration: 3000,
        });
      }
    );
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
  currentComponent:any;

  deleteUser(userID: number) {
    if (window.confirm('Da li želite da nastavite?')) {
      this.http
        .delete('https://localhost:7272/api/Users/delete/' + userID)
        .subscribe((data) => {
          alert('Uspjesno izbrisan korisnik!');
          this.ngOnInit();
        });
    } 
    else {
    }
  }
}

@NgModule({
  declarations: [
    // Component declarations
  ],
  imports: [
    // Other module imports
  ],
})
export class AdminUsersModule {}
