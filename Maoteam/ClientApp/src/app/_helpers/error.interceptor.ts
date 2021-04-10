import { Injectable } from '@angular/core';
import {
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpInterceptor,
  HttpErrorResponse,
} from '@angular/common/http';
import { Observable, of, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { AuthenticationService } from '../_services/authentication.service';

@Injectable()
export class ErrorInterceptor implements HttpInterceptor {
  constructor(private authenticationService: AuthenticationService) {}

  intercept(
    request: HttpRequest<any>,
    next: HttpHandler
  ): Observable<HttpEvent<any>> {
    return next.handle(request).pipe(
      catchError((err: HttpErrorResponse) => {
        const error = err.error.message || err.statusText;

        if (err.status === 401 && err.url?.includes('/api/account/login')) {
          return throwError(error);
        }

        if (err.status === 401) {
          // auto logout if 401 response returned from api
          this.authenticationService.logout();
          location.reload();
        }

        return throwError(error);
      })
    );
  }
}
