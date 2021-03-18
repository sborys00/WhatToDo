"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.OpeningHours = void 0;
var OpeningHours = /** @class */ (function () {
    function OpeningHours() {
        this.dayOfTheWeek = -1;
        this.openingHoursId = -1;
        this.openingHour = new Date("1970-01-01T00:00:00");
        this.closingHour = new Date("1970-01-01T00:00:00");
    }
    return OpeningHours;
}());
exports.OpeningHours = OpeningHours;
//# sourceMappingURL=opening-hours.model.js.map