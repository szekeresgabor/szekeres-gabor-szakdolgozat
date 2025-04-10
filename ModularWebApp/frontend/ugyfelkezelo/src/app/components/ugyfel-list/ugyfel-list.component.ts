import { Component, OnInit } from '@angular/core';
import { UgyfelDto } from '../../generated/ugyfelkezelo-api';
import { UgyfelService } from '../../services/ugyfel.service';
import { UgyfelSharedDto } from 'core-frontend-package';

@Component({
  selector: 'app-ugyfel-list',
  standalone: false,
  templateUrl: './ugyfel-list.component.html',
  styleUrls: ['./ugyfel-list.component.scss']
})
export class UgyfelListComponent implements OnInit {
  ugyfelek: UgyfelSharedDto[] = [];
  selectedRow: UgyfelDto | null = null;

  popupVisible = false;
  szerkesztendoUgyfel: UgyfelDto | null = null;

  constructor(private ugyfelService: UgyfelService) { }

  ngOnInit(): void {
    this.loadData();
  }

  loadData(): void {
    this.ugyfelService.getAll().subscribe({
      next: data => this.ugyfelek = data
    });
  }

  newUgyfel(): void {
    this.szerkesztendoUgyfel = null;
    this.popupVisible = true;
  }

  editUgyfel(): void {
    if (this.selectedRow) {
      this.szerkesztendoUgyfel = this.selectedRow;
      this.popupVisible = true;
    }
  }

  deleteUgyfel(): void {
    if (this.selectedRow) {
      this.ugyfelService.delete(this.selectedRow.id!).subscribe({
        next: () => this.loadData()
      });
    }
  }

  onUgyfelSaved(): void {
    this.popupVisible = false;
    this.loadData();
  }
}