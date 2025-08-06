import { Component } from '@angular/core';
import { RecipeService } from '../../services/recipe.service';
import { Router, RouterLink } from '@angular/router';
import { Recipe } from '../../interfaces/Recipe.interface';

@Component({
  selector: 'app-home-page',
  imports: [],
  templateUrl: './home-page.component.html',
  styleUrl: './home-page.component.css'
})

export class HomePageComponent {
  constructor(private recipeService: RecipeService, private active: Router) { }
  ngOnInit() {
    this.recipeService.GetAllRecipes().subscribe(
      (data) => {
        //שמירת הנתונים בסרוויס
        this.recipeService.listRecpie = data;
      },
      err => {
        console.log(err);
      })
  }

  //שליפת כל המתכונים מהסרוויס
  get() {
    return this.recipeService.listRecpie
  }

  //ניתוב יזום לקומפוננטת פרטים נוספים
  goToMoreDetails(id: number) {
    this.active.navigate(["/more details", id])
  }
}

