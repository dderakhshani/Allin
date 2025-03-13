import { Component } from '@angular/core';
import { BasicModule } from '../../../../../core/basic.module';
import { AccordionModule } from 'primeng/accordion';
import { MessageService } from 'primeng/api';
import { CreateArrangementCommnad, CreatePackingCommnad } from '../../../models/commands/create-packing-command';
import { FormBuilder, FormControl, FormGroup } from '@angular/forms';
import { PackingService } from '../../../apis/packing.service';
import { Select } from 'primeng/select';
import { finalize, Observable, of } from 'rxjs';
import { BasevalueService } from '../../../../admin/apis/basevalue.service';
import { BaseValueTypeModel } from '../../../../admin/models/queries/base-value-type-model';
import { FloatLabel } from 'primeng/floatlabel';
import { PackingModel } from '../../../models/queries/packing-model';

interface Level {
    name: number;
    code: number;
}

@Component({
    selector: 'app-create-packing-page',
    standalone: true,
    imports: [BasicModule,
        AccordionModule,
        Select,
        FloatLabel
    ],
    providers: [MessageService],
    templateUrl: './create-packing-page.component.html',
    styleUrl: './create-packing-page.component.scss'
})
export class CreatePackingPageComponent {

    isLoading = false;

    levels: Level[] | undefined;
    packings?: PackingModel[];

    measureBaseValue: BaseValueTypeModel = {
        id: 10009,
        title: "Measure Units",
        uniqueName: "MeasureUnits",
        description: "توضیحات",
        items: []
    };

    packing?: CreatePackingCommnad;

    form = this.fb.group({
        title: this.fb.control<string | null>(null),
        levelCode: this.fb.control<number | null>(null),
        conversionFactor: this.fb.control<number | null>(null),
        measureUnitBaseId: this.fb.control<number | null>(null),
        arrangements: this.fb.array<FormGroup>([]),
    })

    constructor(private messageService: MessageService,
        private packingService: PackingService,
        private basevalueService: BasevalueService,
        public fb: FormBuilder) {

    }
    countries: any[] | undefined;

    selectedBasevalue: string | undefined;
    selectedLevel: Level | undefined;
    selectedPacking: PackingModel | undefined;

    ngOnInit() {

        this.isLoading = true;
        this.levels = [
            { name: 1, code: 1 },
            { name: 2, code: 2 },
            { name: 3, code: 3 },
            { name: 4, code: 4 },
            { name: 5, code: 5 }
        ];

        this.basevalueService.getItemsByBaseValueId(this.measureBaseValue.id)
            .pipe(finalize(() => {
                this.isLoading = false;
            }))
            .subscribe(response => {
                this.measureBaseValue.items = response;
            });


    }

    onSelectLevel() {
        this.packingService.getPackingByLevel(this.selectedLevel?.code ?? 0)
            .pipe(finalize(() => {
                this.isLoading = false;
            }))
            .subscribe(response => {
                this.packings = response;
            });
    }

    get arrangementsForm() {
        return this.form.controls.arrangements;
    }

    addItem() {

        const itemGroup = this.fb.group({
            packingId: new FormControl(0),
            conversionFactor: new FormControl(0),
        });
        this.arrangementsForm.controls.push(itemGroup);

    }

    save(): Observable<boolean> {
        if (this.form.valid) {
            const command = <CreatePackingCommnad>{
                ...<CreatePackingCommnad>this.form.getRawValue(),
            }
            return new Observable((subscriber) => {
                this.packingService.create(command).subscribe(data => {

                    subscriber.next(true);
                });
            });

        }
        else
            return of(false);
    }

}
