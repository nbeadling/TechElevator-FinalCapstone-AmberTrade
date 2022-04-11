<template>
  <div id="app">
    <div id="nav">
      <router-link v-bind:to="{ name: 'home' }">Home</router-link>&nbsp;|&nbsp;
      <router-link v-bind:to="{ name: 'logout' }" v-if="$store.state.token != ''">Logout</router-link>
    </div>
    <router-view />
  </div>
</template>
<style>
*{
    margin: 0;
    padding: 0;
}
.home{
    height: 100%;
    width: 100%;
    background-color: black;
    background-position: center;
    background-size: cover;
    position: absolute;

}
</style>
