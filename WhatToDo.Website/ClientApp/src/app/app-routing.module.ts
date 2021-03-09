import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ContentComponent } from './content/content.component';
import { CategoriesComponent } from './categories/categories.component';

const routes: Routes = [
  { path: 'categories', component: CategoriesComponent },
  { path: 'places', component: ContentComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
