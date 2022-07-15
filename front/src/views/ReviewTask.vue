<template>
  <div>
    <div class="content-title">
      <h1>Technical task</h1>
    </div>

    <div class="content-inp">
      <h2>Purpose</h2>
      <p>WEB application for fetching movies from a catalog and displaying selected movie details.</p>
      <h2>Guidelines</h2>
      <p>Log in to imdb api and view a gallery of popular movies with a movie search option. You can use http://www.omdbapi.com/</p>
      <p>The first screen should display 10 movies with paging support.</p>
      <p>Each movie tab will be composed of: img, title, description, imdb-rating</p>
      <p>Above the gallery will be a text box for searching for a specific movie from the api</p>
      <p>By clicking on a movie card - Modal must be displayed with extended details about the movie of your choice (can be a year of release, a summary of the movie, who plays it, etc</p>
      <h2>Highlights</h2>
      <p>The page should be responsive.</p>
      <p>Design / UX – use your imagination.</p>
      <p>You can use material or bootstrap and so on ...</p>
      <p>The project will be written in :</p>
      <p> - client side - react or angular or vue;</p>
      <p> - server side- node express or .net (IMDB API referral will be made from the server and not directly from the client).</p>
    </div>
  </div>
</template>

<script lang="ts">
import { Component, Vue } from "vue-property-decorator";

@Component({
  components: {},
})
export default class ReviewTask extends Vue {}
</script>

<style>
h2 {
  margin-bottom: 10px;
}
p {
  font-size: 22px;
}
.table-data {
  width: 100%;
  margin-bottom: 20px;
  border: 1px solid #dddddd;
  border-collapse: collapse;
  font-size: 22px;
  margin-top: 25px;
}

.table-data tr {
  padding: 5px 0;
}

.table-data th {
  font-weight: bold;
  padding: 15px;
  background: #efefef;
  border: 1px solid #dddddd;
  text-align: center;
}

.table-data th img{
  height: 100px;
}

.table-data td {
  border: 1px solid #dddddd;
  padding: 15px;
  text-align: center;
}

.filtr-block {
  margin-top: 10px;
  margin-bottom: 30px;
}

.content-select {
  height: 40px;
  width: 250px;
  font-size: 20px;
  border: 1px solid silver;
  border-radius: 5px;
}

.content-find{
  width: 200px;
  height: 42px;
  margin-left: 30px;
  float: right;
  background-color: white;
  border-radius: 5px;
  border: 1px solid silver;
  font-size: 18px;
  cursor: pointer;
}
</style>
