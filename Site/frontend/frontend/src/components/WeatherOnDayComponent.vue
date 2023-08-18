<script setup>
import {defineProps, ref, onMounted, watch} from "vue";
  import LoadingComponent from "@/components/LoadingComponent.vue";

  const props = defineProps({
    date: Date
  })

  const apiBaseUrl = process.env.VUE_APP_API_URL

  const isLoading = ref(true)

  const weather = ref(null)

  onMounted(async () => {
    await LoadWeatherDataForOneDay(props.date)
  })

  watch(props, async () => {
    isLoading.value = true
    await LoadWeatherDataForOneDay(props.date)
  })
  async function LoadWeatherDataForOneDay(date)
  {
    weather.value = (await (await fetch(apiBaseUrl + '/api/Weather/FullWeather/' + date)).json())
    isLoading.value = false
  }
</script>

<template>
  <div class="one-day-weather-container">
    <LoadingComponent v-if="isLoading" />
    <div v-if="!isLoading">
      <div> {{ props.date }} </div>
      <div> {{ weather.weather.temperature }} </div>
      <div> {{ weather.weather.humidity }} </div>
      <div> {{ weather.weather.pressure }} </div>
    </div>
  </div>
</template>