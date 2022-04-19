import axios from 'axios';


export default {

  login(user) {
    return axios.post('/login', user)
  },

  register(user) {
    return axios.post('/register', user)
  },


//GET the c# endpoints:

  //will this be getting all users according to a gameId:  MUST CONFIRM THIS EXISTS
  getGame(gameId) {
    return axios.get(`/game/${gameId}`)
  },

  //the complete portfolio:  all their stocks in all their games 
  getPortfolio(userName) {
    return axios.get(`/trade/seestocks/${userName}`)
  },

  //#2
  getUserGames(userId) {
    alert("We're calling the API")
    return axios.get(`/game/viewgame/${userId}`)
  },

  //#3
  getStock(stockTicker) {
    return axios.get(`/getprice/${stockTicker}`)
  },

//POST the API endpoints

//#1
addPlayer(userId) {
  return axios.post(`/game/invite/${userId}`, userId)
},

//3
createGame(newGame) {
  alert(newGame)
  return axios.post(`/game/create`, newGame)
},

buyStock(buyTransaction){
  return axios.post(`/trade/buyastock`, buyTransaction)
},

sellStock(sellTransaction){
  return axios.post(`/trade/sellastock`, sellTransaction)
}


}
