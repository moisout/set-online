import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { PracticeComponent } from './game/practice/practice.component';

const routes: Routes = [
  { path: 'practice', component: PracticeComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
