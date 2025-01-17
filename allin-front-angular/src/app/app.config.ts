import { ApplicationConfig, importProvidersFrom, provideZoneChangeDetection } from '@angular/core';
import { provideRouter } from '@angular/router';
import { routes } from './app.routes';

import { provideAnimationsAsync } from '@angular/platform-browser/animations/async';
import { API_BASE_URL } from './core/services/base.http.service';
import { environment } from '../environments/environment';
import { HttpClient, provideHttpClient, withInterceptors } from '@angular/common/http';
import { provideTranslateService, TranslateLoader } from "@ngx-translate/core";
import { TranslateHttpLoader } from '@ngx-translate/http-loader';
import { providePrimeNG } from 'primeng/config';
import { definePreset } from '@primeng/themes';
import Aura from '@primeng/themes/aura';
import { httpErrorsInterceptor } from './core/interceptors/http-errors.interceptor';
import { MessageService } from 'primeng/api';
import { ToastModule } from 'primeng/toast';

const httpLoaderFactory: (http: HttpClient) => TranslateHttpLoader = (http: HttpClient) =>
    new TranslateHttpLoader(http, './i18n/', '.json');

const AuraBlue = definePreset(Aura, {
    semantic: {
        primary: {
            50: '{blue.50}',
            100: '{blue.100}',
            200: '{blue.200}',
            300: '{blue.300}',
            400: '{blue.400}',
            500: '{blue.500}',
            600: '{blue.600}',
            700: '{blue.700}',
            800: '{blue.800}',
            900: '{blue.900}',
            950: '{blue.950}'
        }
    }
});

export const appConfig: ApplicationConfig = {
    providers: [
        provideZoneChangeDetection({ eventCoalescing: true }), provideRouter(routes),
        provideAnimationsAsync(),
        providePrimeNG({
            ripple: true,
            theme: {
                preset: AuraBlue,
                options: {
                    darkModeSelector: '.dark',
                }
            }
        }),

        { provide: API_BASE_URL, useValue: `${environment.baseUrl}/api` },
        provideHttpClient(withInterceptors([httpErrorsInterceptor])),
        MessageService,
        importProvidersFrom(ToastModule),
        provideTranslateService({
            defaultLanguage: 'en',
            loader: {
                provide: TranslateLoader,
                useFactory: httpLoaderFactory,
                deps: [HttpClient],
            },
        })
    ]
};

