import { HttpService } from './http.service';
import { HttpClient } from 'selenium-webdriver/http';
import { Injectable } from '@angular/core';
import { Order } from '../models/order';
import { API } from 'src/environments/environment';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class CheckoutService {

  constructor(private httpService: HttpService) { }

  getAllOrders(customerId: string): Observable<Order[]> {
    return this.httpService.get(`${API.orders.get}/${customerId}`, {});
  }

  getInvoice(customerId: string): Observable<any> {
    return this.httpService.download(`${API.orders.invoice}/${customerId}/invoice`);
  }
}
