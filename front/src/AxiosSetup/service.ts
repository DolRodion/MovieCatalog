
export class AxiosBase {
    public axios: any;

    constructor() {
        this.axios = require("axios");
    }
}

export class  MovieService {
    static urlBase = "http://localhost:5000/api/";
    static AxiosBase = new AxiosBase();
    
    // MovieController/GetMoviesByTitle
    static async GetMoviesByTitle(movieTitle : string, page : number): Promise<ShortMovieModel[]> {    
        const url = this.urlBase + "Movie/GetMoviesByTitle";
        const response = await this.AxiosBase.axios.get(url, {params: {movieTitle: movieTitle, page : page}});
        return response.data as ShortMovieModel[];
    }
    
    // MovieController/GetFullMovie
    static async GetFullMovieById(movieId : string): Promise<FullMovieModel> {
        const url = this.urlBase + "Movie/GetFullMovie";
        const response = await this.AxiosBase.axios.get(url, {params: {movieId: movieId}});
        return response.data as FullMovieModel;
    }


}


export class ShortMovieModel {
    /** Id */
    'ImdbId': string;

    'Title': string;

    'Description': string;

    'Poster': string;

    /** Movie rating */
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

// Full information about the movie for the modal window
export class FullMovieModel {
    /** Id */
    'ImdbId': string;

    'Title': string;

    'Description': string;

    'Poster': string;

    /** Movie rating */
    'ImdbRating': string;

    'Actors': string;

    /** Filming country */
    'Country': string;

    'Genre': string;

    'Producer': string;

    constructor(data: undefined | any = {}) {
        this['ImdbId'] = data['ImdbId'];
        this['Title'] = data['Title'];
        this['Description'] = data['Description'];
        this['ImdbRating'] = data['ImdbRating'];
        this['Poster'] = data['Poster']; 
        this['Actors'] = data['Actors'];
        this['Country'] = data['Country'];
        this['Genre'] = data['Genre'];
        this['Producer'] = data['Producer'];

    }
    public static validationModel = {};
}