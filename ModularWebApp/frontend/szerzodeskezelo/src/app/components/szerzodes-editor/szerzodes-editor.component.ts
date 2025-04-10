import { Component, EventEmitter, Input, Output } from '@angular/core';
import { UgyfelSharedDto, UgyfelSharedService } from 'core-frontend-package';
import { SzerzodesDto } from '../../generated/szerzodeskezelo-api';
import { SzerzodesService } from '../../services/szerzodes.service';

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

  constructor(
    private szerzodesService: SzerzodesService,
    private ugyfelService: UgyfelSharedService
  ) { }

  ngOnChanges(): void {
    this.ugyfelService.getAll().subscribe({
      next: data => this.ugyfelek = data
    });

    this.szerkesztes = this.szerzodes ? this.szerzodes : this.getEmpty();
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
}