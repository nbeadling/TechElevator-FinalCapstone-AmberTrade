<template>
  <div class="content">
   <join-game></join-game>

<div class="sidenav">
  <router-link to='profile'>Profile</router-link>
  <router-link to='games'>View My Games</router-link>
  <a href="#">See Stocks</a>
  <router-link to='newgame'>Create</router-link>
  <router-link to='joingame'>Join</router-link>
  <a href="#">See Leaderboard</a>
  <a href="#">Trade Stocks</a>
</div>
  </div>


</template>
<script>
import JoinGame from '../components/JoinGame.vue';

export default {
  components: { JoinGame },


  name: "join-game"
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
  