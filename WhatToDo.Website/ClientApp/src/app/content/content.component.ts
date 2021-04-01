import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Place } from '../shared/models/place.model';
import { PlacesService } from '../shared/services/places.service';

@Component({
  selector: 'app-content',
  templateUrl: './content.component.html',
  styleUrls: ['./content.component.css']
})
export class ContentComponent implements OnInit {

  private _ps: PlacesService;

  places: Place[] = [];
  place: Place = this.places[0];
  i: number = 0;
  enabledCategories: string[]; 
  constructor(ps: PlacesService) {
    this._ps = ps;
    var categories = localStorage.getItem("categories");
    if (categories == null) {
      this.enabledCategories = [];
    }
    else {
      this.enabledCategories = categories.split(",");
    }

    ps.getPlaces(this.enabledCategories).subscribe(places => {      
      this.places = places;
      this.place = this.places[0];
    });
  }

  ngOnInit(): void {
    document.getElementById("main-content")?.scrollIntoView(false);
  }

  nextPlace(): void {
    if (this.i < this.places.length - 1) {
      this.i++;
      this.place = this.places[this.i];
      if (this.i == this.places.length - 1) {
        this._ps.getPlaces(history.state.categories).subscribe(places => {
          for (var place of places) {
            this.places.push(place);
          }
        });
      }
    }
  }
  prevPlace(): void {
    if (this.i > 0) {
      this.i--;
      this.place = this.places[this.i];
    }
  }

  navFunc(dir:number): void {
    if (dir == 1) {
      this.nextPlace();
    } else if (dir == -1) {
      this.prevPlace();
    }
  }
}
