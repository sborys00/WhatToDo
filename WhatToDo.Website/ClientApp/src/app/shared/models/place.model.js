"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.Place = void 0;
var Place = /** @class */ (function () {
    function Place(id, name, description, thumbnail, address) {
        this.openingHoursList = [];
        this.placeId = id;
        this.name = name;
        this.description = description;
        this.thumbnail = thumbnail;
        this.address = address;
    }
    return Place;
}());
exports.Place = Place;
//# sourceMappingURL=place.model.js.map