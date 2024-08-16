import { NgModule } from '@angular/core';
import { BrowserModule, provideClientHydration } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { SubscriptionComponent } from './features/subscription/subscription.component';
import { EffectsModule } from '@ngrx/effects';
import { UserEffects } from './core/manager/effects/user.effect';
import { StoreModule } from '@ngrx/store';
import { userReducer } from './core/manager/reducers/user.reducer';
import { HttpClientModule } from '@angular/common/http';
import { TableModule } from 'primeng/table';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { CreateUserComponent } from './features/user/components/create-user/create-user.component';
import { UserComponent } from './features/user/components/list-user/user.component';
import { ButtonModule } from 'primeng/button';
import { InputTextModule } from 'primeng/inputtext';
import { CardModule } from 'primeng/card';
import { FieldsetModule } from 'primeng/fieldset';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MessageService } from 'primeng/api';
import { ToastModule } from 'primeng/toast'; 
import { MessagesModule } from 'primeng/messages'; 

@NgModule({
  declarations: [
    AppComponent,
    UserComponent,
    SubscriptionComponent,
    CreateUserComponent
  ],
  imports: [
    StoreModule.forRoot({ user: userReducer }),  
    EffectsModule.forRoot([UserEffects]),
    BrowserModule,
    BrowserAnimationsModule,
    AppRoutingModule,
    HttpClientModule,
    TableModule,
    ReactiveFormsModule,
    FormsModule,
    InputTextModule,
    CardModule,
    FieldsetModule,
    ButtonModule,
    MessagesModule,
    ToastModule
  ],
  providers: [
    MessageService,
    provideClientHydration()
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
