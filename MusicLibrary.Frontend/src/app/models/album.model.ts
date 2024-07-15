import { Song } from "./song.model";

export interface Album {
    id: number;
    title: string;
    description:string;
    artistId: number;
    songs: Song[];
  }
  