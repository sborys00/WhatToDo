import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ContentComponent } from './content/content.component';
import { CategoriesComponent } from './categories/categories.component';
import { HomeComponent } from './home/home.component';

const routes: Routes = [
  { path: 'categories', component: CategoriesComponent },
  { path: 'places', component: ContentComponent },
  { path: '', component: HomeComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
