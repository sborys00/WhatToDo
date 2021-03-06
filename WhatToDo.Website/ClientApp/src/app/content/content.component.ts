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

  constructor(ps: PlacesService) {
    ps.getPlaces().subscribe(places => {
       this.places = places;
    });
  }

  ngOnInit(): void {
  }

}
