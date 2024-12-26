import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { ButtonModule } from 'primeng/button';
import { AppComponent } from '../app.component';
import { InputTextModule } from 'primeng/inputtext';
import { TreeTableModule } from 'primeng/treetable';
import { DividerModule } from 'primeng/divider';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';

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
    DividerModule
  ]
})
export class BasicModule { }
