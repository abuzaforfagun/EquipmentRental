import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  isLoggedIn: boolean;
  constructor() { }

  login(email: string, password: string): Observable<boolean> {
    // Todo: need to implement authentication;
    if (email === 'jhon@email.com' && password === '123') {
      this.isLoggedIn = true;
      sessionStorage.setItem('isLoggedIn', 'true');
      return of(true);
    }
    return of(false);
  }

  checkAuth(): void {
    if (sessionStorage.getItem('isLoggedIn') === 'true') {
      this.isLoggedIn = true;
    }
  }
}
