<template>
  <div class="content">

<div class="card-background text-center" id="game-actions">
       <h1>Hi {{profile.username}}!</h1>
        <h2>"{{game.gameName}}"</h2>
        <p>game description</p>

    <div class="buy-sell-container"> 
        <div class= "buy-stock-form">
              <div class="buy-inputs">
              <input type="text" id="buy-stock-ticker" placeholder="Stock Ticker" v-model="buyStockObject.stockTicker" autofocus /> <br>
              <label for="quantity-buy">Number of Stocks:</label>   <br>
              <input type="number" id="quantity-buy" v-model="buyStockObject.quantity" autofocus />
              </div>
              <div class="button-group">
              <button type="button" 
              class="btn1 btn-primary btn-rounded btn-block buysell-button"
              v-on:click="buyStock(buyStockObject)"
              >Buy Stocks</button>
              </div>
        </div>
          
        <div class="sell-stock-form">
              <div class="sell-inputs">
              <input type="text" id="sell-stock-ticker" placeholder="Stock Ticker" v-model="sellStockObject.stockTicker" autofocus /> <br>
              <label for="quantity-buy">Number of Stocks:</label>   <br>
              <input type="number" id="quantity-sell" v-model="sellStockObject.quantity" autofocus />
              </div>
              <div class="button-group">
                <button type="button" 
                class="btn2 btn-danger btn-rounded btn-block buysell-button"
                v-on:click="sellStock(sellStockObject)"
                >Sell Stocks</button>
            </div>
        </div>  
    </div>
 </div>
     
  <div class="card-background text-center" id="leaderboard">
      <div class="table-responsive">
        <h1>Leaderboard</h1>
          <table class="table table-hover table-dark">
            <thead class="thead-dark">
              <tr>
                <th scope="col">Name</th>
                <th scope="col">Portfolio Total</th>
              </tr>
            </thead>
            <tbody>
             <tr v-bind:key="user" v-for="user in this.$store.state.leaderboard">
               <td></td>
             </tr>
            </tbody>
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
              v-model="invitePlayer"
              autofocus
            />
            <button
              type="button"
              class="btn btn-secondary btn-rounded"
              v-on:click="addPlayerToGame(invitePlayer)"
            >Invite Player</button>
       </div>
   

  </div>
</template>
<script>
import ApiService from '../services/ApiService.js';

export default {

  name: "my-games",
   data() {
    return {
      isOpen: false,
      invitePlayer: '', 
      buyStockObject: {
        stockTicker: '',
        quantity: '', 
        price: '', 
      },
      sellStockObject: {
        stockTicker: '',
        quantity: '', 
        price: '', 
      },
    }
  },
  computed: {
    profile(){
      return this.$store.state.user;
    },
     game(){
      return this.$store.state.game;
    },
  },

  methods:{
  addPlayerToGame(addNewPlayer){
    ApiService
    .addPlayer(addNewPlayer)
    .then(response => {
      if (response.status === 200){
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
    },

  getGameDetail(gameId) {
      ApiService
      .getGame(gameId)
      .then(response => {
        this.$store.commit("SET_CURRENT_GAME", response.data);
      });
    },

 buyStock(stockTransaction){
      ApiService
      .buyStock(stockTransaction)
      .then(response => {
      if (response.status === 200){
        this.$store.commit("SET_CURRENT_TRANSACTION", response.data);
        alert(`You have bought ${this.newBuyTransaction.Quantity} shares of ${this.newBuyTransaction.Stock} at $${this.newBuyTransaction.Purchase_Price}`)  
        //popup to inform the gameId
      }
      })
     .catch(error => {
        this.handleErrorResponse(error, "adding");
      })

      .catch(error => {
          if (error.response && error.response.status === 404) {
            alert(
              "Sorry, something went wrong. This transaction did not occur. Please try again."
            );
          }
        });
    },

  sellStock(stockTransaction){
      ApiService
      .sellStock(stockTransaction)
      .then(response => {
      if (response.status === 200){
        this.$store.commit("SET_CURRENT_TRANSACTION", response.data);
        alert(`You have sold ${this.newSellTransaction.Quantity} shares of ${this.newSellTransaction.Stock} at $${this.newSellTransaction.Purchase_Price}`)  
        //popup to inform the gameId
      }
      })
     .catch(error => {
        this.handleErrorResponse(error, "adding");
      })

      .catch(error => {
          if (error.response && error.response.status === 404) {
            alert(
              "Sorry, something went wrong. This transaction did not occur. Please try again."
            );
          }
        });
    },
//need to write the get leaderboard methods
  getGameLeaderboard(gameId) {
    alert("method calling for API")
      ApiService
      .getLeaderboard(gameId)
      .then(response => {
        this.$store.commit("SET_CURRENT_LEADERBOARD", response.data);
      });
      console.log(this.$store.state.leaderboard)
      alert(this.$store.state.leaderboard.andrew)
      alert(this.$store.state.leaderboard.user)

    },

  },

  created() {
    this.getGameLeaderboard(this.$route.params.id);  
    this.getGameDetail(this.$route.params.id);
    
  }, 
  
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
  