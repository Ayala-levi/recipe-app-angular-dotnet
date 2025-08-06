import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { RecipeService } from '../../services/recipe.service';
import { Recipe } from '../../interfaces/Recipe.interface';
import { RecipeIngredient } from '../../interfaces/RecipeIngredient.interface';
import { RecipeIngredientService } from '../../services/recipe-ingredient.service';

@Component({
  selector: 'app-more-details',
  imports: [],
  templateUrl: './more-details.component.html',
  styleUrl: './more-details.component.css'
})
export class MoreDetailsComponent {
  id: number = 0
  recipe: Recipe = {
    recipeId: 0,
    name: "",
    description: "",
    imageUrl: "",
    difficultyLevel: "",
    preparationTime: 0,
    servings: 0,
    instructions: "",
    userId: 0,
  }
  listIngredient: Array<RecipeIngredient> = []

  //ActivatedRoute-לשליפת הקוד מהניתוב
  constructor(private route: ActivatedRoute, private recipeService: RecipeService, private recipeIngredientService: RecipeIngredientService) {
    //שליפת הקוד מהניתוב לתוך המשתנה קוד שבמחלקה
    this.route.params.subscribe(params => this.id = params['recipeId'])
  }
  //שליפת המתכון בעת טעינת הקומפוננטה
  ngOnInit() {
    this.recipeService.GetRecipe(this.id).subscribe(
      (data) => {
        //הכנסת המתכון למחלקה מהסרוויס
        this.recipe = data;
      },
      err => {
        console.log(err);
      }),
      //הכנסת הרכיבים למתכון למחלקה מהסרוויס
      this.recipeIngredientService.GetRecipeIngredient(this.id).subscribe(
        (data) => {
          debugger
          //הכנסת המתכון למחלקה מהסרוויס
          this.listIngredient = data
        },
        err => {
          console.log(err);
        })
  }
  // פונקציה להדפסת המתכון
  printRecipe() {
    window.print();
  }
  //פונקציה לשיתוף מתכון
  shareRecipe() {
    const recipeName = this.recipe.name;
    const recipeUrl = window.location.href;
    const shareText = `בדוק את המתכון הטעים הזה: ${recipeName}\n${recipeUrl}`;
    if (navigator.share) {
      navigator.share({
        title: recipeName,
        text: shareText,
        url: recipeUrl,
      }).then(() => console.log('שותף בהצלחה.'))
        .catch((error) => console.log('שגיאה בשיתוף', error));
    } else {
      const shareUrl = `mailto:?subject=${encodeURIComponent('מתכון מעניין!')}&body=${encodeURIComponent(shareText)}`;
      window.open(shareUrl, '_blank');
      console.log('Web Share API לא נתמך, פתיחת מייל לשיתוף.');
    }
  }
  //פונקציה להעתקת מתכון
  copyRecipe() {
    let recipeText = `שם המתכון: ${this.recipe.name}\n\nתיאור: ${this.recipe.description}\n\nרכיבים:\n`;
    this.listIngredient.forEach(item => {
      recipeText += `- ${item.quantity} ${item.ingredient.ingredientName}\n`;
    });
    recipeText += `\nהוראות:\n${this.recipe.instructions}`;

    navigator.clipboard.writeText(recipeText)
      .then(() => {
        alert('המתכון הועתק בהצלחה ללוח הגזירים!');
      })
      .catch(err => {
        console.error('שגיאה בהעתקת המתכון: ', err);
        alert('לא הצלחתי להעתיק את המתכון.');
      });
  }
  //להורדת מתכון
  downloadRecipeAsTxt() {
    let recipeText = `שם המתכון: ${this.recipe.name}\n\nתיאור: ${this.recipe.description}\n\nרכיבים:\n`;
    this.listIngredient.forEach(item => {
      recipeText += `- ${item.quantity} ${item.ingredient.ingredientName}\n`;
    });
    recipeText += `\nהוראות:\n${this.recipe.instructions}`;

    const fileName = `${this.recipe.name.replace(/\s+/g, '_')}.txt`;
    const blob = new Blob([recipeText], { type: 'text/plain;charset=utf-8' });
    const url = window.URL.createObjectURL(blob);
    const a = document.createElement('a');
    a.href = url;
    a.download = fileName;
    document.body.appendChild(a);
    a.click();
    document.body.removeChild(a);
    window.URL.revokeObjectURL(url);

    console.log('המתכון הורד כקובץ TXT.');
  }
}
