<script setup>

  // API base URL
  import {onMounted, ref} from "vue";
  import DayWeatherComponent from "@/components/DayWeatherComponent.vue";
  import LoadingComponent from "@/components/LoadingComponent.vue";
  import WeatherCalendar from "@/components/WeatherCalendar.vue";

  const apiBaseUrl = process.env.VUE_APP_API_URL

  const isLoading = ref(true)

  const currentDate = ref(null)

  // OnMounted hook
  onMounted(async () =>
  {
    await OnLoad();
  })

  // Called when page is loaded
  async function OnLoad()
  {
    currentDate.value = (await (await fetch(apiBaseUrl + '/api/Weather/CurrentDate')).json())
    isLoading.value = false
  }

</script>

<template>
  <div class="centered">

    <LoadingComponent v-if="isLoading" />

    <div v-if="!isLoading">
      <DayWeatherComponent :date="currentDate.currentDate" />

      <WeatherCalendar />
    </div>
  </div>
</template>