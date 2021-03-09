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

  constructor(private http: HttpClient) { }
  getPlaces(limit: number = this.limit, random: boolean = this.random): Observable<Place[]> {
    return this.http.get<Place[]>(`${this.apiUrl}/${this.placesEndpoint}?limit=${this.limit}&random=${this.random}`);
  }

  getCategories() {
    return this.http.get<Category[]>(`${this.apiUrl}/${this.categoriesEndpoint}`);
  }
}
