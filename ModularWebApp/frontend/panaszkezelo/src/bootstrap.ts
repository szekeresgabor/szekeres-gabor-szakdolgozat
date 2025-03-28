import { platformBrowser } from '@angular/platform-browser';
import { PanaszkezeloModule } from './app/app.module';

platformBrowser().bootstrapModule(PanaszkezeloModule, {
  ngZoneEventCoalescing: true,
})
  .catch(err => console.error(err));
