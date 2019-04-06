import { Component, OnInit } from '@angular/core';
import { PlayerService } from 'app/services/player.service';
import { Player } from 'app/models/player';
import { NotifyService } from 'app/services/notify.service'
@Component({
  selector: 'app-table-list',
  templateUrl: './table-list.component.html',
  styleUrls: ['./table-list.component.css']
})
export class TableListComponent implements OnInit {


  players: Player[];


  constructor(private service: PlayerService, private notify: NotifyService) {

  }

  ngOnInit() {
    this.getList();
  }

  getList() {
    this.service.getList()
      .subscribe(players => {
        this.players = players;
      }, error => {
        console.log(error);
        this.notify.danger(`Algo errado aconteceu: ${error}`);

      })
  }

}
