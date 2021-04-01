import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { Category } from '../shared/models/category.model';
import { icons } from '../shared/category-icons';

@Component({
  selector: 'app-category',
  templateUrl: './category.component.html',
  styleUrls: ['./category.component.css']
})
export class CategoryComponent implements OnInit {

  @Input() category: Category = { categoryId: -1, name: "Kategoria" };
  @Input() enabled: boolean = true;

  @Output() categoryStatusEvent = new EventEmitter<string>();


  faIcon = icons[""].icon;
  bgColor = icons[""].bgColor;

  constructor() { }

  ngOnInit(): void {
    this.faIcon = icons[this.category.name].icon;
    this.bgColor = icons[this.category.name].bgColor;
    this.enabled = localStorage.getItem("categories")?.split(',').includes(this.category.name) ?? this.enabled;
  }

  toggleCategory() {
    if (this.enabled) {
      this.enabled = false;
      this.categoryStatusEvent.emit(this.category.name);
    }
    else {
      this.enabled = true;
      this.categoryStatusEvent.emit(this.category.name);
    }
  }
}
