import { Component } from '@angular/core';
import { GenealCategoryComponent } from '../../../components/general-category/general-category.component';
import { PropertiesCategoryComponent } from '../../../components/properties-category/properties-category.component';
import { PropertyItemsCategoryComponent } from '../../../components/property-items-category/property-items-category.component';
import { DividerModule } from 'primeng/divider';

@Component({
    selector: 'app-create-category-page',
    standalone: true,
    imports: [GenealCategoryComponent,
        PropertiesCategoryComponent,
        PropertyItemsCategoryComponent,
        DividerModule
    ],
    templateUrl: './create-category-page.component.html',
    styleUrl: './create-category-page.component.scss'
})
export class CreateCategoryPageComponent {

}
