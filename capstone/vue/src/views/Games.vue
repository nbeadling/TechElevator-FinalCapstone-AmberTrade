<template>

 
  <div class="content">
    <router-link to='mygames'>My Games</router-link> <br>
   <router-link to='newgame'>Create a new Game</router-link>  <br>
    <router-link to='joingame'>Join Game</router-link> 
 
     <div class="card-background text-center" id="game-actions">
        <div class="button-group">
            <button type="button" class="btn btn-primary btn-rounded btn-block buysell-button"
            >Buy Stocks</button>
            <button type="button" class="btn btn-danger btn-rounded btn-block buysell-button"
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
export default {
  name: "games",
  data() {
    return {
      isOpen: false,
    }
  }
};
</script>




<style>
.content{
  background:linear-gradient(to right, #96d9d9, #6969b3 );
  margin-left: 10px;
  padding-left: 20px;

}
* {
  box-sizing: border-box;
}

body {
  margin: 0;
  font-family: Arial, Helvetica, sans-serif;
}


</style>
  