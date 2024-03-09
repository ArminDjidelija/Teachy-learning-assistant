import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import {VirtualMentorComponent} from "./virtual-mentor/virtual-mentor.component";
import {HttpClient, HttpClientModule} from "@angular/common/http";
import {NgIf} from "@angular/common";
import {virtualManagerService} from "./services/virtualManager-service";

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, VirtualMentorComponent, HttpClientModule, NgIf],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  title = 'frontend';
  protected readonly virtualManagerService = virtualManagerService;
}
