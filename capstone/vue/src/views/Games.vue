<template>
  <div class="content">
    <router-link to='mygames'>My Games</router-link> <br>
   <router-link to='newgame'>Create a new Game</router-link>  <br>
    <router-link to='joingame'>Join Game</router-link> 
    


  </div>


</template>
<script>
export default {
 


  name: "games"
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
  