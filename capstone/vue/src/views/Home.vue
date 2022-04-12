<template>
  <div class="home">
    
<div class="sidenav">
  <a href="#">Profile</a>
  <a href="#">View Games</a>
  <a href="#">See Stocks</a>
  <a href="#">Create Game</a>
  <a href="#">See Leaderboard</a>
  <a href="#">Trade Stocks</a>
</div>
  </div>
</template>
<script>
export default {
  name: "home"
};
</script>
<style>
.home{
  background:linear-gradient(to right, #96d9d9, #6969b3 );
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

/* Style the content */
.home {
  margin-left: 200px;
  padding-left: 20px;
}
</style>
  