<script setup>
import {defineProps} from "vue";

  const props = defineProps({
    shortWeather: Object
  })

  console.log(props)
</script>

<template>
  <div class="weather-calendar-item">
    <div class="one-day-calendar-weather-date">
      {{ props.shortWeather.date }}
      <div v-if="props.shortWeather.shortWeather.temperature >= 23"><img src="images/sun.png" width="100"></div>
      <div v-if="props.shortWeather.shortWeather.temperature < 23 && props.shortWeather.shortWeather.temperature > 4"><img src="images/cloud.png" width="100"></div>
      <div v-if="props.shortWeather.shortWeather.temperature <= 4"><img src="images/snowflake.png" width="100"></div>
    </div>
    <div class="one-day-weather-temperature">
      {{ props.shortWeather.shortWeather.temperature }}°C
    </div>
  </div>
</template>
