import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import {VirtualMentorComponent} from "./virtual-mentor/virtual-mentor.component";
import {HttpClient, HttpClientModule} from "@angular/common/http";

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, VirtualMentorComponent, HttpClientModule],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  title = 'frontend';
}
