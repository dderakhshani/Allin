
import { CommonModule } from '@angular/common';
import { Component, OnInit, Inject, Input, TemplateRef, Type, ViewChild, ViewContainerRef, AfterViewInit } from '@angular/core';
import { ButtonModule } from 'primeng/button';
import { DialogService, DynamicDialogConfig, DynamicDialogRef } from 'primeng/dynamicdialog';

export interface ConfirmDialogConfig {
    title: string;
    message: string;
    headerCssClasses: string;
    messageCssClasses?: string;
    mainActionButtonConfigs?: ConfirmDialogActionButtonConfig;
    secondaryActionButtonConfigs?: ConfirmDialogActionButtonConfig;
    contentAreaTemplate?: TemplateRef<any>;
    actionAreaTemplate?: TemplateRef<any>;

    mainButtonDisabled?: () => boolean;
}

export interface ConfirmDialogActionButtonConfig { title: string, color: 'success' | 'info' | 'warn' | 'danger' | 'help' | 'primary' | 'secondary' }

export interface ConfirmDialogActionButtonConfig { title: string, color: 'success' | 'info' | 'warn' | 'danger' | 'help' | 'primary' | 'secondary' }

@Component({
    selector: 'app-confirm-dialog',
    templateUrl: './confirm-dialog.component.html',
    standalone: true,
    imports: [
        CommonModule,
        ButtonModule,
    ],
    styleUrls: ['./confirm-dialog.component.scss']
})
export class ConfirmDialogComponent {

    protected config: ConfirmDialogConfig;

    constructor(public dialogRef: DynamicDialogRef,
        public dialogConfig: DynamicDialogConfig<ConfirmDialogConfig>,) {

        this.config = dialogConfig.data!;

        this.config.headerCssClasses = this.config.headerCssClasses || 'bg-primary-500';


        this.config.mainActionButtonConfigs = {
            title: this.config.mainActionButtonConfigs?.title || "OK",//TODO: translate
            color: this.config.mainActionButtonConfigs?.color || 'primary'
        };

        this.config.secondaryActionButtonConfigs = {
            title: this.config.secondaryActionButtonConfigs?.title || 'Cancel',//TODO: translate
            color: this.config.secondaryActionButtonConfigs?.color || 'secondary'
        };

    }

    onConfirm(): void {
        this.dialogRef.close(true);
    }

    onDismiss(): void {
        this.dialogRef.close(false);
    }
}


export function openConfirmDialog(config: ConfirmDialogConfig, dialogService: DialogService) {

    return dialogService.open(ConfirmDialogComponent, {
        data: config,
        header: config.title,
        closable: true,
        modal: true,
        contentStyle: { overflow: 'auto' },
    });
}

export function openConfirmDeleteDialog(message: string, dialogService: DialogService) {

    return dialogService.open(ConfirmDialogComponent, {
        data: <ConfirmDialogConfig>{
            title: 'Confirm Delete',//TODO: translate
            message: message,
            mainActionButtonConfigs: {
                title: 'Delete',
                color: 'danger'
            },
            secondaryActionButtonConfigs: {
                title: 'Cancel',
                color: 'secondary'
            }
        },
        header: 'Confirm Delete',//TODO: translate,
        closable: true,
        modal: true,
        contentStyle: { overflow: 'auto' },
    });
}