import { Component, OnInit } from '@angular/core';
import { PanaszService } from '../../services/panasz.service';
import { PanaszDto } from '../../generated/panaszkezelo-api';

@Component({
  selector: 'app-panasz-list',
  standalone: false,
  templateUrl: './panasz-list.component.html',
  styleUrl: './panasz-list.component.scss'
})
export class PanaszListComponent implements OnInit {
  panaszok: PanaszDto[] = [];
  selectedRow: PanaszDto | null = null;

  popupVisible = false;
  szerkesztendoPanasz: PanaszDto | null = null;

  constructor(private panaszService: PanaszService) { }

  ngOnInit(): void {
    this.loadData();
  }

  loadData() {
    this.panaszService.getAll().subscribe({
      next: data => this.panaszok = data
    });
  }

  newPanasz() {
    this.szerkesztendoPanasz = null;
    this.popupVisible = true;
  }

  editPanasz() {
    if (this.selectedRow) {
      this.szerkesztendoPanasz = this.selectedRow;
      this.popupVisible = true;
    }
  }

  onPanaszSaved() {
    this.popupVisible = false;
    this.loadData();
  }

  deletePanasz() {
    if (this.selectedRow) {
      this.panaszService.delete(this.selectedRow.id!).subscribe({
        next: () => this.loadData()
      });
    }
  }

}