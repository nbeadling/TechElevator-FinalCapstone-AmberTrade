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


  name: "my-games"
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
  