<template>
  <div>
 
        <h1>Placeholder for details for single game. </h1>
        <ul>
          <li>{{game.startDate}}</li>
          <li>{{game.endDate}}</li>
          <li>{{game.gameId}}</li>
          <li>{{game.gameName}}</li>
          <li> the leaderboard.  Sort by name or by balance</li>
          
        </ul>
       


  </div>
</template>

<script>



export default {
  name: "game-detail",
  
  data(){
    return {
      game: {
        startDate: '4/1/2022',
        endDate: '1/1/2023',
        gameId: '2345', 
        gameName: 'game Not Connected to API services', 

      },
      isLoading: true
    };
  },
  
  
};
</script>
