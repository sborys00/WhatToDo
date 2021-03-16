import { Component, Injectable, Input, OnInit, Output, EventEmitter } from '@angular/core';
import { Place } from '../shared/models/place.model';
import { faChevronLeft, faChevronRight } from '@fortawesome/free-solid-svg-icons';

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

  @Output() navEvent = new EventEmitter<number>();

  leftIcon = faChevronLeft;
  rightIcon = faChevronRight;

  constructor() {

  }

  ngOnInit(): void {

  }

  nextPlace(): void {
    this.navEvent.next(1);
  }
  prevPlace(): void {
    this.navEvent.next(-1);
  }
}
