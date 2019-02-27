import { Component, OnInit } from '@angular/core';
import { DataService } from './data.service';
import { Game } from './game';

@Component({
    selector: 'app',
    templateUrl: './app.component.html',
    providers: [DataService]
})
export class AppComponent implements OnInit {
    game: Game = new Game();
    games: Game[];
    tableMode: boolean = true;

    constructor(private dataService: DataService) {
    }

    ngOnInit() {
        this.loadProducts();    
    }

    loadProducts() {
        this.dataService.getGames()
            .subscribe((data: Game[]) => this.games = data);
    }

    cancel() {
        this.game = new Game();
        this.tableMode = true;
    }

    add() {
        this.cancel();
        this.tableMode = false;
    }

    save() {
        if (this.game.id == null) {
            this.dataService.createGame(this.game)
                .subscribe((data: Game) => this.games.push(data));
        } 
        
        this.cancel();
    }

}