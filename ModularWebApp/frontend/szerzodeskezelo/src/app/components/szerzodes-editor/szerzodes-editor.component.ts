import { Component, EventEmitter, Input, Output } from '@angular/core';
import { StorageService, UgyfelSharedDto, UgyfelSharedService } from 'core-frontend-package';
import { SzerzodesDto } from '../../generated/szerzodeskezelo-api';
import { SzerzodesService } from '../../services/szerzodes.service';
import { finalize } from 'rxjs';

@Component({
  selector: 'app-szerzodes-editor',
  standalone: false,
  templateUrl: './szerzodes-editor.component.html',
  styleUrl: './szerzodes-editor.component.scss'
})
export class SzerzodesEditorComponent {
  @Input() visible = false;
  @Input() szerzodes: SzerzodesDto | null = null;
  @Output() closed = new EventEmitter<void>();
  @Output() saved = new EventEmitter<void>();

  szerkesztes: SzerzodesDto = this.getEmpty();
  ugyfelek: UgyfelSharedDto[] = [];

  dokumentumFileName: string | null = null;
  dokumentumBetoltve = false;

  constructor(
    private szerzodesService: SzerzodesService,
    private ugyfelService: UgyfelSharedService,
    private storage: StorageService
  ) { }

  ngOnChanges(): void {
    this.ugyfelService.getAll().subscribe({
      next: data => this.ugyfelek = data
    });

    this.szerkesztes = this.szerzodes ? this.szerzodes : this.getEmpty();

    if (this.szerkesztes.dokumentumId) {
      this.loadFileName(this.szerkesztes.dokumentumId);
    } else {
      this.dokumentumFileName = null;
    }
  }

  save(): void {
    const req = this.szerkesztes.id
      ? this.szerzodesService.update(this.szerkesztes.id, this.szerkesztes)
      : this.szerzodesService.create(this.szerkesztes);

    req.subscribe(() => {
      this.saved.emit();
      this.close();
    });
  }

  close(): void {
    this.closed.emit();
  }

  getEmpty(): SzerzodesDto {
    return SzerzodesDto.fromJS({
      azonosito: '',
      kotesDatuma: new Date().toISOString(),
      lejaratDatuma: null,
      megjegyzes: '',
      ugyfelId: '',
      dokumentumId: null,
      osszeg: 0
    });
  }

  onFileUploaded(event: { id: string, name: string }): void {
    this.szerkesztes.dokumentumId = event.id;
    this.dokumentumFileName = event.name;
  }

  loadFileName(id: string): void {
    this.dokumentumBetoltve = true;
    this.storage.getFileName(id).subscribe({
      next: (name) => {
        this.dokumentumFileName = name;
      }
    });
  }

  deleteFile(): void {
    if (this.szerkesztes.dokumentumId) {
      this.storage.deleteFile(this.szerkesztes.dokumentumId).subscribe({
        next: () => {
          this.szerkesztes.dokumentumId = null;
          this.dokumentumFileName = null;
          this.save();
        }
      });
    }
  }

  downloadFile(): void {
    if (this.szerkesztes.dokumentumId) {
      this.storage.downloadFile(this.szerkesztes.dokumentumId).subscribe(blob => {
        const url = window.URL.createObjectURL(blob);
        const a = document.createElement('a');
        a.href = url;
        a.download = this.dokumentumFileName || 'dokumentum';
        a.click();
        window.URL.revokeObjectURL(url);
      });
    }
  }
}