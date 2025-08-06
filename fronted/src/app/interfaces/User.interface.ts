import { Recipe } from "./Recipe.interface"

export interface User {
    userId: number
    lastName: string
    email: string
    passwordHash: string
    firstName: string
    recipes: Recipe[]
}