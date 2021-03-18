import { Component, Injectable, Input, OnInit, Output, EventEmitter } from '@angular/core';
import { Place } from '../shared/models/place.model';
import { faChevronLeft, faChevronRight } from '@fortawesome/free-solid-svg-icons';
import { OpeningHours } from '../shared/models/opening-hours.model';
import { OpeningHoursPicker } from '../shared/utils/opening-hours-picker';

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
      address: { addressId: -1, city: "City", street: "Street", number: "Number", },
      openingHoursList: []
  };

  @Output() navEvent = new EventEmitter<number>();

  leftIcon = faChevronLeft;
  rightIcon = faChevronRight;

  openingHour: number = -1;
  closingHour: number = -1;
  alwaysOpen: boolean = false;

  constructor() {
  }
  
  ngOnInit(): void {

  }

  ngOnChanges(): void {
    let oh = OpeningHoursPicker.pickHours(this.place.openingHoursList);
    console.log(this.place);
    this.openingHour = Date.parse(oh.openingHour);
    this.closingHour = Date.parse(oh.closingHour);
    console.log(this.openingHour);
    console.log(this.closingHour);
    console.log(this.closingHour - this.openingHour);
    if (this.closingHour - this.openingHour == 86400000) {
      this.alwaysOpen = true;
    }
    else {
      this.alwaysOpen = false;
    }
    console.log(this.closingHour - 86400000);
    console.log(this.alwaysOpen);
  }

  nextPlace(): void {
    this.navEvent.next(1);
  }
  prevPlace(): void {
    this.navEvent.next(-1);
  }
}
