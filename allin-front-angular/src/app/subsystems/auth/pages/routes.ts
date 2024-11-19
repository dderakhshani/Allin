import { Routes } from "@angular/router";
import { LoginComponent } from "./login/login.component";
import { ForgotPasswordComponent } from "./forgot-password/forgot-password.component";

export const AUTH_ROOT_ROUTES: Routes = [
    {
        path: "",
        redirectTo: "login",
        pathMatch: "full"
    },
    {
        path: "login",
        component: LoginComponent, 
        data: {
            title: 'Login'
        }
    },
    {
        path: "forgot-password",
        component: ForgotPasswordComponent, 
        data: {
            title: 'Forgot Password'
        }
    },
];
