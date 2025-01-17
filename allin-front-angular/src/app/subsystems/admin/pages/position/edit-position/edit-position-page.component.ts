import { Component, Input } from '@angular/core';
import { BasicModule } from '../../../../../core/basic.module';
import { MessageService } from 'primeng/api';
import { PositionModel } from '../../../models/queries/position-model';
import { PositionService } from '../../../apis/position.service';
import { PageDialogConfig } from '../../../../../core/components/page-dialog/page-dialog.component';
import { FormBuilder, Validators } from '@angular/forms';
import { DynamicDialogConfig } from 'primeng/dynamicdialog';
import { Observable, of } from 'rxjs';
import { EditPositionCommand } from '../../../models/commands/edit-position-command';

@Component({
    selector: 'app-edit-position-page',
    standalone: true,
    imports: [BasicModule,

    ],
    providers: [MessageService],
    templateUrl: './edit-position-page.component.html',
    styleUrl: './edit-position-page.component.scss'
})
export class EditPositionPageComponent {

    @Input()
    item?: PositionModel;
    showValidationWarning = true;

    form = this.fb.group({
        title: this.fb.control<string | null>(null, Validators.required),
    })

    constructor(private messageService: MessageService,
        private positionService: PositionService,
        public dialogConfig: DynamicDialogConfig<PageDialogConfig>,
        public fb: FormBuilder
    ) {
        this.item = dialogConfig.data?.extraData;

    }

    ngOnInit() {
        this.form.patchValue({
            title: this.item?.title,
        });

    }

    save(): Observable<boolean> {
        if (this.form.valid) {
            const command = <EditPositionCommand>{
                ...<EditPositionCommand>this.form.getRawValue(),
                id: this.item?.id,
                parentId: this.item?.parentId,
                levelCode: "",
            }
            return new Observable((subscriber) => {
                this.positionService.edit(command).subscribe(data => {

                    subscriber.next(true);
                });
            });

        }
        else
            return of(false);
    }
}
