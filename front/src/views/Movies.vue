<!-- Main page -->
<template>
  <div class="dinamicBlock">
    <div class="mainContent">
      <div class="search-block">
        <h2>Search film</h2>
        <v-row>
          <v-col cols="6" sm="4" xs="4">
            <v-text-field v-model.trim="movieTitle" class="inputSearchMovie"></v-text-field>
          </v-col>
          <v-col cols="1">
            <v-btn @click="moviesByTitle">Search</v-btn>
          </v-col>
        </v-row>
      </div>

      <v-card outlined tile v-for="movie in getMovies" v-on:click="getMovieById(movie.ImdbId)" class="mb-5">
        <v-row>
          <v-col sm="4" xs="9" >
            <v-img :src="movie.Poster"></v-img>
          </v-col>
          <v-col >
            <h1>{{ movie.Title }}</h1>
            <p class="Description"><span>Description: </span>{{ movie.Description }}</p>
            <p><span>Movie rating:</span> {{ movie.ImdbRating }}</p>
          </v-col>
        </v-row>
      </v-card>

    </div>
    <div v-if="isPressed">
      <ModalFullMovie :movieId="getMovieId" v-on:closeModalWidow="closeModel" />
    </div>
    <infinite-loading v-if="!isLoading" @infinite="infiniteHandler"></infinite-loading>
    <p>Loading...</p>
  </div>
</template>

<script lang="ts">

import { ShortMovieModel, MovieService } from '@/AxiosSetup/service';
import { Component, Vue } from "vue-property-decorator";
import ModalFullMovie from '@/components/ModalFullMovie.vue';
import InfiniteLoading from 'vue-infinite-loading';


@Component({
  components: {
    ModalFullMovie,  // modal window with a movie
    InfiniteLoading  // infinite scroll component
  },
})

export default class Movie extends Vue {
  private movies: ShortMovieModel[] = [];
  public movieTitle: string = ''; 
  private movieId: string = '';
  public isPressed = false; //is the movie card pressed
  public isLoading = true;  //scroll end trigger
  private page = 1;   // page number

  async created() {
    try {
      //Since the api does not allow you to get all the movies for the start page, we will get movies from predefined titles randomly
      let movieTitleMass: string[] = ["avengers", "water", "cold", "thirst", "war", "world", "save", "bounce", "one", "explosion"];
      this.movieTitle = movieTitleMass[Math.floor(Math.random() * 10) + 1];
      this.movies = await MovieService.GetMoviesByTitle(this.movieTitle, this.page); //we get the first 10 movies on the main page
      this.isLoading = false;
      if (!this.movieTitle || 0 === this.movieTitle.length) {
        alert("Fill in the movie search field");
      }
    }
    catch (e) {

      alert("Movies getting error");
    }

  }

  //for the prop component of the movie and its opening trigger
  public async getMovieById(moviesId: string) {
    this.movieId = moviesId;
    this.isPressed = true;
  }

  public async moviesByTitle() {

    try {
      this.movies = await MovieService.GetMoviesByTitle(this.movieTitle, this.page); //we get the first 10 movies on the main page
    }

    catch {
      alert("Movies getting error");
    }
  }

  public closeModel() {
    this.isPressed = !this.isPressed;
  }

  public async infiniteHandler() {
    try {
      this.isLoading = true;
      const newMovies = await MovieService.GetMoviesByTitle(this.movieTitle, ++this.page); //we get the following 10 films
      this.movies.push(...newMovies);
      this.isLoading = false;
    }
    catch (e) {

      alert("Movies getting error");
    }
  }

  get getMovies() {
    return this.movies;
  }

  get getMovieId() {
    return this.movieId;
  }
}

</script>

<style>

h2 {
  margin-left: 10px;
}

img {
  max-width: 100%;
  height: auto;
}

button {
  width: 100px;
  height: 32px;
}

span {
  font-weight: bold;
}

.inputSearchMovie {
  float: left;
  margin: 0 10px 0 10px;
  width: 100% !important;
}

.dinamicBlock {
  max-width: 1400px;
  margin: auto;
}

.search-block {
  border: 1px solid silver;
  margin-bottom: 20px;
}

.movie-list .divForImg {
  float: left;
  margin-left: 5px;
  margin-right: 10px;
  max-width: 250px;
  height: auto;
}

</style>
