<template>
  <div class="content">
    <h1>Here is where stock info should be</h1>
    
    <input type="text" id="search" v-model="searchStock" placeholder="Search for your stock" />
    <table class="table table-hover table-dark">
          <thead class="thead-dark">
            <tr>
              <th scope="col">Ticker Symbol</th>
              <th scope="col">Name</th>
              <th scope="col">Current Price</th>
              <th scope="col"></th>
            </tr>
          </thead>
        <tbody>
            <tr v-bind:key="stock.stockTicker" v-for="stock in filteredData">
              <td>{{stock.stockTicker}}</td>
              <td>{{stock.companyName}}</td>
              <td>{{ formatCurrency(stock.stockPrice) }}</td>
              <td>
                <router-link
                  :to="{name: 'stock-details', params: {stockSymbol: stock.stockSymbol}}"
                >
                  <button type="button" class="btn btn-primary btn-rounded btn-sm m-0">Stock Details</button>
                </router-link>
              </td>
            </tr>
          </tbody>
        </table>

  


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
    };
  },
  computed: {
    stock(){
      return this.$store.state.stockPrice.close;
    }
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

    }
  }
};
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
  