<template>
  <div class="content">
    <h1>Here is where stock info should be</h1>
    <input type="text" id="search" placeholder="Search for your stock" />
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
export default {
  components: { ResearchStockPrice },


  name: "research-stock-view",
  computed: {
    stock(){
      return this.$store.state.stockPrice;
    }
  }
};
</script>




<style>
.content{
  background:linear-gradient(to right, #96d9d9, #6969b3 );
  margin-left: 200px;
  padding-left: 20px;

}
* {
  box-sizing: border-box;
}

body {
  margin: 0;
  font-family: Arial, Helvetica, sans-serif;
}

/* Style the side navigation */
.sidenav {
  height: 100%;
  width: 200px;
  position: fixed;
  z-index: 1;
  top: 28.5px;
  left: 0;
  background:#96d9d9;
  overflow-x: hidden;
  color:black;
  
}


/* Side navigation links */
.sidenav a {
  color: black;
  padding: 16px;
  text-decoration: none;
  display: block;
}

/* Change color on hover */
.sidenav a:hover {
  background-color: #FEE1C7;
  color: black;
}


</style>
  