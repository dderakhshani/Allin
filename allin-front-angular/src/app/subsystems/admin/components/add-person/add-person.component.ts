import { Component } from '@angular/core';
import { BasicModule } from '../../../../core/basic.module';
import { MessageService } from 'primeng/api';
import { CalendarModule } from 'primeng/calendar';
import { AccordionModule } from 'primeng/accordion';
import { FieldsetModule } from 'primeng/fieldset';
import { FileUploadEvent, FileUploadModule } from 'primeng/fileupload';
import { SelectButtonModule } from 'primeng/selectbutton';
import { FloatLabel } from 'primeng/floatlabel';
import { Address, CreatePersonCommand, Mobile } from '../../models/commands/create-Person-command';

interface UploadEvent {
    originalEvent: Event;
    files: File[];
}


@Component({
    selector: 'app-add-person',
    standalone: true,
    imports: [BasicModule, CalendarModule, AccordionModule, FieldsetModule, FileUploadModule, SelectButtonModule,FloatLabel],
    providers: [MessageService],
    templateUrl: './add-person.component.html',
    styleUrl: './add-person.component.scss'
})
export class AddPersonComponent {

    user!: CreatePersonCommand;

    legalOptions: any[] = [{ label: 'Legal Entity', isLegal: 'Legal Entity' }, { label: 'Natural Person', isLegal: 'Natural Person' }];
    isLegal: string = 'Natural Person';

    genderOptions: any[] = [{ label: 'Male', genderValue: 1 }, { label: 'Female', genderValue: 2 }];
    genderValue: number = 1;


    value: string | undefined;
    date: Date | undefined;

    
    
    uploadedFiles: any[] = [];

    contact: any[] | undefined;
    selectedContact: any | undefined;

    location: any[] | undefined;
    selectedLocation: any | undefined;

    constructor(private messageService: MessageService) { }

    ngOnInit() {
        this.user = {
            firstName: '',
            lastName: '',
            ssn: '',
            mobiles: [{type:0,phoneNumber:""}],
            addresses: [{type:0,address:""}],
            email: '',
            photoUrl: '',
            signatureImageUrl: '',
            // birthDate: null,
            // genderBaseId: null,
            // maritalStatus: null,
            isLegal: false // مقدار پیش‌فرض
          };
          
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

    addMobile() {

        let newMobile: Mobile = {type:0,phoneNumber:""};
        this.user.mobiles.push(newMobile);
    
      }

      addAddress() {

        let newAddress: Address = {type:0,address:""};
        this.user.addresses.push(newAddress);
    
      }

}
