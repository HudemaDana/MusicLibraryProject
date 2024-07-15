import { Component, OnInit } from '@angular/core';
import { ArtistService } from '../../services/artist.service';
import { Artist } from '../../models/artist.model';

@Component({
  selector: 'app-artist-list',
  template: `
    <div class="container mt-5">
      <div *ngFor="let artist of artists" class="card mb-3">
        <div class="card-body">
          <h5 class="card-title">{{ artist.name }}</h5>
          <p class="card-text">
            <a [routerLink]="['/artist', artist.id]">View Albums</a>
          </p>
        </div>
      </div>
    </div>
  `,
  styles: []
})
export class ArtistListComponent implements OnInit {
  artists: Artist[] = [];

  constructor(private artistService: ArtistService) {}

  ngOnInit(): void {
    this.artistService.getArtists().subscribe(artists => {
      this.artists = artists;
    });
  }
}
