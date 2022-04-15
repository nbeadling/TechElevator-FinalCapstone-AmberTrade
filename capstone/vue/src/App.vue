<template>
  <div id="app">
    <div id="nav">
      <router-link to='profile'>Profile</router-link>&nbsp;|&nbsp;
      <!--<router-link to='games'>View My Games</router-link>&nbsp;|&nbsp; -->
      <img src= './images/amberTradeLogo.png' id="Amber-Logo" />

<li class="nav-item dropdown">
        <a
          class="nav-link dropdown-toggle"
          id="navbarDropdown"
          href="#"
          data-toggle="dropdown"
          aria-haspopup="true"
          aria-expanded="false"
          >Games</a>

    <div class="dropdown-menu" aria-labelledby="navbarDropdown">
          <router-link :to="{path: '/games/mygames'}" class="dropdown-item">My Games</router-link>
          <router-link :to="{path: '/games/join'}" class="dropdown-item">Join a Game</router-link>
          <router-link :to="{path: '/games/create'}" class="dropdown-item">Create New Game</router-link>
        
    </div>
</li>











      <a href="#">See Stocks</a>&nbsp;|&nbsp;
      <router-link to='newgame'>Create</router-link>&nbsp;|&nbsp;
      <router-link to='joingame'>Join</router-link>&nbsp;|&nbsp;
      <a href="#">See Leaderboard</a> &nbsp;|&nbsp;
      <a href="#">Trade Stocks</a> &nbsp;|&nbsp;
      <router-link v-bind:to="{ name: 'home' }">Home</router-link>&nbsp;|&nbsp;
      <router-link v-bind:to="{ name: 'logout' }" v-if="$store.state.token != ''">Logout</router-link>
    </div>

    <div class="sidenav">
  
    </div>

    <router-view />
  </div>
</template>





<style>
*{
    margin: 0;
    padding: 0;
}
.home{
    height: 100%;
    width: 100%;
    background-color: white;
    background-position: center;
    background-size: cover;
    position: absolute;
    justify-content: right;

}
#nav{
  text-align: right;
  padding: 15px 30px;
background-color: white;

 
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
#Amber-Logo {
  width: 100px;

}
</style>

