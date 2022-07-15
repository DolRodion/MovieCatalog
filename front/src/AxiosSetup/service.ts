
export class AxiosBase {
    public axios: any;

    constructor() {
        this.axios = require("axios");
    }
}

export class  MovieService {
    static urlBase = "http://localhost:5000/api/";
    static AxiosBase = new AxiosBase();
    
    static async GetMovies(): Promise<ShortMovieModel[]> {
        
        const url = this.urlBase + "Movie/GetMovies";
        const response = await this.AxiosBase.axios.get(url);
        console.log(response);
        return response.data as ShortMovieModel[];
    }

    static async GetMoviesByTitle(movieTitle : string): Promise<ShortMovieModel[]> {
        const url = this.urlBase + "Movie/GetMoviesByTitle";
        const response = await this.AxiosBase.axios.get(url, {params: {movieTitle: movieTitle}});
        return response.data as ShortMovieModel[];
    }
}


export class ShortMovieModel {
    /** Id */
    'ImdbId': string;

    'Title': string;

    'Description': string;

    'Poster': string;

    'ImdbRating': string;


    constructor(data: undefined | any = {}) {
        this['ImdbId'] = data['ImdbId'];
        this['Title'] = data['Title'];
        this['Description'] = data['Description'];
        this['ImdbRating'] = data['ImdbRating'];
        this['Poster'] = data['Poster'];       
    }
    public static validationModel = {};
}