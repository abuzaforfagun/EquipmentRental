import { Injectable } from '@angular/core';
import { HttpService } from './http.service';
import { Observable } from 'rxjs';
import { Equipment } from '../models/equipment';
import { API } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class EquipmentService {

  selectedEquipment: Equipment;
  isAnyEquipmentSelected: boolean;
  countOfAddedCartItem = 0;
  constructor(private httpService: HttpService) { }

  getAllEquipments(): Observable<Equipment[]> {
    return this.httpService.get(API.equipments.getAll, {});
  }
}
