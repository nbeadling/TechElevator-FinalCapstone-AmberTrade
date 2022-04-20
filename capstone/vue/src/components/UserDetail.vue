<template>
  <div>
 
        <h1>WELCOME BACK {{profile.username}}</h1>
      <h3> Below are details for your profile</h3>
          <ul>
              <li>Your username is: {{profile.username}}</li>
              <li>Your access level is: {{profile.role}}</li>
              <li>Your userId is: {{profile.userId}}</li>
             
            </ul>


  </div>
</template>

<script>



export default {
  name: "user-detail",
  
  data(){
    return {
      isLoading: true
    };
  },
  computed: {
    profile(){
      return this.$store.state.user;
    }
  }
  
  
};
</script>
