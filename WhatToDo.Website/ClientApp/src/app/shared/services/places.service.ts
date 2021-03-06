import { Injectable } from "@angular/core";
import { Observable } from 'rxjs';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Place } from "../models/place.model";

@Injectable({
  providedIn: 'root',
})
export class PlacesService {
  apiUrl: string = "https://localhost:44300/Places"
  limit: number = 5;

  constructor(private http: HttpClient) { }
  getPlaces(): Observable<Place[]> {
    return this.http.get<Place[]>(`${this.apiUrl}?limit=${this.limit}`);
  }
}