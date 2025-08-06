export interface Recipe {
   recipeId: number;
   name: string
   description: string
   imageUrl: string
   difficultyLevel: string //רמה-קל בינוני קשה
   preparationTime: number| null; //משך זמן
   servings: number| null; //מספר מנות
   instructions: string //הוראות
   userId: number
}
