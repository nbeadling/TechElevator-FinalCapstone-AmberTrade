<template>
  <div class="content">
   <router-link to='newgame'>Create a new Game</router-link>  <br>
    <router-link to='joingame'>Join Game</router-link>  

<div id="joingame-container">
    <div id="joingame" class="text-center">
      <div class="table-responsive">
        <h1>Join a Game</h1>
        <table class="table table-hover table-dark" > <!-- v-if="data" -->
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
      </div>
    </div>
  </div>
 

  </div>


</template>
<script>
import ApiService from '../services/ApiService.js';

export default {
  name: "join-game",
  data(){
    return {
      addNewPlayer: {
        gameId: '', 
        gameName: '',
        userId: '',     
        startDate: '',
        endDate: '',
      }
    }
  },

  methods: {
   addPlayerToGame(addNewPlayer){
    ApiService
    .addPlayer(addNewPlayer)
    .then(response => {
      if (response.status === 201){
        confirm(`You have added a player to the game: ${this.addNewPlayer.gameName}`)  //popup 
      }
      })
      .catch(error => {
        this.handleErrorResponse(error, "adding");
    })

    .catch(error => {
          if (error.response && error.response.status === 404) {
            alert(
              "Sorry, something went wrong. This game was not created. Please try again."
            );
          }
        });
    } 
  }
};

// (1) <invite player to game> (POST method)
// path = https://localhost:44315/game/create
// JSON BODY = {gameId}, {userId}, {startDate}, {endDate}
//       { "gameName": "tyler1",
//         "userId": 2,
//         "startDate": "2012-06-18",
//         "endDate": "2012-12-18" }

</script>




<style>


#joingame-container {
 background:linear-gradient(to right, #59c3c3, #6969b3 );
  background-size: cover;
  padding-top: 5%;
  position: fixed;
  overflow: auto;
  width: 100%;
  height: 100%;
  padding-top: 60px;
  padding-bottom: 220px;
}
#joingame {
  width: 50%;
  padding: 25px;
  margin: 50px;
  border-radius: 25px;
  border: 2px solid rgba(0, 0, 0, 0.05);
  background-color: purple;
  color: black;
}
#thead-purple{
  color: black; 
}
</style>
  