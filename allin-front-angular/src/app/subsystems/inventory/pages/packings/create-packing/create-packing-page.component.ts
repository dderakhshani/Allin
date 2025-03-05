import { Component } from '@angular/core';
import { BasicModule } from '../../../../../core/basic.module';
import { AccordionModule } from 'primeng/accordion';
import { MessageService } from 'primeng/api';
import { CreatePackingCommnad } from '../../../models/commands/create-packing-command';
import { FormBuilder } from '@angular/forms';
import { PackingService } from '../../../apis/packing.service';
import { Select } from 'primeng/select';
import { Observable, of } from 'rxjs';

interface City {
    name: string;
    code: string;
}

@Component({
    selector: 'app-create-packing-page',
    standalone: true,
    imports: [BasicModule,
        AccordionModule,
        Select],
    providers: [MessageService],
    templateUrl: './create-packing-page.component.html',
    styleUrl: './create-packing-page.component.scss'
})
export class CreatePackingPageComponent {

    isLoading = false;

    packing?: CreatePackingCommnad;

    cities: City[] | undefined;

    form = this.fb.group({
        title: this.fb.control<string | null>(null),
        levelCode: this.fb.control<number | null>(null),
        conversionFactor: this.fb.control<number | null>(null),
        measureUnitBaseId: this.fb.control<number | null>(null),
    })

    constructor(private messageService: MessageService,
        private packingService: PackingService,
        // private basevalueService: BasevalueService,
        public fb: FormBuilder) {

    }

    ngOnInit() {
        this.cities = [
            { name: 'New York', code: 'NY' },
            { name: 'Rome', code: 'RM' },
            { name: 'London', code: 'LDN' },
            { name: 'Istanbul', code: 'IST' },
            { name: 'Paris', code: 'PRS' }
        ];

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
