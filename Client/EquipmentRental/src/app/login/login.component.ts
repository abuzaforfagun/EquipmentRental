import { AuthService } from './../services/auth.service';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { DashboardComponent } from '../dashboard/dashboard.component';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {

  email: string;
  password: string;
  isDisplayError: boolean;
  constructor(private authService: AuthService, private router: Router) { }

  ngOnInit() {
  }

  tryLogin() {
    this.authService.login(this.email, this.password).subscribe(result => {
      if (!result) {
        this.isDisplayError = true;
      } else {
        this.router.navigateByUrl('dashboard');
      }
    });
  }
}
