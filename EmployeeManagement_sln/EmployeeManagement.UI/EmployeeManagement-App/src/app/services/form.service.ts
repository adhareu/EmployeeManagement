import { Injectable } from '@angular/core';
import { FormControl } from '@angular/forms';

@Injectable({
  providedIn: 'root'
})
export class FormService {

  constructor() { }
  isEdit(formControl:any):boolean
  {
    formControl=formControl as FormControl;
    if(formControl.value==null|| formControl.value==''||formControl.value==0)
    {
      return false;
    }
    return true;
  }
}
