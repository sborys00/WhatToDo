import { Component, Input, OnInit } from '@angular/core';
import { Category } from '../shared/models/category.model';
import { icons } from '../shared/category-icons';

@Component({
  selector: 'app-category',
  templateUrl: './category.component.html',
  styleUrls: ['./category.component.css']
})
export class CategoryComponent implements OnInit {


  @Input()
  category: Category = { categoryId: -1, name: "Kategoria" };
  faIcon = icons[""];

  constructor() { }

  ngOnInit(): void {
    this.faIcon = icons[this.category.name];
  }

}
