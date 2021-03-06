export class Url {
  urlId: number;
  urlAdress: string;
  description: string;

  constructor(id: number, address: string, description: string) {
    this.urlAdress = address;
    this.urlId = id;
    this.description = description;
  }
}
