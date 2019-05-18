import { AuthService } from './../../services/auth.service';
import { Component, OnInit } from '@angular/core';
import { EquipmentService } from 'src/app/services/equipment.service';

@Component({
  selector: 'app-nav-bar',
  templateUrl: './nav-bar.component.html',
  styleUrls: ['./nav-bar.component.scss']
})
export class NavBarComponent implements OnInit {

  constructor(private authService: AuthService, public equipmentService: EquipmentService) { }

  ngOnInit() {
  }

  tryLogout(): void {
    this.authService.logout();
  }
}
