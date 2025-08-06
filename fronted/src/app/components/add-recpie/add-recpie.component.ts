import { Component } from '@angular/core';
import { FormsModule } from "@angular/forms";
import { Recipe } from '../../interfaces/Recipe.interface';
import { RecipeService } from '../../services/recipe.service';
import { Router } from '@angular/router';
import { RecipeIngredientService } from '../../services/recipe-ingredient.service';
import { AddRecipeIngredientsRequestDTO } from '../../interfaces/AddRecipeIngredientsRequestDTO';
import { IngredientService } from '../../services/ingredient.service';
import { Ingredient } from '../../interfaces/Ingredient.interface';
import { UserService } from '../../services/user.service';

@Component({
  selector: 'app-add-recpie',
  imports: [FormsModule],
  templateUrl: './add-recpie.component.html',
  styleUrl: './add-recpie.component.css'
})
export class AddRecpieComponent {
  constructor(private recipeService: RecipeService, private recipeIngredientService: RecipeIngredientService, private active: Router, private ingredientService: IngredientService,private userService:UserService) { }
  recipe: Recipe = this.getInitialRecipeState();
  recipeIngredients: AddRecipeIngredientsRequestDTO = {
    ingredientIds: [],
    quantities: []
  }
  //רשימה לשליפת כל הרכיבים
  ingredientsList: Array<Ingredient> = []
  // שמירת כמות רכיב נוכחי להוספה
  currentQuantity: string = "";
  // שמירת קוד רכיב נוכחי להוספה
  currentIngredientId: number = 0;
  // מצב האם נבחר 'אחר'
  isOtherSelected: boolean = false;
  // שם רכיב חדש שיוזן
  newIngredientName: string = "";
  //בחירת תמונה
  selectedFile: File | null = null;

  ngOnInit() {
    //קבלת כל הרכיבים 
    this.ingredientService.Get().subscribe(
      (data) => {
        //שמירת כל הרכיבים במחלקה
        this.ingredientsList = data;
      },
      err => {
        console.log(err);
      });
  }
  // פונקציה לטיפול בבחירת קובץ
  onFileSelected(event: any) {
    //בחירת הקובץ הראשון שנבחר עי המשתמש
    //as File- המרה לקובץ
    this.selectedFile = event.target.files[0] as File;
  }

  //בדיקה אם נבחר ברכיבים -"אחר"
  onIngredientSelect() {
    if (this.currentIngredientId <= 0) {
      this.isOtherSelected = true;
    }
  }

  //הוספת רכיב חדש
  addNewIngredient() {
    if (this.newIngredientName.trim()) {
      //יצירת רכיב חדש
      const newIngredient: Ingredient = {
        ingredientId: 0,
        ingredientName: this.newIngredientName.trim()
      };
      //הוספת הרכיב
      this.ingredientService.AddIngredient(newIngredient).subscribe(
        (data) => {
          // בחירת הרכיב החדש בתיבת הסלקט
          this.currentIngredientId = data.ingredientId;
          //ריענון של הרכיבים לאחר ההוספה
          this.ingredientService.Get().subscribe(
            (data2) => {
              //שמירת כל הרכיבים במחלקה
              this.ingredientsList = data2;
            },
            err => {
              console.log(err);
            })
        }, err => {
          console.log(err);
        }),
        // איפוס שדה שם הרכיב החדש
        this.newIngredientName = "";
      // הסתרת שדה הוספת רכיב חדש
      this.isOtherSelected = false;
    }
  }

  //AddRecipeIngredientsRequestDTO הוספת השדות כמות וקוד רכיב לאובייקט 
  addIngredientToList() {
    if (this.currentIngredientId && this.currentQuantity !== null) {
      this.recipeIngredients.ingredientIds.push(this.currentIngredientId);
      this.recipeIngredients.quantities.push(this.currentQuantity);
      // איפוס השדות לאחר הוספה
      this.currentIngredientId = 0;
      this.currentQuantity = "";
    }
  }
  // פונקציה לאתחול מצב המתכון (עוזר לאפס את הטופס)
  private getInitialRecipeState(): Recipe {
    return {
      recipeId: 0,
      name: "",
      description: "",
      imageUrl: "",
      difficultyLevel: "",
      preparationTime: null,
      servings: null,
      instructions: "",
      userId: 0
    };
  }
  saveRecipe() {
    this.recipe.userId=this.userService.UserId;
    if (this.selectedFile) {
      //העלאת התמונה
      this.recipeService.UploadImage(this.selectedFile).subscribe(
        (data: any) => {
          // השרת צריך להחזיר את הנתיב של התמונה
          this.recipe.imageUrl = data.path;
          //שמירת המתכון
          this.recipeService.AddRecipe(this.recipe).subscribe(
            (data) => {
              this.recipe = data;
              // שמירת הרכיבים נעשה כאן כדי שנעדכן את הרכיבים רק לאחר שיחזור הקוד מתכון מהמסד 
              this.recipeIngredientService.AddIngredients(this.recipe.recipeId, this.recipeIngredients).subscribe(
                (data) => {
                  //איפוס המתכון
                  this.recipe = this.getInitialRecipeState();
                  //recipeIngredients איפוס 
                  this.recipeIngredients.ingredientIds = [];
                  this.recipeIngredients.quantities = [];
                  //ניתוב יזום לדף הבית
                  this.active.navigate(["/home page"])
                },
                err => {
                  console.log(err);
                }
              );
            },
            err => {
              console.log(err);
            });
        },
        error => {
          console.error('שגיאה בהעלאת התמונה', error);
        }
      );
    }
  }
}