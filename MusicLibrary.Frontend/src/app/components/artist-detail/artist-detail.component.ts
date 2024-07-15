import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ArtistService } from '../../services/artist.service';
import { Artist } from '../../models/artist.model';

@Component({
  selector: 'app-artist-detail',
  template: `
    <div class="container mt-5" *ngIf="artist">
      <h2>{{ artist.name }}</h2>
      <div *ngFor="let album of artist.albums" class="card mb-3">
        <div class="card-body">
          <h5 class="card-title">{{ album.title }}</h5>
          <p class="card-text">{{ album.description }}</p>
          <a [routerLink]="['/album', album.id]" class="btn btn-primary">View Songs</a>
        </div>
      </div>
    </div>
  `,
  styles: []
})
export class ArtistDetailComponent implements OnInit {
  artist: Artist | null = null;

  constructor(
    private route: ActivatedRoute,
    private artistService: ArtistService
  ) {}

  ngOnInit(): void {
    const id = Number(this.route.snapshot.paramMap.get('id'));
    this.artistService.getArtist(id).subscribe(artist => {
      this.artist = artist;
    });
  }
}
