import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Recipe } from '../interfaces/Recipe.interface';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
//מקביל לקונטרולר של מתכונים
export class RecipeService {
  listRecpie: Array<Recipe> = []
  Url: string = "https://localhost:7062/api/Recipe"

  constructor(private httpc: HttpClient) { }
  //שליפת כל המתכונים
  GetAllRecipes(): Observable<Recipe[]> {
    return this.httpc.get<Recipe[]>(this.Url);
  }
  //Observable-התחברות לשרת באופן אסינכרוני
  //שליפת מתכון לפי קוד
  GetRecipe(id: number): Observable<Recipe> {
    return this.httpc.get<Recipe>(`${this.Url}/GetRecipe/${id}`);
  }

  //הוספת מתכון
  AddRecipe(recipe: Recipe): Observable<Recipe> {
    debugger
    return this.httpc.post<Recipe>(this.Url, recipe);
  }
  UploadImage(selectedFile: File): Observable<any> {
    // FormData מאפשר לשלוח נתונים בפורמט של טופס HTML,
    // שמתאים לשליחת קבצים.
    const formData = new FormData();
    // מוסיף את הקובץ שנבחר (selectedFile) ל-FormData.
    formData.append('image', selectedFile, selectedFile.name);
    return this.httpc.post(`${this.Url}/upload`, formData);
  }
}
