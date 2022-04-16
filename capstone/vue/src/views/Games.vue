<template>
  <div class="content">
   <router-link to='newgame'>Create a new Game</router-link>  <br>
    <router-link to='joingame'>Join Game</router-link>  

   <game-list></game-list>

  </div>


</template>
<script>
import GameList from '../components/GameList.vue';
export default {
  components: { GameList },


  name: "games"
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
  