<template>
  <div class="content">
   <router-link to='newgame'>Create a new Game</router-link>  <br>
  <router-link to='joingame'>Join Game</router-link>  

<div class="card-background text-center" id="game-actions">
       <h1>Hi {{profile.username}}!</h1>
        <h2>"{{game.gameName}}"</h2>
        <p>game description</p>
        <div class="button-group">
            <button type="button" class="btn1 btn-primary btn-rounded btn-block buysell-button"
            >Buy Stocks</button>
            <button type="button" class="btn2 btn-danger btn-rounded btn-block buysell-button"
            >Sell Stocks</button>
        </div>
 </div>
       <game-list></game-list>
           <div class="card-background text-center" id="leaderboard">
        <div class="table-responsive">
          <h1>Leaderboard</h1>
          <table class="table table-hover table-dark">
            <thead class="thead-dark">
              <tr>
                <th scope="col">Rank</th>
                <th scope="col">Name</th>
                <th scope="col">Balance</th>
                <th scope="col">Stock Owned</th>
                <th scope="col">Total</th>
              </tr>
            </thead>
          </table>
        </div>
      </div>
      <div class="form-group" >
            <label for="name" class="sr-only">Player Name</label>
            <input
              type="text"
              id="name"
              class="form-control"
              placeholder="Player to Invite"
              autofocus
            />
            <button
              type="button"
              class="btn btn-secondary btn-rounded"
            >Invite Player</button>
          </div>
   

  </div>
</template>
<script>
import GameList from "../components/GameList.vue"

export default {
  components: { GameList },
  name: "my-games",
   data() {
    return {
      isOpen: false,
    }
  },
  computed: {
    profile(){
      return this.$store.state.user;
    },
     game(){
      return this.$store.state.game;
    },
  }
};

</script>




<style>

#leaderboard{
    margin: 0;
    margin-left: 80px;
    min-width: 400px;
    flex-grow: 1;
  }
  #game-actions{
     margin: 0;
    margin-left: 80px;
    min-width: 400px;
    flex-grow: 1;
  }
  #form-group{
        margin: 0;
    margin-left: 80px;
    min-width: 400px;
    flex-grow: 1;
    background-color: indianred;
  }
  .btn{
    color:white;
    background-color: blue;
  }
   .btn1{
    color:white;
    background-color: green;
  }
   .btn2{
    color:white;
    background-color: red;
  }



</style>
  