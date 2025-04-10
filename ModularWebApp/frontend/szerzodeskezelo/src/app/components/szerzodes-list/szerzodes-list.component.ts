import { Component, OnInit } from '@angular/core';
import { SzerzodesDto } from '../../generated/szerzodeskezelo-api';
import { SzerzodesService } from '../../services/szerzodes.service';

@Component({
  selector: 'app-szerzodes-list',
  standalone: false,
  templateUrl: './szerzodes-list.component.html',
  styleUrl: './szerzodes-list.component.scss'
})
export class SzerzodesListComponent implements OnInit {
  szerzodesek: SzerzodesDto[] = [];
  selectedRow: SzerzodesDto | null = null;

  popupVisible = false;
  szerkesztendoSzerzodes: SzerzodesDto | null = null;

  constructor(private szerzodesService: SzerzodesService) { }

  ngOnInit(): void {
    this.loadData();
  }

  loadData(): void {
    this.szerzodesService.getAll().subscribe(data => this.szerzodesek = data);
  }

  newSzerzodes(): void {
    this.szerkesztendoSzerzodes = null;
    this.popupVisible = true;
  }

  editSzerzodes(): void {
    if (this.selectedRow) {
      this.szerkesztendoSzerzodes = this.selectedRow;
      this.popupVisible = true;
    }
  }

  deleteSzerzodes(): void {
    if (this.selectedRow) {
      this.szerzodesService.delete(this.selectedRow.id!).subscribe(() => this.loadData());
    }
  }

  onSzerzodesSaved(): void {
    this.popupVisible = false;
    this.loadData();
  }
}