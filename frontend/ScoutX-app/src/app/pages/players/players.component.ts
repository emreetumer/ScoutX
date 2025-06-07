import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import {PlayerDto, PlayerService} from '../../services/player.service';

@Component({
  selector: 'app-players',
  standalone: true,
  templateUrl: './players.component.html',
  styleUrl: './players.component.scss',
  imports: [ CommonModule ],
})

export class PlayersComponent implements OnInit {
  players: PlayerDto[] = [];

  constructor(private playerService: PlayerService) {}

  ngOnInit(): void {
    this.loadPlayers();
  }

  loadPlayers(): void {
    this.playerService.getAllPlayers().subscribe({
      next: (data) => {
        this.players = data;
      },
      error: err => {
        console.error('Oyuncular alınmadı:', err)
      },
    });
  }
}
