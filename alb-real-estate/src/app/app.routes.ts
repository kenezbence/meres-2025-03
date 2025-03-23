import { Routes } from '@angular/router';
import { StartPageComponent } from './start-page/start-page.component';
import { OffersComponent } from './offers/offers.component';
import { NewAdComponent } from './new-ad/new-ad.component';

export const routes: Routes = [
    { path: '', component: StartPageComponent },
    { path: 'offers', component: OffersComponent },
    { path: 'newad', component: NewAdComponent }
];
