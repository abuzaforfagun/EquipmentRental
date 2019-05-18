import { API } from 'src/environments/environment';
import { HttpService } from './http.service';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  isLoggedIn: boolean;
  constructor(private httpService: HttpService) { }

  login(email: string, password: string): Promise<any> {

    const credentials = {
      email,
      password
    };

    return new Promise((resolve) => {
      this.httpService.post(API.auth.login, credentials)
        .subscribe(data => {
          sessionStorage.setItem('userId', data.id.toString());
          this.isLoggedIn = true;
          resolve(true);
        }, err => resolve(false));
    });
  }
  checkAuth(): void {
    if (sessionStorage.getItem('userId')) {
      this.isLoggedIn = true;
    }
  }

  logout(): void {
    sessionStorage.removeItem('userId');
  }
}
