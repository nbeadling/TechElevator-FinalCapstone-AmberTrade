<template>
  <div>
 
        <h1>WELCOME BACK {{profile.username}}</h1>
      <h2> DETAILS FOR THE PROFILE PAGE</h2>
          <ul>
              <li>Your userId is: {{profile.userId}}</li>
              <li>Your access level is: {{profile.role}}</li>
              <li>Accessing your info through the profile method.  Your name is: {{profile.username}}</li>
             
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
