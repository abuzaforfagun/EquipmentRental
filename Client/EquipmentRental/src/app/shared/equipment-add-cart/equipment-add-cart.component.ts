import { Component, OnInit } from '@angular/core';
import { EquipmentService } from 'src/app/services/equipment.service';

@Component({
  selector: 'app-equipment-add-cart',
  templateUrl: './equipment-add-cart.component.html',
  styleUrls: ['./equipment-add-cart.component.scss']
})
export class EquipmentAddCartComponent implements OnInit {

  constructor(public equipmentService: EquipmentService) { }

  ngOnInit() {
  }

  closeCart(): void {
    this.equipmentService.isAnyEquipmentSelected = false;
    this.equipmentService.selectedEquipment = null;
  }
}
