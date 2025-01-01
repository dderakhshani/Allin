import { NgModule } from '@angular/core';
import { ButtonModule } from 'primeng/button';
import { InputTextModule } from 'primeng/inputtext';
import { TreeTableModule } from 'primeng/treetable';
import { DividerModule } from 'primeng/divider';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { TimelineModule } from 'primeng/timeline';
import { CheckboxModule } from 'primeng/checkbox';
import { DropdownModule } from 'primeng/dropdown';
import { IconFieldModule } from 'primeng/iconfield';
import { InputIconModule } from 'primeng/inputicon';
import { MultiSelectModule } from 'primeng/multiselect';
import { TranslateDirective, TranslatePipe } from '@ngx-translate/core';

import { MessagesModule } from 'primeng/messages';
import { MessageModule } from 'primeng/message';
@NgModule({
    declarations: [


    ],
    imports: [
        TranslatePipe,
        TranslateDirective
    ],
    exports: [
        CommonModule,
        FormsModule,
        ButtonModule,
        CheckboxModule,
        InputTextModule,
        IconFieldModule,
        InputIconModule,
        MultiSelectModule,
        DropdownModule,
        DividerModule,
        MessageModule,
        TimelineModule,
        TranslatePipe,
        TranslateDirective
    ]
})
export class BasicModule { }
