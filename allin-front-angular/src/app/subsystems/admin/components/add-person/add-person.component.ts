import { Component, EventEmitter, Output } from '@angular/core';
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

interface UploadEvent {
    originalEvent: Event;
    files: File[];
}


@Component({
    selector: 'app-add-person',
    standalone: true,
    imports: [BasicModule, CalendarModule, AccordionModule, FieldsetModule, FileUploadModule, SelectButtonModule, FloatLabel, ExtendedFieldsComponent],
    providers: [MessageService],
    templateUrl: './add-person.component.html',
    styleUrl: './add-person.component.scss'
})
export class AddPersonComponent {
    TableName = ExtendedFieldTableNamesEnum.Person;

    @Output()
    commandChange = new EventEmitter<CreatePersonCommand>();

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
        email: this.fb.control<string | null>(null),
        photoUrl: this.fb.control<string | null>(null),
        signatureImageUrl: this.fb.control<string | null>(null),
        maritalEnum: this.fb.control<number | null>(null),
        personAddresses: this.fb.array<FormGroup>([]),

    })


    legalOptions: any[] = [{ label: 'Legal Entity', isLegal: true }, { label: 'Natural Person', isLegal: false }];
    genderOptions: any[] = [{ label: 'Male', genderValue: 1 }, { label: 'Female', genderValue: 2 }];
    contact: any[] | undefined;
    location: any[] | undefined;

    uploadedFiles: any[] = [];

    //Output

    constructor(private messageService: MessageService,
        public fb: FormBuilder) { }

    ngOnInit() {

        this.form.valueChanges.subscribe(x => {
            let command: CreatePersonCommand = {
                ...<CreatePersonCommand>this.form.getRawValue(),
                extendedFieldValues: this.extendedFieldsValue
            };

            // emit command to output
            this.commandChange.emit(command);
        })

        this.contact = [
            { name: 'Mobile', code: 'Mobile' },
            { name: 'Phone', code: 'Phone' },
        ];
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
            type: new FormControl('', Validators.required),
            mobil: new FormControl('', Validators.required)
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
