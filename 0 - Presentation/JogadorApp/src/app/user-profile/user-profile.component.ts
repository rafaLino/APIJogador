import { Component, OnInit } from '@angular/core';
import { PlayerService } from 'app/services/player.service';
import { ActivatedRoute, Router } from '@angular/router';
import { Player } from 'app/models/player';
import { NotifyService } from 'app/services/notify.service';
import { States } from 'app/models/states';
import { environment } from 'environments/environment';

@Component({
  selector: 'app-user-profile',
  templateUrl: './user-profile.component.html',
  styleUrls: ['./user-profile.component.css']
})
export class UserProfileComponent implements OnInit {

  stateTitle: string = 'Novo Jogador';
  player: Player;
  Image: File;
  private id: string;
  private states: States = { Inserir: 1, Alterar: 2 };
  private state: Number = this.states.Inserir;
  constructor(private service: PlayerService,
    private activatedRoute: ActivatedRoute,
    private notify: NotifyService,
    private router: Router) { }

  ngOnInit() {
    this.player = new Player();
    this.id = this.activatedRoute.snapshot.paramMap.get('id');
    if (this.id) {
      this.state = this.states.Alterar;
      this.stateTitle = 'Alterar Jogador';
      this.getPlayer(this.id);
    }
  }

  // getPlayer(id: string) {
  //   this.service.get(id)
  //     .subscribe((result: Player) => {
  //       this.player = result;
  //     }, (error: Error) => {
  //       this.notify.danger(`Algo errado aconteceu: ${error.message}`);
  //     })
  // }

  async getPlayer(id: string) {
    try {
      this.player = await this.service.get(id);
    } catch (error) {
      this.notify.danger(`Algo errado aconteceu: ${(<Error>error).message}`);
    }
  }

  onSubmit(player: Player) {
    if (this.state == this.states.Inserir) {
      this.service.insert(player)
        .subscribe((result: Player) => {
          this.player = result;
          this.notify.success(`O jogador foi inserido com sucesso`, 'done');
          this.router.navigate(['table-list']);
        })
    } else {
      this.service.update(this.id, player)
        .subscribe((result: Response) => {
          this.notify.success(`O jogador foi editado com sucesso`, 'done');
          this.router.navigate(['table-list']);
        }, (error: Error) => {
          this.notify.danger(`Algo errado aconteceu: ${error.message}`);
        })
    }
  }

  ImgPath(path: string) {
    if (path)
      return `https://localhost:44374/${path}`;
    else
      return `./assets/img/faces/male-silo.png`;
  }

  Upload(files) {
    let upFile = <File>files[0];
    const formData = new FormData();
    formData.append('file', upFile, upFile.name);

    this.service.uploadImage(formData)
      .subscribe((response: any) => {
        this.player.imgPath = response.dbPath;
      }, error => {
        this.notify.danger(error.message);
      })
  }

}
