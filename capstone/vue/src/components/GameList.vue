<template>
  <div>
 
        <h1>Here are the details for all your games:</h1>
          <ul>
              <li>List of games that the user is a member of</li>
              <li>Details including: Game name, start date, end date</li>
              <li> Links to view details of each game individually </li>
              <li> be able to sort users in a game by portfolio value, alphabetical? </li>
            </ul>
            <game-detail></game-detail>


  </div>
</template>

<script>
import GameDetail from './GameDetail.vue';
import ApiService from '../services/ApiService.js';


export default {
  components: { GameDetail },
  name: "game-list",
  
  data(){
    return {
      game: {
        startDate: '',
        endDate: '',
        gameId: '', 
        gameName: '', 
      },
      isLoading: true
    };
  },
  created(){
    this.retrieveGames(this.profile.userId);
  },

  computed: {
    profile(){
      return this.$store.state.user;
    },
  },

  methods:{
    retrieveGames(userId) {
      ApiService
      .getUserGames(userId)
      .then(response => {
        this.$store.commit("SET_GAMES_LIST", response.data);

        if (this.$route.name == "Home" && response.status === 200 && response.data.length > 0) {
          this.$router.push(`/board/${response.data[0].id}`);
        }
      });
    },
  }
  
  
};
</script>
