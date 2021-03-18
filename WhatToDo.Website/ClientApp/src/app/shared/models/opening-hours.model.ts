export class OpeningHours {
  closingHour: Date;
  dayOfTheWeek: number = -1;
  openingHour: Date;
  openingHoursId: number = -1;

  constructor() {
    this.openingHour = new Date("1970-01-01T00:00:00");
    this.closingHour = new Date("1970-01-01T00:00:00");
  }
}
