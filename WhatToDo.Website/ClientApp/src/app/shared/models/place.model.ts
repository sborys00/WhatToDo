import { Address } from "./address.model";
import { Category } from "./category.model";
import { Image } from "./image.model";
import { OpeningHours } from './opening-hours.model';
import { Url } from "./url.model";

export class Place {
  placeId: number;
  name: string;
  description: string;
  thumbnail: Image;
  address: Address;
  images?: Image[];
  urls?: Url[];
  categories?: Category[];
  openingHoursList: OpeningHours[] = [];

  constructor(id: number, name: string, description: string, thumbnail: Image, address: Address) {
    this.placeId = id;
    this.name = name;
    this.description = description;
    this.thumbnail = thumbnail;
    this.address = address;
  }
}
