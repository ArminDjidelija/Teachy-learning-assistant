import { Component } from '@angular/core';
import {FormsModule} from "@angular/forms";

@Component({
  selector: 'app-virtual-mentor',
  standalone: true,
  imports: [
    FormsModule
  ],
  templateUrl: './virtual-mentor.component.html',
  styleUrl: './virtual-mentor.component.css'
})
export class VirtualMentorComponent {
  public VM_pitanje: string = '';
  public GPT_response:string = "Dobro došli, kako vam mogu pomoći?";
  public shrinkedChat = true;
  Pretraga() {

  }

  ToogleMentor() {
    this.shrinkedChat = !this.shrinkedChat;
    if(this.shrinkedChat)
    {
      document.getElementById('search')!.style.display = 'none';
      document.getElementById('main')!.style.height = '15%';
      document.getElementById('toggleIcon')!.style.transform = 'rotate(0deg)';
    }
    else if(!this.shrinkedChat)
    {
      document.getElementById('search')!.style.display = 'flex';
      document.getElementById('main')!.style.height = '90%';
      document.getElementById('toggleIcon')!.style.transform = 'rotate(180deg)';
    }

  }
}
