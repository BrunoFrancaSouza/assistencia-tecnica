import { Pipe, PipeTransform } from '@angular/core';
import { DatePipe } from '@angular/common';

@Pipe({
  name: 'DateFormatPipe'
})
export class DateFormatPipePipe extends DatePipe implements PipeTransform {

  transform(value: Date, args?: any): any {
    return super.transform(value, 'dd/MM/yyyy');
  }

}
