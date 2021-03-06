export class Address {
  addressId: number;
  city: string;
  street: string;
  number: string;

  constructor(id: number, city:string, street:string, number:string) {
    this.addressId = id;
    this.city = city;
    this.street = street;
    this.number = number;
  }
}
