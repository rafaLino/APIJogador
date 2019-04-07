import { Component, OnInit, ErrorHandler } from '@angular/core';
import { PlayerService } from 'app/services/player.service';
import { Player } from 'app/models/player';
import { NotifyService } from 'app/services/notify.service'
import { Router } from '@angular/router';

@Component({
  selector: 'app-table-list',
  templateUrl: './table-list.component.html',
  styleUrls: ['./table-list.component.css']
})
export class TableListComponent implements OnInit {


  players: Player[];


  constructor(private service: PlayerService,
    private notify: NotifyService,
    private router: Router
    ) {

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
        this.notify.danger(`Algo errado aconteceu: ${error.message}`);

      })
  }

  Edit(id: string) {
    console.log('go to edit page!: ', id);
    this.router.navigate(['user-profile', id]);
  }

  Remove(id: string) {
    
    this.service.delete(id)
      .subscribe((response: Response) => {
        this.notify.success(`Jogador removido com sucesso.`);
        this.getList();
      }, (error: Error) => {
        this.notify.danger(`Algo errado aconteceu: ${error.message}`)
      })

  }

  ImgPath(path: string) {
    if (path)
      return `https://localhost:44374/${path}`;
    else
      return `./assets/img/faces/male-silo.png`;
  }

}
