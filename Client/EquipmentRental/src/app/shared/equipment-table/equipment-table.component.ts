import { Component, OnInit } from '@angular/core';
import { EquipmentService } from 'src/app/services/equipment.service';
import { Equipment } from 'src/app/models/equipment';

@Component({
  selector: 'app-equipment-table',
  templateUrl: './equipment-table.component.html',
  styleUrls: ['./equipment-table.component.scss']
})
export class EquipmentTableComponent implements OnInit {

  equipments: Equipment[];

  constructor(private equipmentService: EquipmentService) { }

  ngOnInit() {
    this.equipmentService.getAllEquipments().subscribe(data => {
      this.equipments = data;
    });
  }

  openAddtoCartBox(equipment: Equipment): void {
    this.equipmentService.selectedEquipment = equipment;
    this.equipmentService.isAnyEquipmentSelected = true;
  }

}
