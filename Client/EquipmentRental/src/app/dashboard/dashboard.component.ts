import { Component, OnInit } from '@angular/core';
import { AuthService } from '../services/auth.service';
import { EquipmentService } from '../services/equipment.service';
import { Equipment } from '../models/equipment';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.scss']
})
export class DashboardComponent implements OnInit {

  constructor(private authService: AuthService, public equipmentService: EquipmentService) { }

  ngOnInit(): void {

  }

  tryLogout(): void {
    this.authService.logout();
  }

}
