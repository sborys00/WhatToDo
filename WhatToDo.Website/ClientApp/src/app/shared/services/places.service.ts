import { Injectable } from "@angular/core";
import { Observable } from 'rxjs';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Place } from "../models/place.model";
import { Category } from '../models/category.model';

@Injectable({
  providedIn: 'root',
})
export class PlacesService {
  apiUrl: string = "api";
  placesEndpoint: string = "places";
  categoriesEndpoint: string = "categories";
  limit: number = 5;
  random: boolean = true;
  categoriesString: string = "";

  constructor(private http: HttpClient) { }
  getPlaces(categories: string[] = [], limit: number = this.limit, random: boolean = this.random): Observable<Place[]> {
    console.log(categories);
    this.categoriesString = categories.join('&categories=');
    return this.http.get<Place[]>(`${this.apiUrl}/${this.placesEndpoint}?limit=${this.limit}&random=${this.random}&categories=${this.categoriesString}`);
  }

  getCategories() {
    return this.http.get<Category[]>(`${this.apiUrl}/${this.categoriesEndpoint}`);
  }
}
