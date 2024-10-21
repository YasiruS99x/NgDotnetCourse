import { inject, Injectable } from '@angular/core';
import {
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpInterceptor
} from '@angular/common/http';
import { Observable } from 'rxjs';
import { CookieService } from 'ngx-cookie-service';

@Injectable()
export class AuthInterceptor implements HttpInterceptor {

  constructor() { }

  intercept(request: HttpRequest<unknown>, next: HttpHandler): Observable<HttpEvent<unknown>> {
    const cookieService = inject(CookieService);
    // Check for the JWT Token
    let token = cookieService.get('Authorization');

    if (token) {
      request = request.clone({
        setHeaders: {
          Authorization: token
        }
      });
    }

    // Pass the request to the next handler
    return next.handle(request);
  }
}




