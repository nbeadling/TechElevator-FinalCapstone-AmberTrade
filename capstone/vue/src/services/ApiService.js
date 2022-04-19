import axios from 'axios';

export default {

  login(user) {
    return axios.post('/login', user)
  },

  register(user) {
    return axios.post('/register', user)
  },


//GET the c# endpoints:

  //will this be getting all users according to a gameId?
  getGame() {
    return axios.get(`/`)
  },

  //#2
  getUserGames(userId) {
    return axios.get(`/game/${userId}`)
  },

  //getHoldings may need to switch to being a loop to get all their stocks via userId and gameId
  getHoldings() {
    return axios.get(`}`)
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
createGame(gameName) {
  return axios.post(`/game/create/${gameName}`)
},

buyStock(stockTransaction){
  return axios.post(`/trade/buyastock`, stockTransaction)
}









}





