import { OpeningHours } from '../models/opening-hours.model';

export class OpeningHoursPicker {
  static pickHours(hours: OpeningHours[]){
    let day = (new Date().getDay() - 1 + 7) % 7;
    let todayHours = new OpeningHours();

    if (hours != undefined) {
      for (let h of hours) {
        if (h.dayOfTheWeek == day) {
          todayHours = h;
        }
      }
    }
    return todayHours;
  }
}
