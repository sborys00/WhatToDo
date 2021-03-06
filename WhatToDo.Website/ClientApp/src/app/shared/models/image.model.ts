export class Image {
  imageId: number;
  description: string;
  source: string;

  constructor(id:number, description:string, source:string) {
    this.imageId = id;
    this.description = description;
    this.source = source;
  }
}
