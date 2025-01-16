import { NgModule } from '@angular/core';
import { ButtonModule } from 'primeng/button';
import { InputTextModule } from 'primeng/inputtext';
import { TreeTableModule } from 'primeng/treetable';
import { DividerModule } from 'primeng/divider';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { TimelineModule } from 'primeng/timeline';
import { CheckboxModule } from 'primeng/checkbox';
import { DropdownModule } from 'primeng/dropdown';
import { IconFieldModule } from 'primeng/iconfield';
import { InputIconModule } from 'primeng/inputicon';
import { MultiSelectModule } from 'primeng/multiselect';
import { TranslateDirective, TranslatePipe } from '@ngx-translate/core';
import { InputNumber } from 'primeng/inputnumber';


import { MessagesModule } from 'primeng/messages';
import { MessageModule } from 'primeng/message';
import { PageContentComponent } from './components/page-content/page-content.component';
import { TreeSelect } from 'primeng/treeselect';
import { FormControlPipe } from './pipes/form-control.pipe';
@NgModule({
    declarations: [


    ],
    imports: [
        TranslatePipe,
        TranslateDirective,
        PageContentComponent,
        InputNumber,
        TreeSelect,
        FormControlPipe
    ],
    exports: [
        CommonModule,
        FormsModule,
        ReactiveFormsModule,
        ButtonModule,
        CheckboxModule,
        InputTextModule,
        TreeSelect,

        IconFieldModule,
        InputIconModule,
        MultiSelectModule,
        DropdownModule,
        DividerModule,
        MessageModule,
        InputNumber,
        TranslatePipe,
        TranslateDirective,
        PageContentComponent,
        FormControlPipe
    ]
})
export class BasicModule { }
