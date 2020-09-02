import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'uniqueFilter'
})
export class UniqueFilterByPipe implements PipeTransform {

  transform(arr: any[], property?:string): any[] {
    if (!arr) return [];
    let newArr = [];
    arr.forEach(element => {
        if (!newArr.find(el => {
            if(property)
                return el[property] == element[property];
            else
                return el == element;
        })) {
            newArr.push(element);
        }
    });
    
    return newArr;
  }
}