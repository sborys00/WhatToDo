export class OpeningHours {
  closingHour: string;
  dayOfTheWeek: number = -1;
  openingHour: string;
  openingHoursId: number = -1;

  constructor() {
    this.openingHour = "1970-01-01T00:00:00";
    this.closingHour = "1970-01-01T00:00:00";
  }
}
