import { CheckoutService } from './../services/checkout.service';
import { Component, OnInit } from '@angular/core';
import { Order } from '../models/order';

@Component({
  selector: 'app-checkout',
  templateUrl: './checkout.component.html',
  styleUrls: ['./checkout.component.scss']
})
export class CheckoutComponent implements OnInit {

  orders: Order[];
  totalOrders: number;
  totalLoyalityPoint: number;
  constructor(public checkoutService: CheckoutService) { }

  ngOnInit() {
    // todo: dynamic customer id
    this.checkoutService.getAllOrders(1).subscribe(data => {
      this.orders = data;
      this.totalOrders = data.length;
      this.totalLoyalityPoint = data.reduce((a, b) => a + (b['loyalityPoint'] || 0), 0);
    });
  }

}
