import { SqDateTime } from "./sq-date-time";
import { TimeSpan } from "./time-span";

export function getObjectParsedFromString(typeName: string, value: any) {
    /* if (!value) return value;
     let object = new ClassStore[`Sq${typeName}`];
     object.set(value);
     return object;*/

    switch (typeName) {
        case "DateOnly":
            const [year, month, day] = value.split('-');
            return new SqDateTime(true, new Date(year, month - 1, day));
        case "DateTimeOffset":
            return new SqDateTime(false, new Date(value));
        case "DateTime":
            return new SqDateTime(true, new Date(value));
        case "TimeSpan": case "TimeOnly":
            return parseTimeSpan(value);
        default:
            break;
    }
    throw new Error(`There is no corresponding type for ${typeName}`);
}

export const parseTimeSpan = (time: string): TimeSpan | null => {
    const parsedTime = parseTime(time);
    if (!parsedTime) return null;
    return new TimeSpan(parsedTime.hours, parsedTime.minutes, parsedTime.seconds);
}

export const parseTime = (time: string): { hours: number, minutes: number, seconds: number } | null => {
    if (!time.length) {
        return null;
    }
    const splitted = time.split(":", 3);
    const hours = +splitted[0];
    let minutes = 0;
    let seconds = 0;
    if (splitted.length > 1) {
        minutes = +splitted[1];
        if (splitted.length > 2) {
            seconds = +splitted[2];
        }
    }
    return { hours: hours, minutes: minutes, seconds: seconds };
}
