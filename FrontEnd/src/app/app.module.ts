import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { SigninComponent } from './Components/signin/signin.component';

import { AuthService } from './Services/auth.service';
import { CategoriesAIService } from './Services/categories-ai.service';
import { IntelligenceArtificialService } from './Services/intelligence-artificial.service';
import { environment } from '../environments/environment';
import { AngularFireModule } from '@angular/fire/compat';
import { AngularFireAuthModule } from '@angular/fire/compat/auth';
import { IndexComponent, DataSharingService } from './Components/index/index.component';
import { CategoriesIAComponent } from './Components/categories-ia/categories-ia.component';
import { IntelligenceArtificialComponent } from './Components/intelligence-artificial/intelligence-artificial.component';
import { ViewAIComponent } from './Components/view-ai/view-ai.component';
import { RegisterComponent } from './Components/register/register.component';
import { NavBarComponent } from './Components/nav-bar/nav-bar.component';
import { FooterComponent } from './Components/footer/footer.component';
import { RecoverPasswordComponent } from './Components/recover-password/recover-password.component';
import { ConfigurationComponent } from './Components/configuration/configuration.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';

@NgModule({
  declarations: [
    AppComponent,
    SigninComponent,
    IndexComponent,
    CategoriesIAComponent,
    IntelligenceArtificialComponent,
    ViewAIComponent,
    RegisterComponent,
    NavBarComponent,
    FooterComponent,
    RecoverPasswordComponent,
    ConfigurationComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    AngularFireModule.initializeApp(environment.firebase),
    AngularFireAuthModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule
  ],
  providers: [
    AuthService, 
    CategoriesAIService, 
    IntelligenceArtificialService, 
    NavBarComponent, 
    DataSharingService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
