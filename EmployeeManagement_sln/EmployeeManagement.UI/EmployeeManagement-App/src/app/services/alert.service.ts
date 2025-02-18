import { Injectable } from '@angular/core';
import {HotToastService} from '@ngneat/hot-toast'
@Injectable({
  providedIn: 'root'
})
export class AlertService {

  constructor(private toastService:HotToastService) { }
  success(message: string) {
    this.toastService.success(message, {
      style: {
        border: '1px solid #ddd',
        padding: '16px',
        color: '#1E1E1E',
        background: '#E8F6F0',
  
      },
      position:'top-right',
      iconTheme: {
        primary: '#49CC90',
        secondary: '#FFFAEE',
  
      },
      dismissible: true,
      autoClose:true
    });
  }
  error(message: string) {
    console.log(message);
   
    let truncatedMessage = message;
  
   
    this.toastService.error(truncatedMessage, {
      style: {
        border: '1px solid #ddd',
        padding: '16px',
        color: '#eb4039',
        background: '#ffc2b3',
  
      },
      position:'top-right',
      iconTheme: {
        primary: '#eb4039',
        secondary: '#FFFAEE',
  
      },
      dismissible: true,
    });
  }
  warningToast(message: string) {
    this.toastService.warning(message, {
      style: {
        border: '1px solid #ddd',
        padding: '16px',
      },
      position:'top-right',
      dismissible: true,
    });
  }

}
