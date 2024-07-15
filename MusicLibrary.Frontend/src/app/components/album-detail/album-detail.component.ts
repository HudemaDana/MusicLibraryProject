import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ArtistService } from '../../services/artist.service';
import { Artist } from '../../models/artist.model';
import { Album } from '../../models/album.model';

@Component({
  selector: 'app-album-detail',
  template: `
    <div class="container mt-5" *ngIf="album">
      <h2>{{ album.title }}</h2>
      <p>{{ album.description }}</p>
      <ul class="list-group">
        <li class="list-group-item" *ngFor="let song of album.songs">
          {{ song.title }} - {{ song.length }}
        </li>
      </ul>
    </div>
  `,
  styles: []
})
export class AlbumDetailComponent implements OnInit {
  album: Album | null = null;

  constructor(
    private route: ActivatedRoute,
    private artistService: ArtistService
  ) {}

  ngOnInit(): void {
    const artistId = Number(this.route.snapshot.paramMap.get('artistId'));
    const albumId = Number(this.route.snapshot.paramMap.get('albumId'));
    this.artistService.getArtist(artistId).subscribe((artist: Artist) => {
      this.album = artist.albums.find(album => album.id === albumId) || null;
    });
  }
}
