<script setup>
  import {defineProps, onMounted, ref} from "vue";
  import LoadingComponent from "@/components/LoadingComponent.vue";
  import WeatherPicture from "@/components/WeatherPicture.vue";

  const props = defineProps({
    date: String
  })

  const apiBaseUrl = process.env.VUE_APP_API_URL

  const isLoading = ref(true)

  const weather = ref(null)

  onMounted(async () =>
  {
    await LoadWeatherData(props.date);
  })

  async function LoadWeatherData(date)
  {
    weather.value = (await (await fetch(apiBaseUrl + '/api/Weather/' + date)).json())
    isLoading.value = false
  }
</script>

<template>
  <div class="one-day-weather-container">

    <LoadingComponent v-if="isLoading" />

    <div v-if="!isLoading">
      <!-- Это отображаем когда данные получены -->
      <div class="one-day-weather-date">
        {{ weather.date }}
      </div>
      <div class="full-temperature-information">
        <div>Температура: {{ weather.weather.temperature }}°C</div>
        <div>Влажность: {{ weather.weather.humidity }}%</div>
        <div>Давление: {{ weather.weather.pressure }}гПа</div>
      </div>
      <div>
        <WeatherPicture :temperature="weather.weather.temperature"/>
      </div>
    </div>
  </div>
</template>