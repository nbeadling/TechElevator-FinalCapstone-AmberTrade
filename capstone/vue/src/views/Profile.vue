<template>
  <div class="content">
    <user-detail></user-detail>

<div class="sidenav">
  <router-link to='profile'>PROFILE</router-link>
  <router-link to='games'>View My Games</router-link>
  <a href="#">See Stocks</a>
     <router-link to='newgame'>Create</router-link>

  <a href="#">See Leaderboard</a>
  <a href="#">Trade Stocks</a>
</div>
  </div>


</template>
<script>
import UserDetail from '../components/UserDetail.vue';
export default {
  components: { UserDetail },
  name: "profile"
};
</script>




<style >
@import url('https://fonts.googleapis.com/css2?family=Source+Code+Pro:ital,wght@0,600;1,600&display=swap');
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
  font-family: Source Code Pro;
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
  