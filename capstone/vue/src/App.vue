<template>
  <div id="app">

    <div class="header">
      <img src= './images/amberTradeLogo.png' id="Amber-Logo" />
      <div class="header-right">
        <router-link v-bind:to="{ name: 'home' }">Home</router-link>
       <!-- <button @click="$router.push({name: 'about-something', params: { id: 'abc123' },})">Click to Navigate</button> -->

      <!-- <router-link to='games'>Games -->

      <select class= "header" name="dropdown-games">  
        <router-link tag="option" class="header" to="joingame">Join Game</router-link>
       <option @click="this.$router.push('mygames')">My Games</option> 
       <option @click="this.$router.push('newgames')">Create a Game</option>
       <option v-bind:to="{ name: 'joingame' }">Join Game</option>   
     </select> 
     
  <!-- </router-link> -->
     
        <router-link to= 'stocks'>Stocks</router-link>
        
        <router-link to= 'aboutambertrade'>About</router-link>
        <router-link v-bind:to="{ name: 'logout' }" v-if="$store.state.token != ''">Logout</router-link>
    
     </div>
    </div>

    <router-view />

<div id="footer-container">
        <footer id="footer-body">
            <p>&copy;2022 Amber Trade. All rights reserved.</p>
            <p>Tech Elevator Orange 4 </p>
        </footer>
    </div>



  </div>
</template>



<script>
export default {
  
  } 

</script>


<style>
@import url('https://fonts.googleapis.com/css2?family=Source+Code+Pro:ital,wght@0,600;1,600&display=swap');
* {box-sizing: border-box;}

body { 
  margin: 0;
  font-family: Arial, Helvetica, sans-serif;
}

.header {
  overflow: hidden;
  background-color: #f1f1f1;
  padding: 20px 10px;
}

.header a {
  float: left;
  color: black;
  text-align: center;
  padding: 12px;
  text-decoration: none;
  font-size: 18px; 
  line-height: 25px;
  border-radius: 4px;
}

.header a.logo {
  font-size: 25px;
  font-weight: bold;
}

.header a:hover {
  background-color: #ddd;
  color: black;
}

.header a.active {
  background-color: dodgerblue;
  color: white;
}

.header-right {
  float: right;
}

/*alter the logo picture */
#Amber-Logo{
  width: 100px;
}
#footer-container{
    display: flex;
    flex-direction: row;
    align-items: flex-end;
    flex-basis: auto;
    width: 100%;
    height: 90px;
    background-color: purple;
    position: absolute;
    bottom: 0;
}
#footer-body{
    width: 100%;
    text-align: center;
    color: black;
}


@media screen and (max-width: 500px) {
  .header a {
    float: none;
    display: block;
    text-align: left;
  }
  
  .header-right {
    float: none;
  }

  .nav-item-dropdown{
    background-color: purple;

  }
}





</style>