<!-- Modal window component with full movie description -->
<template>
  <div class="blackout-block">
    <div class="fullFilm">
      <v-row>
        <v-col md="4" sm="4" xs="6">
          <div class="divForImg"><img :src="GetFullMovie?.Poster"></div>
        </v-col>
        <v-col>
          <button v-on:click="closeModal">&#10006;</button>
          <h1>{{ GetFullMovie?.Title }}</h1>
          <p><span> Description: </span>{{ GetFullMovie?.Description }}</p>
          <p><span>Rating:</span> {{ GetFullMovie?.ImdbRating }}</p>
          <p><span>Actors:</span> {{ GetFullMovie?.Actors }}</p>
          <p><span>Country:</span> {{ GetFullMovie?.Country }}</p>
          <p><span>Genre:</span> {{ GetFullMovie?.Genre }}</p>
          <p><span>Producer:</span> {{ GetFullMovie?.Producer }}</p>
        </v-col>
      </v-row>
    </div>
  </div>
</template>

<script lang="ts">

import { MovieService, FullMovieModel } from "@/AxiosSetup/service";
import { Component, Prop, Vue } from "vue-property-decorator";

@Component({
  components: {},
})
export default class FullMovie extends Vue {
  @Prop() readonly movieId!: string;
  private result?: FullMovieModel | null = null;


  async created() {
    try {
      this.result = await MovieService.GetFullMovieById(this.movieId);  // get full information about the movie
    }
    catch (e) {
      alert("Movie getting error");
    }
  }

  //emmit to change the trigger from /Moves.vue
  public closeModal() {
    this.$emit('closeModalWidow');
  }

  get GetFullMovie() {
    return this.result;
  }
}
</script>

<style scoped>

span {
  font-weight: bold;
}

button {
  font-size: 30px;
  float: right;
  width: 50px;
}

img {
  max-width: 100%;
  height: auto;
}

.blackout-block {
  position: absolute;
  height: 100%;
  width: 100%;
  left: 0;
  top: 0;
  z-index: 10;
  background-color: rgba(0, 0, 0, 0.5);
}

.blackout-block .fullFilm {
  margin: 10% auto 0 auto;
  padding: 20px 10px;
  background-color: rgb(250, 250, 250);
  border: 3px solid silver;
  border-radius: 10px;
  position: fixed;
  top: 0;
  width: 100%;
  height: auto;
  z-index: 11;
}

.divForImg {
  margin-left: 5px;
  margin: auto;
  max-width: 250px;
  height: auto;
}
</style>