import { platformBrowser } from '@angular/platform-browser';
import { UgyfelkezeloModule } from './app/app.module';

platformBrowser().bootstrapModule(UgyfelkezeloModule, {
  ngZoneEventCoalescing: true,
})
  .catch(err => console.error(err));
