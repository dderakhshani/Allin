import { HttpRequest, HttpHandlerFn, HttpEvent, HttpErrorResponse } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { MessageService } from 'primeng/api';
import { ChangeDetectorRef, inject } from '@angular/core';

export function httpErrorsInterceptor(req: HttpRequest<unknown>, next: HttpHandlerFn): Observable<HttpEvent<unknown>> {
    const messageService = inject(MessageService); // Inject MessageService

    return next(req).pipe(
        catchError((error: HttpErrorResponse) => {
            let errorMessage = 'An unknown error occurred!';

            switch (error.status) {
                case 0:
                    errorMessage = 'No network connection. Please check your internet.';
                    break;
                case 400:// Bad Request
                    errorMessage = 'Bad Request: There might be a programming error.';
                    break;
                case 422:// Validation Error
                    errorMessage = 'Validation Errors:';
                    if (error.error.errors) {
                        var message = '';
                        Object.entries(error.error.errors).forEach(([index, item]) => {
                            errorMessage += (item as any).errorMessage + '\r\n';
                        });
                    }
                    break;
                case 500:// Internal Server Error
                    errorMessage = 'Internal Server Error: A programming error occurred.';
                    break;
                default:
                    errorMessage = `Error ${error.status}: ${error.message}`;
            }
            messageService.add({ severity: 'error', summary: 'Error', detail: errorMessage, key: 'br', life: 3000 });

            // Return a user-friendly error
            return throwError(() => new Error(errorMessage));
        })
    );
}
