import { Injectable } from '@angular/core';
import { CanActivate, Router } from '@angular/router';
import { AuthService } from '../services/auth.service';
@Injectable({
  providedIn: 'root',
})
export class authGuard implements CanActivate  {
  constructor(private authService: AuthService, private router: Router) {}
  canActivate(): boolean {
   
    if (!this.authService.isAuthenticated()) {
      console.log('go to login');
      this.router.navigate(['/login']);
      return false;
    }
    console.log('authenticated');
    return true;
  }
 
};
