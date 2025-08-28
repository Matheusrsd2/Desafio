import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { NovaDividaComponent } from './nova-divida/nova-divida.component';

const routes: Routes = [
  { path: '', component: HomeComponent },
  { path: 'nova-divida', component: NovaDividaComponent } 
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
