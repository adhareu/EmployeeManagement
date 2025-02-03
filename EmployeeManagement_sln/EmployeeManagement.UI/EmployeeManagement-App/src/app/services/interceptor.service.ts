import { HttpInterceptorFn } from '@angular/common/http';
import { inject } from '@angular/core';
import { AuthService } from './auth.service';
import { HttpRequest, HttpHandlerFn, HttpErrorResponse, HttpEvent } from '@angular/common/http';
import { Observable, BehaviorSubject, catchError, switchMap, throwError, filter, take } from 'rxjs';

export const interceptor: HttpInterceptorFn = (req: HttpRequest<unknown>, next: HttpHandlerFn): Observable<HttpEvent<unknown>> => {
  const authService = inject(AuthService); // ✅ Use inject() to get services in functions
  const accessToken = authService.getAccessToken();
  let clonedRequest = req;

  if (accessToken) {
    clonedRequest = req.clone({
      setHeaders: { Authorization: `Bearer ${accessToken}` },
    });
  }

  return next(clonedRequest).pipe(
    catchError((error: HttpErrorResponse) => {
      if (error.status === 401) {
        return handle401Error(req, next, authService);
      }
      return throwError(() => error);
    })
  );
};

const isRefreshing = new BehaviorSubject<boolean>(false);
const refreshTokenSubject = new BehaviorSubject<string | null>(null);

const handle401Error = (request: HttpRequest<any>, next: HttpHandlerFn, authService: AuthService): Observable<HttpEvent<any>> => {
  if (!isRefreshing.value) {
    isRefreshing.next(true);
    refreshTokenSubject.next(null);

    return authService.refresh().pipe(
      switchMap((response) => {
        isRefreshing.next(false);
        refreshTokenSubject.next(response.accessToken);
        return next(request.clone({
          setHeaders: { Authorization: `Bearer ${response.accessToken}` },
        }));
      }),
      catchError((error) => {
        isRefreshing.next(false);
        authService.logout();
        return throwError(() => error);
      })
    );
  } else {
    return refreshTokenSubject.pipe(
      filter((token) => token !== null),
      take(1),
      switchMap((accessToken) => {
        return next(request.clone({
          setHeaders: { Authorization: `Bearer ${accessToken}` },
        }));
      })
    );
  }
};