<script setup>
import {defineProps} from "vue";
import WeatherPicture from "@/components/WeatherPicture.vue";

  const props = defineProps({
    shortWeather: Object
  })

</script>

<template>
  <div>
    <div class="weather-calendar-item-container weather-calendar-item-top">
      <div>
        {{ props.shortWeather.date }}
      </div>

      <div>
        <WeatherPicture :temperature="props.shortWeather.shortWeather.temperature"/>
      </div>
    </div>

    <div class="weather-calendar-item-container weather-calendar-item-bottom">
      {{ props.shortWeather.shortWeather.temperature }}°C
    </div>
  </div>
</template>
