import { Component, OnInit } from '@angular/core';
import { EquipmentService } from 'src/app/services/equipment.service';

@Component({
  selector: 'app-equipment-table',
  templateUrl: './equipment-table.component.html',
  styleUrls: ['./equipment-table.component.scss']
})
export class EquipmentTableComponent implements OnInit {

  constructor(private equipmentService: EquipmentService) { }

  ngOnInit() {
    this.equipmentService.getAllEquipments().subscribe(data => {
      this.equipments = data;
    });
  }

}
