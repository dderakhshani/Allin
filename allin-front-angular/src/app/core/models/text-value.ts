export interface TextValue<T = number> {
    text: string;
    value: T;
    extraProperties?: any;
}