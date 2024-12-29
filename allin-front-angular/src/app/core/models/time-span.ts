import { inject, Injectable, InjectionToken } from "@angular/core";
import { BaseType } from "./base-type";


export class TimeSpan extends BaseType {
    public date: Date | null;

    static override[Symbol.hasInstance](value: any) {
        if (value)
            return value['date'] != undefined && value['date'] instanceof Date;
        return false;
    }

    /**
     * toJSON: will be used in Json.Stringify
     */
    public toJSON() {
        return this.toString();
    }

    constructor(hours?: number, minutes: number = 0, seconds: number = 0,) {
        super();
        if (hours || hours === 0)
            this.date = new Date(2000, 2, 10, hours, minutes, seconds);
        else
            this.date = null;
    }

    public override valueOf() {
        if (this.date)
            return this.date.valueOf();
        return -100000;
    }

    public override toString = (): string | null => {
        if (this.date) {
            const hours = this.date.getHours().toString().padStart(2, '0');
            const minutes = this.date.getMinutes().toString().padStart(2, '0');
            const seconds = this.date.getSeconds().toString().padStart(2, '0');

            // Replace format placeholders with actual time values
            let format = 'hh:mm';

            return format
                .replace(/hh/g, hours)
                .replace(/mm/g, minutes)
                .replace(/ss/g, seconds);
        }

        return null;
    }
    public getHours() {
        return this.date?.getHours();
    }
    public getMinutes() {
        return this.date?.getMinutes();
    }
    public getSeconds() {
        return this.date?.getSeconds();
    }
    public getTime() {
        return this.date?.getTime();
    }
    public getFullYear() {
        return this.date?.getFullYear();
    }
    public getMonth() {
        return this.date?.getMonth();
    }
    public getDay() {
        return this.date?.getDay();
    }
    public getDate() {
        return this.date?.getDate();
    }
    public getMilliseconds() {
        return this.date?.getMilliseconds();
    }
    public setHours(hours: number, min?: number, sec?: number, ms?: number): number {
        if (this.date)
            return this.date.setHours(hours, min, sec, ms);
        else {
            this.date = new Date(2000, 2, 10);
            return this.date.setHours(hours, min, sec, ms);
        }

    }
    public setMinutes(min: number, sec?: number, ms?: number): number {
        if (this.date)
            return this.date.setMinutes(min, sec, ms);
        else {
            this.date = new Date(2000, 2, 10);
            return this.date.setMinutes(min, sec, ms);
        }
    }
    public setSeconds(sec: number, ms?: number): number {
        if (this.date)
            return this.date.setSeconds(sec, ms);
        else {
            this.date = new Date(2000, 2, 10);
            return this.date.setSeconds(sec, ms);
        }
    }
    public setMilliseconds(ms: number): number {
        if (this.date)
            return this.date.setMilliseconds(ms);
        else {
            this.date = new Date(2000, 2, 10);
            return this.date.setMilliseconds(ms);
        }
    }
    public setTime(time: number): number {
        if (this.date)
            return this.date.setTime(time);
        else {
            this.date = new Date(2000, 2, 10);
            return this.date.setTime(time);
        }
    }

    public isValid() {
        return true;
    }
}


