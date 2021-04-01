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
  currentAvailability: Availability = Availability.Other;
  availability = Availability;

  constructor() {
  }
  
  ngOnInit(): void {

  }

  ngOnChanges(): void {
    let oh = OpeningHoursPicker.pickHours(this.place.openingHoursList);
    this.openingHour = Date.parse(oh.openingHour);
    this.closingHour = Date.parse(oh.closingHour);
    if (this.closingHour - this.openingHour == 86400000) {
      this.currentAvailability = Availability.AlwaysAvailable;
    }
    else if (this.closingHour - this.openingHour == 0) {
      this.currentAvailability = Availability.ClosedToday;
    }
    else {
      this.currentAvailability = Availability.Other;
    }
  }

  nextPlace(): void {
    this.navEvent.next(1);
  }
  prevPlace(): void {
    this.navEvent.next(-1);
  }
}

export enum Availability {
  AlwaysAvailable,
  ClosedToday,
  Other
}
