import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Category } from '../shared/models/category.model';
import { PlacesService } from '../shared/services/places.service';

@Component({
  selector: 'app-categories',
  templateUrl: './categories.component.html',
  styleUrls: ['./categories.component.css']
})
export class CategoriesComponent implements OnInit {

  private _ps: PlacesService;
  private _router: Router;
  categories: Category[] = [];
  enabledCategories: string[] = [];

  constructor(ps: PlacesService, router: Router) {
    this._ps = ps;
    this._router = router;
    this._ps.getCategories().subscribe(categories => {
      this.categories = categories;
      for (var category of this.categories) {
        this.enabledCategories.push(category.name);
      }
    });
  }

  ngOnInit(): void {
  }

  toggleCategory(category: string) {
    if (!this.enabledCategories.includes(category)) {
      this.enabledCategories.push(category);
    }
    else {
      this.enabledCategories.splice(this.enabledCategories.indexOf(category), 1);
    }

    console.log(this.enabledCategories);
  }

  submit(): void {
    this._router.navigateByUrl('/places', { state: { categories: this.enabledCategories } });
  }
}
