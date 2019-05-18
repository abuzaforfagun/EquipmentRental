import { CartService } from './../../services/cart.service';
import { Component, OnInit } from '@angular/core';
import { EquipmentService } from 'src/app/services/equipment.service';

@Component({
  selector: 'app-equipment-add-cart',
  templateUrl: './equipment-add-cart.component.html',
  styleUrls: ['./equipment-add-cart.component.scss']
})
export class EquipmentAddCartComponent implements OnInit {

  constructor(public equipmentService: EquipmentService, private cartService: CartService) { }
  isItemAddedInCart = false;
  daysOfRent: number;
  ngOnInit() {
  }

  addToCart(): void {
    this.equipmentService.countOfAddedCartItem++;
    this.cartService.addItem(this.equipmentService.selectedEquipment.id, this.daysOfRent).subscribe(data => {
      if (data) {
        this.isItemAddedInCart = true;
        this.daysOfRent = 0;
        setTimeout(() => {
          this.isItemAddedInCart = false;
        }, 4000);
      }
    });
  }
  closeCart(): void {
    this.equipmentService.isAnyEquipmentSelected = false;
    this.equipmentService.selectedEquipment = null;
  }
}
