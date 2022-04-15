<template>
  <div>
 
        <h1>WELCOME BACK {{profile.firstName}}</h1>
      <h2> DETAILS FOR THE PROFILE PAGE</h2>
          <ul>
              <li>{{profile.userId}}</li>
              <li>{{profile.username}}</li>
              <li>{{profile.firstName}}, {{profile.lastName}}</li>
              <li>preview of and link to games</li>
              <li> preview of and link to holdings</li>
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
      return this.$store.state.profile;
    }
  }
  
  
};
</script>
