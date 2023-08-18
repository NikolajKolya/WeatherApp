<script setup>
import {defineProps} from "vue";

  const props = defineProps({
    shortWeather: Object
  })

  console.log(props)
</script>

<template>
  <div class="weather-calendar-item">
    <div class="one-day-weather-date">
      {{ props.shortWeather.date }}
    </div>
    <div class="one-day-weather-temperature">
      {{ props.shortWeather.shortWeather.temperature }}°C
    </div>
  </div>
</template>
