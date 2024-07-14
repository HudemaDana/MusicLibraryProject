import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../environments/environment';
import { Artist } from '../models/artist.model';

@Injectable({
  providedIn: 'root'
})
export class ArtistService {
  private apiUrl = `${environment.apiUrl}/artists`;

  constructor(private http: HttpClient) { }

  getArtists(): Observable<Artist[]> {
    return this.http.get<Artist[]>(this.apiUrl);
  }

  getArtist(id: number): Observable<Artist> {
    return this.http.get<Artist>(`${this.apiUrl}/${id}`);
  }

  createArtist(artist: Artist): Observable<Artist> {
    return this.http.post<Artist>(this.apiUrl, artist);
  }

  updateArtist(artist: Artist): Observable<void> {
    return this.http.put<void>(`${this.apiUrl}/${artist.id}`, artist);
  }

  deleteArtist(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${id}`);
  }
}
