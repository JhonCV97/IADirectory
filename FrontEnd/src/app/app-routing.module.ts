import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { SigninComponent } from './Components/signin/signin.component';
import { IndexComponent } from './Components/index/index.component';
import { CategoriesIAComponent } from './Components/categories-ia/categories-ia.component';
import { IntelligenceArtificialComponent } from './Components/intelligence-artificial/intelligence-artificial.component';
import { ViewAIComponent } from './Components/view-ai/view-ai.component';
import { RegisterComponent } from './Components/register/register.component';
import { RecoverPasswordComponent } from './Components/recover-password/recover-password.component';
import { ConfigurationComponent } from './Components/configuration/configuration.component';

const routes: Routes = [ 
    {path: '', component: SigninComponent},
    {path: 'index', component: IndexComponent},
    {path: 'register', component: RegisterComponent},
    {path: 'configuration', component: ConfigurationComponent},
    {path: 'recoverPassword', component: RecoverPasswordComponent},
    {path: 'categories', component: CategoriesIAComponent},
    {path: 'intelligenceArtificial', component: IntelligenceArtificialComponent},
    {path: 'ViewAI/:id', component: ViewAIComponent},
    {path: '**', redirectTo: '/'}
  ];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }

