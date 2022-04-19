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



</style>
  