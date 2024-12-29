
import { Inject, Injectable, InjectionToken } from '@angular/core';
import { HttpClient, HttpErrorResponse, HttpEvent, HttpHeaders, HttpParams } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError, map } from 'rxjs/operators';
import { getObjectParsedFromString } from '../models/type-converter';


export const API_BASE_URL = new InjectionToken<string>('API_BASE_URL');

@Injectable({
    providedIn: 'root'
})
export class BaseHttpService {

    constructor(@Inject(API_BASE_URL) public apiBaseUrl: string,
        private http: HttpClient,) {
    }

    private makeFullUrl(urlSegments: UrlSegments): string {
        let fullUrl: string = `${this.apiBaseUrl}/${urlSegments.controller}`;
        if (urlSegments.action) {
            fullUrl += `/${urlSegments.action}`;
        }
        if (urlSegments.routeParameters?.length) {
            fullUrl += "/"
            urlSegments.routeParameters.forEach(parameter => {
                fullUrl += `${parameter}/`;
            });
        }

        if (urlSegments.queryStringParams) {
            fullUrl += "?"
            Object.keys(urlSegments.queryStringParams).forEach(key => {
                const value = urlSegments.queryStringParams![key];
                if (value instanceof Array) {
                    value.forEach(v => {
                        // encoding URI to handle special characters, like +
                        fullUrl += `${encodeURIComponent(key)}=${encodeURIComponent(v)}&`;
                    });
                } else {
                    fullUrl += `${encodeURIComponent(key)}=${value ? encodeURIComponent(value.toString()) : value}&`;
                }
            });
        }
        return fullUrl;
    }

    getStringData(urlSegments: UrlSegments): Observable<string> {
        return this.http.get(this.makeFullUrl(urlSegments), { responseType: 'text' });
    }


    getData<T>(urlSegments: UrlSegments, headers: any = null): Observable<T> {
        let httpRequest: Observable<T>;
        if (headers)
            httpRequest = this.http.get<T>(this.makeFullUrl(urlSegments), { headers });
        else
            httpRequest = this.http.get<T>(this.makeFullUrl(urlSegments));
        return httpRequest.pipe(
            map(item => {
                item = this.reviveNonPrimitiveTypes(item);
                return item;
            })
        )
            ;;
    }

    postJsonData<T>(urlSegments: UrlSegments, data: any): Observable<T> {
        const headers = { 'Content-Type': 'application/json' }
        return this.http.post<T>(this.makeFullUrl(urlSegments), JSON.stringify(data), { headers }).pipe(
            map(item => {
                item = this.reviveNonPrimitiveTypes(item);
                return item;
            })
        )
            ;

    }


    postFileData<T>(urlSegments: UrlSegments, files: File[]): Observable<HttpEvent<T>> {
        const formData: FormData = new FormData();

        Array.from(files).map((file, index) => {
            return formData.append('file' + index, file, file.name);
        });

        return this.http.post<T>(this.makeFullUrl(urlSegments), formData, { reportProgress: true, observe: "events" }).pipe(
            map(item => {
                item = this.reviveNonPrimitiveTypes(item);
                return item;
            })
        )
            ;

    }

    postFormData<T>(urlSegments: UrlSegments, formData: FormData): Observable<T> {
        return this.http.post<T>(this.makeFullUrl(urlSegments), formData).pipe(
            map(item => {
                item = this.reviveNonPrimitiveTypes(item);
                return item;
            })
        )
            ;

    }

    getFileData(urlSegments: UrlSegments): Observable<any> {
        const headers = {
            'cache-control': 'no-cache, must-revalidate, post-check=0, pre-check=0',
            'pragma': 'no-cache',
            'expires': '0'
        };

        return this.http.get(this.makeFullUrl(urlSegments), { headers, responseType: 'blob' });
    }


    putJsonData<T>(urlSegments: UrlSegments, data: any): Observable<T> {
        const headers = { 'Content-Type': 'application/json' }
        return this.http.put<T>(this.makeFullUrl(urlSegments), JSON.stringify(data), { headers })
            .pipe(
                map(item => {
                    item = this.reviveNonPrimitiveTypes(item);
                    return item;
                })
            )
            ;
    }
    putJsonList<T>(param: string, data: any[], controller: String): Observable<T> {
        const headers = { 'Content-Type': 'application/json' }
        return this.http.put<T>(`${this.apiBaseUrl}/${controller}/${param}`, JSON.stringify(data), { headers }).pipe(
            map(item => {
                item = this.reviveNonPrimitiveTypes(item);
                return item;
            })
        );
    }


    patchJsonData<T>(urlSegments: UrlSegments, data?: any): Observable<T> {
        const headers = { 'Content-Type': 'application/json' }
        return this.http.patch<T>(this.makeFullUrl(urlSegments), JSON.stringify(data), { headers })
            .pipe(
                map(item => {
                    item = this.reviveNonPrimitiveTypes(item);
                    return item;
                })
            )
            ;
    }
    deleteData<T>(urlSegments: UrlSegments): Observable<T> {
        const headers = { 'Content-Type': 'application/json' }

        return this.http.delete<T>(this.makeFullUrl(urlSegments), { headers });

    }


    private readonly nameToFindType = "typeToReviveInInterceptor";

    private reviveValue = (item: any): any => {
        const value: string = item.value;

        if (item.value == null) {
            // this should not ideally happen; back-end's job.
            return null;
        }

        return getObjectParsedFromString(item[this.nameToFindType], value);

    }

    private reviveNonPrimitiveTypes = (item: any): any => {
        if (item == null || "object" !== typeof item) {
            return item;
        }

        // Handle Array
        if (item instanceof Array) {
            for (let index = 0; index < item.length; index++) {
                item[index] = this.reviveNonPrimitiveTypes(item[index]);
            }
            return item;
        }

        if (item[this.nameToFindType]) {
            item = this.reviveValue(item);
        } else {
            Object.keys(item).forEach(key => {
                item[key] = this.reviveNonPrimitiveTypes(item[key]);
            });
        }

        return item;
    }
}

export interface UrlSegments {
    controller: string;
    action?: string;
    routeParameters?: any[];
    queryStringParams?: { [key: string]: string | number | boolean | undefined | string[] | number[] };
}

