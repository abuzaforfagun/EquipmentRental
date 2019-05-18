import { HttpService } from './http.service';
import { CartItem } from './../models/cart-item';
import { Injectable } from '@angular/core';
import { Equipment } from '../models/equipment';
import { API } from 'src/environments/environment';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class CartService {

  constructor(private httpService: HttpService) { }

  addItem(equipmentId: number, daysOfRent: number): Observable<any> {
    const cart = new CartItem();
    cart.equipmentId = equipmentId;
    cart.daysOfRent = daysOfRent;
    cart.customerId = 1; // todo: need to make it dynamic
    return this.httpService.post(API.orders.add, cart);
  }
}
