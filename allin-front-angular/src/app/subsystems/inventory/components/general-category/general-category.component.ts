import { Component } from '@angular/core';
import { BasicModule } from '../../../../core/basic.module';
import { MessageService } from 'primeng/api';
import { Select } from 'primeng/select';
import { FormBuilder, FormGroup } from '@angular/forms';
import { SelectButton } from 'primeng/selectbutton';
import { TextareaModule } from 'primeng/textarea';

interface Level {
    name: number;
    code: number;
}

@Component({
    selector: 'app-geneal-category',
    standalone: true,
    imports: [BasicModule,
        Select,
        SelectButton,
        TextareaModule
    ],
    providers: [MessageService],
    templateUrl: './general-category.component.html',
    styleUrl: './general-category.component.scss'
})
export class GenealCategoryComponent {
    isLoading = false;


    //for sample
    levels: Level[] | undefined;
    value!: number;
    value1: string = '';

    paymentOptions: any[] = [
        { name: 'Option 1', value: 1 },
        { name: 'Option 2', value: 2 },
        { name: 'Option 3', value: 3 },
        { name: 'Option 4', value: 4 }
    ];



    form = this.fb.group({
        title: this.fb.control<string | null>(null),
        levelCode: this.fb.control<number | null>(null),
        conversionFactor: this.fb.control<number | null>(null),
        measureUnitBaseId: this.fb.control<number | null>(null),
        arrangements: this.fb.array<FormGroup>([]),
    })

    constructor(private messageService: MessageService,
        // private packingService: PackingService,
        // private basevalueService: BasevalueService,
        public fb: FormBuilder) {

    }

    selectedLevel: Level | undefined;
    ngOnInit() {

        this.isLoading = true;
        this.levels = [
            { name: 1, code: 1 },
            { name: 2, code: 2 },
            { name: 3, code: 3 },
            { name: 4, code: 4 },
            { name: 5, code: 5 }
        ];

    }

    onSelectLevel() {
        // this.packingService.getPackingByLevel(this.selectedLevel?.code ?? 0)
        //     .pipe(finalize(() => {
        //         this.isLoading = false;
        //     }))
        //     .subscribe(response => {
        //         this.packings = response;
        //     });
    }

}
