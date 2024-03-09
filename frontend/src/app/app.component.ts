import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import {VirtualMentorComponent} from "./virtual-mentor/virtual-mentor.component";

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, VirtualMentorComponent],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  title = 'frontend';
}
