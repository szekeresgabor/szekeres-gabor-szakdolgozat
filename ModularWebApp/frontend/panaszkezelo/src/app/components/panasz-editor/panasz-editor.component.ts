import { Component, EventEmitter, Input, Output } from '@angular/core';
import { UgyfelSharedDto, UgyfelSharedService } from 'core-frontend-package';
import { PanaszDto } from '../../generated/panaszkezelo-api';
import { PanaszService } from '../../services/panasz.service';

@Component({
  selector: 'app-panasz-editor',
  standalone: false,
  templateUrl: './panasz-editor.component.html',
  styleUrl: './panasz-editor.component.scss'
})
export class PanaszEditorComponent {
  @Input() visible = false;
  @Input() panasz: PanaszDto | null = null;
  @Output() closed = new EventEmitter<void>();
  @Output() saved = new EventEmitter<void>();

  ugyfelek: UgyfelSharedDto[] = [];

  szerkesztes: PanaszDto = this.getEmptyPanasz();

  constructor(private panaszService: PanaszService, private ugyfelService: UgyfelSharedService) { }

  ngOnChanges() {
    this.ugyfelService.getAll().subscribe({
      next: data => this.ugyfelek = data
    });
    if (this.panasz) {
      this.szerkesztes = this.panasz;
    } else {
      this.szerkesztes = this.getEmptyPanasz();
    }
  }

  save() {
    const req = this.szerkesztes.id
      ? this.panaszService.update(this.szerkesztes.id, this.szerkesztes)
      : this.panaszService.create(this.szerkesztes);

    req.subscribe({
      next: () => {
        this.saved.emit();
        this.close();
      }
    });
  }

  close() {
    this.closed.emit();
  }

  getEmptyPanasz() {
    return PanaszDto.fromJS({
      cim: '',
      leiras: '',
      bejelentesDatuma: new Date(),
      statusz: 'Új',
      ugyfelId: '',
    });
  }
}