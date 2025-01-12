import { Component, EventEmitter, Input, Output } from '@angular/core';
import { BasicModule } from '../../../../../core/basic.module';
import { FormBuilder, Validators } from '@angular/forms';
import { CreateDepartmentCommand } from '../../../models/commands/create-department-command';
import { MessageService } from 'primeng/api';
import { DepartmentModel } from '../../../models/queries/department-model';
import { DepartmentService } from '../../../apis/department.service';
import { IFormDialogContainer, PageDialogConfig } from '../../../../../core/components/page-dialog/page-dialog.component';
import { Observable, of } from 'rxjs';
import { DynamicDialogConfig } from 'primeng/dynamicdialog';

@Component({
  selector: 'app-create-department-page',
  standalone: true,
  imports: [
    BasicModule,

  ],
  providers: [MessageService],
  templateUrl: './create-department-page.component.html',
  styleUrl: './create-department-page.component.scss'
})
export class CreateDepartmentPageComponent implements IFormDialogContainer {

  @Input()
  parentDepartment?: DepartmentModel;
  showValidationWarning = true;

  @Output()
  commandChange = new EventEmitter<CreateDepartmentCommand | null>();


  form = this.fb.group({
    code: this.fb.control<string | null>(null, Validators.required),
    title: this.fb.control<string | null>(null, Validators.required),


  })

  constructor(private messageService: MessageService,
    private departmentService: DepartmentService,
    public dialogConfig: DynamicDialogConfig<PageDialogConfig>,
    public fb: FormBuilder
  ) {
    this.parentDepartment = dialogConfig.data?.extraData;

  }

  ngOnInit() {


  }

  save(): Observable<boolean> {
    if (this.form.valid) {
      const command = <CreateDepartmentCommand>{
        ...<CreateDepartmentCommand>this.form.getRawValue(),
        parentId: this.parentDepartment?.id,
        branchId: this.parentDepartment?.branchId,
        positionIds: [0],
      }
      return new Observable((subscriber) => {
        this.departmentService.create(command).subscribe(data => {

          subscriber.next(true);
        });
      });

    }
    else
      return of(false);
  }


}