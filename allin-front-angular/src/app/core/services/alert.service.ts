import { Observable } from 'rxjs';
import { finalize, take } from 'rxjs/operators';
import { Injectable } from '@angular/core';
import { DialogService, DynamicDialogRef } from 'primeng/dynamicdialog';
import { ConfirmDialogComponent, ConfirmDialogModel } from '../components/confirm-dialog/confirm-dialog.component';

interface ProccessingOptions<T> {
    execute$: () => Observable<T>;
    onSucess?: (result: T) => void;
    onFinalize?: () => void;
    onError?: (result: any) => void;
    loadingMessage?: string;
    finishedMessage?: string;
    showFinishedMessage?: boolean,
    confirmMessage?: string,
    confirmation?: boolean,
    confirmationType?: 'info' | 'warn',
    confirmButtonCaption?: string,
    cancelButtonCaption?: string,
}

@Injectable({ providedIn: 'root' })
export class ProccessingService {
    ref: DynamicDialogRef | undefined;

    constructor(public dialogService: DialogService) {
    }

    public saveSubscribe<T>(options: ProccessingOptions<T>): void {
        if (!options.loadingMessage) options.loadingMessage = 'Saving...';
        if (!options.finishedMessage) options.finishedMessage = 'Item saved';

        this.generalSubscribe(options);
    }

    public deleteSubscribe<T>(options: ProccessingOptions<T>): void {
        if (!options.loadingMessage) options.loadingMessage = 'Deleting...';
        if (!options.finishedMessage) options.finishedMessage = 'Item deleted';

        this.generalSubscribe(options);
    }

    public generalSubscribe<T>(options: ProccessingOptions<T>): void {
        if (!options.loadingMessage) options.loadingMessage = 'Loading...';
        if (!options.finishedMessage) options.finishedMessage = 'Done';

        const call = () => {
            // let snackbarRef = this.snackBar.open(options.loadingMessage!);
            options.execute$()
                .pipe(
                    finalize(() => {
                        // snackbarRef.dismiss();
                        if (options.onFinalize)
                            options.onFinalize();
                    }),
                    take(1)
                ).subscribe({
                    next: (result) => {
                        if (options.onSucess) {
                            options.onSucess(result);
                        }
                        // if (options.showFinishedMessage)
                        //     this.snackBar.open(options.finishedMessage!, 'OK', { duration: 8 * 1000 });
                    },
                    error: options.onError
                });
        };

        if (options.confirmation === true) {
            //Defaults of warn confirmation
            let headerCssClasses = "bg-red-400 text-white";
            let mainActionButtonColor = "warn";

            if (options.confirmationType === 'info') {
                headerCssClasses = "bg-primary-500";
                mainActionButtonColor = "primary";
            }

            const data: ConfirmDialogModel = {
                title: 'Confirmation',
                headerCssClasses: headerCssClasses,
                message: options.confirmMessage ? options.confirmMessage : "Are you sure you'd like to delete this? It cannot be undone.",
                messageCssClasses: 'text-neutral-950 whitespace-pre-line',
                mainActionButtonConfigs: {
                    title: options.confirmButtonCaption ?? "OK",
                    color: mainActionButtonColor
                },
                secondaryActionButtonConfigs: {
                    title: options.cancelButtonCaption ?? "CANCEL",
                    color: 'Basic'
                }
            };

            this.ref = this.dialogService.open(ConfirmDialogComponent, {
                header: 'Confirmation',
                width: '300px',
                modal: true,
                breakpoints: {
                    '960px': '75vw',
                    '640px': '90vw'
                },
            });

            this.ref.onClose.subscribe(result => {
                if (result) {
                    call();
                }
            });
        }
        else
            call();
    }
}
