import { ApplicationConfig, provideZoneChangeDetection } from '@angular/core';
import { provideRouter } from '@angular/router';

import { routes } from './app.routes';
import { provideHttpClient,withInterceptors  } from '@angular/common/http';
import { interceptor } from './services/interceptor.service';
import { provideHotToastConfig } from '@ngneat/hot-toast';
export const appConfig: ApplicationConfig = {
  providers: [provideHotToastConfig(),provideZoneChangeDetection({ eventCoalescing: true }), provideRouter(routes),provideHttpClient(withInterceptors([interceptor]))]
};
