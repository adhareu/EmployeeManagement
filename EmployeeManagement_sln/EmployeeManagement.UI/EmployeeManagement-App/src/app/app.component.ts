import { Component } from '@angular/core';
import { Router, RouterOutlet,NavigationEnd, RouterModule  } from '@angular/router';

@Component({
  selector: 'app-root',
  imports: [RouterOutlet,RouterModule],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  isLogin: boolean = false;
  constructor(private router: Router){
    // ✅ Subscribe to Router Events to track route changes dynamically
    this.router.events.subscribe(event => {
      if (event instanceof NavigationEnd) {
        this.isLogin = event.urlAfterRedirects === '/login';
        console.log('🔄 Route changed to:', event.urlAfterRedirects, 'isLogin:', this.isLogin);
      }
    });
  }
  title = 'EmployeeManagement-App';
    // Function to check if the current route is the login page
    
}
