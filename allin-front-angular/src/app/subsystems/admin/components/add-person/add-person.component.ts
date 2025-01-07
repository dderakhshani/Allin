import { Component, EventEmitter, Input, Output } from '@angular/core';
import { BasicModule } from '../../../../core/basic.module';
import { MessageService } from 'primeng/api';
import { CalendarModule } from 'primeng/calendar';
import { AccordionModule } from 'primeng/accordion';
import { FieldsetModule } from 'primeng/fieldset';
import { FileUploadEvent, FileUploadModule } from 'primeng/fileupload';
import { SelectButtonModule } from 'primeng/selectbutton';
import { FloatLabel } from 'primeng/floatlabel';
import { Address, CreatePersonCommand, Mobile } from '../../models/commands/create-Person-command';
import { ExtendedFieldTableNamesEnum } from '../../../shared/models/enums/extended-field-table-enum';
import { ExtendedFieldsComponent } from '../../../shared/components/extended-fields/extended-fields.component';
import { ExtendedFieldModel } from '../../../shared/models/extended-fields-model';
import { ExtendedFieldValueModel } from '../../../shared/models/extended-field-value-model';
import { FormArray, FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { Toast } from 'primeng/toast';

interface UploadEvent {
    originalEvent: Event;
    files: File[];
}


@Component({
    selector: 'app-add-person',
    standalone: true,
    imports: [BasicModule,
        Toast,
        CalendarModule,
        AccordionModule,
        FieldsetModule,
        FileUploadModule,
        SelectButtonModule,
        FloatLabel,
        ExtendedFieldsComponent],
    providers: [MessageService],
    templateUrl: './add-person.component.html',
    styleUrl: './add-person.component.scss'
})
export class AddPersonComponent {
    TableName = ExtendedFieldTableNamesEnum.Person;

    @Input()
    showValidationWarning = true;

    @Output()
    commandChange = new EventEmitter<CreatePersonCommand | null>();

    extendedFields: ExtendedFieldModel[] = [];
    extendedFieldsValue?: ExtendedFieldValueModel[];

    form = this.fb.group({
        firstName: this.fb.control<string | null>(null),
        lastName: this.fb.control<string | null>(null),
        ssn: this.fb.control<string | null>(null),
        birthDate: this.fb.control<Date | null>(null),
        genderEnum: this.fb.control<number | null>(null),
        isLegal: this.fb.control<Boolean | null>(null),
        mobiles: this.fb.array<FormGroup>([]),
        email: this.fb.control<string | null>(null, Validators.email),
        photoUrl: this.fb.control<string | null>(null),
        signatureImageUrl: this.fb.control<string | null>(null),
        maritalEnum: this.fb.control<number | null>(null),
        personAddresses: this.fb.array<FormGroup>([]),

    })


    legalOptions: any[] = [{ label: 'Legal Entity', isLegal: true }, { label: 'Natural Person', isLegal: false }];
    genderOptions: any[] = [{ label: 'Male', genderValue: 1 }, { label: 'Female', genderValue: 2 }];
    // contact: any[] | undefined;
    location: any[] | undefined;
    mobileTypes = [{ name: 'HomePhone', value: 1 }, { name: 'OfficePhone', value: 2 }, { name: 'Mobile', value: 3 }, { name: 'Fax', value: 4 }]
    uploadedFiles: any[] = [];

    //Output

    constructor(private messageService: MessageService,
        public fb: FormBuilder) { }

    ngOnInit() {

        this.form.valueChanges.subscribe(x => {
            if (this.form.valid) {
                let command: CreatePersonCommand = {
                    ...<CreatePersonCommand>this.form.getRawValue(),
                    extendedFieldValues: this.extendedFieldsValue ?? [],
                    photoUrl: "",
                    signatureImageUrl: "",
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

        this.location = [
            { name: 'Home', code: 'Home' },
            { name: 'Office', code: 'Office' },
            { name: 'Store', code: 'Store' },
            { name: 'Warehouse', code: 'Warehouse' },
        ];

    }

    onUpload(event: FileUploadEvent) {
        for (let file of event.files) {
            this.uploadedFiles.push(file);
        }

        this.messageService.add({ severity: 'info', summary: 'File Uploaded', detail: '' });
    }

    get mobilesForm() {
        return this.form.controls.mobiles;
    }
    addMobile() {

        const itemGroup = this.fb.group({
            type: new FormControl(1, Validators.required),
            phoneNumber: new FormControl('', Validators.required)
        });
        this.mobilesForm.controls.push(itemGroup);

    }

    get addressForm() {
        return this.form.controls.personAddresses;
    }

    addAddress() {
        const itemGroup = this.fb.group({
            type: new FormControl(null, Validators.required),
            addressLine: new FormControl('', Validators.required)
        });
        this.addressForm.controls.push(itemGroup);
    }



}
