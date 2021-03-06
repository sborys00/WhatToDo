import { Component, Injectable, Input, OnInit } from '@angular/core';
import { Place } from '../shared/models/place.model';

@Component({
  selector: 'app-place-card',
  templateUrl: './place-card.component.html',
  styleUrls: ['./place-card.component.css']
})
export class PlaceCardComponent implements OnInit {

  @Input()
  place: Place = {
    placeId: -1,
    name: "Name",
    description: "Description",
    thumbnail: { imageId: -1, description: "", source: "" },
    address: { addressId: -1, city: "City", street: "Street", number: "Number" }
  };

  constructor() {

  }

  ngOnInit(): void {

  }

}
