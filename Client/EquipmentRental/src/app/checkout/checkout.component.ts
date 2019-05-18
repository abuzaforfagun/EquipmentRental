import { CheckoutService } from './../services/checkout.service';
import { Component, OnInit } from '@angular/core';
import { Order } from '../models/order';
import { saveAs } from 'file-saver';

@Component({
  selector: 'app-checkout',
  templateUrl: './checkout.component.html',
  styleUrls: ['./checkout.component.scss']
})
export class CheckoutComponent implements OnInit {

  customerName: string;
  orders: Order[];
  totalOrders: number;
  totalLoyalityPoint: number;
  constructor(public checkoutService: CheckoutService) { }

  ngOnInit() {
    this.customerName = sessionStorage.getItem('userName');
    this.checkoutService.getAllOrders(sessionStorage.getItem('userId')).subscribe(data => {
      this.orders = data;
      this.totalOrders = data.length;
      this.totalLoyalityPoint = data.reduce((a, b) => a + (b['loyalityPoint'] || 0), 0);
    });
  }

  getInvoice() {
    this.checkoutService.getInvoice(sessionStorage.getItem('userId')).subscribe(data => {
      saveAs(data, 'Invoice.txt');
    });
  }
}
