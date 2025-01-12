
import { Component, OnInit, Inject, Input, TemplateRef, Type, ViewChild, ViewContainerRef, AfterViewInit } from '@angular/core';
import { DynamicDialogConfig, DynamicDialogRef } from 'primeng/dynamicdialog';

export interface ConfirmDialogModel {
    title: string;
    message: string;
    headerCssClasses: string;
    messageCssClasses?: string;
    mainActionButtonConfigs?: ConfirmDialogActionButtonConfig;
    secondaryActionButtonConfigs?: ConfirmDialogActionButtonConfig;
    contentAreaTemplate?: TemplateRef<any>;
    actionAreaTemplate?: TemplateRef<any>;
    showModalHeader?: boolean | undefined;
    showModalFooter?: boolean | undefined;
    showDismissButton?: boolean | undefined;

    extraData?: any;

    mainButtonDisabled?: () => boolean;
}

export interface ConfirmDialogActionButtonConfig { title: string, color: string }

export interface ConfirmDialogActionButtonConfig { title: string, color: string }

@Component({
    selector: 'app-confirm-dialog',
    templateUrl: './confirm-dialog.component.html',
    styleUrls: ['./confirm-dialog.component.scss']
})
export class ConfirmDialogComponent {

    protected config: ConfirmDialogModel;

    constructor(public dialogRef: DynamicDialogRef,
        public dialogConfig: DynamicDialogConfig<ConfirmDialogModel>,) {

        this.config = dialogConfig.data!;

        this.config.headerCssClasses = this.config.headerCssClasses || 'bg-primary-500';
        this.config.showModalHeader = this.config.showModalHeader || true;
        this.config.showModalFooter = this.config.showModalFooter || true;

        this.config.mainActionButtonConfigs = {
            title: this.config.mainActionButtonConfigs?.title || "OK",
            color: this.config.mainActionButtonConfigs?.color || 'primary'
        };

        this.config.secondaryActionButtonConfigs = {
            title: this.config.secondaryActionButtonConfigs?.title || 'CANCEL',
            color: this.config.secondaryActionButtonConfigs?.color || 'primary'
        };

    }

    onConfirm(): void {
        this.dialogRef.close(true);
    }

    onDismiss(): void {
        this.dialogRef.close(false);
    }
}

/**
 * Class to represent confirm dialog model.
 *
 * It has been kept here to keep it as part of shared component.
 */
