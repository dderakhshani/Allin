import { Routes } from "@angular/router";
import { CreateTeamPageComponent } from "./create-team/create-team-page.component";
import { TeamListPageComponent } from "./team-list/team-list-page.component";


export const Team_ROUTES: Routes = [
    {
        path: "",
        redirectTo: "list",
        pathMatch: "full"
    },
    {
        path: "create",
        component: CreateTeamPageComponent, data: {
            title: 'create team page'
        }
    },
    {
        path: "list",
        component: TeamListPageComponent, data: {
            title: 'team list page'
        }
    },
];
