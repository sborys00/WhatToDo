import { Address } from "./address.model";
import { Category } from "./category.model";
import { Image } from "./image.model";
import { Url } from "./url";

export class Place {
  placeId: number;
  name: string;
  description: string;
  address: Address;
  images: Image[];
  urls: Url[];
  categories: Category[];
}
