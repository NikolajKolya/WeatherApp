<script setup>

  // API base URL
  import {onMounted, ref} from "vue";

  const apiBaseUrl = process.env.VUE_APP_API_URL

  const isLoading = ref(true)

  const currentWeather = ref(null)

  // OnMounted hook
  onMounted(async () =>
  {
    await OnLoad();
  })

  // Called when page is loaded
  async function OnLoad()
  {
    currentWeather.value = (await (await fetch(apiBaseUrl + '/api/Weather/Current')).json()).currentWeather
    isLoading.value = false
  }

</script>

<template>
  <h1>Weather</h1>

  <!-- When page is loading -->
  <div v-if="isLoading === true">
    Page is loading, please wait
  </div>

  <!-- When page is ready -->
  <div v-if="isLoading === false">
      <div>Date: {{ currentWeather.timestamp }}</div>
      <div>Temperature: {{ currentWeather.temperature }}</div>
  </div>
</template>