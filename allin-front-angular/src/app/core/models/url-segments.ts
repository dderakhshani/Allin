export interface UrlSegments {
    controller: string;
    action?: string;
    routeParameters?: any[];
    queryStringParams?: { [key: string]: string | number | boolean | undefined | string[] | number[] };
}