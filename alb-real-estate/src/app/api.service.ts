import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ApiService {
  private apiUrl = 'http://localhost:5000/api';

  constructor(private http: HttpClient) { }

  getOffers(): Observable<any> {
    return this.http.get(`${this.apiUrl}/ingatlan`);
  }

  getCategories(): Observable<any> {
    return this.http.get(`${this.apiUrl}/kategoriak`);
  }

  postNewAd(ad: any): Observable<any> {
    return this.http.post(`${this.apiUrl}/ujingatlan`, ad);
  }
}