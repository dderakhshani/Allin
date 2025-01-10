import { Component, EventEmitter, Input, input, Output } from '@angular/core';
import { ExtendedFieldModel } from '../../models/extended-fields-model';
import { ExtendedFieldsService } from '../../apis/extended-fields.service';
import { BasicModule } from '../../../../core/basic.module';
import { ExtendedFieldTypeEnum } from '../../models/enums/extended-field-type-enum';
import { ExtendedFieldUIControlEnum } from '../../models/enums/extended-field-ui-control-enum';
import { ExtendedFieldTableNamesEnum } from '../../models/enums/extended-field-table-enum';
import { ToggleSwitchModule } from 'primeng/toggleswitch';
import { FormArray, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ExtendedFieldValueModel } from '../../models/extended-field-value-model';

@Component({
    selector: 'app-extended-fields',
    standalone: true,
    imports: [
        BasicModule,
        ToggleSwitchModule
    ],
    templateUrl: './extended-fields.component.html',
    styleUrl: './extended-fields.component.scss'
})
export class ExtendedFieldsComponent {

    TypeEnum = ExtendedFieldTypeEnum;
    UIControlEnum = ExtendedFieldUIControlEnum

    @Input()
    tableName!: ExtendedFieldTableNamesEnum;

    @Input()
    values?: ExtendedFieldValueModel[];

    @Output()
    valuesChange = new EventEmitter<ExtendedFieldValueModel[]>()

    private fields!: ExtendedFieldValueModel[];

    checked: boolean = false;
    amount: number = 0;

    form = this.fb.group({
        fields: this.fb.array<any>([]) // Initialize the FormArray
    });

    constructor(private extendedFieldsService: ExtendedFieldsService,
        public fb: FormBuilder) {
    }

    ngOnInit() {
        //If it is Create Mode without initial values
        if (!this.values) {
            this.extendedFieldsService.getExtendedFields(this.tableName)
                .subscribe(response => {
                    this.fields = response as any;

                    this.initForm();
                });
        }
        else {//If it is Edit Mode: Fields and values are given by input{
            this.fields = this.values;
            this.initForm();
        }

    }

    initForm() {
        this.fields.forEach(field => {
            const control = this.fb.group({
                tableExtendedFieldId: this.fb.control(field.id),
                value: this.fb.control(field.value),
            });
            this.fieldsForm.push(control);
        });

        this.form.valueChanges.subscribe(x => {
            this.valuesChange.emit(this.fieldsForm.getRawValue());
        });
    }

    getField(index: number) {
        return this.fields[index];
    }


    get fieldsForm(): FormArray {
        return this.form.controls.fields as FormArray;
    }



}
