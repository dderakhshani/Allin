import moment, { DurationInputArg1, DurationInputArg2 } from 'moment/moment';
import { BaseType } from './base-type';


export class SqDateTime extends BaseType {
    public date: Date;
    public excludeTimeZone: boolean;

    static [Symbol.hasInstance](value: any) {
        if (value)
            return value["excludeTimeZone"] != undefined && value['date'] != undefined && !isNaN(Date.parse(value['date']));
        return false;
    }

    /**
     * toJSON: will be used in Json.Stringify
     */
    public toJSON() {
        if (!this.date)
            return null;

        return this.excludeTimeZone ? this.getAdjustedDate() : this.date.toJSON();
    }

    constructor(excludeTimeZone: boolean = true, date: Date = new Date()) {
        super();
        this.date = date;
        this.excludeTimeZone = excludeTimeZone;
    }

    public static parse(excludeTimeZone: boolean = true, value: any) {
        return new SqDateTime(excludeTimeZone, new Date(value));
    }

    public override valueOf() {
        if (!this.date)
            return null;

        return this.excludeTimeZone ? this.getAdjustedDate().valueOf() : this.date.valueOf();
    }

    public override toString = (): string => {
        return this.date.toString();//`${this.getHours()}:${this.getMinutes()}:${this.getSeconds()}`;
    }
    public getHours() {
        return this.date.getHours();
    }
    public getMinutes() {
        return this.date.getMinutes();
    }
    public getSeconds() {
        return this.date.getSeconds();
    }
    public getTime() {
        return this.date.getTime();
    }
    public getFullYear() {
        return this.date.getFullYear();
    }
    public getMonth() {
        return this.date.getMonth();
    }
    public getDay() {
        return this.date.getDay();
    }
    public getDate() {
        return this.date.getDate();
    }
    public getMilliseconds() {
        return this.date.getMilliseconds();
    }
    public setHours(hours: number, min?: number, sec?: number, ms?: number): number {
        return this.date.setHours(hours, min ?? 0, sec ?? 0, ms ?? 0);
    }
    public setMinutes(min: number, sec?: number, ms?: number): number {
        return this.date.setMinutes(min, sec, ms);
    }
    public setSeconds(sec: number, ms?: number): number {
        return this.date.setSeconds(sec, ms);
    }
    public setMilliseconds(ms: number): number {
        return this.date.setMilliseconds(ms);
    }
    public setTime(time: number): number {
        return this.date.setTime(time);
    }
    public setDate(date: number): number {
        return this.date.setDate(date);
    }

    /**
 * Formats the date using the provided format string or default format 'DD MMM YYYY', ex., 01 Jan 2024
 *
 * @param {string} formatString - Optional format string to format the date. See https://momentjs.com/docs/#/displaying/ for more formatting options.
 * @return {string} The formatted date string.
 */
    public format(formatString: string | undefined = undefined): string {
        return moment(this.date).format(formatString ?? 'D MMM YYYY');
    }

    public add(amount?: DurationInputArg1, unit?: DurationInputArg2) {
        let date = moment(this.date);
        date = date.add(amount, unit);
        return new SqDateTime(this.excludeTimeZone, date.toDate());
    }

    public subtract(amount?: DurationInputArg1, unit?: DurationInputArg2) {
        let date = moment(this.date);
        date = date.subtract(amount, unit);
        return new SqDateTime(this.excludeTimeZone, date.toDate());
    }

    public diff(date: SqDateTime, unit: DurationInputArg2) {
        return moment(this.date).diff(date.date, unit);
    }

    public getNextWeekStart() {
        let date = moment(this.date);
        //edited part
        let daysToMonday = 0 - (date.isoWeekday() - 1) + 7;
        let nextMonday = date.add(daysToMonday, 'days');

        return new SqDateTime(this.excludeTimeZone, nextMonday.toDate());
    }

    public getNextWeekEnd() {
        let nextMonday = this.getNextWeekStart();
        let nextSunday = nextMonday.subtract(2, 'days');

        return nextSunday;
    }

    public getLastWeekStart() {
        let today = moment();
        let daysToLastMonday = 0 - (1 - today.isoWeekday()) + 7;

        let lastMonday = today.subtract(daysToLastMonday, 'days');

        return new SqDateTime(this.excludeTimeZone, lastMonday.toDate());;
    }

    public getLastWeekEnd() {
        let lastMonday = this.getLastWeekStart();
        let lastSaturday = lastMonday.add(5, 'days');

        return lastSaturday;
    }

    public getSaturday() {
        let date = new Date();
        let saturday = new Date(
            date.setDate(
                this.date.getDate() + ((7 - this.date.getDay() + 6) % 7 || 7) - 7,
            )
        );

        return new SqDateTime(this.excludeTimeZone, saturday);
    }

    public getNextSaturday() {
        let date = new Date();
        let nextSaturday = new Date(
            date.setDate(
                this.date.getDate() + ((7 - this.date.getDay() + 6) % 7 || 7),
            )
        );
        return new SqDateTime(this.excludeTimeZone, nextSaturday);
    }

    public getNextFriday() {
        let date = new Date();
        let nextFriday = new Date(
            date.setDate(
                this.date.getDate() + ((7 - this.date.getDay() + 5) % 7 || 7),
            )
        );

        return new SqDateTime(this.excludeTimeZone, nextFriday);
    }

    private getAdjustedDate(): string {
        const temp = moment(this.date);
        return temp.format('YYYY-MM-DDTHH:mm:ss');
    }

    public getParseDate(): string {
        //return "YYYY-MM-DD"
        return this.date.toISOString().split('T')[0];
    }
}