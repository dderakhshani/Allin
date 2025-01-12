import { CommonModule } from '@angular/common';
import { Component, TemplateRef, Type, ViewChild, ViewContainerRef } from '@angular/core';
import { FormGroup, FormsModule } from '@angular/forms';
import { TranslateService } from '@ngx-translate/core';
import { ConfirmationService } from 'primeng/api';
import { ButtonModule } from 'primeng/button';
import { DialogService, DynamicDialogConfig, DynamicDialogRef } from 'primeng/dynamicdialog';
import { StepperModule } from 'primeng/stepper';
import { TimelineModule } from 'primeng/timeline';
import { Observable } from 'rxjs';


export interface PageDialogConfig {
    header: string;
    description?: string,
    mainActionButtonConfigs?: DialogActionButtonConfig;
    secondaryActionButtonConfigs?: DialogActionButtonConfig;
    component?: Type<any> | TemplateRef<any>;
    extraData?: any;
    customActionsTemplate?: TemplateRef<any>;
    onConfirm?: () => void;
    canDismiss?: (componentInstance?: IFormDialogContainer) => boolean;
    onDismiss?: () => void;
    mainButtonDisabled?: () => boolean;
    showModalHeader?: boolean | undefined;
    showModalFooter?: boolean | undefined;
    showDismissButton?: boolean | undefined;
    steps?: DialogSteps[];
    isFullScreen?: boolean;
    /**
     * Use this config if you want to add a custom css class to the dialog content e.g. overwrite the default responsive classes of the content.
     * 
     * The default is "w-full md:w-4/5 lg:w-3/4 max-w-5xl min-w-80", it is a document :D, to be sure check the html template.
    */
    customCssClasses?: string;
}
export interface DialogSteps {
    caption: string;
    description: string;
    index: number;
}
export interface DialogActionButtonConfig { title?: string, color?: 'success' | 'info' | 'warn' | 'danger' | 'help' | 'primary' | 'secondary', visible?: boolean }

@Component({
    selector: 'app-page-dialog',
    providers: [DialogService, ConfirmationService],
    standalone: true,
    imports: [
        CommonModule,
        FormsModule,
        ButtonModule,
        TimelineModule
    ],
    templateUrl: './page-dialog.component.html',
    styleUrl: './page-dialog.component.scss'
})
export class PageDialogComponent {

    @ViewChild('container', { read: ViewContainerRef })
    protected container!: ViewContainerRef;
    protected componentInstance?: IFormDialogContainer;
    protected templateContent: any;
    protected config: PageDialogConfig;
    protected selectedStepIndex = 0;

    constructor(public dialogRef: DynamicDialogRef,
        public dialogConfig: DynamicDialogConfig<PageDialogConfig>,
        private confirmationService: ConfirmationService,
        private translate: TranslateService) {

        this.config = dialogConfig.data!;

        // if (this.config.isFullScreen !== false) {
        //     dialogConfig.height = '100%';
        //     dialogConfig.width = '100%';
        // }

        this.config.mainActionButtonConfigs = {
            title: this.config.mainActionButtonConfigs?.title || this.translate.instant("save"),
            color: this.config.mainActionButtonConfigs?.color || 'primary',
            visible: true
        };

        this.config.secondaryActionButtonConfigs = {
            title: this.config.secondaryActionButtonConfigs?.title || this.translate.instant("cancel"),
            color: this.config.secondaryActionButtonConfigs?.color || 'secondary',
            visible: this.config.secondaryActionButtonConfigs?.visible != undefined ? this.config.secondaryActionButtonConfigs?.visible : true
        };
        this.config.showModalHeader = this.config.showModalHeader ?? true;
        this.config.showModalFooter = this.config.showModalFooter ?? true;

        if (!this.config.canDismiss) {
            //it is the default of canDismiss
            this.config.canDismiss = () => this.componentInstance?.form === undefined || this.componentInstance?.form?.pristine;
        }

    }

    ngOnInit(): void {

    }

    ngAfterViewInit(): void {
        if (this.config.component instanceof Type) {
            this.loadComponent();
        }
        else
            this.templateContent = this.config.component as TemplateRef<any>;
    }

    loadComponent() {
        this.container.clear();
        const componentRef = this.container?.createComponent(this.config.component as Type<any>);
        this.componentInstance = componentRef.instance;
    }

    onNext() {
        this.selectedStepIndex += 1;
    }

    onConfirm() {
        this.componentInstance?.save().subscribe(result => {
            if (result) {
                this.config.onConfirm?.();
                this.dialogRef.close(true);
            }
        });

    }

    onDismiss(): void {
        if (this.config.canDismiss!(this.componentInstance) == false) {

            this.confirmationService.confirm({
                message: `There are some unsaved data, Are you sure you want to exit?`,
                header: 'Confirmation',
                acceptLabel: 'Confirm Exit',
                rejectLabel: 'Cancel',
                icon: 'pi pi-exclamation-triangle',
                acceptButtonStyleClass: "p-button-warning",
                acceptIcon: "none",
                rejectIcon: "none",
                accept: this.dismiss,
            });

        }
        else
            this.dismiss();
    }

    private dismiss = () => {
        this.config.onDismiss?.();
        // Close the dialog, return false
        this.dialogRef.close(false);
    }
}

export function openDialog(config: PageDialogConfig, dialogService: DialogService) {

    return dialogService.open(PageDialogComponent, {
        data: config,
        header: config.header,
        styleClass: "full-screen-dialog",
        closable: true,
        modal: true,
        contentStyle: { overflow: 'auto' },
    });
}

export interface IFormDialogContainer {
    form?: FormGroup<any>;
    save(): Observable<boolean>;
}
