import { Component } from '@angular/core';
import { AuthService } from '../../services/auth.service';
import { Router } from '@angular/router';
import { FormsModule } from '@angular/forms'; // ✅ Import FormsModule
@Component({
  selector: 'app-login',
  imports: [FormsModule],
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})
export class LoginComponent {
  username: string = '';
  password: string = '';
  errorMessage: string = '';
  constructor(private authService: AuthService, private router: Router) {}
  onLogin(){
   
    console.log('Login called');
    this.authService.login(this.username, this.password).subscribe(
      () => {
        window.location.href = '/home'; // ✅ This forces a full reload
        //this.router.navigate(['/home']); // Redirect after successful login
      },
      (error) => {
        this.errorMessage = 'Invalid username or password.';
      }
    );
  }
}
