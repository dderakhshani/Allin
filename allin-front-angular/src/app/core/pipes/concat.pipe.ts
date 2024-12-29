import { Injectable, Pipe, PipeTransform } from '@angular/core';

interface Option {
  valueIfAllNull?: string;
  separator?: string;
}

@Pipe({
  name: 'concat',
  standalone: true
})
@Injectable({
  providedIn: 'root'
})
export class ConcatPipe implements PipeTransform {

  transform(
    stringArray: (string | undefined | null)[],
    options: Option | undefined = { valueIfAllNull: '', separator: ' ' }
  ): string {
    const result = stringArray.filter((name) => name).join(options.separator ?? ' ').trim()
    return result ? result : options.valueIfAllNull!
  }

}
