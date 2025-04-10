import { Component, EventEmitter, Input, Output } from '@angular/core';
import { UgyfelDto } from '../../generated/ugyfelkezelo-api';
import { UgyfelService } from '../../services/ugyfel.service';

@Component({
  selector: 'app-ugyfel-editor',
  standalone: false,
  templateUrl: './ugyfel-editor.component.html',
  styleUrls: ['./ugyfel-editor.component.scss']
})
export class UgyfelEditorComponent {
  @Input() visible = false;
  @Input() ugyfel: UgyfelDto | null = null;
  @Output() closed = new EventEmitter<void>();
  @Output() saved = new EventEmitter<void>();

  szerkesztes: UgyfelDto = this.getEmptyUgyfel();

  constructor(private ugyfelService: UgyfelService) { }

  ngOnChanges(): void {
    this.szerkesztes = this.ugyfel
      ? this.ugyfel
      : this.getEmptyUgyfel();
  }

  save(): void {
    const req = this.szerkesztes.id
      ? this.ugyfelService.update(this.szerkesztes.id, this.szerkesztes)
      : this.ugyfelService.create(this.szerkesztes);

    req.subscribe(() => {
      this.saved.emit();
      this.close();
    });
  }

  close(): void {
    this.closed.emit();
  }

  getEmptyUgyfel(): UgyfelDto {
    return UgyfelDto.fromJS({
      nev: '',
      email: '',
      telefonszam: ''
    });
  }
}