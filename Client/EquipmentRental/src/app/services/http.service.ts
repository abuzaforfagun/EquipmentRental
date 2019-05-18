import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';


@Injectable({
  providedIn: 'root'
})
export class HttpService {

  constructor(private httpClient: HttpClient) { }

  get(url: string, params: any): Observable<any> {
    return this.httpClient.get(url, params);
  }

  download(url: string): Observable<any> {
    return this.httpClient.get(url, { responseType: 'blob' });
  }

  post(url: string, data: any): Observable<any> {
    return this.httpClient.post(url, data);
  }
}
