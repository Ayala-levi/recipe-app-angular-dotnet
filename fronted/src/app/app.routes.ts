import { Routes } from '@angular/router';
import { AddRecpieComponent } from './components/add-recpie/add-recpie.component';
import { HomePageComponent } from './components/home-page/home-page.component';
import { LoginComponent } from './components/login/login.component';
import { MoreDetailsComponent } from './components/more-details/more-details.component';
import { RegistrationComponent } from './components/registration/registration.component';
import { AboutComponent } from './components/about/about.component';

export const routes: Routes = [
    { path: "home page", component: HomePageComponent },
     { path: "about", component: AboutComponent },
    { path: "registration", component: RegistrationComponent },
    { path: "login", component: LoginComponent },
    { path: "add recpie", component: AddRecpieComponent },
    { path: "more details/:recipeId", component: MoreDetailsComponent }
   
];