import { Ingredient } from "./Ingredient.interface"

export interface RecipeIngredient {
    recipeIngredientId: number
    recipeId: number
    ingredientId: number
    quantity: string
    ingredient: Ingredient;
}