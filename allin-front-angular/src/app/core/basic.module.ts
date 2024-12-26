import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { ButtonModule } from 'primeng/button';
import { AppComponent } from '../app.component';
import { InputTextModule } from 'primeng/inputtext';
import { TreeTableModule } from 'primeng/treetable';
import { DividerModule } from 'primeng/divider';

@NgModule({
  declarations: [
    

  ],
  imports: [
  
  ],
  exports:[
    ButtonModule,
    InputTextModule,
    TreeTableModule,
    DividerModule
  ]
})
export class BasicModule { }
