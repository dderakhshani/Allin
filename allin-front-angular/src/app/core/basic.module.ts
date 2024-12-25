import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { ButtonModule } from 'primeng/button';
import { AppComponent } from '../app.component';
import { InputTextModule } from 'primeng/inputtext';

@NgModule({
  declarations: [
    

  ],
  imports: [
  
  ],
  exports:[
    ButtonModule,
    InputTextModule
  ]
})
export class BasicModule { }
