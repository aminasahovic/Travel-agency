import { Component } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Router } from '@angular/router';
import { AuthService } from 'src/app/Services/auth.service';
import { UserStoreService } from 'src/app/Services/user-store.service';

@Component({
  selector: 'app-twofactorau',
  templateUrl: './twofactorau.component.html',
  styleUrls: ['./twofactorau.component.css']
})
export class TwofactorauComponent {
  verificationCode: string = '';
  userId!: number; // Assuming you have a variable to store the user ID

  constructor(
    private http: HttpClient,
    private snackBar: MatSnackBar,
    private router: Router, private userStore: UserStoreService, private auth: AuthService
  ) {}

  submitVerification() {
    this.userStore.getIdFromStore().subscribe((val) => {
      const idFromToken = this.auth.getIdFromToken();
      this.userId = idFromToken || val;
    });

    alert(this.userId);
    const url = `https://localhost:7272/api/Users/Code?code=${this.verificationCode}&user=${this.userId}`;
    
    this.http.get<boolean>(url).subscribe(
      (response: boolean) => {
        if (response) {

          this.router.navigate(['/user-dashboard']);
        } else {
          // Code is incorrect
          this.openSnackBar('Pokusajte ponovno, kod koji ste unijeli nije tačan');
          this.verificationCode = ''; // Clear the input field
        }
      },
      (error) => {
        console.error('Error occurred:', error);
      }
    );
  }

  openSnackBar(message: string) {
    this.snackBar.open(message, 'Close', {
      duration: 3000, // Duration in milliseconds
    });
  }
}
