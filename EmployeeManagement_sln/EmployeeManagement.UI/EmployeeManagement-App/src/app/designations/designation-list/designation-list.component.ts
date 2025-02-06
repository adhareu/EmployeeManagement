import { Component } from '@angular/core';
import { HotToastService } from '@ngneat/hot-toast';
@Component({
  selector: 'app-designation-list',
  imports: [],
  templateUrl: './designation-list.component.html',
  styleUrl: './designation-list.component.css'
})
export class DesignationListComponent {
constructor(private toast: HotToastService)
{

}
showToast() {
  this.toast.show('Hello World!');
  this.toast.loading('Lazyyy...');
  this.toast.success('Yeah!!');
  this.toast.warning('Boo!');
  this.toast.error('Oh no!');
  this.toast.info('Something...');
}
}
