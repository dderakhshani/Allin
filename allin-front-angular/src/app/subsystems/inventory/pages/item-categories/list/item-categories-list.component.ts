import { Component } from '@angular/core';
import { BasicModule } from '../../../../../core/basic.module';

@Component({
  selector: 'app-item-categories-list',
  standalone: true,
  imports: [BasicModule,],
  templateUrl: './item-categories-list.component.html',
  styleUrl: './item-categories-list.component.scss'
})
export class ItemCategoriesListComponent {

}
