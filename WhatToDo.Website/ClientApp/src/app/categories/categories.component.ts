import { Component, OnInit } from '@angular/core';
import { Category } from '../shared/models/category.model';
import { PlacesService } from '../shared/services/places.service';

@Component({
  selector: 'app-categories',
  templateUrl: './categories.component.html',
  styleUrls: ['./categories.component.css']
})
export class CategoriesComponent implements OnInit {

  private _ps: PlacesService;

  categories: Category[] = [];

  constructor(ps: PlacesService) {
    this._ps = ps;
    this._ps.getCategories().subscribe(categories => {
      this.categories = categories;
    });
  }

  ngOnInit(): void {
  }

}
