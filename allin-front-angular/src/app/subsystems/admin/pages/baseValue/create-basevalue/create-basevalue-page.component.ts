import { Component } from '@angular/core';
import { BasicModule } from '../../../../../core/basic.module';
import { AccordionModule } from 'primeng/accordion';
import { MessageService, TreeNode } from 'primeng/api';
import { FormBuilder } from '@angular/forms';
import { BasevalueService } from '../../../apis/basevalue.service';
import { CreateBaseValueCommand, CreateBaseValueItemCommand } from '../../../models/commands/create-basevalue-command';
import { Observable, of } from 'rxjs';
import { TreeTableModule } from 'primeng/treetable';

@Component({
    selector: 'app-create-basevalue-page',
    standalone: true,
    imports: [BasicModule,
        AccordionModule,
        TreeTableModule
    ],
    providers: [MessageService],
    templateUrl: './create-basevalue-page.component.html',
    styleUrl: './create-basevalue-page.component.scss'
})
export class CreateBasevaluePageComponent {
    isLoading = false;

    baseValue?: CreateBaseValueCommand;
    // baseValueItems?: TreeNode<CreateBaseValueItemCommand>[];
    baseValueItems?: CreateBaseValueItemCommand[];
    form = this.fb.group({
        title: this.fb.control<string | null>(null),
        uniqueName: this.fb.control<string | null>(null),
        description: this.fb.control<string | null>(null),
        //    permissionIds: this.fb.control<[number] | null>(null),
    })

    constructor(private messageService: MessageService,
        private basevalueService: BasevalueService,
        public fb: FormBuilder) {

    }

    addItem() {

        this.baseValueItems = [
            {
                title: "test",
                description: "test",
                baseValueId: 0,
                value: 1,
            }
        ];
        // const itemGroup = this.fb.group({
        //     type: new FormControl(1, Validators.required),
        //     phoneNumber: new FormControl('', Validators.required)
        // });
        // this.mobilesForm.controls.push(itemGroup);

    }

    save(): Observable<boolean> {
        if (this.form.valid) {
            const command = <CreateBaseValueCommand>{
                ...<CreateBaseValueCommand>this.form.getRawValue(),
                items: this.baseValueItems,
            }
            return new Observable((subscriber) => {
                this.basevalueService.create(command).subscribe(data => {

                    subscriber.next(true);
                });
            });

        }
        else
            return of(false);
    }

}
