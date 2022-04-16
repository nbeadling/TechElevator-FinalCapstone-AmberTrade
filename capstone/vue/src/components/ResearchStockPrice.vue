<!--
<template>
  <div>
      <div class="text-center research-background">
    <div id="research-container">
      <div class="table-responsive">
        <div class="header">
          <h1>Research Stocks</h1>
          <h1 style="text:align-right">
            <input type="text" id="search" v-model="search" placeholder="Search Stocks..." />
          </h1>
        </div>
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
            <tr v-bind:key="stock.stockSymbol" v-for="stock in filteredData">
              <td>{{stock.stockSymbol}}</td>
              <td>{{stock.companyName}}</td>
              <td>{{ formatCurrency(stock.currentPrice) }}</td>
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
      </div>
    </div>
  </div>
     


  </div>
</template>

<script>

export default {
  name: "research-stock",
  
  data(){
    return {
    };
  },
  computed: {
    
  }
  
  
};
</script>


<style scoped>
#research-container{
  background-color: purple;
  color: white;
}


</style>
-->