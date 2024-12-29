import { ApplicationConfig, provideZoneChangeDetection } from '@angular/core';
import { provideRouter } from '@angular/router';

import { routes } from './app.routes';

import { provideAnimationsAsync } from '@angular/platform-browser/animations/async';
import { API_BASE_URL } from './core/services/base.http.service';
import { environment } from '../environments/environment';
import { provideHttpClient } from '@angular/common/http';


export const appConfig: ApplicationConfig = {
    providers: [
        provideZoneChangeDetection({ eventCoalescing: true }), provideRouter(routes),
        provideAnimationsAsync(),
        provideHttpClient(),
        { provide: API_BASE_URL, useValue: `${environment.baseUrl}/admin/api` },
    ]
};
