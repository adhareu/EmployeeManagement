import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Router } from '@angular/router';
import { Observable, BehaviorSubject } from 'rxjs';
import { tap } from 'rxjs/operators';
import { environment } from '../../environments/environment';
import { jwtDecode } from 'jwt-decode';
interface LoginResponse {
  accessToken: string;
  refreshToken: string;
}
@Injectable({
  providedIn: 'root'
})
export class AuthService {
  private tokenSubject: BehaviorSubject<string | null> = new BehaviorSubject<string | null>(null);

  constructor(private http: HttpClient, private router: Router) { }
  // Login function
  login(username: string, password: string): Observable<LoginResponse> {
    return this.http.post<LoginResponse>(`${environment.base_Url}/Auth/login`, { username, password }).pipe(
      tap((response: LoginResponse) => {
        this.setAccessToken(response.accessToken);
        this.setRefreshToken(response.refreshToken);
      })
    );
  }
  // Login function
  refresh(): Observable<LoginResponse> {
    const username = this.getUsernameFromToken(); // Extract username from the token
    return this.http.post<LoginResponse>(`${environment.base_Url}/Auth/refresh`, { username}).pipe(
      tap((response: LoginResponse) => {
        this.setAccessToken(response.accessToken);
        this.setRefreshToken(response.refreshToken);
      })
    );
  }
  // Logout function
  logout(): void {
    localStorage.removeItem('access_token');
    localStorage.removeItem('refresh_token');
    this.tokenSubject.next(null);
    this.router.navigate(['/login']);
  }

  // Store Access Token
  private setAccessToken(token: string): void {
    localStorage.setItem('access_token', token);
    this.tokenSubject.next(token);
  }

  // Store Refresh Token
  private setRefreshToken(token: string): void {
    localStorage.setItem('refresh_token', token);
  }

  // Get Access Token
  getAccessToken(): string | null {
    return localStorage.getItem('access_token');
  }

  // Get Refresh Token
  getRefreshToken(): string | null {
    return localStorage.getItem('refresh_token');
  }
  // Check if user is authenticated
  isAuthenticated(): boolean {
    const token = this.getAccessToken();
    if (!token) return false;
    return true;

  }
  // Extract Username from Access Token
  private getUsernameFromToken(): string | null {
    const token = this.getAccessToken();
    if (!token) return null;

    try {
      const decodedToken: any = jwtDecode(token);
      return decodedToken.name || decodedToken.sub || null;
    } catch (error) {
      return null;
    }
  }
}
