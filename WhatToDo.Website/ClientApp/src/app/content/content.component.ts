import { Component, OnInit } from '@angular/core';
import { Place } from '../shared/models/place.model';
import { PlacesService } from '../shared/services/places.service';

@Component({
  selector: 'app-content',
  templateUrl: './content.component.html',
  styleUrls: ['./content.component.css']
})
export class ContentComponent implements OnInit {

  places: Place[] = [];
  place: Place = this.places[0];
  i: number = 0;
  constructor(ps: PlacesService) {
    ps.getPlaces().subscribe(places => {
      this.places = places;
      this.place = this.places[0];
    });
  }

  ngOnInit(): void {
  }

  nextPlace(): void {
    if (this.i < this.places.length - 1) {
      this.i++;
      this.place = this.places[this.i];
    }
  }
  prevPlace(): void {
    if (this.i > 0) {
      this.i--;
      this.place = this.places[this.i];
    }
  }
}
