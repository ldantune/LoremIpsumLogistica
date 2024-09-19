import { Pipe, PipeTransform } from '@angular/core';
import { Constants } from '../util/Constants';
import { DatePipe } from '@angular/common';

@Pipe({
  name: 'dateFormat'
})
export class DateFormatPipe extends DatePipe implements PipeTransform {

  override transform(value: any, args?: any): any {
    return super.transform(value, Constants.DATE_FMT);
  }
}
