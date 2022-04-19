<template>
  <div>
 
        <h1>Here are the details for all your games:</h1>

          <table class="table table-hover table-dark" >
          <thead class="thead-purple">
            <tr>
              <th scope="col">Creator</th>
              <th scope="col">Game Name</th>
              <th scope="col">Date Created</th>
              <th scope="col">Game Ends</th>
              <th scope="col"></th>
            </tr>           
          </thead>
          <tbody>
            <tr v-bind:key="game.gameId" v-for="game in data">
              <td>{{ game.creatorUsername }}</td>
              <td>{{ game.name }}</td>
              <td>{{ game.dateCreated }}</td>
              <td>{{ game.endDate }}</td>
              <td>
                <router-link :to="{ name: 'join-game', params: {id: game.gameId} }">
                  <button type="button" class="btn btn-primary btn-rounded btn-sm m-0">Join Game</button>
                </router-link>
              </td>
            </tr>
          </tbody>
          </table>

            <game-detail></game-detail>


  </div>
</template>

<script>
import GameDetail from './GameDetail.vue';
import ApiService from '../services/ApiService.js';


export default {
  components: { GameDetail },
  name: "game-list",
  
  data(){
    return {
      game: {
        startDate: '',
        endDate: '',
        gameId: '', 
        gameName: '', 
      },
    };
  },
  created(){
    this.retrieveGames(this.profile.userId);
  },

  computed: {
    profile(){
      return this.$store.state.user;
    },
  },

  methods:{
    retrieveGames(userId) {
      ApiService
      .getUserGames(userId)
      .then(response => {
        this.$store.commit("SET_GAMES_LIST", response.data);
      });
    },
  }
  
  
};
</script>

<style scoped>
#thead-purple {
 background: orange;
  background-size: cover;
  padding-top: 5%;
  position: fixed;
  overflow: auto;
  width: 100%;
  height: 100%;
  padding-top: 60px;
  padding-bottom: 220px;
}
#thead-purple{
  width: 75%;
  padding: 25px;
  margin: auto;
  border-radius: 25px;
  border: 2px solid rgba(0, 0, 0, 0.05);
  background-color: purple;
  color: black;
}
</style>