import { HttpEvent, HttpEventType, HttpResponse } from '@angular/common/http';
import { Component, EventEmitter, Output } from '@angular/core';
import { StorageService } from 'core-frontend-package';
import { finalize } from 'rxjs';

@Component({
  selector: 'uip-file-uploader',
  standalone: false,
  templateUrl: './file-uploader.component.html',
  styleUrl: './file-uploader.component.css'
})
export class FileUploaderComponent {
  @Output() fileUploaded = new EventEmitter<{ id: string, name: string }>();

  selectedFile: File | null = null;
  uploading = false;

  constructor(private storage: StorageService) { }

  onFileSelected(event: any): void {
    const file = event.value?.[0];
    if (file) {
      this.selectedFile = file;
    }
  }

  uploadSelectedFile(): void {
    if (!this.selectedFile) return;

    this.uploading = true;

    this.storage.uploadFile(this.selectedFile).pipe(
      finalize(() => this.uploading = false)
    ).subscribe({
      next: (res: HttpEvent<any>) => {
        if (res.type === HttpEventType.Response) {
          const response = res as HttpResponse<any>;
          const id = response.body?.id;
          if (id) {
            this.fileUploaded.emit({ id, name: this.selectedFile!.name });
            this.selectedFile = null;
          }
        }
      },
      error: err => {
        console.error('Feltöltés sikertelen', err);
      }
    });
  }
}