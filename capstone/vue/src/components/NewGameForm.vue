<template>
  <div>
 
        <h1>Want to create a game?  Start here! </h1>
          <form class="newGame" @submit.prevent="newGame">
            <input type="text"
            id="gameName"
            required 
            placeholder="game name"/>

             <input type="date"
            id="end date"
            required 
            placeholder="game name"/>
          </form>

  </div>
</template>

<script>



export default {
  name: "new-game-form",
  
  data(){
    return {
      newGame: {
        startDate: '',
        endDate: '',
        gameId: '', 
        gameName: '', 
        userId: '',

      },
      isLoading: true
    };
  },
  
  
};
</script>
