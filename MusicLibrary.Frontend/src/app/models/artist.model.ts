import { Album } from "./album.model";

export interface Artist {
    id: number;
    name: string;
    albums: Album[];
  }
  