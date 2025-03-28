import { platformBrowser } from '@angular/platform-browser';
import { SzerzodeskezeloModule } from './app/app.module';

platformBrowser().bootstrapModule(SzerzodeskezeloModule, {
  ngZoneEventCoalescing: true,
})
  .catch(err => console.error(err));
