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
export default {
 

  name: "join-game"
};
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
  