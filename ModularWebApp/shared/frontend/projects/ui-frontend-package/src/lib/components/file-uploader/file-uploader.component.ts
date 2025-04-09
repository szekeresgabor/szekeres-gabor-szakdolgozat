import { Component } from '@angular/core';
import { StorageService } from 'core-frontend-package';

@Component({
  selector: 'uip-file-uploader',
  standalone: false,
  templateUrl: './file-uploader.component.html',
  styleUrl: './file-uploader.component.css'
})
export class FileUploaderComponent {
  constructor(private storage: StorageService) { }

  onUpload(event: any): void {
    const file = event.file;
    if (file) {
      this.storage.uploadFile(file).subscribe();
    }
  }
}
