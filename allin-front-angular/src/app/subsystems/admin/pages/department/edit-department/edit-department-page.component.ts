import { Component, EventEmitter, Input, Output } from '@angular/core';
import { BasicModule } from '../../../../../core/basic.module';
import { MessageService } from 'primeng/api';
import { DepartmentModel } from '../../../models/queries/department-model';
import { FormBuilder, Validators } from '@angular/forms';
import { DepartmentService } from '../../../apis/department.service';
import { IFormDialogContainer, PageDialogConfig } from '../../../../../core/components/page-dialog/page-dialog.component';
import { DynamicDialogConfig } from 'primeng/dynamicdialog';
import { Observable, of } from 'rxjs';
import { EditDepartmentCommand } from '../../../models/commands/edit-department-command';

@Component({
  selector: 'app-edit-department-page',
  standalone: true,
  imports: [BasicModule,

  ],
  providers: [MessageService],
  templateUrl: './edit-department-page.component.html',
  styleUrl: './edit-department-page.component.scss'
})
export class EditDepartmentPageComponent implements IFormDialogContainer {

  @Input()
  item?: DepartmentModel;
  showValidationWarning = true;

  @Output()
  commandChange = new EventEmitter<EditDepartmentCommand | null>();


  form = this.fb.group({
    code: this.fb.control<string | null>(null, Validators.required),
    title: this.fb.control<string | null>(null, Validators.required),
  })

  constructor(private messageService: MessageService,
    private departmentService: DepartmentService,
    public dialogConfig: DynamicDialogConfig<PageDialogConfig>,
    public fb: FormBuilder
  ) {
    this.item = dialogConfig.data?.extraData;

  }

  ngOnInit() {
    this.form.patchValue({
      title: this.item?.title,
      code: this.item?.code
    });

  }

  save(): Observable<boolean> {
    if (this.form.valid) {
      const command = <EditDepartmentCommand>{
        ...<EditDepartmentCommand>this.form.getRawValue(),
        id: this.item?.id,
        parentId: this.item?.parentId,
        branchId: this.item?.branchId,
        positionIds: [],
      }
      return new Observable((subscriber) => {
        this.departmentService.edit(command).subscribe(data => {

          subscriber.next(true);
        });
      });

    }
    else
      return of(false);
  }


}
