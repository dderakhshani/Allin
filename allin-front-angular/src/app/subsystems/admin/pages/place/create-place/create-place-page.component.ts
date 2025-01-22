import { Component, Input } from '@angular/core';
import { BasicModule } from '../../../../../core/basic.module';
import { MessageService } from 'primeng/api';
import { IFormDialogContainer, PageDialogConfig } from '../../../../../core/components/page-dialog/page-dialog.component';
import { PlacetModel } from '../../../models/queries/place-model';
import { FormBuilder, Validators } from '@angular/forms';
import { PlaceService } from '../../../apis/place.service';
import { DynamicDialogConfig } from 'primeng/dynamicdialog';
import { Observable, of } from 'rxjs';
import { CreatePlaceCommand } from '../../../models/commands/create-place-command';

@Component({
    selector: 'app-create-place-page',
    standalone: true,
    imports: [BasicModule,

    ],
    providers: [MessageService],
    templateUrl: './create-place-page.component.html',
    styleUrl: './create-place-page.component.scss'
})
export class CreatePlacePageComponent implements IFormDialogContainer {

    @Input()
    parentPlace?: PlacetModel;
    showValidationWarning = true;

    form = this.fb.group({
        placeTitle: this.fb.control<string | null>(null, Validators.required),
    })

    constructor(private messageService: MessageService,
        private placeService: PlaceService,
        public dialogConfig: DynamicDialogConfig<PageDialogConfig>,
        public fb: FormBuilder
    ) {
        this.parentPlace = dialogConfig.data?.extraData;
    }

    save(): Observable<boolean> {
        if (this.form.valid) {
            const command = <CreatePlaceCommand>{
                ...<CreatePlaceCommand>this.form.getRawValue(),
                parentId: this.parentPlace?.id,
                placeBaseId: 16,
            }
            return new Observable((subscriber) => {
                this.placeService.create(command).subscribe(data => {

                    subscriber.next(true);
                });
            });

        }
        else
            return of(false);
    }

}
