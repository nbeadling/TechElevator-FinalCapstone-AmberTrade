<template>
  <div>
 
        <h1>WELCOME BACK {{user.firstName}}</h1>
      <h2> DETAILS FOR THE PROFILE PAGE</h2>
          <ul>
              <li>{{user.userId}}</li>
              <li>{{user.username}}</li>
              <li>{{user.firstName}}, {{user.lastName}}</li>
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
      user: {
        userId: '1234',
        firstName: 'connected',
        lastName: 'toAPI',
        username:'not',
      },
      isLoading: true
    };
  },
  
  
};
</script>
