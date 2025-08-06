import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { RecipeIngredient } from '../interfaces/RecipeIngredient.interface';
import { Observable } from 'rxjs';
import { AddRecipeIngredientsRequestDTO } from '../interfaces/AddRecipeIngredientsRequestDTO';
import { Recipe } from '../interfaces/Recipe.interface';

@Injectable({
  providedIn: 'root'
})
//מקביל לקונטרולר של רכיבים למתכון
export class RecipeIngredientService {
  Url: string = "https://localhost:7062/api/RecipeIngredient"
  constructor(private httpc: HttpClient) { }

  //שליפת ריכיבים לפי קוד מתכון
  GetRecipeIngredient(id: number): Observable<RecipeIngredient[]> {
    return this.httpc.get<RecipeIngredient[]>(`${this.Url}/${id}`);
  }

  //הוספת רכיבים למתכון
  AddIngredients(id: number, requestData: AddRecipeIngredientsRequestDTO) {
    debugger
    return this.httpc.post<Recipe>(`${this.Url}/${id}`, requestData);
  }
}
