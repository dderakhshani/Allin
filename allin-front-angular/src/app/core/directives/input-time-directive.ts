import { Directive, ElementRef, HostListener, Renderer2 } from "@angular/core";
import {
    AbstractControl,
    ControlValueAccessor,
    NG_VALIDATORS,
    NG_VALUE_ACCESSOR,
    ValidationErrors,
    Validator,
} from "@angular/forms";
import { TimeSpan } from "../models/time-span";


@Directive({
    selector: "input[type=time]",
    providers: [
        {
            provide: NG_VALUE_ACCESSOR,
            useExisting: InputTimeDirective,
            multi: true,
        },
        {
            provide: NG_VALIDATORS,
            useExisting: InputTimeDirective,
            multi: true,
        },
    ],
})
export class InputTimeDirective implements ControlValueAccessor, Validator {
    constructor(
        private _elementRef: ElementRef<HTMLInputElement>,
        private _renderer: Renderer2
    ) { }

    @HostListener("input", ["$event.target.value"])
    onInput = (_: any) => { };

    writeValue(value: TimeSpan | null): void {
        const time = value || new TimeSpan();
        this._renderer.setProperty(
            this._elementRef.nativeElement,
            "value",
            time.toString() ?? ""
        );
    }

    registerOnChange(fn: any): void {
        this.onInput = (value: string) => {
            let timeValues = value.split(":");
            const telephone = new TimeSpan(
                parseInt(timeValues[0]),
                parseInt(timeValues[1] ?? 0),
                parseInt(timeValues[2] ?? 0)
            );
            fn(telephone);
        };
    }

    registerOnTouched(fn: any): void { }

    validate(control: AbstractControl): ValidationErrors | null {
        const time = control.value as TimeSpan;
        if (time == null || time == undefined)
            return null;
        return time?.isValid() ? null : { invalidTimeSpan: true };
    }
}