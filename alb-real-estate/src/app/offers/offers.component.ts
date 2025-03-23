import { Component, OnInit } from '@angular/core';
import { ApiService } from '../api.service';

@Component({
  selector: 'app-offers',
  standalone: true,
  templateUrl: './offers.component.html',
  styleUrls: ['./offers.component.css']
})
export class OffersComponent implements OnInit {
  offers: any[] = [];
  displayedColumns: string[] = ['id', 'category', 'description', 'creditFree', 'pictureUrl'];

  constructor(private apiService: ApiService) { }

  ngOnInit(): void {
    this.apiService.getOffers().subscribe(data => {
      this.offers = data;
    });
  }
}