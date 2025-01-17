import { Component, Input } from '@angular/core';
import { BasicModule } from '../../../../../core/basic.module';
import { IFormDialogContainer, PageDialogConfig } from '../../../../../core/components/page-dialog/page-dialog.component';
import { PositionModel } from '../../../models/queries/position-model';
import { MessageService } from 'primeng/api';
import { FormBuilder, Validators } from '@angular/forms';
import { PositionService } from '../../../apis/position.service';
import { DynamicDialogConfig } from 'primeng/dynamicdialog';
import { CreatePositionCommand } from '../../../models/commands/create-position-command';
import { Observable, of } from 'rxjs';

@Component({
    selector: 'app-create-position-page',
    standalone: true,
    imports: [BasicModule,

    ],
    providers: [MessageService],
    templateUrl: './create-position-page.component.html',
    styleUrl: './create-position-page.component.scss'
})
export class CreatePositionPageComponent implements IFormDialogContainer {

    @Input()
    parentPosition?: PositionModel;
    showValidationWarning = true;

    form = this.fb.group({
        title: this.fb.control<string | null>(null, Validators.required),
    })

    constructor(private messageService: MessageService,
        private positionService: PositionService,
        public dialogConfig: DynamicDialogConfig<PageDialogConfig>,
        public fb: FormBuilder
    ) {
        this.parentPosition = dialogConfig.data?.extraData;

    }

    save(): Observable<boolean> {
        if (this.form.valid) {
            const command = <CreatePositionCommand>{
                ...<CreatePositionCommand>this.form.getRawValue(),
                parentId: this.parentPosition?.id,
                levelCode: "",
            }
            return new Observable((subscriber) => {
                this.positionService.create(command).subscribe(data => {

                    subscriber.next(true);
                });
            });

        }
        else
            return of(false);
    }


}
