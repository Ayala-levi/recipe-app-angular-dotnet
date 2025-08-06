import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Ingredient } from '../interfaces/Ingredient.interface';

@Injectable({
  providedIn: 'root'
})
//מקביל לקונטרולר של רכיבים
export class IngredientService {
  Url: string = "https://localhost:7062/api/Ingredient"
  constructor(private httpc: HttpClient) { }

  //שליפת כל הרכיבים
  Get(): Observable<Ingredient[]> {
    return this.httpc.get<Ingredient[]>(this.Url);
  }
  //הוספת רכיב
  AddIngredient(newIngredient: Ingredient): Observable<Ingredient> {
    return this.httpc.post<Ingredient>(this.Url, newIngredient);
  }
}
