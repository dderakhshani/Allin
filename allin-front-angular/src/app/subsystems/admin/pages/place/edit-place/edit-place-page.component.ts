import { Component, Input } from '@angular/core';
import { BasicModule } from '../../../../../core/basic.module';
import { MessageService } from 'primeng/api';
import { PlacetModel } from '../../../models/queries/place-model';
import { FormBuilder, Validators } from '@angular/forms';
import { PlaceService } from '../../../apis/place.service';
import { PageDialogConfig } from '../../../../../core/components/page-dialog/page-dialog.component';
import { DynamicDialogConfig } from 'primeng/dynamicdialog';
import { Observable, of } from 'rxjs';
import { EditPlaceCommand } from '../../../models/commands/edit-place-command';

@Component({
    selector: 'app-edit-place-page',
    standalone: true,
    imports: [BasicModule,

    ],
    providers: [MessageService],
    templateUrl: './edit-place-page.component.html',
    styleUrl: './edit-place-page.component.scss'
})
export class EditPlacePageComponent {

    @Input()
    item?: PlacetModel;
    showValidationWarning = true;

    form = this.fb.group({
        placeTitle: this.fb.control<string | null>(null, Validators.required),
    })

    constructor(private messageService: MessageService,
        private placeService: PlaceService,
        public dialogConfig: DynamicDialogConfig<PageDialogConfig>,
        public fb: FormBuilder
    ) {
        this.item = dialogConfig.data?.extraData;

    }

    ngOnInit() {
        this.form.patchValue({
            placeTitle: this.item?.placeTitle,
        });

    }

    save(): Observable<boolean> {
        if (this.form.valid) {
            const command = <EditPlaceCommand>{
                ...<EditPlaceCommand>this.form.getRawValue(),
                id: this.item?.id,
                parentId: this.item?.parentId,
                placeBaseId: 16,
            }
            return new Observable((subscriber) => {
                this.placeService.edit(command).subscribe(data => {

                    subscriber.next(true);
                });
            });

        }
        else
            return of(false);
    }

}
