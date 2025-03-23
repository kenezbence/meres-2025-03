import { Component, NgModule, OnInit } from '@angular/core';
import { ApiService } from '../api.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-new-ad',
  standalone: true,
  imports: [NgModule],  // Import FormsModule for ngModel
  templateUrl: './new-ad.component.html',
  styleUrls: ['./new-ad.component.css']
})
export class NewAdComponent implements OnInit {
  categories: any[] = [];
  newAd = {
    category: '',
    date: new Date().toISOString().split('T')[0],
    description: '',
    creditFree: true,
    pictureUrl: ''
  };
  errorMessage = '';

  constructor(private apiService: ApiService, private router: Router) { }

  ngOnInit(): void {
    this.apiService.getCategories().subscribe(data => {
      this.categories = data;
    });
  }

  onSubmit(): void {
    this.apiService.postNewAd(this.newAd).subscribe({
      next: () => {
        this.router.navigate(['/offers']);
      },
      error: (err) => {
        this.errorMessage = err.message || 'Hiba történt a küldés során!';
      }
    });
  }
}