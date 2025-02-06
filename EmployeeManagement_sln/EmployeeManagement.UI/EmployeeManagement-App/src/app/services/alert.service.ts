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
    const words = message.split(' ');
    let truncatedMessage = '';
  
    for (const word of words) {
      if (word.length > 15) {
        const splitWords = [];
        let currentWord = '';
  
        for (let i = 0; i < word.length; i++) {
          currentWord += word[i];
  
          if (currentWord.length === 15) {
            splitWords.push(currentWord);
            currentWord = '';
          }
        }
  
        if (currentWord.length > 0) {
          splitWords.push(currentWord);
        }
  
        truncatedMessage += splitWords.join(' ') + ' ';
      } else {
        truncatedMessage += word + ' ';
      }
    }
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
