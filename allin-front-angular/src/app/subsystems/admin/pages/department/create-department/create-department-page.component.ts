import { Component, EventEmitter, Input, Output } from '@angular/core';
import { BasicModule } from '../../../../../core/basic.module';
import { FormBuilder } from '@angular/forms';
import { CreateDepartmentCommand } from '../../../models/commands/create-department-command';
import { MessageService } from 'primeng/api';
import { DepartmentModel } from '../../../models/queries/department-model';
import { DepartmentService } from '../../../apis/department.service';
import { IFormDialogContainer } from '../../../../../core/components/page-dialog/page-dialog.component';
import { Observable, of } from 'rxjs';

@Component({
    selector: 'app-create-department-page',
    standalone: true,
    imports: [
        BasicModule,

    ],
    providers: [MessageService],
    templateUrl: './create-department-page.component.html',
    styleUrl: './create-department-page.component.scss'
})
export class CreateDepartmentPageComponent implements IFormDialogContainer {

    @Input()
    extraData?: DepartmentModel;
    showValidationWarning = true;

    @Output()
    commandChange = new EventEmitter<CreateDepartmentCommand | null>();


    form = this.fb.group({
        parentId: this.fb.control<number | null>(null),
        code: this.fb.control<string | null>(null),
        title: this.fb.control<string | null>(null),
        branchId: this.fb.control<number | null>(null),
        positionIds: this.fb.control<[number] | null>(null),

    })

    constructor(private messageService: MessageService,
        private departmentService: DepartmentService,
        public fb: FormBuilder
    ) { }

    ngOnInit() {

        this.form.valueChanges.subscribe(x => {
            if (this.form.valid) {
                let command: CreateDepartmentCommand = {
                    ...<CreateDepartmentCommand>this.form.getRawValue(),
                    parentId: this.extraData?.id,
                    branchId: 1,
                    positionIds: [0],
                };

                // emit command to output
                this.commandChange.emit(command);
            }
            else {
                if (this.showValidationWarning)
                    this.messageService.add({ severity: 'warn', summary: 'Warn', detail: 'Please fix the errors' });//TODO: translate
                this.commandChange.emit(null);
            }
        })
    }

    save(): Observable<boolean> {
        if (this.form.valid) {
            const command = <CreateDepartmentCommand>{
                ...this.form.getRawValue()
            }
            return new Observable((subscriber) => {
                this.departmentService.create(command).subscribe(data => {

                    subscriber.next(true);
                });
            });

        }
        else
            return of(false);
    }


}