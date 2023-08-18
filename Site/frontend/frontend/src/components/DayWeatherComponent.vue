<script setup>
import {defineProps, onMounted, ref} from "vue";
  import LoadingComponent from "@/components/LoadingComponent.vue";

  const props = defineProps({
    date: Date
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
      <div>Температура: {{ weather.weather.temperature }}°C</div>
    </div>
  </div>
</template>