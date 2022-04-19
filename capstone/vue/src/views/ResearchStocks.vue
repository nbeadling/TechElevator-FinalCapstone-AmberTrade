<template>
  <div class="content">
    <h1>Here is where stock info should be</h1>
    
    <input type="text" id="search" v-model="searchStock" placeholder="Search for your stock" @keydown.enter="retrieveStock(searchStock)" />


<div class="form-group">          
  <button class="btn btn-lg btn-primary btn-block" type="submit">Find Stock Price</button>        
</div>  

  <h2>The {{searchStock}} price is ${{stock.close}}.</h2>
    


   <router-link to='researchstock'>Research Stocks</router-link>  <br>
   <research-stock-price></research-stock-price>

</div>
</template>
<script>

import ResearchStockPrice from '../components/ResearchStockPrice.vue';
import ApiService from '../services/ApiService.js'

export default {
  components: { ResearchStockPrice },


  name: "research-stock-view",
  data(){
    return{
    searchStock: '',
    stockQuotes: [],
    newBuyTransaction: {
      Stock: '',
      User_Id: '',
      Game_Id: '',
      Quantity: '', 
      Purchase_Price: '', 
    },
    newSellTransaction: {
      Stock: '',
      User_Id: '',
      Game_Id: '',
      Quantity: '', 
      Purchase_Price: '', 
      Sale_Price: '',
    },
    Quote: {
      stock: '',
      price: '',
    },
    };
  },
  computed: {
    stock(){
      return this.$store.state.stockPrice;
    },
    
  },
  methods: {
    retrieveStock(searchStock){
    ApiService
    .getStock(searchStock)
    .then(response => {
      this.$store.commit("SET_CURRENT_STOCK", response.data);
    })
    .catch(error => {
          if (error.response && error.response.status === 404) {
            alert(
              "Stock not available. This stock may not exist."
            );
            this.$router.push("/");
          }
        });

    },
    buyStock(stockTransaction){
      ApiService
      .buyStock(stockTransaction)
      .then(response => {
      if (response.status === 201){
        this.$store.commit("SET_CURRENT_TRANSACTION", response.data);
        confirm(`You have bought ${this.newBuyTransaction.Quantity} shares of ${this.newBuyTransaction.Stock} at $${this.newBuyTransaction.Purchase_Price}`)  
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
      if (response.status === 201){
        this.$store.commit("SET_CURRENT_TRANSACTION", response.data);
        confirm(`You have sold ${this.newSellTransaction.Quantity} shares of ${this.newSellTransaction.Stock} at $${this.newSellTransaction.Purchase_Price}`)  
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

  }
};
// (7) <sell a stock> (POST method)
// path = https://localhost:44315/Trade/sellastock
// JSON BODY = {Stock, User_Id, Game_Id, Quantity, Purchase_Price, Sale_Price}
// {
//         "Stock": "CCC",
//         "User_Id": 4,
//         "Game_Id": 105,
//         "Quantity": 200,
//         "Purchase_Price": 500,
//         "Sale_Price": 10
//     }

</script>




<style>

/* .table{
  background-color: white;
}
.table-dark{
  color: rgb(223, 31, 63);
}
tr {
  display: table-row;
  vertical-align: middle;
} */
.research-background {
  background-color: blue;
  padding-top: 3%;
  position: fixed;
  overflow: auto;
  height: 100%;
  width: 100%;
  padding-top: 60px;
  padding-bottom: 220px;
}
#research-container {
  border: 2px solid black;
  border-radius: 25px;
  
  background-color: yellow;
  color: green;
  margin: auto;
  padding: 25px;
  width: 75%;
}
#search {
  margin: 20px;
  border-radius: 10px;
  padding: 2.5px;
  width: 40%;
  font-size: 55%;
}


</style>
  