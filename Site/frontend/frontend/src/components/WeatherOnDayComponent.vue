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
  <div class="full-weather-container">
    <LoadingComponent v-if="isLoading" />
    <div v-if="!isLoading">
      <div class="one-day-weather-date"> {{ props.date }} </div>
      <div class="text-left-aligned"> температура: {{ weather.weather.temperature }}°C
      <br/> влажность: {{ weather.weather.humidity }}%
      <br/> давление: {{ weather.weather.pressure }}чего то там</div>
    </div>
  </div>
</template>