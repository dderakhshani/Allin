import { Pipe, PipeTransform } from '@angular/core';
import { Observable, isObservable, of } from 'rxjs';

@Pipe({
  name: 'observableOrArray',
  standalone: true,
})
export class ObservableOrArrayPipe implements PipeTransform {
  transform<T>(value: Observable<T[]> | T[]): Observable<T[]> {
    if (isObservable(value)) {
      return value; // Pass through if it's already an Observable
    }
    return of(value); // Wrap the array into an Observable
  }
}
