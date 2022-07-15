<template>
  <div class="dinamicBlock">
    <div class="content-title">
      <h1>Movie list</h1>
    </div>

    <div class="mainContent">
      <div class="search-block">
        <h2>Search film</h2>
        <v-text-field v-model.trim="movieTitle" class="inputSearchMovie"></v-text-field>
        <v-btn v-on:click="moviesByTitle()">Search</v-btn>
      </div>

      <ul class="movie-list">
        <li v-for="movie in Movies" v-on:click="movieById()">
          <div class="divForImg"><img :src="movie.Poster"></div>
          <h1>{{ movie.Title }}</h1>
          <p class="Description"> Description: <span class="DescriptionItem">{{ movie.Description }}</span></p>
          <p class="Rating"> <span>Movie rating:</span> {{ movie.ImdbRating }}</p>
        </li>
      </ul>

    </div>
  </div>
</template>

<script lang="ts">

import { ShortMovieModel, MovieService } from '@/AxiosSetup/service';
import { Component, Vue } from "vue-property-decorator";


@Component({
  components: {},
})

export default class Movie extends Vue {
  public movies: ShortMovieModel[] = [];
  public movieTitle: string = '';

  async created() {
    try {
      this.movies = await MovieService.GetMovies();
    }
    catch (e) {

      alert("Ошибка получения фильмов");
    }

  }

  public async movieById() {
    alert("Ты нажал на меня");
  }

  public async moviesByTitle() {
    this.movies = await MovieService.GetMoviesByTitle(this.movieTitle);
  }

  get Movies() {
    return this.movies;
  }
}

</script>

<style scoped>
@import url('https://fonts.googleapis.com/css2?family=Arima&family=Cabin:ital@1&display=swap');

h1 {
  margin: 0px 0px 15px 320px;
}

img {
  width: 300px;
  height: 440px;
}


button {
  width: 100px;
  height: 32px; 
}
.inputSearchMovie{
  float: left;
}
.dinamicBlock{
  max-width: 1400px;
}
.content-title{
  margin-bottom: 20px;
  text-align: center;
 }
.content-title h1{
  margin: 0;
  color: blue;
}

.search-block {
  border: 1px solid silver;
  margin-bottom: 20px;
  height: 100px;
}

.movie-list li {
  padding: 20px 0;
  height: 430px;
  border: 1px solid silver;
  margin-bottom: 10px;
}

.movie-list li:hover {
   transform: scale(1.05);
   transition: 1s; /* Время эффекта */
}

.movie-list .Description {
  font-weight: bold;
  margin: 0px 0px 15px 320px;
}

.movie-list .divForImg {
  float: left;
  margin-left: 5px;
}


.movie-list .DescriptionItem {
  font-family: 'Arima', cursive;
  font-family: 'Cabin', sans-serif;
}

.movie-list li p {
  margin-left: 320px;
  font-size: 18px;
}

.Rating span {
  font-weight: bold;
}
</style>
