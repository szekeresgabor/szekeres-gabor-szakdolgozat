import { loadRemoteModule } from '@angular-architects/module-federation';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

const routes: Routes = [
  {
    path: 'panaszkezelo',
    loadChildren: () =>
      loadRemoteModule({
        type: 'module',
        remoteEntry: 'http://localhost:4445/remoteEntry.js',
        exposedModule: './Module'
      }).then(m => m.PanaszkezeloModule)
  },
  {
    path: 'ugyfelkezelo',
    loadChildren: () =>
      loadRemoteModule({
        type: 'module',
        remoteEntry: 'http://localhost:5194/remoteEntry.js',
        exposedModule: './Module'
      }).then(m => m.UgyfelkezeloModule)
  },
  {
    path: 'szerzodeskezelo',
    loadChildren: () =>
      loadRemoteModule({
        type: 'module',
        remoteEntry: 'http://localhost:4432/remoteEntry.js',
        exposedModule: './Module'
      }).then(m => m.SzerzodeskezeloModule)
  },
  { path: '**', redirectTo: '' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
