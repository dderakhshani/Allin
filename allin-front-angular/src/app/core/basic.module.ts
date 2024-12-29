import { NgModule } from '@angular/core';
import { ButtonModule } from 'primeng/button';
import { InputTextModule } from 'primeng/inputtext';
import { TreeTableModule } from 'primeng/treetable';
import { DividerModule } from 'primeng/divider';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { TimelineModule } from 'primeng/timeline';
import { FloatLabelModule } from 'primeng/floatlabel';
import { SelectButtonModule } from 'primeng/selectbutton';
import { DropdownModule } from 'primeng/dropdown';

@NgModule({
  declarations: [


  ],
  imports: [

  ],
  exports: [
    CommonModule,
    FormsModule,
    ButtonModule,
    InputTextModule,
    TreeTableModule,
    DividerModule,
    TimelineModule,
    FloatLabelModule,
    SelectButtonModule,
    DropdownModule,
  ]
})
export class BasicModule { }
