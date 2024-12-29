import { Component } from '@angular/core';
import { BasicModule } from '../../../../core/basic.module';
import { MessageService } from 'primeng/api';
import { CalendarModule } from 'primeng/calendar';
import { AccordionModule } from 'primeng/accordion';
import { FieldsetModule } from 'primeng/fieldset';
import { FileUploadEvent, FileUploadModule } from 'primeng/fileupload';

interface UploadEvent {
  originalEvent: Event;
  files: File[];
}


@Component({
  selector: 'app-add-person',
  standalone: true,
  imports: [BasicModule, CalendarModule, AccordionModule, FieldsetModule, FileUploadModule,],
  providers: [MessageService],
  templateUrl: './add-person.component.html',
  styleUrl: './add-person.component.scss'
})
export class AddPersonComponent {

  value: string | undefined;
  date: Date | undefined;

  typeOptions: any[] = [{ label: 'Legal Entity', value3: 'Legal Entity' }, { label: 'Natural Person', value3: 'Natural Person' }];
  value3: string = 'Natural Person';
  genderOptions: any[] = [{ label: 'Male', value2: 'Male' }, { label: 'Female', value2: 'Female' }];
  value2: string = 'Male';
  uploadedFiles: any[] = [];

  contact: any[] | undefined;
  selectedContact: any | undefined;

  location: any[] | undefined;
  selectedLocation: any | undefined;

  constructor(private messageService: MessageService) { }

  ngOnInit() {
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

}
