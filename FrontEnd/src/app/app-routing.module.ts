import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { SigninComponent } from './Components/signin/signin.component';
import { IndexComponent } from './Components/index/index.component';

const routes: Routes = [ 
    {path: '', component: SigninComponent},
    {path: 'index', component: IndexComponent},
    {path: '**', redirectTo: '/'}
    
  ];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }

